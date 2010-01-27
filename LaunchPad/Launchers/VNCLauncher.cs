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
            ServiceController service;
            ServiceControllerStatus status;

            try
            {
                service = new ServiceController( "winvnc" );
                status = service.Status;
            }
            catch ( InvalidOperationException )
            {
                try
                {
                    service = new ServiceController( "uvnc_service" );
                    status = service.Status;
                }
                catch ( InvalidOperationException )
                {
                    // Service not installed, try to launch as an application

                    if ( !File.Exists( @"C:\Program Files\UltraVNC\winvnc.exe" ) )
                    {
                        throw new Exception( @"UltraVNC appears not to be installed in C:\Program Files\UltraVNC." );
                    }

                    var info = new ProcessStartInfo();
                    info.WorkingDirectory = @"C:\Program Files\UltraVNC";
                    info.FileName = @"C:\Program Files\UltraVNC\winvnc.exe";
                    Process.Start( info );

                    return;
                }
            }

            // status contains the service status
            if ( status == ServiceControllerStatus.Stopped )
            {
                service.Start();
            }
        }

        #endregion
    }
}
