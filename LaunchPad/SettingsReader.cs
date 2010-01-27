using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Net;
using System.IO;
using ADOX;

namespace TermConfig
{
    class SettingsReader
    {
        // Singleton
        private static SettingsReader _Instance = null;
        public static SettingsReader Instance
        {
            get
            {
                if ( _Instance == null )
                {
                    _Instance = new SettingsReader();
                }
                return _Instance;
            }
        }

        private const string Filename = @"Settings.mdb";
        private OleDbConnection Db;

        #region Settings

        public bool Integrous { get; private set; }

        private bool @_PointOfSale_Changed = false;
        private PointOfSale @_PointOfSale;
        public PointOfSale @PointOfSale
        {
            get { return _PointOfSale; }
            set
            {
                _PointOfSale_Changed = true;
                _PointOfSale = value;
            }
        }

        private bool _ComputerName_Changed = false;
        private string _ComputerName;
        public string ComputerName
        {
            get { return _ComputerName; }
            set
            {
                _ComputerName_Changed = true;
                _ComputerName = value;
            }
        }

        private bool _IPAddress_Changed = false;
        private IPAddress _IPAddress;
        public IPAddress IPAddress
        {
            get { return _IPAddress; }
            set
            {
                _IPAddress_Changed = true;
                _IPAddress = value;
            }
        }


        private bool _PosdriverIPAddress_Changed = false;
        private IPAddress _PosdriverIPAddress;
        public IPAddress PosdriverIPAddress
        {
            get { return _PosdriverIPAddress; }
            set
            {
                _PosdriverIPAddress_Changed = true;
                _PosdriverIPAddress = value;
            }
        }

        private bool _BackofficeIPAddress_Changed = false;
        private IPAddress _BackofficeIPAddress;
        public IPAddress BackofficeIPAddress
        {
            get { return _BackofficeIPAddress; }
            set
            {
                _BackofficeIPAddress_Changed = true;
                _BackofficeIPAddress = value;
            }
        }

        private bool _RedundantIPAddress_Changed = false;
        private IPAddress _RedundantIPAddress;
        public IPAddress RedundantIPAddress
        {
            get { return _RedundantIPAddress; }
            set
            {
                _RedundantIPAddress_Changed = true;
                _RedundantIPAddress = value;
            }
        }


        private bool _LaunchPositerm_Changed = false;
        private bool _LaunchPositerm;
        public bool LaunchPositerm
        {
            get { return _LaunchPositerm; }
            set
            {
                _LaunchPositerm_Changed = true;
                _LaunchPositerm = value;
            }
        }

        private bool _LaunchPosiw_Changed = false;
        private bool _LaunchPosiw;
        public bool LaunchPosiw
        {
            get { return _LaunchPosiw; }
            set
            {
                _LaunchPosiw_Changed = true;
                _LaunchPosiw = value;
            }
        }

        private bool _LaunchVNC_Changed = false;
        private bool _LaunchVNC;
        public bool LaunchVNC
        {
            get { return _LaunchVNC; }
            set
            {
                _LaunchVNC_Changed = true;
                _LaunchVNC = value;
            }
        }


        private bool _LaunchIbercfg_Changed = false;
        private bool _LaunchIbercfg;
        public bool LaunchIbercfg
        {
            get { return _LaunchIbercfg; }
            set
            {
                _LaunchIbercfg_Changed = true;
                _LaunchIbercfg = value;
            }
        }

        #endregion


        private SettingsReader()
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

            try
            {
                Db.Open();

                try
                {
                    var selectquery = @"SELECT [key], [value] FROM tblSettings;";
                    using ( var cmd = new OleDbCommand( selectquery, Db ) )
                    {
                        cmd.ExecuteReader();
                    }
                }
                catch ( OleDbException )
                {
                    // tblSettings does not exist

                    var createquery = @"CREATE TABLE tblSettings ([key] VARCHAR NOT NULL, [value] VARCHAR NOT NULL);";
                    using ( var cmd = new OleDbCommand( createquery, Db ) )
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                Db.Close();
            }
            catch ( Exception )
            {
                Db.Close();
                throw;
            }

            ReadSettings();
        }

        private void ClearSettings()
        {
            Integrous = false;

            _PointOfSale = PointOfSale.None;
            _PointOfSale_Changed = false;

            _ComputerName = null;
            _ComputerName_Changed = false;
            _IPAddress = null;
            _IPAddress_Changed = false;

            _PosdriverIPAddress = null;
            _PosdriverIPAddress_Changed = false;
            _BackofficeIPAddress = null;
            _BackofficeIPAddress_Changed = false;
            _RedundantIPAddress = null;
            _RedundantIPAddress_Changed = false;

            _LaunchPosiw = false;
            _LaunchPosiw_Changed = false;
            _LaunchPositerm = false;
            _LaunchPositerm_Changed = false;
            _LaunchVNC = false;
            _LaunchVNC_Changed = false;
            _LaunchIbercfg = false;
            _LaunchIbercfg_Changed = false;
        }

        private void CheckIntegrity()
        {
            Integrous = false;

            if ( _ComputerName == null )
                return;
            if ( _IPAddress == null )
                return;
            if ( _LaunchVNC == null )
                return;

            if ( PointOfSale == PointOfSale.Positouch )
            {
                if ( _PosdriverIPAddress == null )
                    return;
                if ( _BackofficeIPAddress == null )
                    return;
                // Might be a 1 terminal system, so redundant terminal null is OK.
                if ( _LaunchPosiw == null )
                    return;
                if ( _LaunchPositerm == null )
                    return;
            }
            else if ( PointOfSale == PointOfSale.Aloha )
            {
                if ( _LaunchIbercfg == null )
                    return;
            }

            Integrous = true;
        }

        public void ReadSettings()
        {
            ClearSettings();

            if ( File.Exists( @"POSITOUCH" ) )
            {
                _PointOfSale = PointOfSale.Positouch;
            }
            else if ( File.Exists( @"ALOHA" ) )
            {
                _PointOfSale = PointOfSale.Aloha;
            }
            else
            {
                _PointOfSale = PointOfSale.None;
            }
            _PointOfSale_Changed = false;

            try
            {
                Db.Open();

                var query = @"SELECT [key], [value] FROM tblSettings;";
                using ( var cmd = new OleDbCommand( query, Db ) )
                {
                    using ( var reader = cmd.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            var key = reader["key"].ToString().ToUpper();
                            switch ( key )
                            {
                                case "COMPUTER_NAME":
                                    _ComputerName = reader["value"].ToString();
                                    _ComputerName_Changed = false;
                                    break;
                                case "IPADDRESS":
                                    _IPAddress = IPAddress.Parse( reader["value"].ToString() );
                                    _IPAddress_Changed = false;
                                    break;

                                case "POSDRIVER_IPADDRESS":
                                    _PosdriverIPAddress = IPAddress.Parse( reader["value"].ToString() );
                                    _PosdriverIPAddress_Changed = false;
                                    break;
                                case "BACKOFFICE_IPADDRESS":
                                    _BackofficeIPAddress = IPAddress.Parse( reader["value"].ToString() );
                                    _BackofficeIPAddress_Changed = false;
                                    break;
                                case "REDUNDANT_IPADDRESS":
                                    _RedundantIPAddress = IPAddress.Parse( reader["value"].ToString() );
                                    _RedundantIPAddress_Changed = false;
                                    break;

                                case "LAUNCH_POSIW":
                                    _LaunchPosiw = reader["value"].ToString().ToUpper().Equals( "YES" );
                                    _LaunchPosiw_Changed = false;
                                    break;
                                case "LAUNCH_POSITERM":
                                    _LaunchPositerm = reader["value"].ToString().ToUpper().Equals( "YES" );
                                    _LaunchPositerm_Changed = false;
                                    break;
                                case "LAUNCH_VNC":
                                    _LaunchVNC = reader["value"].ToString().ToUpper().Equals( "YES" );
                                    _LaunchVNC_Changed = false;
                                    break;
                                case "LAUNCH_IBERCFG":
                                    _LaunchIbercfg = reader["value"].ToString().ToUpper().Equals( "YES" );
                                    _LaunchIbercfg_Changed = false;
                                    break;
                            }
                        }
                    }
                }

                Db.Close();

            }
            catch ( Exception )
            {
                Db.Close();
                throw;
            }

            CheckIntegrity();
        }

        public void Commit()
        {
            var settingsToChange = new Dictionary<string, string>();

            settingsToChange.Add( "COMPUTER_NAME", _ComputerName );
            settingsToChange.Add( "IPADDRESS", _IPAddress.ToString() );

            settingsToChange.Add( "POSDRIVER_IPADDRESS", _PosdriverIPAddress.ToString() );
            settingsToChange.Add( "BACKOFFICE_IPADDRESS", _BackofficeIPAddress.ToString() );
            try
            {
                settingsToChange.Add( "REDUNDANT_IPADDRESS", _RedundantIPAddress.ToString() );
            }
            catch ( NullReferenceException )
            { }

            settingsToChange.Add( "LAUNCH_POSIW", _LaunchPosiw ? "YES" : "NO" );
            settingsToChange.Add( "LAUNCH_POSITERM", _LaunchPositerm ? "YES" : "NO" );
            settingsToChange.Add( "LAUNCH_VNC", _LaunchVNC ? "YES" : "NO" );
            settingsToChange.Add( "LAUNCH_IBERCFG", _LaunchIbercfg ? "YES" : "NO" );

            try
            {
                Db.Open();

                var txn = Db.BeginTransaction();

                var deletequery = @"DELETE FROM tblSettings;";
                using ( var cmd = new OleDbCommand( deletequery, Db, txn ) )
                {
                    cmd.ExecuteNonQuery();
                }

                var query = @"INSERT INTO tblSettings ( [key], [value] ) VALUES ( ?, ? );";
                using ( var cmd = new OleDbCommand( query, Db, txn ) )
                {
                    foreach ( var kvp in settingsToChange )
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add( new OleDbParameter( "@Key", kvp.Key ) );
                        cmd.Parameters.Add( new OleDbParameter( "@Value", kvp.Value ) );
                        cmd.ExecuteNonQuery();
                    }
                }

                txn.Commit();

                Db.Close();
            }
            catch ( Exception )
            {
                Db.Close();
                throw;
            }

            ReadSettings();
        }
    }

    enum PointOfSale
    {
        Positouch,
        Aloha,
        None
    }
}
