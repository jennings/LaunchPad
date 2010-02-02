using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace LaunchPad.Configuration.Configurators
{
    class PositermConfigurator : IConfigurator
    {
        public PositouchTerminalStation StationSettings { get; private set; }

        private List<string> Filenames = new List<string>()
        {
            "AMS32.INI",
            "DELIVERY.INI",
            "GIFTCERT.INI",
            "ORDRSCRN.INI",
            "WINTERM.INI"
        };

        private string PosdriverCFolder;

        private PositermConfigurator() { }
        public PositermConfigurator( PositouchTerminalStation TerminalStationSettings )
        {
            StationSettings = TerminalStationSettings;
        }


        public void Configure()
        {
            CreateCShare();

            // Copy INI files
            Utilities.MapDriveLetter( 'L', SettingsReader.Instance.PosdriverIPAddress.ToString() );
            PosdriverCFolder = @"L:\";
            CopyINIFiles();

            // Write TERM.$$$
            WriteTerminalName();
        }


        private void CreateCShare()
        {
            Utilities.RunNet( @"share C /DELETE", 10000 );
            Utilities.RunNet( @"share C=C:\", 10000 );
        }


        private void CopyINIFiles()
        {
            foreach ( var filename in Filenames )
            {
                var fullfilename = Path.Combine( PosdriverCFolder, @"SC" + filename );
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
                sw.Write( StationSettings.ComputerName );
            }
        }
    }
}
