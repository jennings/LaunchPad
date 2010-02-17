using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using LaunchPad.Authentication;
using LaunchPad.Configuration.Configurators;
using System.Net;
using System.Collections;
using LaunchPad.Configuration.Tasks;
using System.Runtime.Remoting.Activation;

namespace LaunchPad.Configuration.Dispatch
{
    class ConfiguratorDispatcher : MarshalByRefObject, IConfiguratorDispatcher
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
        private const string IpcChannelName = "LaunchPadService";


        #region Listener/Receiver

        public static ConfiguratorDispatcher CreateRemoteDispatcher()
        {
            var channel = new IpcClientChannel();
            ChannelServices.RegisterChannel( channel, true );

            return (ConfiguratorDispatcher)Activator.CreateInstance(
                typeof( ConfiguratorDispatcher ),
                null,
                new object[] { new UrlAttribute( @"ipc://" + IpcChannelName ) } );
        }

        public static void RegisterServerType()
        {
            var ipcProperties = new Hashtable();
            ipcProperties["portName"] = IpcChannelName;
            ipcProperties["authorizedGroup"] = "Everyone";

            var channel = new IpcServerChannel( ipcProperties, null );
            ChannelServices.RegisterChannel( channel, true );
            RemotingConfiguration.RegisterActivatedServiceType( typeof( ConfiguratorDispatcher ) );
        }

        #endregion


        public void AddTask( ITask task )
        {
            var type = task.GetType();

            if ( type == typeof( CredentialsTask ) )
            {
                TaskList.Add( new CredentialsConfigurator( (CredentialsTask)task ) );
            }
            else if ( type == typeof( AutomaticLogonTask ) )
            {
                TaskList.Add( new AutomaticLogonConfigurator( (AutomaticLogonTask)task ) );
            }
            else if ( type == typeof( ComputerNameTask ) )
            {
                TaskList.Add( new ComputerNameConfigurator( (ComputerNameTask)task ) );
            }
            else if ( type == typeof( IPAddressTask ) )
            {
                TaskList.Add( new IPAddressConfigurator( (IPAddressTask)task ) );
            }
            else if ( type == typeof( PositermTask ) )
            {
                TaskList.Add( new PositermConfigurator( (PositermTask)task ) );
            }
            else if ( type == typeof( PosiwTask ) )
            {
                TaskList.Add( new PosiwConfigurator( (PosiwTask)task ) );
            }
            else if ( type == typeof( VNCTask ) )
            {
                TaskList.Add( new VNCConfigurator( (VNCTask)task ) );
            }
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
