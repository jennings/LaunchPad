using System.Collections.Generic;
using LaunchPad.Authentication;
using LaunchPad.Configuration.Configurators;
using LaunchPad.Configuration.Tasks;
using LaunchPad.Models;
using LaunchPad.Settings;

namespace LaunchPad.Configuration
{
    class PositouchInitialConfiguratorController : IConfiguratorController
    {
        public bool RequiresAuthentication
        {
            get { return RemoteDispatcher.RequiresAuthentication; }
        }

        private List<IConfigurator> Configurators = new List<IConfigurator>();
        private ConfiguratorDispatcher RemoteDispatcher;
        private PositouchInitialConfigurationModel Model;

        private PositouchInitialConfiguratorController() { }
        public PositouchInitialConfiguratorController( PositouchInitialConfigurationModel model )
        {
            Model = model;
            RemoteDispatcher = ConfiguratorDispatcher.CreateRemoteDispatcher();

            if ( Model.BasePassword != null )
            {
                RemoteDispatcher.AddTask( new CredentialsTask( "pos", "pos" ) );
                RemoteDispatcher.AddTask( new AutomaticLogonTask( "pos", "pos" ) );
                RemoteDispatcher.AddTask( new CredentialsTask( "cbs", Model.CbsPassword ) );
                RemoteDispatcher.AddTask( new CredentialsTask( "acronis", Model.AcronisPassword ) );
            }

            if ( Model.IPAddress != null )
            {
                RemoteDispatcher.AddTask( new IPAddressTask( Model.IPAddress ) );
            }

            if ( Model.PosdriverIPAddress != null )
            {
            }

            if ( Model.BackofficeIPAddress != null )
            {
            }

            RemoteDispatcher.AddTask( new VNCTask() );
            RemoteDispatcher.AddTask( new SettingsTask( SettingsReader.Instance ) );
        }

        public void Configure()
        {
            if ( RemoteDispatcher.RequiresAuthentication )
            {
                // TODO: Challenge / Response
                RemoteDispatcher.Response = new Response( RemoteDispatcher.Challenge );
            }

            RemoteDispatcher.Dispatch();

            foreach ( var configurator in Configurators )
            {
                configurator.Configure();
            }

            // FIXME: This should be done by the Configurators as
            // they run because if one fails, this will still get set.
            var settings = SettingsReader.Instance;
            settings.PosdriverIPAddress = Model.PosdriverIPAddress;
            settings.BackofficeIPAddress = Model.BackofficeIPAddress;
            settings.WriteSettings();

            Rebooter.Reboot();
        }
    }
}
