﻿using System;
using System.Diagnostics;
using System.IO;

namespace TermConfig.Launchers
{
    class PositermLauncher : ILauncher
    {
        #region ILauncher Members

        public void Launch()
        {
            if ( !File.Exists( @"C:\SC\Positerm.exe" ) )
            {
                throw new Exception( @"C:\SC\Positerm.exe does not exist." );
            }

            var info = new ProcessStartInfo();
            info.WorkingDirectory = @"C:\SC";
            info.FileName = @"C:\SC\Positerm.exe";
            Process.Start( info );
        }

        #endregion
    }
}
