using System;
using System.Collections.Generic;
using System.Text;

namespace TermConfig.Launchers
{
    public class AlohaLaunchController : ILaunchController
    {
        public bool LaunchesTerminal { get; set; }

        private List<ILauncher> Launchers = new List<ILauncher>();

        public AlohaLaunchController()
        {
            Launchers.Add( new AlohaTerminalLauncher() );
        }

        public void Launch()
        {
            foreach ( var launcher in Launchers )
            {
                launcher.Launch();
            }
        }
    }
}
