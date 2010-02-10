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

        private string Username;
        private string Password;

        private CredentialsConfigurator() { }
        public CredentialsConfigurator( string username, string password )
        {
            Username = username;
            Password = password;
        }

        public void Configure()
        {
            var localDirectory = @"WinNT://" + Environment.MachineName;
            var local = new DirectoryEntry( localDirectory );

            try
            {
                var deUser = local.Children.Find( Username, "user" );
                deUser.Invoke( "SetPassword", new object[] { Password } );
                deUser.CommitChanges();
            }
            catch ( DirectoryServicesCOMException e )
            {
                if ( e.ErrorCode == 0x2030 )
                {
                    throw new Exception( "User '" + Username + "' was not found in the local directory ('" + localDirectory + "').", e );
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
