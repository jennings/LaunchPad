using LaunchPad.Editors;
using Microsoft.Win32;
using System.Collections.Generic;

namespace LaunchPad.Configuration.Configurators
{
    class CredentialsConfigurator : IConfigurator
    {
        public bool RequiresElevation { get { return true; } }
        public bool RequiresAuthentication { get { return true; } }

        private List<Credential> Credentials;
        private Credential AutomaticLogonCredential;

        private CredentialsConfigurator() { }
        public CredentialsConfigurator( string customerBasePassword )
        {
            AutomaticLogonCredential = new Credential() { Username = "pos", Password = "pos" };

            Credentials = new List<Credential>();
            Credentials.Add( AutomaticLogonCredential );
            Credentials.Add( new Credential() { Username = "cbs", Password = GenerateCbsPassword( customerBasePassword ) } );
            Credentials.Add( new Credential() { Username = "acronis", Password = GenerateAcronisPassword( customerBasePassword ) } );
        }

        public void Configure()
        {
            foreach ( var cred in Credentials )
            {
                var foo = WindowsCredential.Select( cred.Username );
                foo.ChangePassword( cred.Password );
            }

            var WinlogonKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";

            Registry.SetValue( WinlogonKey, "DefaultUserName", AutomaticLogonCredential.Username, RegistryValueKind.String );
            Registry.SetValue( WinlogonKey, "DefaultPassword", AutomaticLogonCredential.Password, RegistryValueKind.String );
            Registry.SetValue( WinlogonKey, "AutoAdminLogon", "1", RegistryValueKind.String );
        }

        private string GenerateCbsPassword( string basePassword )
        {
            return basePassword;
        }

        private string GenerateAcronisPassword( string basePassword )
        {
            return basePassword;
        }

        public string GetCurrentCredentials()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }
    }

    class Credential
    {
        public string Username;
        public string Password;
    }
}
