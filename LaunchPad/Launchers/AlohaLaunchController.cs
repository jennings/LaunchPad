﻿using System.Collections.Generic;
using LaunchPad.Settings;

namespace LaunchPad.Launchers
{
    public class AlohaLaunchController : ILaunchController
    {
        public bool LaunchesIbercfg { get; private set; }
        public bool LaunchesVNC { get; private set; }

        private List<ILauncher> Launchers = new List<ILauncher>();

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

            LaunchesIbercfg = settings.LaunchIbercfg == true;
            LaunchesVNC = settings.LaunchVNC == true;

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
