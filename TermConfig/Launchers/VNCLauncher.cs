using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;
using System.IO;
using System.Diagnostics;

namespace TermConfig.Launchers
{
    class VNCLauncher : ILauncher
    {
        #region ILauncher Members

        public void Launch()
        {
            var service = new ServiceController( "winvnc" );

            try
            {
                if ( service.Status == ServiceControllerStatus.Stopped )
                {
                    service.Start();
                }
            }
            catch ( Exception )
            {
                if ( !File.Exists( @"C:\Program Files\UltraVNC\winvnc.exe" ) )
                {
                    throw new Exception( @"UltraVNC appears not to be installed in C:\Program Files\UltraVNC." );
                }

                var info = new ProcessStartInfo();
                info.WorkingDirectory = @"C:\Program Files\UltraVNC";
                info.FileName = @"C:\Program Files\UltraVNC\winvnc.exe";
                Process.Start( info );
            }
        }

        #endregion
    }
}
