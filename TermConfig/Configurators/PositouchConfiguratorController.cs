using System;
using System.Collections.Generic;
using System.Text;

namespace TermConfig.Configurators
{
    class PositouchConfiguratorController : IConfiguratorController
    {
        private PositouchTerminalStation StationSettings;

        private PositouchConfiguratorController() { }
        public PositouchConfiguratorController( PositouchTerminalStation terminalStation )
        {
            StationSettings = terminalStation;
        }

        public void Configure()
        {
            throw new NotImplementedException();
        }
    }
}
