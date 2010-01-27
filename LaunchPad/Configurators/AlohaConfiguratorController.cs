using System;
using System.Collections.Generic;
using System.Text;

namespace LaunchPad.Configurators
{
    class AlohaConfiguratorController : IConfiguratorController
    {
        private AlohaTerminalStation StationSettings;
        private List<IConfigurator> Configurators = new List<IConfigurator>();

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
