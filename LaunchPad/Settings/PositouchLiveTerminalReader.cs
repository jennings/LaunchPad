using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using LaunchPad.Settings;

namespace LaunchPad.Models
{
    class PositouchLiveTerminalReader
    {
        public List<TerminalStation> Terminals { get; set; }

        public PositouchLiveTerminalReader()
        {
            Terminals = new List<TerminalStation>();
            RefreshTerminalList();
        }

        public void RefreshTerminalList()
        {
            Terminals.Clear();

            CopySpcwinAndNametermToTemp();

            var dbfdb = new OleDbConnection( @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Temp; Extended Properties=""dBASE IV""" );

            dbfdb.Open();

            using ( var dbfcmd = new OleDbCommand() )
            {
                dbfcmd.Connection = dbfdb;
                dbfcmd.CommandText = @"SELECT [Code], [Name] FROM nameterm;";
                var dbfreader = dbfcmd.ExecuteReader();

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

                    Terminals.Add( new TerminalStation( devnum, termname, ipaddress ) );
                }
            }

            dbfdb.Close();
        }

        private void CopySpcwinAndNametermToTemp()
        {
            if ( !Directory.Exists( @"C:\Temp" ) )
            {
                Directory.CreateDirectory( @"C:\Temp" );
            }
            var ip = SettingsReader.Instance.PosdriverIPAddress.ToString();
            File.Copy( @"\\" + ip + @"\DBF\NAMETERM.DBF", @"C:\Temp\NAMETERM.DBF", true );
            File.Copy( @"\\" + ip + @"\SC\SPCWIN.INI", @"C:\Temp\SPCWIN.INI", true );

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
