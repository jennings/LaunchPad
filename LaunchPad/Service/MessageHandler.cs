using System;
using System.Collections.Generic;
using System.Text;

namespace LaunchPad.Service
{
    class MessageHandler
    {
        public bool RequiresAuthentication { get; private set; }
        public string Challenge { get; private set; }

        private List<ITask> TaskList;

        private MessageHandler() { }

        public MessageHandler( List<ITask> tasklist )
        {
            if ( tasklist.Count == 0 )
            {
                throw new Exception( "Task list is empty." );
            }

            TaskList = tasklist;
            RequiresAuthentication = false;

            foreach ( var task in TaskList )
            {
                if ( task.RequiresAuthentication )
                {
                    RequiresAuthentication = true;
                    break;
                }
            }
        }

        public void Process()
        {
            if ( RequiresAuthentication )
            {
                throw new Exception( "At least one task requires authorization." );
            }

            ProcessTasks();
        }

        public void Process( string response )
        {
            if ( !ValidateResponse( Challenge, response ) )
            {
                throw new Exception( "Challenge validation failed!" );
            }

            ProcessTasks();
        }

        private void ProcessTasks()
        {
            foreach ( var task in TaskList )
            {
                task.Process();
            }
        }

        private bool ValidateResponse( string challenge, string response )
        {
            // TODO
            return false;
        }
    }
}
