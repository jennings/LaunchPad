using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace TermConfig.Launchers
{
    class IbercfgLauncher : ILauncher
    {
        public void Launch()
        {
            var info = new ProcessStartInfo();
            info.FileName = @"C:\IBERCFG.BAT";
            info.WorkingDirectory = @"C:\";
            Process.Start( info );
        }
    }
}
