using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using LaunchPad.Configuration.Tasks;
using LaunchPad.Models;
using LaunchPad.Settings;

namespace LaunchPad.Configuration.Configurators
{
    class SettingsConfigurator : IConfigurator
    {
        public bool RequiresElevation { get { return true; } }
        public bool RequiresAuthentication { get { return false; } }

        private SettingsReader Settings;

        private SettingsConfigurator() { }
        public SettingsConfigurator( SettingsTask task )
        {
            Settings = task.SettingsReader;
        }
        
        public void Configure()
        {
            Settings.WriteSettings();
        }
    }
}
