using System;
using System.Collections.Generic;
using System.Text;
using Banks.Core.Abstructions;

namespace Banks.Core.SystemObjects.Types.Notifications
{
    public class EmailNotify : INotify
    {
        private string _email;

        public EmailNotify(string email)
        {
            _email = email;
        }

        public void SendNotify()
        {
            //some logic that doesnt need to be implemend;
        }
    }
}
