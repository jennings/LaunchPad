using LaunchPad.Editors;

namespace LaunchPad.Configuration.Configurators
{
    class NetworkConfigurator : IConfigurator
    {
        public bool RequiresElevation { get { return true; } }
        public bool RequiresAuthentication { get { return false; } }

        ITerminalStation StationSettings;

        private NetworkConfigurator() { }
        public NetworkConfigurator( ITerminalStation settings )
        {
            StationSettings = settings;
        }


        public void Configure()
        {
            //WindowsNetwork.SetNetBIOSName( StationSettings.ComputerName );
            //WindowsNetwork.SetIPAddress( StationSettings.IPAddress );
            RecordSettings();
        }


        private void RecordSettings()
        {
            var settings = SettingsReader.Instance;
            settings.ComputerName = StationSettings.ComputerName;
            settings.IPAddress = StationSettings.IPAddress;

            if ( settings.PointOfSale == PointOfSale.Positouch )
            {
                var source = (PositouchTerminalStation)StationSettings;
                if ( source.PosdriverIPAddress != null )
                {
                    settings.PosdriverIPAddress = source.PosdriverIPAddress;
                }
                if ( source.BackofficeIPAddress != null )
                {
                    settings.BackofficeIPAddress = source.BackofficeIPAddress;
                }
                if ( source.RedundantIPAddress != null )
                {
                    settings.RedundantIPAddress = source.RedundantIPAddress;
                }
            }
        }
    }
}
