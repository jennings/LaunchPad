using System;

namespace LaunchPad.Configuration.Configurators
{
    interface IConfigurator
    {
        bool RequiresElevation { get; }
        bool RequiresAuthentication { get; }
        void Configure();
    }
}
