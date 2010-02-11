using LaunchPad.Configuration.Tasks;
using Microsoft.Win32;

namespace LaunchPad.Configuration.Configurators
{
    class AutomaticLogonConfigurator : IConfigurator
    {
        public bool RequiresElevation { get { return true; } }
        public bool RequiresAuthentication { get { return true; } }

        private string Username;
        private string Password;

        private AutomaticLogonConfigurator() { }
        public AutomaticLogonConfigurator( AutomaticLogonTask task )
        {
            Username = task.Username;
            Password = task.Password;
        }

        public void Configure()
        {
            var WinlogonKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon";

            Registry.SetValue( WinlogonKey, "DefaultUserName", Username, RegistryValueKind.String );
            Registry.SetValue( WinlogonKey, "DefaultPassword", Password, RegistryValueKind.String );
            Registry.SetValue( WinlogonKey, "AutoAdminLogon", "1", RegistryValueKind.String );
        }
    }
}
