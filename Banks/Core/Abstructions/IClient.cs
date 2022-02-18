using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.Core.Abstructions
{
    public interface IClient
    {
        public void AddAddress(string address);
        public void AddPassportId(string pasportId);
        public void StatusCheck();
        public void GetNotify();
        public void AddNotify(INotify notify);
        public void AddAccount(IAccount _account);
    }
}
