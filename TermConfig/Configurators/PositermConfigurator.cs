using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.Net;
using System.IO;

namespace TermConfig.Configurators
{
    class PositermConfigurator : IConfigurator
    {
        public TerminalStation StationSettings { get; private set; }

        [Obsolete]
        IPAddress SourceAddress;
        [Obsolete]
        string Share;
        [Obsolete]
        string Username;
        [Obsolete]
        string Password;

        List<string> Filenames;

        public bool Connected { get; set; }

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

        public void ConnectToRemoteShare( string address, string share, string username, string password )
        {
            SourceAddress = IPAddress.Parse( address );
            Share = share;
            Username = username;
            Password = password;

            // Connect
        }

        public void CopyFiles( List<string> filenames )
        {
            Filenames = filenames;
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
