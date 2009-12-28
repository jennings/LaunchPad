using System;
using System.Collections.Generic;
using System.IO;

namespace TermConfig.Configurators
{
    class PositermConfigurator : IConfigurator
    {
        public TerminalStation StationSettings { get; private set; }

        private List<string> Filenames = new List<string>()
        {
            "AMS32.INI",
            "DELIVERY.INI",
            "GIFTCERT.INI",
            "ORDRSCRN.INI"
        };

        private bool Connected { get; set; }


        public PositermConfigurator( TerminalStation TerminalStationSettings )
        {
            TerminalStationSettings.Validate();
            StationSettings = TerminalStationSettings;
        }


        public void Configure()
        {
            // Copy INI files

            // Write TERM.$$$
            WriteTerminalName();
        }


        public void ConnectToRemoteShare()
        {
        }


        public void CopyINIFiles()
        {
        }


        public void WriteTerminalName()
        {
            if ( File.Exists( @"C:\SC\TERM.$$$" ) )
            {
                var timestring = DateTime.Now.ToString( @"yyyyMMddHHmmss" );
                File.Move( @"C:\SC\TERM.$$$", @"C:\Temp\TERM.$$$." + timestring );
            }

            using ( var sw = new StreamWriter( @"C:\SC\TERM.$$$" ) )
            {
                sw.Write( StationSettings.Name );
            }
        }
    }
}
