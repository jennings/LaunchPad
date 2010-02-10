using System;
using System.Collections.Generic;
using System.Text;

namespace LaunchPad.Configuration.Dispatch
{
    /// <summary>
    /// A dispatcher is responsible for actually commanding
    /// each configurator to do its work.
    /// </summary>
    interface IConfiguratorDispatcher
    {
        void Dispatch();
    }
}
