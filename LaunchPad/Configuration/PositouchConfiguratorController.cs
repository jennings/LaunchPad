using System.Collections.Generic;
using LaunchPad.Authentication;
using LaunchPad.Configuration.Configurators;
using LaunchPad.Configuration.Tasks;
using LaunchPad.Models;

namespace LaunchPad.Configuration
{
    class PositouchConfiguratorController : IConfiguratorController
    {
        public bool RequiresAuthentication
        {
            get { return RemoteDispatcher.RequiresAuthentication; }
        }

        private PositouchTerminalStation StationSettings;

        private ConfiguratorDispatcher LocalDispatcher;
        private ConfiguratorDispatcher RemoteDispatcher;
        private PositouchTerminalSelectionModel Model;

        private PositouchConfiguratorController() { }
        public PositouchConfiguratorController( PositouchTerminalStation terminalStation )
        {
            terminalStation.Validate();
            StationSettings = terminalStation;

            LocalDispatcher = new ConfiguratorDispatcher();
            RemoteDispatcher = ConfiguratorDispatcher.CreateRemoteDispatcher();

            RemoteDispatcher.AddTask( new ComputerNameTask( StationSettings.ComputerName ) );
            RemoteDispatcher.AddTask( new IPAddressTask( StationSettings.IPAddress ) );

            LocalDispatcher.AddTask( new PositermTask( StationSettings.ComputerName ) );
            LocalDispatcher.AddTask( new PosiwTask(
                StationSettings.DeviceNumber ?? 0, // FIXME
                StationSettings.PosiwType ?? PosiwTerminalType.Normal, // FIXME
                StationSettings.BackofficeIPAddress,
                StationSettings.PosdriverIPAddress,
                StationSettings.RedundantIPAddress ) );

            LocalDispatcher.AddTask( new VNCTask() );
        }

        public void Configure()
        {
            if ( RemoteDispatcher.RequiresAuthentication )
            {
                // TODO: Challenge / Response
                RemoteDispatcher.Response = new Response( RemoteDispatcher.Challenge );
            }

            RemoteDispatcher.Dispatch();
            LocalDispatcher.Dispatch();

            var settings = SettingsReader.Instance;
            settings.Commit();

            Rebooter.Reboot();
        }
    }
}
