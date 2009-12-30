using System;
using System.Collections.Generic;
using System.Text;

namespace TermConfig.Configurators
{
    class AlohaConfiguratorController : IConfiguratorController
    {
        private AlohaTerminalStation StationSettings;
        private List<IConfigurator> Configurators = new List<IConfigurator>();

        private AlohaConfiguratorController() { }
        public AlohaConfiguratorController( AlohaTerminalStation terminalStation )
        {
            StationSettings = terminalStation;

            Configurators.Add( new RebootConfigurator() );
        }

        public void Configure()
        {
            throw new NotImplementedException();
        }
    }
}
