using System;
using System.Collections.Generic;
using System.Text;

namespace TermConfig.Configurators
{
    class PositouchConfiguratorController : IConfiguratorController
    {
        private PositouchTerminalStation StationSettings;
        private List<IConfigurator> Configurators = new List<IConfigurator>();

        private PositouchConfiguratorController() { }
        public PositouchConfiguratorController( PositouchTerminalStation terminalStation )
        {
            terminalStation.Validate();
            StationSettings = terminalStation;

            Configurators.Add( new CredentialsConfigurator( StationSettings.WindowsUsername, StationSettings.WindowsPassword ) );
            Configurators.Add( new NetworkConfigurator( StationSettings ) );
            Configurators.Add( new PositermConfigurator( StationSettings ) );
            Configurators.Add( new PosiwConfigurator( StationSettings ) );
            Configurators.Add( new VNCConfigurator( StationSettings ) );
            Configurators.Add( new RebootConfigurator() );
        }

        public void Configure()
        {
            foreach ( var configurator in Configurators )
            {
                configurator.Configure();
            }
        }
    }
}
