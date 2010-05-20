using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace LaunchPad.Settings
{
    [Serializable]
    public class SettingsReader
    {
        public static string LaunchPadDirectory
        { get { return @"C:\LaunchPad"; } }

        public static string SettingsFilename
        { get { return Path.Combine( LaunchPadDirectory, @"Settings.txt" ); } }

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

        #region Settings

        private Dictionary<string, string> Settings = new Dictionary<string, string>();

        public bool IntegrousInitialSettings
        {
            get
            {
                if ( PointOfSale == PointOfSaleType.Positouch )
                {
                    if ( PosdriverIPAddress == null )
                        return false;
                    if ( BackofficeIPAddress == null )
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

                if ( LaunchVNC == null )
                    return false;

                if ( PointOfSale == PointOfSaleType.Positouch )
                {
                    if ( LaunchPosiw == null )
                        return false;
                    if ( LaunchPositerm == null )
                        return false;
                }
                else if ( PointOfSale == PointOfSaleType.Aloha )
                {
                    if ( LaunchIbercfg == null )
                        return false;
                }
                else if ( PointOfSale == PointOfSaleType.None )
                {
                }

                return true;
            }
        }

        public PointOfSaleType @PointOfSale
        {
            get
            {
                try
                {
                    switch ( Settings["POS"].ToUpper() )
                    {
                        case "POSITOUCH":
                            return PointOfSaleType.Positouch;
                        case "ALOHA":
                            return PointOfSaleType.Aloha;
                        default:
                            return PointOfSaleType.None;
                    }
                }
                catch ( KeyNotFoundException )
                {
                    return PointOfSaleType.None;
                }
            }
            set { Settings["POS"] = value.ToString(); }
        }

        public string ComputerName
        {
            get
            {
                try { return Settings["ComputerName"]; }
                catch ( KeyNotFoundException ) { return null; }
            }
            set { Settings["ComputerName"] = value; }
        }

        public IPAddress IPAddress
        {
            get
            {
                try { return IPAddress.Parse( Settings["IPAddress"] ); }
                catch ( KeyNotFoundException ) { return null; }
            }
            set { Settings["IPAddress"] = value.ToString(); }
        }

        public IPAddress PosdriverIPAddress
        {
            get
            {
                try { return IPAddress.Parse( Settings["PosdriverIPAddress"] ); }
                catch ( KeyNotFoundException ) { return null; }
            }
            set { Settings["PosdriverIPAddress"] = value.ToString(); }
        }

        public IPAddress BackofficeIPAddress
        {
            get
            {
                try { return IPAddress.Parse( Settings["BackofficeIPAddress"] ); }
                catch ( KeyNotFoundException ) { return null; }
            }
            set { Settings["BackofficeIPAddress"] = value.ToString(); }
        }

        public IPAddress RedundantIPAddress
        {
            get
            {
                try { return IPAddress.Parse( Settings["RedundantIPAddress"] ); }
                catch ( KeyNotFoundException ) { return null; }
            }
            set { Settings["RedundantIPAddress"] = value.ToString(); }
        }


        public bool? LaunchPositerm
        {
            get
            {
                try { return Convert.ToBoolean( Settings["LaunchPositerm"] ); }
                catch ( KeyNotFoundException ) { return null; }
                catch ( FormatException )
                {
                    Settings.Remove( "LaunchPositerm" );
                    return null;
                }
            }
            set { Settings["LaunchPositerm"] = value.ToString(); }
        }

        public bool? LaunchPosiw
        {
            get
            {
                try { return Convert.ToBoolean( Settings["LaunchPosiw"] ); }
                catch ( KeyNotFoundException ) { return null; }
                catch ( FormatException )
                {
                    Settings.Remove( "LaunchPosiw" );
                    return null;
                }
            }
            set { Settings["LaunchPosiw"] = value.ToString(); }
        }

        public bool? LaunchVNC
        {
            get
            {
                try { return Convert.ToBoolean( Settings["LaunchVNC"] ); }
                catch ( KeyNotFoundException ) { return null; }
                catch ( FormatException )
                {
                    Settings.Remove( "LaunchVNC" );
                    return null;
                }
            }
            set { Settings["LaunchVNC"] = value.ToString(); }
        }

        public bool? LaunchIbercfg
        {
            get
            {
                try { return Convert.ToBoolean( Settings["LaunchIbercfg"] ); }
                catch ( KeyNotFoundException ) { return null; }
                catch ( FormatException )
                {
                    Settings.Remove( "LaunchIbercfg" );
                    return null;
                }
            }
            set { Settings["LaunchIbercfg"] = value.ToString(); }
        }

        #endregion


        private SettingsReader()
        {
            ReadSettings();
        }

        public void ReadSettings()
        {
            Settings.Clear();

            try
            {
                var settingsFile = File.ReadAllLines( SettingsFilename );
                foreach ( var line in settingsFile )
                {
                    var splitLine = line.Split( new char[] { '=' }, 2 );
                    if ( splitLine.Length < 2 )
                    {
                        continue;
                    }
                    Settings[splitLine[0]] = splitLine[1];
                }
            }
            catch ( FileNotFoundException )
            {
                File.Create( SettingsFilename );
            }
        }

        public void WriteSettings()
        {
            var lines = new List<string>();
            foreach ( var line in Settings )
            {
                lines.Add( line.Key.Trim() + "=" + line.Value.Trim() );
            }
            File.WriteAllLines( SettingsFilename, lines.ToArray() );
        }
    }

    public enum PointOfSaleType
    {
        Positouch,
        Aloha,
        None
    }
}
