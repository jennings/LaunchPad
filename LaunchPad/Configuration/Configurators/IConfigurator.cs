using System;

namespace LaunchPad.Configuration.Configurators
{
    interface IConfigurator
    {
        bool RequiresElevation { get; }
        bool RequiresAuthorization { get; }
        void Configure();
    }
}
