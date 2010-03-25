using System;
using System.Diagnostics;
using System.IO;
using LaunchPad.Configuration.Tasks;
using LaunchPad.Settings;

namespace LaunchPad.Configuration.Configurators
{
    class VNCConfigurator : IConfigurator
    {
        public bool RequiresElevation { get { return true; } }
        public bool RequiresAuthentication { get { return false; } }

        private readonly string VNCDirectory;
        private readonly string VNCBackupDirectory;
        private readonly string SourceVNCDirectory;

        private VNCConfigurator() { }
        public VNCConfigurator( VNCTask task )
        {
            var pfpath = Environment.GetFolderPath( Environment.SpecialFolder.ProgramFiles );
            VNCDirectory = Path.Combine( pfpath, @"UltraVNC" );
            VNCBackupDirectory = Path.Combine( pfpath, @"UltraVNC2" );
            SourceVNCDirectory = Path.Combine( SettingsReader.LaunchPadDirectory, @"UltraVNC" );
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
            CopyDirectoryRecursively(
                new DirectoryInfo( SourceVNCDirectory ),
                new DirectoryInfo( VNCDirectory ) );
        }


        private void ChangeVNCPassword()
        {
            // FIXME
        }


        private void RegisterVNCService()
        {
            var info = new ProcessStartInfo();
            info.FileName = Path.Combine( VNCDirectory, "winvnc.exe" );
            info.Arguments = "-uninstall";
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
