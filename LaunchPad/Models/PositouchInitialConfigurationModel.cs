using System.Net;

namespace LaunchPad.Models
{
    public class PositouchInitialConfigurationModel
    {
        public IPAddress @IPAddress { get; set; }
        public IPAddress PosdriverIPAddress { get; set; }
        public IPAddress BackofficeIPAddress { get; set; }
        public string BasePassword { get; set; }

        public string CbsPassword { get { return BasePassword; } }
        public string AcronisPassword { get { return BasePassword; } }
    }
}
