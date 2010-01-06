using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace TermConfig
{
    class DriveMappingManager
    {
        private SettingsReader Settings = SettingsReader.Instance;

        public string MapDriveLetter( char driveLetterChar, string computerIn )
        {
            string driveLetter;         // L
            string drive;               // L:
            string driveDir;            // L:\
            string computer;            // 10.10.1.40
            string shareName;           // C
            string computerShareName;   // \\10.10.1.40\C

            driveLetter = driveLetterChar.ToString();
            drive = driveLetter + ":";
            driveDir = Path.Combine( drive, @"\" );
            computer = computerIn;
            shareName = "C";
            computerShareName = @"\\" + computer + @"\" + shareName;

            var info = new ProcessStartInfo()
            {
                FileName = Path.Combine( Environment.SystemDirectory, @"net.exe" ),
                Arguments = @"use " + drive + @" /d"
            };
            if ( !Process.Start( info ).WaitForExit( 10000 ) )
            {
                throw new Exception( @"NET " + info.Arguments + @" did not return in 10 seconds." );
            }

            info.Arguments = @"use " + drive + @" " + computerShareName;
            if ( !Process.Start( info ).WaitForExit( 15000 ) )
            {
                throw new Exception( @"NET " + info.Arguments + @" did not return in 15 seconds." );
            }

            if ( !Directory.Exists( driveDir ) )
            {
                shareName = shareName + "$";
                computerShareName = @"\\" + computer + @"\" + shareName;
                info.Arguments = "use " + drive + " " + computerShareName;
                if ( !Process.Start( info ).WaitForExit( 15000 ) )
                {
                    throw new Exception( @"NET " + info.Arguments + @" did not return in 15 seconds." );
                }

                if ( !Directory.Exists( driveDir ) )
                {
                    throw new Exception( @"Could not map to C or C$ share of " + computer );
                }
            }

            return driveDir;
        }
    }
}
