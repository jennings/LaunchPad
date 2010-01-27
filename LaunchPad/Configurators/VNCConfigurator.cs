using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

namespace LaunchPad.Configurators
{
    class VNCConfigurator : IConfigurator
    {
        ITerminalStation StationSettings;

        private const string VNCDirectory = @"C:\Program Files\UltraVNC";
        private const string VNCBackupDirectory = @"C:\Program Files\UltraVNC2";
        private const string SourceVNCDirectory = @"Configurators\UltraVNC";

        private VNCConfigurator() { }
        public VNCConfigurator( ITerminalStation settings )
        {
            StationSettings = settings;
        }


        public void Configure()
        {
            StopVNCProcesses();
            System.Threading.Thread.Sleep( 500 );

            MoveExistingVNCDirectory();
            System.Threading.Thread.Sleep( 500 );

            CreateNewVNCDirectory();

            ChangeVNCPassword();

            RegisterVNCService();
        }


        private void StopVNCProcesses()
        {
            var vncprocs = Process.GetProcessesByName( "winvnc" );
            foreach ( var proc in vncprocs )
            {
                proc.Kill();
            }
            System.Threading.Thread.Sleep( 1000 );
        }


        private void MoveExistingVNCDirectory()
        {
            // Delete C:\Program Files\UltraVNC2
            if ( Directory.Exists( VNCBackupDirectory ) )
            {
                Directory.Delete( VNCBackupDirectory, true );
            }

            // Rename C:\Program Files\UltraVNC to UltraVNC2
            if ( Directory.Exists( VNCDirectory ) )
            {
                Directory.Move( VNCDirectory, VNCBackupDirectory );
            }
        }


        private void CreateNewVNCDirectory()
        {
            CopyDirectoryRecursively( new DirectoryInfo( SourceVNCDirectory ), new DirectoryInfo( VNCDirectory ) );
        }


        private void ChangeVNCPassword()
        {
            // Hrm...
        }


        private void RegisterVNCService()
        {
            var info = new ProcessStartInfo();
            info.FileName = @"C:\Program Files\UltraVNC\winvnc.exe";
            info.Arguments = "-remove";
            Process.Start( info );
            System.Threading.Thread.Sleep( 500 );

            info.Arguments = "-install";
            Process.Start( info );
        }


        private void CopyDirectoryRecursively( DirectoryInfo source, DirectoryInfo dest )
        {
            if ( !dest.Exists )
            {
                dest.Create();
            }

            foreach ( var file in source.GetFiles() )
            {
                file.CopyTo( Path.Combine( dest.ToString(), file.Name ), true );
            }

            foreach ( var sourceSubDir in source.GetDirectories() )
            {
                var destSubDir = dest.CreateSubdirectory( sourceSubDir.Name );
                CopyDirectoryRecursively( sourceSubDir, destSubDir );
            }
        }
    }
}
