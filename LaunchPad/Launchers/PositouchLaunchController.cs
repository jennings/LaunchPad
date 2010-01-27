using System.Collections.Generic;

namespace LaunchPad.Launchers
{
    public class PositouchLaunchController : ILaunchController
    {
        public bool LaunchesPosiw { get; private set; }
        public bool LaunchesPositerm { get; private set; }
        public bool LaunchesVNC { get; private set; }

        private List<ILauncher> Launchers = new List<ILauncher>();

        public PositouchLaunchController()
        {
            ReadSettings();
        }

        public void Launch()
        {
            foreach ( var launcher in Launchers )
            {
                launcher.Launch();
            }
        }

        private void ReadSettings()
        {
            LaunchesPositerm = false;
            LaunchesPosiw = false;
            LaunchesVNC = false;

            var settings = SettingsReader.Instance;

            LaunchesPosiw = settings.LaunchPosiw;
            LaunchesPositerm = settings.LaunchPositerm;
            LaunchesVNC = settings.LaunchVNC;

            if ( LaunchesVNC )
            {
                Launchers.Add( new VNCLauncher() );
            }
            if ( LaunchesPosiw )
            {
                Launchers.Add( new PosiwLauncher() );
            }
            if ( LaunchesPositerm )
            {
                Launchers.Add( new PositermLauncher() );
            }
        }
    }
}
