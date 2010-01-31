using System;
using System.Collections.Generic;
using System.Text;

namespace LaunchPad.Service
{
    class CredentialTask : ITask
    {
        public bool RequiresAuthentication { get { return true; } }

        public void Process()
        {
            throw new NotImplementedException();
        }
    }
}
