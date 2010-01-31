using System;
using System.Collections.Generic;
using System.Text;

namespace LaunchPad.Service
{
    interface ITask
    {
        bool RequiresAuthentication { get; }

        void Process();
    }
}
