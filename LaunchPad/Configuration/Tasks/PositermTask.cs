﻿using System;

namespace LaunchPad.Configuration.Tasks
{
    public class PositermTask : ITask
    {
        public string ComputerName { get; private set; }

        private PositermTask() { }
        public PositermTask( string computername )
        {
            ComputerName = computername;
        }
    }
}
