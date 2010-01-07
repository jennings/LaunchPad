using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace TermConfig.Configurators
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
            DriveMapper.MapDriveLetter( 'L', SettingsReader.Instance.PosdriverIPAddress.ToString() );
            CopyINIFiles();

            // Write TERM.$$$
            WriteTerminalName();
        }


        private void CreateCShare()
        {
            var netExecutable = Path.Combine(
                Environment.GetFolderPath( Environment.SpecialFolder.System ),
                "net.exe" );

            var info = new ProcessStartInfo();
            info.Arguments = @"share C=C:\";
            info.FileName = netExecutable;

            if ( !File.Exists( netExecutable ) )
            {
                throw new Exception( @"net.exe does not exist in system/system32 folder." );
            }

            var netProcess = Process.Start( info );

            if ( netProcess.WaitForExit( 15000 ) )
            {
            }
            else
            {
                throw new Exception( @"NET SHARE did not exit within 15 seconds." );
            }
        }


        private void CopyINIFiles()
        {
            foreach ( var filename in Filenames )
            {
                System.Windows.Forms.MessageBox.Show( "Going to copy " + filename );
                System.Threading.Thread.Sleep( 1000 );

                var fullfilename = Path.Combine( PosdriverCFolder, @"SC" + filename );
                if ( File.Exists( fullfilename ) )
                {
                    File.Copy( fullfilename, Path.Combine( @"C:\SC", filename ), true );
                    System.Windows.Forms.MessageBox.Show( "Copied " + filename );
                    System.Threading.Thread.Sleep( 1000 );
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
