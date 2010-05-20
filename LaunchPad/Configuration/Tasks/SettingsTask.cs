using System;
using LaunchPad.Settings;

namespace LaunchPad.Configuration.Tasks
{
    [Serializable]
    public class SettingsTask : ITask
    {
        public SettingsReader @SettingsReader { get; private set; }

        private SettingsTask() { }
        public SettingsTask( SettingsReader settingsReader )
        {
            @SettingsReader = settingsReader;
        }
    }
}
