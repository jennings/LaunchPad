using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace LaunchPad.Editors
{
    class WindowsCredential
    {
        private DirectoryEntry UserEntry;

        private WindowsCredential() { }


        /// <summary>
        /// Selects an existing credential.
        /// </summary>
        /// <param name="username">Username to select.</param>
        /// <returns>Credential with given username.</returns>
        /// <exception cref="CredentialException">Credential does not exist.</exception>
        public static WindowsCredential Select( string username )
        {
            var localDirectory = @"WinNT://" + Environment.MachineName;
            var local = new DirectoryEntry( localDirectory );

            try
            {
                var deUser = local.Children.Find( username, "user" );
                var cred = new WindowsCredential();
                cred.UserEntry = deUser;
                return cred;
            }
            catch ( DirectoryServicesCOMException e )
            {
                if ( e.ErrorCode == 0x2030 )
                {
                    throw new CredentialException( "User '" + username + "' was not found in the local directory ('" + localDirectory + "').", e );
                }
                else
                {
                    throw;
                }
            }
        }


        /// <summary>
        /// Creates a new Windows credential.
        /// </summary>
        /// <param name="username">Username to create.</param>
        /// <param name="password">Password for credential.</param>
        /// <param name="administrator">New user is a local administrator.</param>
        /// <returns>WindowsCredential that was created.</returns>
        /// <exception cref="CredentialException">Username already exists or cannot create new credential.</exception>
        public static WindowsCredential Create( string username, string password, bool administrator )
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Change password of this credential.
        /// </summary>
        /// <param name="newPassword">New password.</param>
        /// <exception cref="CredentialException">Cannot change password.</exception>
        public void ChangePassword( string newPassword )
        {
            UserEntry.Invoke( "SetPassword", new object[] { newPassword } );
            UserEntry.CommitChanges();
        }
    }

    class CredentialException : Exception
    {
        public CredentialException() : base() { }
        public CredentialException( string message ) : base( message ) { }
        public CredentialException( string message, Exception innerException ) : base( message, innerException ) { }
    }
}
