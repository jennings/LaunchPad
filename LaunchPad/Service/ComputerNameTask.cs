using System;
using System.Collections.Generic;
using System.Text;

namespace LaunchPad.Service
{
    class ComputerNameTask : ITask
    {
        public bool RequiresAuthentication { get { return false; } }

        public void Process()
        {
            throw new NotImplementedException();
        }
    }
}
