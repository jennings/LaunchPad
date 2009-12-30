using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;
using Microsoft.Win32;

namespace TermConfig.Configurators
{
    class CredentialsConfigurator : IConfigurator
    {
        private string newPassword;

        public void Configure()
        {
            SetPosAccountPassword();
        }

        private void SetPosAccountPassword()
        {
            var newPassword = "pos";

            var local = new DirectoryEntry( @"WinNT://" + Environment.MachineName );
            var posUser = local.Children.Find( "pos", "user" );

            posUser.Invoke( "SetPassword", new object[] { newPassword } );
            posUser.CommitChanges();

            posUser.Close();
            local.Close();
        }

        private void SetAutoLogon()
        {
            var WinlogonKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";
            
            Registry.SetValue( WinlogonKey, "DefaultUserName", "pos", RegistryValueKind.String );
            Registry.SetValue( WinlogonKey, "DefaultPassword", newPassword, RegistryValueKind.String );
            Registry.SetValue( WinlogonKey, "AutoAdminLogon", "1", RegistryValueKind.String );
        }
    }
}
