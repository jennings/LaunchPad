using LaunchPad.Editors;
using Microsoft.Win32;

namespace LaunchPad.Configuration.Configurators
{
    class CredentialsConfigurator : IConfigurator
    {
        public bool RequiresElevation { get { return true; } }
        public bool RequiresAuthentication { get { return true; } }

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
