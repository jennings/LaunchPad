using System.Collections.Generic;

namespace TermConfig.Launchers
{
    public class AlohaLaunchController : ILaunchController
    {
        public bool LaunchesIbercfg { get; private set; }
        public bool LaunchesVNC { get; private set; }

        private List<ILauncher> Launchers = new List<ILauncher>();
        private const string ConfigDatabase = @"TermConfig.mdb";

        public AlohaLaunchController()
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
            LaunchesIbercfg = false;
            LaunchesVNC = false;

            var settings = SettingsReader.Instance;

            LaunchesIbercfg = settings.LaunchIbercfg;
            LaunchesVNC = settings.LaunchVNC;

            if ( LaunchesVNC )
            {
                Launchers.Add( new VNCLauncher() );
            }
            if ( LaunchesIbercfg )
            {
                Launchers.Add( new IbercfgLauncher() );
            }
        }
    }
}
