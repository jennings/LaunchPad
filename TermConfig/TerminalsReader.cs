using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using ADOX;
using System.IO;
using System.Net;

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

        private const string Filename = @"Terminals.mdb";
        private OleDbConnection Db;

        public bool Integrous { get; private set; }

        public List<TerminalStation> Terminals { get; set; }

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
            // Run posidbfw on the posdriver

            // Read NAMETERM.DBF

            // Read SPCWIN.INI

            // Add terminals to Terminals.mdb
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
