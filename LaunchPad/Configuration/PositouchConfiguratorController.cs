﻿using System.Collections.Generic;
using LaunchPad.Authentication;
using LaunchPad.Configuration.Configurators;
using LaunchPad.Configuration.Dispatch;
using LaunchPad.Configuration.Tasks;
using LaunchPad.Models;

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
        private PositouchTerminalSelectionModel Model;

        private PositouchConfiguratorController() { }
        public PositouchConfiguratorController( PositouchTerminalStation terminalStation )
        {
            terminalStation.Validate();
            StationSettings = terminalStation;

            RemoteConfigurators.AddComputerNameTask( new ComputerNameTask( StationSettings.ComputerName ) );
            RemoteConfigurators.AddIPAddressTask( new IPAddressTask( StationSettings.IPAddress ) );

            Configurators.Add( new PositermConfigurator( new PositermTask( StationSettings.ComputerName ) ) );
            Configurators.Add( new PosiwConfigurator( new PosiwTask(
                StationSettings.DeviceNumber ?? 0, // FIXME
                StationSettings.PosiwType ?? PosiwTerminalType.Normal, // FIXME
                StationSettings.BackofficeIPAddress,
                StationSettings.PosdriverIPAddress,
                StationSettings.RedundantIPAddress ) ) );
            Configurators.Add( new VNCConfigurator( new VNCTask() ) );
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

            var settings = SettingsReader.Instance;
            settings.IPAddress = Model.IPAddress;
            settings.Commit();

            Rebooter.Reboot();
        }
    }
}
