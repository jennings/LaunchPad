using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using LaunchPad.Authentication;
using LaunchPad.Configuration.Configurators;
using System.Net;

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


        //public void Add( IConfigurator task )
        //{
        //    if ( task.RequiresAuthentication )
        //    {
        //        GenerateChallenge();
        //    }

        //    TaskList.Add( task );
        //}

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

        public void Process()
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
                if ( task.GetType() == typeof( CredentialsConfigurator ) )
                {
                    var foo = (CredentialsConfigurator)task;
                    System.Windows.Forms.MessageBox.Show( "CredentialsConfigurator running as: " + foo.GetCurrentCredentials() );
                }
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
