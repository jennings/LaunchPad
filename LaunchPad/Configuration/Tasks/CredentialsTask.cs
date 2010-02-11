
namespace LaunchPad.Configuration.Tasks
{
    public class CredentialsTask : ITask
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        private CredentialsTask() { }
        public CredentialsTask( string username, string password )
        {
            Username = username;
            Password = password;
        }
    }
}
