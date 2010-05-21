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

        private ConfiguratorDispatcher RemoteDispatcher;
        private PositouchTerminalSelectionModel Model;

        private PositouchConfiguratorController() { }
        public PositouchConfiguratorController( PositouchTerminalSelectionModel model )
        {
            Model = model;

            RemoteDispatcher = ConfiguratorDispatcher.CreateRemoteDispatcher();

            RemoteDispatcher.AddTask( new ComputerNameTask( model.ComputerName ) );
            RemoteDispatcher.AddTask( new IPAddressTask( model.IPAddress ) );
            RemoteDispatcher.AddTask( new VNCTask() );
            RemoteDispatcher.AddTask( new SettingsTask( SettingsReader.Instance ) );

            RemoteDispatcher.AddTask( new PositermTask( model.ComputerName ) );
            RemoteDispatcher.AddTask( new PosiwTask(
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
            
            var settings = SettingsReader.Instance;
            settings.LaunchPosiw = true; // FIXME
            settings.LaunchPositerm = true; // FIXME
            settings.LaunchVNC = true; // FIXME
            settings.WriteSettings();

            Rebooter.Reboot();
        }
    }
}
