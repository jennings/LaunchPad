using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace TermConfig
{
    class DriveMapper
    {
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
            var info = new ProcessStartInfo()
            {
                FileName = Path.Combine( Environment.SystemDirectory, @"net.exe" ),
                Arguments = String.Format( @"use {0}: /d", driveLetter )
            };

            if ( !Process.Start( info ).WaitForExit( 10000 ) )
            {
                throw new Exception( String.Format( @"net {0} did not exit within 10 seconds.", info.Arguments ) );
            }

            info.Arguments = String.Format( @"use {0}: \\{1}\{2}", driveLetter, computer, shareName );

            if ( !Process.Start( info ).WaitForExit( 15000 ) )
            {
                throw new Exception( String.Format( @"net {0} did not exit within 15 seconds.", info.Arguments ) );
            }

            if ( !Directory.Exists( String.Format( @"{0}:\", driveLetter ) ) )
            {
                throw new Exception( String.Format( @"{0}:\ does not exist.", driveLetter ) );
            }
        }
    }
}
