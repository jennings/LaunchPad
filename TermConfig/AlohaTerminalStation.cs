using System;
using System.Collections.Generic;
using System.Text;

namespace TermConfig
{
    class AlohaTerminalStation : ITerminalStation
    {

        #region ITerminalStation Members

        public PointOfSale PointOfSale
        {
            get { return PointOfSale.Aloha; }
        }

        public string Username
        {
            get { throw new NotImplementedException(); }
        }

        public string Password
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.Net.IPAddress IPAddress
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ComputerName
        {
            get { throw new NotImplementedException(); }
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
