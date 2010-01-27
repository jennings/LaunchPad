using System;
using System.DirectoryServices;
using Microsoft.Win32;

namespace LaunchPad.Configurators
{
    class CredentialsConfigurator : IConfigurator
    {
        private string Username;
        private string NewPassword;

        private CredentialsConfigurator() { }
        public CredentialsConfigurator( string username, string password )
        {
            Username = username;
            NewPassword = password;
        }

        public void Configure()
        {
            SetPosAccountPassword();
            SetAutoLogon();
        }

        private void SetPosAccountPassword()
        {
            var local = new DirectoryEntry( @"WinNT://" + Environment.MachineName );
            var posUser = local.Children.Find( Username, "user" );

            posUser.Invoke( "SetPassword", new object[] { NewPassword } );
            posUser.CommitChanges();

            posUser.Close();
            local.Close();
        }

        private void SetAutoLogon()
        {
            var WinlogonKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";

            Registry.SetValue( WinlogonKey, "DefaultUserName", "pos", RegistryValueKind.String );
            Registry.SetValue( WinlogonKey, "DefaultPassword", NewPassword, RegistryValueKind.String );
            Registry.SetValue( WinlogonKey, "AutoAdminLogon", "1", RegistryValueKind.String );
        }
    }
}
