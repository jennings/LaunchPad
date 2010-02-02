using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using LaunchPad.Authentication;
using LaunchPad.Configuration.Configurators;
using System.Net;
using System.Collections;

namespace LaunchPad.Configuration
{
    class RemoteConfiguratorDispatcher : MarshalByRefObject, IConfiguratorDispatcher
    {
        public bool RequiresAuthentication
        {
            get
            {
                foreach ( var task in TaskList )
                {
                    if ( task.RequiresAuthentication == true )
                    { return true; }
                }
                return false;
            }
        }

        public Challenge @Challenge { get; private set; }
        public Response @Response { get; set; }

        private List<IConfigurator> TaskList = new List<IConfigurator>();
        private const int ListenPort = 9091;
        private const string IpcChannelName = "LaunchPadService";


        #region Listener/Receiver

        public static void RegisterClientType()
        {
            var channel = new IpcClientChannel();
            ChannelServices.RegisterChannel( channel, true );
            RemotingConfiguration.RegisterActivatedClientType(
                typeof( RemoteConfiguratorDispatcher ),
                @"ipc://" + IpcChannelName );
        }

        public static void RegisterServerType()
        {
            var ipcProperties = new Hashtable();
            ipcProperties["portName"] = IpcChannelName;
            ipcProperties["authorizedGroup"] = "Everyone";
            
            var channel = new IpcServerChannel( ipcProperties, null );
            ChannelServices.RegisterChannel( channel, true );
            RemotingConfiguration.RegisterActivatedServiceType( typeof( RemoteConfiguratorDispatcher ) );
        }

        #endregion


        public void AddCredentialTask( string baseCustomerPassword )
        {
            TaskList.Add( new CredentialsConfigurator( baseCustomerPassword ) );
        }

        public void AddComputerNameTask( string computerName )
        {
            TaskList.Add( new ComputerNameConfigurator( computerName ) );
        }

        public void AddIPAddressTask( IPAddress ipaddress )
        {
            TaskList.Add( new IPAddressConfigurator( ipaddress ) );
        }

        public void Dispatch()
        {
            if ( RequiresAuthentication )
            {
                if ( Response == null || !Response.Validate() )
                {
                    throw new Exception( "Invalid response to challenge. Not processing task list." );
                }
            }

            foreach ( var task in TaskList )
            {
                task.Configure();
            }
        }

        private void GenerateChallenge()
        {
            // TODO
            Challenge = new Challenge();
        }
    }
}
