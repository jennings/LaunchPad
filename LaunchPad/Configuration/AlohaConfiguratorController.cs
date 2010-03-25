using System;
using System.Collections.Generic;
using LaunchPad.Configuration.Configurators;
using LaunchPad.Models;
using LaunchPad.Configuration.Tasks;
using LaunchPad.Authentication;
using LaunchPad.Settings;

namespace LaunchPad.Configuration
{
    class AlohaConfiguratorController : IConfiguratorController
    {
        public bool RequiresAuthentication
        {
            get { return RemoteDispatcher.RequiresAuthentication; }
        }

        private ConfiguratorDispatcher LocalDispatcher;
        private ConfiguratorDispatcher RemoteDispatcher;
        private AlohaTerminal Model;

        private AlohaConfiguratorController() { }
        public AlohaConfiguratorController( AlohaTerminal model )
        {
            Model = model;

            LocalDispatcher = new ConfiguratorDispatcher();
            RemoteDispatcher = ConfiguratorDispatcher.CreateRemoteDispatcher();

            RemoteDispatcher.AddTask( new ComputerNameTask( Model.TermName ) );
            RemoteDispatcher.AddTask( new IPAddressTask( Model.IPAddress ) );
            RemoteDispatcher.AddTask( new IbercfgTask(
                Model.Term,
                Model.NumberOfTerminals,
                Model.FileserverName,
                Model.MasterCapable,
                Model.ServerCapable ) );
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
            settings.LaunchIbercfg = true; // FIXME
            settings.LaunchVNC = true; // FIXME
            settings.Commit();

            Rebooter.Reboot();
        }
    }
}
