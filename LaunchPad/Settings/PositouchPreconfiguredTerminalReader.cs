using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using LaunchPad.Utilities;

namespace LaunchPad.Settings
{
    class PositouchPreconfiguredTerminalReader : CSVReader
    {
        public static bool PreconfigurationAvailable
        {
            get
            {
                return File.Exists( @"PositouchTerminals.csv" );
            }
        }

        private static PositouchPreconfiguredTerminalReader _Instance = null;
        public static PositouchPreconfiguredTerminalReader Instance
        {
            get
            {
                if ( PreconfigurationAvailable )
                {
                    if ( _Instance == null )
                    {
                        _Instance = new PositouchPreconfiguredTerminalReader();
                    }
                    return _Instance;
                }
                else
                {
                    throw new Exception( @"Preconfiguration is not available." );
                }
            }
        }

        public bool Integrous { get; private set; }
        public List<TerminalStation> Terminals { get; set; }

        private PositouchPreconfiguredTerminalReader()
            : base( "PositouchTerminals.csv" )
        {
            ReadSettings();
        }

        protected override void CreateTableIfNotExists()
        {
            if ( !File.Exists( Filename ) )
            {
                throw new Exception( "Not allowed to create table 'PositouchTerminals.csv'." );
            }
        }

        public void ReadSettings()
        {
            Terminals.Clear();

            Db.Open();

            using ( var cmd = new OleDbCommand() )
            {
                cmd.Connection = Db;
                cmd.CommandText = @"SELECT [devicenum], [name], [ipaddress] FROM tblTerminals;";

                using ( var reader = cmd.ExecuteReader() )
                {
                    while ( reader.Read() )
                    {
                        var devicenum = Convert.ToInt32( reader["devicenum"] );
                        var name = reader["name"].ToString();

                        try
                        {
                            var test = reader["ipaddress"].ToString();
                            var ipaddress = IPAddress.Parse( test );
                            Terminals.Add( new TerminalStation( devicenum, name, ipaddress ) );
                        }
                        catch ( FormatException )
                        {
                            Terminals.Add( new TerminalStation( devicenum, name, null ) );
                        }


                    }
                }
            }

            Db.Close();
        }

        public void RefreshTerminalList()
        {
            Terminals.Clear();

            CopySpcwinAndNametermToTemp();

            // Add Nameterm terminals to tblTerminals
            var tempTerminals = new List<TerminalStation>();

            var dbfdb = new OleDbConnection( @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Temp; Extended Properties=""dBASE IV""" );

            try
            {
                Db.Open();
                dbfdb.Open();

                using ( var dbfcmd = new OleDbCommand() )
                {
                    dbfcmd.Connection = dbfdb;
                    dbfcmd.CommandText = @"SELECT [Code], [Name] FROM nameterm;";
                    var dbfreader = dbfcmd.ExecuteReader();

                    using ( var cmd = new OleDbCommand( @"INSERT INTO tblTerminals ([devicenum],[name],[ipaddress]) VALUES (?,?,?);", Db ) )
                    {
                        while ( dbfreader.Read() )
                        {
                            var devnum = Convert.ToInt32( dbfreader["Code"] );
                            var termname = dbfreader["Name"].ToString();
                            IPAddress @ipaddress = null;

                            var rx = new Regex( @"Device" + devnum.ToString( "D" ) + @"=(\S+)" );
                            var spcwinIni = File.ReadAllText( @"C:\Temp\spcwin.ini" );
                            var ipmatch = rx.Matches( spcwinIni );
                            var first = true;
                            foreach ( Match match in ipmatch )
                            {
                                if ( first == false )
                                    throw new Exception( @"Spcwin.ini has more than one Device" + devnum.ToString( "D" ) + " line." );
                                first = false;
                                var ip = match.Groups[1].Value;
                                ipaddress = IPAddress.Parse( ip );
                            }

                            cmd.Parameters.Clear();
                            cmd.Parameters.Add( new OleDbParameter( @"DevNum", devnum.ToString() ) );
                            cmd.Parameters.Add( new OleDbParameter( @"Name", termname ) );
                            try
                            {
                                cmd.Parameters.Add( new OleDbParameter( @"IPAddress", ipaddress.ToString() ) );
                            }
                            catch ( NullReferenceException )
                            {
                                cmd.Parameters.Add( new OleDbParameter( @"IPAddress", "" ) );
                            }
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                dbfdb.Close();
                Db.Close();
            }
            catch ( Exception )
            {
                Db.Close();
                throw;
            }

            ReadSettings();
        }

        private void CopySpcwinAndNametermToTemp()
        {
            MiscUtilities.MapToPosdriver( 'L' );

            var posidbfwinfo = new ProcessStartInfo();
            posidbfwinfo.FileName = @"L:\SC\Posidbfw.exe";
            posidbfwinfo.WorkingDirectory = @"L:\SC";
            posidbfwinfo.Arguments = @"/dbf " + DateTime.Now.AddDays( -1 ).ToString( "MM/dd/yy" );
            var posidbfw = Process.Start( posidbfwinfo );
            posidbfw.WaitForExit();

            if ( !Directory.Exists( @"C:\Temp" ) )
            {
                Directory.CreateDirectory( @"C:\Temp" );
            }
            File.Copy( @"L:\DBF\NAMETERM.DBF", @"C:\Temp\NAMETERM.DBF", true );
            File.Copy( @"L:\SC\SPCWIN.INI", @"C:\Temp\SPCWIN.INI", true );

        }
    }

    class TerminalStation
    {
        public int DeviceNumber { get; set; }
        public string Name { get; set; }
        public IPAddress @IPAddress { get; set; }

        public TerminalStation( int deviceNumber, string name, IPAddress ipaddress )
        {
            DeviceNumber = deviceNumber;
            Name = name;
            IPAddress = ipaddress;
        }
    }
}
