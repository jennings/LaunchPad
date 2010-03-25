using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using LaunchPad.Utilities;
using LaunchPad.Models;

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
        public List<PositouchTerminal> Terminals { get; set; }

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
                cmd.CommandText = @"SELECT [DeviceNumber], [Name], [IPAddress] FROM [" + Filename + "]";

                using ( var reader = cmd.ExecuteReader() )
                {
                    while ( reader.Read() )
                    {
                        Terminals.Add( new PositouchTerminal()
                        {
                            DeviceNumber = Convert.ToInt32( reader["DeviceNumber"] ),
                            Name = reader["Name"].ToString(),
                            IPAddress = IPAddress.Parse( reader["IPAddress"].ToString() )
                        } );
                    }
                }
            }

            Db.Close();
        }
    }
}
