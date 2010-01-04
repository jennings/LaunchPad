using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using ADOX;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TermConfig
{
    class TerminalsReader
    {
        // Singleton
        private static TerminalsReader _Instance = null;
        public static TerminalsReader Instance
        {
            get
            {
                if ( _Instance == null )
                {
                    _Instance = new TerminalsReader();
                }
                return _Instance;
            }
        }

        public bool Integrous { get; private set; }
        public List<TerminalStation> Terminals { get; set; }

        private const string Filename = @"Terminals.mdb";
        private OleDbConnection Db;


        private TerminalsReader()
        {
            var cat = new Catalog();
            var csb = new OleDbConnectionStringBuilder()
            {
                DataSource = Filename,
                Provider = @"Microsoft.Jet.OLEDB.4.0"
            };

            if ( !File.Exists( Filename ) )
            {
                cat.Create( csb.ConnectionString );
            }

            Db = new OleDbConnection( csb.ConnectionString );

            Db.Open();

            try
            {
                var selectquery = @"SELECT [devicenum], [name], [ipaddress] FROM tblTerminals;";
                using ( var cmd = new OleDbCommand( selectquery, Db ) )
                {
                    cmd.ExecuteReader();
                }
            }
            catch ( OleDbException )
            {
                // tblSettings does not exist

                var createquery = @"CREATE TABLE tblTerminals ( [devicenum] VARCHAR NOT NULL, [name] VARCHAR NOT NULL, [ipaddress] VARCHAR NOT NULL );";
                using ( var cmd = new OleDbCommand( createquery, Db ) )
                {
                    cmd.ExecuteNonQuery();
                }
            }

            Db.Close();

            ReadSettings();
        }


        private void ClearSettings()
        {
            Integrous = false;
        }

        private void CheckIntegrity()
        {
            Integrous = false;

            Integrous = true;
        }

        public void ReadSettings()
        {
            ClearSettings();

            Db.Open();

            var query = @"SELECT [devicenum], [name], [ipaddress] FROM tblTerminals;";
            using ( var cmd = new OleDbCommand( query, Db ) )
            {
                using ( var reader = cmd.ExecuteReader() )
                {
                    while ( reader.Read() )
                    {
                        var devicenum = Convert.ToInt32( reader["devicenum"] );
                        var name = reader["name"].ToString();
                        var ipaddress = IPAddress.Parse( reader["ipaddress"].ToString() );

                        Terminals.Add( new TerminalStation( devicenum, name, ipaddress ) );
                    }
                }
            }

            Db.Close();

            CheckIntegrity();
        }

        void RefreshTerminalList()
        {
            // Map L: to posdriver
            var netExecutable = Path.Combine(
                Environment.GetFolderPath( Environment.SpecialFolder.System ),
                "net.exe" );

            var posdriverCFolder = String.Format(
                @"\\{0}\C",
                SettingsReader.Instance.PosdriverIPAddress.ToString() );

            var info = new ProcessStartInfo();
            info.Arguments = @"use L: " + posdriverCFolder;
            info.FileName = netExecutable;

            if ( !File.Exists( netExecutable ) )
            {
                throw new Exception( @"net.exe does not exist in system/system32 folder." );
            }

            var netProcess = Process.Start( info );

            if ( netProcess.WaitForExit( 15000 ) )
            {
            }
            else
            {
                throw new Exception( @"NET USE did not exit within 15 seconds." );
            }

            // Run "posidbfw /dbf mm/dd/yy" on the posdriver
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

            // Add Nameterm terminals to tblTerminals

            var tempTerminals = new List<TerminalStation>();

            var dbfdb = new OleDbConnection( @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Temp; Extended Properties=""dBase IV""" );
            dbfdb.Open();

            using ( var dbfcmd = new OleDbCommand() )
            {
                dbfcmd.Connection = dbfdb;
                dbfcmd.CommandText = @"SELECT [Code], [Name] FROM nameterm;";
                var dbfreader = dbfcmd.ExecuteReader();

                while ( dbfreader.Read() )
                {
                    tempTerminals.Add( new TerminalStation( Convert.ToInt32( dbfreader["Code"] ), dbfreader["Name"].ToString() ) );
                }
            }

            dbfdb.Close();

            // Add IP addresses to each terminal

            foreach ( var terminal in tempTerminals )
            {
                // Regex c:\temp\spcwin.ini - this is terrible
                var rx = new Regex( @"^Device" + terminal.DeviceNumber.ToString( "D" ) + @"=(\S+)" );
                var ipstring = rx.Replace( File.ReadAllText( @"C:\Temp\spcwin.ini" ), "$1" );
                if ( ipstring != null )
                {
                    terminal.IPAddress = IPAddress.Parse( ipstring );
                }
            }

            Db.Open();
            using ( var cmd = new OleDbCommand( @"INSERT INTO tblTerminals ([devicenum],[name],[ipaddress]) VALUES (?,?,?);", Db ) )
            {
                foreach ( var terminal in tempTerminals )
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add( new OleDbParameter( @"DevNum", terminal.DeviceNumber.ToString() ) );
                    cmd.Parameters.Add( new OleDbParameter( @"Name", terminal.Name ) );
                    cmd.Parameters.Add( new OleDbParameter( @"IPAddress", terminal.IPAddress.ToString() ) );

                }
            }
            Db.Close();
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

        public TerminalStation( int deviceNumber, string name )
        {
            DeviceNumber = deviceNumber;
            Name = name;
        }
    }
}
