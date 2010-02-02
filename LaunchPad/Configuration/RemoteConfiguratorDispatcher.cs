using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using LaunchPad.Authentication;
using LaunchPad.Configuration.Configurators;

namespace LaunchPad.Configuration
{
    class RemoteConfiguratorDispatcher
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


        #region Listener/Receiver

        public static void RegisterClientType()
        {
            var channel = new TcpClientChannel();
            ChannelServices.RegisterChannel( channel, true );
            RemotingConfiguration.RegisterActivatedClientType(
                typeof( RemoteConfiguratorDispatcher ),
                @"tcp://localhost:" + ListenPort + @"/LaunchPadService" );
        }

        public static void RegisterServerType()
        {
            TcpServerChannel channel = new TcpServerChannel( ListenPort );
            ChannelServices.RegisterChannel( channel, true );
            RemotingConfiguration.ApplicationName = "LaunchPadService";
            RemotingConfiguration.RegisterActivatedServiceType( typeof( RemoteConfiguratorDispatcher ) );
        }

        #endregion


        public void Add( IConfigurator task )
        {
            if ( task.RequiresAuthentication )
            {
                GenerateChallenge();
            }

            TaskList.Add( task );
        }

        public void Process()
        {
            if ( RequiresAuthentication )
            {
                if ( !ValidateResponse() )
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

        private bool ValidateResponse()
        {
            // TODO
            return false;
        }
    }
}
