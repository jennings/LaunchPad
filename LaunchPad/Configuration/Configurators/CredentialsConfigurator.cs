using Microsoft.Win32;
using System.Collections.Generic;
using System.DirectoryServices;
using System;

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
                ChangePassword( cred.Username, cred.Password );
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

        private void ChangePassword( string username, string password )
        {
            var localDirectory = @"WinNT://" + Environment.MachineName;
            var local = new DirectoryEntry( localDirectory );

            try
            {
                var deUser = local.Children.Find( username, "user" );
                deUser.Invoke( "SetPassword", new object[] { password } );
                deUser.CommitChanges();
            }
            catch ( DirectoryServicesCOMException e )
            {
                if ( e.ErrorCode == 0x2030 )
                {
                    throw new Exception( "User '" + username + "' was not found in the local directory ('" + localDirectory + "').", e );
                }
                else
                {
                    throw;
                }
            }
        }
    }

    class Credential
    {
        public string Username;
        public string Password;
    }
}
