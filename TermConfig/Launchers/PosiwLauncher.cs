using System;
using System.Diagnostics;
using System.IO;

namespace TermConfig.Launchers
{
    class PosiwLauncher : ILauncher
    {
        #region ILauncher Members

        public void Launch()
        {
            if ( !File.Exists( @"C:\SC\Posiw.exe" ) )
            {
                throw new Exception( @"C:\SC\Posiw.exe does not exist." );
            }

            var info = new ProcessStartInfo();
            info.WorkingDirectory = @"C:\SC";
            info.FileName = @"C:\SC\Posiw.exe";
            Process.Start( info );
        }

        #endregion
    }
}
