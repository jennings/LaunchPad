using System;
using System.Collections.Generic;
using System.Text;

namespace LaunchPad.Configuration
{
    interface IConfiguratorController
    {
        bool RequiresAuthentication { get; }
        void Configure();
    }
}
