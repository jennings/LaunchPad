using System.IO;
using System.Reflection;
using System.ServiceProcess;
using LaunchPad.Configuration;

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
            RemoteConfiguratorDispatcher.RegisterServerType();
        }
    }
}
