using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Reflection;
using ADOX;

namespace LaunchPad
{
    class SettingsReader
    {
        public static readonly string WorkingDirectory;
        public static readonly string LaunchPadDirectory;
        private static readonly string Filename;

        static SettingsReader()
        {
            WorkingDirectory = Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location );
            LaunchPadDirectory = @"C:\LaunchPad";
            Filename = Path.Combine( LaunchPadDirectory, @"Settings.mdb" );
        }

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

        private OleDbConnection Db;

        #region Settings

        public bool Integrous
        {
            get
            {
                if ( _ComputerName == null )
                    return false;
                if ( _IPAddress == null )
                    return false;
                if ( _LaunchVNC == null )
                    return false;

                if ( PointOfSale == PointOfSaleType.Positouch )
                {
                    if ( _PosdriverIPAddress == null )
                        return false;
                    if ( _BackofficeIPAddress == null )
                        return false;
                    // Might be a 1 terminal system, so redundant terminal null is OK.
                    if ( _LaunchPosiw == null )
                        return false;
                    if ( _LaunchPositerm == null )
                        return false;
                }
                else if ( PointOfSale == PointOfSaleType.Aloha )
                {
                    if ( _LaunchIbercfg == null )
                        return false;
                }
                else if ( PointOfSale == null )
                {
                    return false;
                }

                return true;
            }
        }

        private bool @_PointOfSale_Changed = false;
        private PointOfSaleType? @_PointOfSale;
        public PointOfSaleType? @PointOfSale
        {
            get { return _PointOfSale; }
            set
            {
                if ( value == null )
                {
                    _PointOfSale_Changed = false;
                    _PointOfSale = null;
                    return;
                }
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
                if ( value == null )
                {
                    _ComputerName_Changed = false;
                    _ComputerName = null;
                    return;
                }
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
                if ( value == null )
                {
                    _IPAddress_Changed = false;
                    _IPAddress = null;
                    return;
                }
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
                if ( value == null )
                {
                    _PosdriverIPAddress_Changed = false;
                    _PosdriverIPAddress = null;
                    return;
                }
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
                if ( value == null )
                {
                    _BackofficeIPAddress_Changed = false;
                    _BackofficeIPAddress = null;
                    return;
                }
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
                if ( value == null )
                {
                    _RedundantIPAddress_Changed = false;
                    _RedundantIPAddress = null;
                    return;
                }
                _RedundantIPAddress_Changed = true;
                _RedundantIPAddress = value;
            }
        }


        private bool _LaunchPositerm_Changed = false;
        private bool? _LaunchPositerm;
        public bool LaunchPositerm
        {
            get { return _LaunchPositerm ?? false; }
            set
            {
                if ( value == null )
                {
                    _LaunchPositerm_Changed = false;
                    _LaunchPositerm = null;
                    return;
                }
                _LaunchPositerm_Changed = true;
                _LaunchPositerm = value;
            }
        }

        private bool _LaunchPosiw_Changed = false;
        private bool? _LaunchPosiw;
        public bool LaunchPosiw
        {
            get { return _LaunchPosiw ?? false; }
            set
            {
                if ( value == null )
                {
                    _LaunchPosiw_Changed = false;
                    _LaunchPosiw = null;
                    return;
                }
                _LaunchPosiw_Changed = true;
                _LaunchPosiw = value;
            }
        }

        private bool _LaunchVNC_Changed = false;
        private bool? _LaunchVNC;
        public bool LaunchVNC
        {
            get { return _LaunchVNC ?? false; }
            set
            {
                if ( value == null )
                {
                    _LaunchVNC_Changed = false;
                    _LaunchVNC = null;
                    return;
                }
                _LaunchVNC_Changed = true;
                _LaunchVNC = value;
            }
        }


        private bool _LaunchIbercfg_Changed = false;
        private bool? _LaunchIbercfg;
        public bool LaunchIbercfg
        {
            get { return _LaunchIbercfg ?? false; }
            set
            {
                if ( value == null )
                {
                    _LaunchIbercfg_Changed = false;
                    _LaunchIbercfg = null;
                    return;
                }
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
            _PointOfSale = null;
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

        public void ReadSettings()
        {
            ClearSettings();

            if ( File.Exists( @"POSITOUCH" ) )
            {
                _PointOfSale = PointOfSaleType.Positouch;
            }
            else if ( File.Exists( @"ALOHA" ) )
            {
                _PointOfSale = PointOfSaleType.Aloha;
            }
            else
            {
                _PointOfSale = PointOfSaleType.None;
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
        }

        public void Commit()
        {
            var settingsToChange = new Dictionary<string, string>();

            if ( _ComputerName_Changed )
                settingsToChange.Add( "COMPUTER_NAME", ComputerName );
            if ( _IPAddress_Changed )
                settingsToChange.Add( "IPADDRESS", IPAddress.ToString() );

            if ( _PosdriverIPAddress_Changed )
                settingsToChange.Add( "POSDRIVER_IPADDRESS", PosdriverIPAddress.ToString() );
            if ( _BackofficeIPAddress_Changed )
                settingsToChange.Add( "BACKOFFICE_IPADDRESS", BackofficeIPAddress.ToString() );
            if ( _RedundantIPAddress_Changed )
                settingsToChange.Add( "REDUNDANT_IPADDRESS", RedundantIPAddress.ToString() );

            if ( _LaunchPosiw_Changed )
                settingsToChange.Add( "LAUNCH_POSIW", LaunchPosiw ? "YES" : "NO" );
            if ( _LaunchPositerm_Changed )
                settingsToChange.Add( "LAUNCH_POSITERM", LaunchPositerm ? "YES" : "NO" );
            if ( _LaunchVNC_Changed )
                settingsToChange.Add( "LAUNCH_VNC", LaunchVNC ? "YES" : "NO" );
            if ( _LaunchIbercfg_Changed )
                settingsToChange.Add( "LAUNCH_IBERCFG", LaunchIbercfg ? "YES" : "NO" );

            try
            {
                Db.Open();

                var txn = Db.BeginTransaction();

                var delQuery = @"DELETE FROM tblSettings WHERE [key] = ?";
                using ( var cmd = new OleDbCommand( delQuery, Db, txn ) )
                {
                    foreach ( var kvp in settingsToChange )
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add( new OleDbParameter( "@Key", kvp.Key ) );
                        cmd.ExecuteNonQuery();
                    }
                }

                var insQuery = @"INSERT INTO tblSettings ( [key], [value] ) VALUES ( ?, ? );";
                using ( var cmd = new OleDbCommand( insQuery, Db, txn ) )
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

    enum PointOfSaleType
    {
        Positouch,
        Aloha,
        None
    }
}
