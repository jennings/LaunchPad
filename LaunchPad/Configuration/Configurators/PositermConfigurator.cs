using System;
using System.Collections.Generic;
using System.IO;
using LaunchPad.Configuration.Tasks;
using System.Text.RegularExpressions;

namespace LaunchPad.Configuration.Configurators
{
    class PositermConfigurator : IConfigurator
    {
        public bool RequiresElevation { get { return false; } }
        public bool RequiresAuthentication { get { return false; } }

        public string ComputerName { get; private set; }

        private List<string> Filenames = new List<string>()
        {
            "AMS32.INI",
            "DELIVERY.INI",
            "GIFTCERT.INI",
            "ORDRSCRN.INI"
        };

        private PositermConfigurator() { }
        public PositermConfigurator( PositermTask task )
        {
            ComputerName = task.ComputerName;
        }

        public void Configure()
        {
            // Write TERM.$$$
            WriteTerminalName();

            try
            {
                CreateCShare();
            }
            catch { }

            try
            {
                CopyINIFiles();
            }
            catch { } // FIXME

            try
            {
                UpdateWintermIni();
            }
            catch { } // FIXME
        }


        private void CreateCShare()
        {
            MiscUtilities.RunNet( @"share C /DELETE", 10000 );
            MiscUtilities.RunNet( @"share C=C:\", 10000 );
        }


        private void CopyINIFiles()
        {
            string scDirectory;

            try
            {
                scDirectory = Path.Combine( MiscUtilities.PosdriverDirectory.ToString(), "SC" );
            }
            catch { return; } // FIXME: Log error copying INI

            foreach ( var filename in Filenames )
            {
                var fullfilename = Path.Combine( scDirectory, filename );
                if ( File.Exists( fullfilename ) )
                {
                    File.Copy( fullfilename, Path.Combine( @"C:\SC", filename ), true );
                }
            }
        }


        private void WriteTerminalName()
        {
            if ( File.Exists( @"C:\SC\TERM.$$$" ) )
            {
                var timestring = DateTime.Now.ToString( @"yyyyMMddHHmmss" );
                File.Move( @"C:\SC\TERM.$$$", @"C:\Temp\TERM.$$$." + timestring );
            }

            using ( var sw = new StreamWriter( @"C:\SC\TERM.$$$" ) )
            {
                sw.Write( ComputerName );
            }
        }


        private void UpdateWintermIni()
        {
            var spcwinRx = new Regex( @"^((\s*)Spcwin(\s*)=(.*))$", RegexOptions.IgnoreCase | RegexOptions.Multiline );
            var spcwinbackupRx = new Regex( @"^((\s*)SpcwinBackup(.*))$", RegexOptions.IgnoreCase | RegexOptions.Multiline );
            var masterbmppathRx = new Regex( @"^((\s*)MasterBmpPath(.*))$", RegexOptions.IgnoreCase | RegexOptions.Multiline );
            var masterdatpathRx = new Regex( @"^((\s*)MasterDatPath(.*))$", RegexOptions.IgnoreCase | RegexOptions.Multiline );
            var altbmppathRx = new Regex( @"^((\s*)AltBmpPath(.*))$", RegexOptions.IgnoreCase | RegexOptions.Multiline );
            var altdatpathRx = new Regex( @"^((\s*)AltDatPath(.*))$", RegexOptions.IgnoreCase | RegexOptions.Multiline );

            string winterm = File.ReadAllText( @"C:\SC\Winterm.ini" );

            winterm = spcwinRx.Replace( winterm, @"Spcwin=" + SettingsReader.Instance.PosdriverIPAddress.ToString() );
            try
            {
                winterm = spcwinbackupRx.Replace( winterm, @"SpcwinBackup=" + ( SettingsReader.Instance.RedundantIPAddress.ToString() ?? "" ) );
            }
            catch { }
            winterm = masterbmppathRx.Replace( winterm, @"; $1" );
            winterm = masterdatpathRx.Replace( winterm, @"; $1" );
            winterm = altbmppathRx.Replace( winterm, @"; $1" );
            winterm = altdatpathRx.Replace( winterm, @"; $1" );

            File.WriteAllText( @"C:\SC\Winterm.ini", winterm );
        }
    }
}
