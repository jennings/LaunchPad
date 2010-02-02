using System;
using System.Collections.Generic;
using System.Text;

namespace LaunchPad.Configuration
{
    /// <summary>
    /// A controller is responsible for initializing a local dispatcher
    /// and a remote dispatcher.
    /// </summary>
    interface IConfiguratorController
    {
        bool RequiresAuthentication { get; }
        void Configure();
    }
}
