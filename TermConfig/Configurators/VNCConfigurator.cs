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
            throw new NotImplementedException();
        }
    }
}
