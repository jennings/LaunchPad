using System.Collections.Generic;
using LaunchPad.Authentication;
using LaunchPad.Configuration.Configurators;
using LaunchPad.Configuration.Dispatch;

namespace LaunchPad.Configuration
{
    class PositouchConfiguratorController : IConfiguratorController
    {
        public bool RequiresAuthentication
        {
            get { return RemoteConfigurators.RequiresAuthentication; }
        }

        private PositouchTerminalStation StationSettings;
        private List<IConfigurator> Configurators = new List<IConfigurator>();
        private RemoteConfiguratorDispatcher RemoteConfigurators = new RemoteConfiguratorDispatcher();

        private PositouchConfiguratorController() { }
        public PositouchConfiguratorController( PositouchTerminalStation terminalStation )
        {
            terminalStation.Validate();
            StationSettings = terminalStation;

            RemoteConfigurators.AddComputerNameTask( StationSettings.ComputerName );
            RemoteConfigurators.AddIPAddressTask( StationSettings.IPAddress );

            Configurators.Add( new PositermConfigurator( StationSettings.ComputerName ) );
            Configurators.Add( new PosiwConfigurator(
                StationSettings.DeviceNumber ?? 0, // FIXME
                StationSettings.Backoffice,
                StationSettings.PosdriverTerminal,
                StationSettings.RedundantTerminal,
                StationSettings.BackofficeIPAddress,
                StationSettings.PosdriverIPAddress,
                StationSettings.RedundantIPAddress ) );
            Configurators.Add( new VNCConfigurator() );
        }

        public void Configure()
        {
            if ( RemoteConfigurators.RequiresAuthentication )
            {
                // TODO: Challenge / Response
                RemoteConfigurators.Response = new Response( RemoteConfigurators.Challenge );
            }

            RemoteConfigurators.Dispatch();

            foreach ( var configurator in Configurators )
            {
                configurator.Configure();
            }

            SettingsReader.Instance.Commit();

            Rebooter.Reboot();
        }
    }
}
