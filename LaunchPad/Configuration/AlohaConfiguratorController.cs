using System;
using System.Collections.Generic;
using LaunchPad.Configuration.Configurators;

namespace LaunchPad.Configuration
{
    class AlohaConfiguratorController : IConfiguratorController
    {
        public bool RequiresAuthentication
        {
            get { return RemoteConfigurators.RequiresAuthentication; }
        }

        // private AlohaTerminalStation StationSettings;
        private List<IConfigurator> Configurators = new List<IConfigurator>();
        private ConfiguratorDispatcher RemoteConfigurators = new ConfiguratorDispatcher();

        public void Configure()
        {
            throw new NotImplementedException();

            SettingsReader.Instance.Commit();

            Rebooter.Reboot();
        }
    }
}
