using System;
using System.Collections.Generic;
using System.Text;

namespace LaunchPad
{
    class AlohaTerminalStation : ITerminalStation
    {

        #region ITerminalStation Members

        public PointOfSaleType PointOfSale
        {
            get { return PointOfSaleType.Aloha; }
        }

        public string WindowsUsername
        {
            get { throw new NotImplementedException(); }
        }

        public string WindowsPassword
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

        public void ValidateInitial()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
