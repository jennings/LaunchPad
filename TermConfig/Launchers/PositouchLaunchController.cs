using System;
using System.Collections.Generic;
using System.Text;

namespace TermConfig.Launchers
{
    public class PositouchLaunchController : ILaunchController
    {
        public bool LaunchesPosiw { get; set; }
        public bool LaunchesPositerm { get; set; }
        public bool LaunchesVNC { get; set; }

        private List<ILauncher> Launchers = new List<ILauncher>();

        public PositouchLaunchController()
        {
            Launchers.Add( new PosiwLauncher() );
            Launchers.Add( new PositermLauncher() );
            Launchers.Add( new VNCLauncher() );
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
