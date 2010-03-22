using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace LaunchPad.Utilities
{
    class MiscUtilities
    {
        public static DirectoryInfo PosdriverDirectory
        {
            get
            {
                var tempdir = @"\\" + SettingsReader.Instance.PosdriverIPAddress.ToString();
                if ( Directory.Exists( tempdir + @"\C" ) )
                {
                    return new DirectoryInfo( tempdir + @"\C" );
                }
                else if ( Directory.Exists( tempdir + @"\C$" ) )
                {
                    return new DirectoryInfo( tempdir + @"\C$" );
                }

                throw new IOException( @"Unable to map to C or C$ share of: " + tempdir );
            }
        }

        public static void MapToPosdriver( char driveLetterChar )
        {
            MapDriveLetter( driveLetterChar, SettingsReader.Instance.PosdriverIPAddress.ToString() );
        }

        public static void MapToBackoffice( char driveLetterChar )
        {
            MapDriveLetter( driveLetterChar, SettingsReader.Instance.BackofficeIPAddress.ToString() );
        }

        public static void MapDriveLetter( char driveLetterChar, string computerIn )
        {
            try
            {
                MapDriveLetterToShare( driveLetterChar, computerIn, "C" );
            }
            catch ( Exception )
            {
                MapDriveLetterToShare( driveLetterChar, computerIn, "C$" );
            }
        }

        public static void MapDriveLetterToShare( char driveLetter, string computer, string shareName )
        {
            RunNet( String.Format( @"use {0}: /d", driveLetter ), 10000 );
            RunNet( String.Format( @"use {0}: \\{1}\{2}", driveLetter, computer, shareName ), 15000 );

            if ( !Directory.Exists( String.Format( @"{0}:\", driveLetter ) ) )
            {
                throw new Exception( String.Format( @"{0}:\ does not exist.", driveLetter ) );
            }
        }

        public static void RunNet( string args, int timeout )
        {
            var info = new ProcessStartInfo()
            {
                FileName = Path.Combine( Environment.SystemDirectory, @"net.exe" ),
                Arguments = args
            };

            if ( !Process.Start( info ).WaitForExit( timeout ) )
            {
                throw new Exception( string.Format( @"net {0} did not exit within {1} milliseconds.", args, timeout ) );
            }
        }
    }
}
