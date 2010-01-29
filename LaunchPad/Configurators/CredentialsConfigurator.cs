using LaunchPad.Editors;
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
            var cred = WindowsCredential.Select( Username );
            cred.ChangePassword( NewPassword );

            var WinlogonKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";
            Registry.SetValue( WinlogonKey, "DefaultUserName", "pos", RegistryValueKind.String );
            Registry.SetValue( WinlogonKey, "DefaultPassword", NewPassword, RegistryValueKind.String );
            Registry.SetValue( WinlogonKey, "AutoAdminLogon", "1", RegistryValueKind.String );
        }
    }
}
