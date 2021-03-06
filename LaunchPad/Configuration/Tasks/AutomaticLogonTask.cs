﻿using System;

namespace LaunchPad.Configuration.Tasks
{
    [Serializable]
    public class AutomaticLogonTask : ITask
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        private AutomaticLogonTask() { }
        public AutomaticLogonTask( string username, string password )
        {
            Username = username;
            Password = password;
        }
    }
}
