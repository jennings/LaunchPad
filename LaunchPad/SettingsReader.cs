using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Net;
using System.Reflection;

namespace LaunchPad
{
    class SettingsReader
    {
        public static readonly string LaunchPadDirectory;
        private static readonly string Filename;

        static SettingsReader()
        {
            LaunchPadDirectory = @"C:\LaunchPad";
            Filename = Path.Combine( LaunchPadDirectory, @"Settings.csv" );
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

        public bool IntegrousInitialSettings
        {
            get
            {
                if ( PointOfSale == PointOfSaleType.Positouch )
                {
                    if ( _PosdriverIPAddress == null )
                        return false;
                    if ( _BackofficeIPAddress == null )
                        return false;
                    // Might be a 1 terminal system, so redundant terminal null is OK.
                }
                else if ( PointOfSale == PointOfSaleType.Aloha )
                {
                }
                else if ( PointOfSale == PointOfSaleType.None )
                {
                    return false;
                }

                return true;
            }
        }

        public bool IntegrousLaunchSettings
        {
            get
            {
                if ( !IntegrousInitialSettings )
                    return false;

                if ( _LaunchVNC == null )
                    return false;

                if ( PointOfSale == PointOfSaleType.Positouch )
                {
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
                else if ( PointOfSale == PointOfSaleType.None )
                {
                }

                return true;
            }
        }

        public PointOfSaleType @PointOfSale { get; set; }

        private const string _ComputerName_Key = "ComputerName";
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

        private const string _IPAddress_Key = "IPAddress";
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

        private const string _PosdriverIPAddress_Key = "PosdriverIPAddress";
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

        private const string _BackofficeIPAddress_Key = "BackofficeIPAddress";
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

        private const string _RedundantIPAddress_Key = "RedundantIPAddress";
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


        private const string _LaunchPositerm_Key = "LaunchPositerm";
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

        private const string _LaunchPosiw_Key = "LaunchPosiw";
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

        private const string _LaunchVNC_Key = "LaunchVNC";
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


        private const string _LaunchIbercfg_Key = "LaunchIbercfg";
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
            var cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\;";
            cs = cs + @"Extended Properties=""text;HDR=Yes;FMT=Delimited"";";

            /*if ( !File.Exists( Filename ) )
            {
                File.Create( @"C:\LaunchPad\Settings.csv" );
            }*/

            Db = new OleDbConnection( cs );

            try
            {
                Db.Open();

                try
                {
                    var selectquery = @"SELECT [key], [value] FROM Settings.csv;";
                    using ( var cmd = new OleDbCommand( selectquery, Db ) )
                    {
                        cmd.ExecuteReader();
                    }
                }
                catch ( OleDbException )
                {
                    // Settings.csv does not exist

                    var createquery = @"CREATE TABLE Settings.csv ( [key] VARCHAR, [value] VARCHAR );";
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

            _LaunchPosiw = null;
            _LaunchPosiw_Changed = false;
            _LaunchPositerm = null;
            _LaunchPositerm_Changed = false;
            _LaunchVNC = null;
            _LaunchVNC_Changed = false;
            _LaunchIbercfg = null;
            _LaunchIbercfg_Changed = false;
        }

        public void ReadSettings()
        {
            ClearSettings();

            if ( File.Exists( @"POSITOUCH" ) )
            {
                PointOfSale = PointOfSaleType.Positouch;
            }
            else if ( File.Exists( @"ALOHA" ) )
            {
                PointOfSale = PointOfSaleType.Aloha;
            }
            else
            {
                PointOfSale = PointOfSaleType.None;
            }

            try
            {
                Db.Open();

                var query = @"SELECT [key], [value] FROM Settings.csv;";
                using ( var cmd = new OleDbCommand( query, Db ) )
                {
                    using ( var reader = cmd.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            var key = reader["key"].ToString().ToUpper();
                            switch ( key )
                            {
                                case _ComputerName_Key:
                                    _ComputerName = reader["value"].ToString();
                                    _ComputerName_Changed = false;
                                    break;
                                case _IPAddress_Key:
                                    _IPAddress = IPAddress.Parse( reader["value"].ToString() );
                                    _IPAddress_Changed = false;
                                    break;

                                case _PosdriverIPAddress_Key:
                                    _PosdriverIPAddress = IPAddress.Parse( reader["value"].ToString() );
                                    _PosdriverIPAddress_Changed = false;
                                    break;
                                case _BackofficeIPAddress_Key:
                                    _BackofficeIPAddress = IPAddress.Parse( reader["value"].ToString() );
                                    _BackofficeIPAddress_Changed = false;
                                    break;
                                case _RedundantIPAddress_Key:
                                    _RedundantIPAddress = IPAddress.Parse( reader["value"].ToString() );
                                    _RedundantIPAddress_Changed = false;
                                    break;

                                case _LaunchPosiw_Key:
                                    _LaunchPosiw = reader["value"].ToString().ToUpper().Equals( "YES" );
                                    _LaunchPosiw_Changed = false;
                                    break;
                                case _LaunchPositerm_Key:
                                    _LaunchPositerm = reader["value"].ToString().ToUpper().Equals( "YES" );
                                    _LaunchPositerm_Changed = false;
                                    break;
                                case _LaunchVNC_Key:
                                    _LaunchVNC = reader["value"].ToString().ToUpper().Equals( "YES" );
                                    _LaunchVNC_Changed = false;
                                    break;
                                case _LaunchIbercfg_Key:
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
                settingsToChange.Add( _ComputerName_Key, ComputerName );
            if ( _IPAddress_Changed )
                settingsToChange.Add( _IPAddress_Key, IPAddress.ToString() );

            if ( _PosdriverIPAddress_Changed )
                settingsToChange.Add( _PosdriverIPAddress_Key, PosdriverIPAddress.ToString() );
            if ( _BackofficeIPAddress_Changed )
                settingsToChange.Add( _BackofficeIPAddress_Key, BackofficeIPAddress.ToString() );
            if ( _RedundantIPAddress_Changed )
                settingsToChange.Add( _RedundantIPAddress_Key, RedundantIPAddress.ToString() );

            if ( _LaunchPosiw_Changed )
                settingsToChange.Add( _LaunchPosiw_Key, LaunchPosiw ? "YES" : "NO" );
            if ( _LaunchPositerm_Changed )
                settingsToChange.Add( _LaunchPositerm_Key, LaunchPositerm ? "YES" : "NO" );
            if ( _LaunchVNC_Changed )
                settingsToChange.Add( _LaunchVNC_Key, LaunchVNC ? "YES" : "NO" );
            if ( _LaunchIbercfg_Changed )
                settingsToChange.Add( _LaunchIbercfg_Key, LaunchIbercfg ? "YES" : "NO" );

            try
            {
                Db.Open();

                var txn = Db.BeginTransaction();

                // FIXME
                var delQuery = @"DELETE FROM Settings.csv WHERE [key] = ?";
                using ( var cmd = new OleDbCommand( delQuery, Db, txn ) )
                {
                    foreach ( var kvp in settingsToChange )
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add( new OleDbParameter( "@Key", kvp.Key ) );
                        cmd.ExecuteNonQuery();
                    }
                }

                var insQuery = @"INSERT INTO Settings.csv ( [key], [value] ) VALUES ( ?, ? );";
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
