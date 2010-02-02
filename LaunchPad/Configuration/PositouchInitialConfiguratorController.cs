using System.Collections.Generic;
using LaunchPad.Configuration.Configurators;

namespace LaunchPad.Configuration
{
    class PositouchInitialConfiguratorController : IConfiguratorController
    {
        PositouchTerminalStation StationSettings;
        List<IConfigurator> Configurators = new List<IConfigurator>();

        private PositouchInitialConfiguratorController() { }
        public PositouchInitialConfiguratorController( PositouchTerminalStation settings )
        {
            settings.ValidateInitial();
            StationSettings = settings;

            Configurators.Add( new CredentialsConfigurator( StationSettings.WindowsUsername, StationSettings.WindowsPassword ) );
            Configurators.Add( new NetworkConfigurator( StationSettings ) );
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
