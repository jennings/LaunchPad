using System.Collections.Generic;
using LaunchPad.Authentication;
using LaunchPad.Configuration.Configurators;
using LaunchPad.Configuration.Tasks;
using LaunchPad.Models;
using LaunchPad.Settings;

namespace LaunchPad.Configuration
{
    class PositouchConfiguratorController : IConfiguratorController
    {
        public bool RequiresAuthentication
        {
            get { return RemoteDispatcher.RequiresAuthentication; }
        }

        private ConfiguratorDispatcher LocalDispatcher;
        private ConfiguratorDispatcher RemoteDispatcher;
        private PositouchTerminalSelectionModel Model;

        private PositouchConfiguratorController() { }
        public PositouchConfiguratorController( PositouchTerminalSelectionModel model )
        {
            Model = model;

            LocalDispatcher = new ConfiguratorDispatcher();
            RemoteDispatcher = ConfiguratorDispatcher.CreateRemoteDispatcher();

            RemoteDispatcher.AddTask( new ComputerNameTask( model.ComputerName ) );
            RemoteDispatcher.AddTask( new IPAddressTask( model.IPAddress ) );
            RemoteDispatcher.AddTask( new VNCTask() );

            LocalDispatcher.AddTask( new PositermTask( model.ComputerName ) );
            LocalDispatcher.AddTask( new PosiwTask(
                model.DeviceNumber, // FIXME
                model.Type, // FIXME
                model.BackofficeIPAddress,
                model.PosdriverIPAddress,
                null ) );
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
            settings.LaunchPosiw = true; // FIXME
            settings.LaunchPositerm = true; // FIXME
            settings.LaunchVNC = true; // FIXME
            settings.Commit();

            Rebooter.Reboot();
        }
    }
}
