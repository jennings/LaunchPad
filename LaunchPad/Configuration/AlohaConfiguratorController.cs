using System;
using System.Collections.Generic;
using LaunchPad.Configuration.Configurators;
using LaunchPad.Configuration.Dispatch;

namespace LaunchPad.Configuration
{
    class AlohaConfiguratorController : IConfiguratorController
    {
        public bool RequiresAuthentication
        {
            get { return RemoteConfigurators.RequiresAuthentication; }
        }

        private AlohaTerminalStation StationSettings;
        private List<IConfigurator> Configurators = new List<IConfigurator>();
        private RemoteConfiguratorDispatcher RemoteConfigurators = new RemoteConfiguratorDispatcher();

        private AlohaConfiguratorController() { }
        public AlohaConfiguratorController( AlohaTerminalStation terminalStation )
        {
            StationSettings = terminalStation;
        }

        public void Configure()
        {
            throw new NotImplementedException();

            SettingsReader.Instance.Commit();

            Rebooter.Reboot();
        }
    }
}
