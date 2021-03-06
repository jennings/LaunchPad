﻿using System.IO;
using System.ServiceProcess;
using LaunchPad.Configuration;
using LaunchPad.Settings;

namespace LaunchPad
{
    class LaunchPadService : ServiceBase
    {
        public static readonly string LogFilePath;

        static LaunchPadService()
        {
            LogFilePath = Path.Combine( SettingsReader.LaunchPadDirectory, @"LaunchPadService.log" );
        }

        protected override void OnStart( string[] args )
        {
            ConfiguratorDispatcher.RegisterServerType();
        }
    }
}
