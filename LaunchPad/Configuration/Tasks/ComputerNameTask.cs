using System;

namespace LaunchPad.Configuration.Tasks
{
    [Serializable]
    public class ComputerNameTask : ITask
    {
        public string ComputerName { get; private set; }

        private ComputerNameTask() { }
        public ComputerNameTask( string computername )
        {
            ComputerName = computername;
        }
    }
}
