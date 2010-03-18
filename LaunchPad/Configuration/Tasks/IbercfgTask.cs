using System;

namespace LaunchPad.Configuration.Tasks
{
    [Serializable]
    public class IbercfgTask : ITask
    {
        public int TerminalNumber { get; private set; }
        public int NumberTerminals { get; private set; }
        public string FileserverName { get; private set; }
        public bool MasterCapable { get; private set; }
        public bool ServerCapable { get; private set; }

        private IbercfgTask() { }
        public IbercfgTask( int terminalNumber, int countTerminals, string fileserverName, bool masterCapable, bool serverCapable )
        {
            TerminalNumber = terminalNumber;
            NumberTerminals = countTerminals;
            FileserverName = fileserverName;
            MasterCapable = masterCapable;
            ServerCapable = serverCapable;
        }
    }
}
