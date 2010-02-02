using System.Collections.Generic;
using LaunchPad.Configuration.Configurators;

namespace LaunchPad.Configuration
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

            Configurators.Add( new NetworkConfigurator( StationSettings ) );
            Configurators.Add( new PositermConfigurator( StationSettings ) );
            Configurators.Add( new PosiwConfigurator( StationSettings ) );
            Configurators.Add( new VNCConfigurator( StationSettings ) );
        }

        public void Configure()
        {
            foreach ( var configurator in Configurators )
            {
                if ( configurator.RequiresElevation )
                {
                    // TODO: Send to LaunchPadService
                    configurator.Configure();
                }
                else
                {
                    configurator.Configure();
                }
            }

            SettingsReader.Instance.Commit();

            Rebooter.Reboot();
        }
    }
}
