using System;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using LaunchPad.Service;

namespace LaunchPad
{
    class LaunchPadService : ServiceBase
    {
        public static readonly string WorkingDirectory;
        public static readonly string LaunchPadDirectory;
        public static readonly string LogFilePath;

        static LaunchPadService()
        {
            WorkingDirectory = Path.GetDirectoryName( Assembly.GetExecutingAssembly().Location );
            LaunchPadDirectory = @"C:\LaunchPad";
            LogFilePath = Path.Combine( LaunchPadDirectory, @"LaunchPadService.log" );
        }

        protected override void OnStart( string[] args )
        {
            TcpServerChannel tservices = new TcpServerChannel( 9091 );
            ChannelServices.RegisterChannel( tservices, true );
            RemotingConfiguration.ApplicationName = "LaunchPadService";
            RemotingConfiguration.RegisterActivatedServiceType( typeof( MessageHandler ) );
        }
    }
}
