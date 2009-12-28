using System;

namespace TermConfig.Configurators
{
    class VNCConfigurator : IConfigurator
    {
        TerminalStation StationSettings;


        public VNCConfigurator( TerminalStation settings )
        {
            settings.Validate();
            StationSettings = settings;
        }


        public void Configure()
        {
            // Stop VNC

            // Delete C:\Program Files\UltraVNC2

            // Rename C:\Program Files\UltraVNC to UltraVNC2

            // Copy good data into C:\Program Files\UltraVNC

            // Change password in ultravnc.ini
        }
    }
}
