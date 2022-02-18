using System;
using System.Collections.Generic;
using System.Text;
using Banks.Core.Abstructions;
using Banks.Core.Enums;
using Banks.Core.SystemObjects.Types.BankObjects.Accounts.AccountObjects;

namespace Banks.Core.SystemObjects.Types.BankObjects
{
    public class Client : IClient 
    {
        //personal data
        private readonly string name;
        private readonly string surName;
        private string address;
        private string passportId;
        //bank used data
        private List<INotify> notifications { get; }
        public List<INotify> Notifications { get { return notifications; } }
        private Status status { get; set; }
        public Status Status { get { return status; } }
        private List<IAccount> accounts { get; }
        public List<IAccount> Accounts { get { return accounts; } }

        public Client (string _name, string _surName)
        {
            name = _name;
            surName = _surName;
            status = Status.Suspended;
            accounts = new List<IAccount>();
        }

        public Client (string _name, string _surName, string _address, string _pasportId)
        {
            name = _name;
            surName = _surName;
            address = _address;
            passportId = _pasportId;
            status = Status.Active;
            accounts = new List<IAccount>();
        }

        public void AddAddress(string _address)
        {
            address = _address;
        }

        public void AddPassportId(string _passportId)
        {
            passportId = _passportId;
        }

        public void StatusCheck()
        {
            if (address != null && passportId != null)
                status = Status.Active;
            else
                status = Status.Suspended;
        }

        public void ChangeAccountsStatus()
        {
            foreach (IAccount _account in accounts)
            {
                _account.ChangeClientStatus();
            }
        }

        public void AddAccount(IAccount _account)
        {
            accounts.Add(_account);
        }

        public void AddNotify(INotify notify)
        {
            notifications.Add(notify);
        }
        public void GetNotify()
        {
            foreach (INotify notify in notifications)
            {
                notify.SendNotify();
            }
        }

    }
}
