using System;
using System.IO;
using System.Reflection;
using System.ServiceProcess;

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
            var runFrom = Assembly.GetExecutingAssembly().Location;
            Directory.GetParent( runFrom );
            System.IO.File.WriteAllText( LogFilePath, "Last run at: " + DateTime.Now );
        }
    }
}
