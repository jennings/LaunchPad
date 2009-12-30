using System;
using System.Collections.Generic;
using System.Text;

namespace TermConfig.Configurators
{
    class AlohaConfiguratorController : IConfiguratorController
    {
        private AlohaTerminalStation StationSettings;

        private AlohaConfiguratorController() { }
        public AlohaConfiguratorController( AlohaTerminalStation terminalStation )
        {
            StationSettings = terminalStation;
        }

        public void Configure()
        {
            throw new NotImplementedException();
        }
    }
}
