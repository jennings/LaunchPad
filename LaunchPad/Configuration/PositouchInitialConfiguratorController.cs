using System.Collections.Generic;
using LaunchPad.Authentication;
using LaunchPad.Configuration.Configurators;
using LaunchPad.Configuration.Dispatch;
using LaunchPad.Configuration.Tasks;
using LaunchPad.Models;

namespace LaunchPad.Configuration
{
    class PositouchInitialConfiguratorController : IConfiguratorController
    {
        public bool RequiresAuthentication
        {
            get { return RemoteConfigurators.RequiresAuthentication; }
        }

        private List<IConfigurator> Configurators = new List<IConfigurator>();
        private RemoteConfiguratorDispatcher RemoteConfigurators = new RemoteConfiguratorDispatcher();
        private PositouchInitialConfigurationModel Model;

        private PositouchInitialConfiguratorController() { }
        public PositouchInitialConfiguratorController( PositouchInitialConfigurationModel model )
        {
            Model = model;

            if ( Model.BasePassword != null )
            {
                RemoteConfigurators.AddCredentialTask( new CredentialsTask( "pos", "pos" ) );
                RemoteConfigurators.AddAutomaticLogonTask( new AutomaticLogonTask( "pos", "pos" ) );
                RemoteConfigurators.AddCredentialTask( new CredentialsTask( "cbs", Model.CbsPassword ) );
                RemoteConfigurators.AddCredentialTask( new CredentialsTask( "acronis", Model.AcronisPassword ) );
            }

            if ( Model.IPAddress != null )
            {
                RemoteConfigurators.AddIPAddressTask( new IPAddressTask( Model.IPAddress ) );
            }

            if ( Model.PosdriverIPAddress != null )
            {
            }

            if ( Model.BackofficeIPAddress != null )
            {
            }
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

            // FIXME: This should be done by the Configurators as
            // they run because if one fails, this will still get set.
            var settings = SettingsReader.Instance;
            settings.IPAddress = Model.IPAddress;
            settings.PosdriverIPAddress = Model.PosdriverIPAddress;
            settings.BackofficeIPAddress = Model.BackofficeIPAddress;
            settings.Commit();

            Rebooter.Reboot();
        }
    }
}
