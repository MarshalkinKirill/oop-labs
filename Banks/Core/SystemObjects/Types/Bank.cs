using System;
using System.Collections.Generic;
using System.Text;
using Banks.Core.SystemObjects.Types.BankObjects;
using Banks.Core.Abstructions;
using Banks.Core.SystemObjects.Types.BankObjects.Accounts;
using Banks.Core.SystemObjects.Types.BankObjects.Accounts.AccountObjects;
using Banks.Core.Enums;

namespace Banks.Core.SystemObjects.Types
{
    public class Bank
    {
        private readonly string Name;
        private BankCondition BankCondition;
        private List<IClient> clients { get; }
        public List<IClient> Clients { get { return clients; } }
        private int accountIdCounter = 1;

        public Bank(string _name, BankCondition _bankCondition)
        {
            Name = _name;

            BankCondition = _bankCondition;
            clients = new List<IClient>();
        }

        public void AddClient(IClient _client)
        {
            clients.Add(_client);
        }

        public void AddClientInfo(Client _client,string _address, string _passportId)
        {
            if (_client.Status == Status.Active)
            {
                Console.WriteLine("Client already have all information");
            }
            else
            {
                _client.AddAddress(_address);
                _client.AddPassportId(_passportId);
                _client.StatusCheck();
                _client.ChangeAccountsStatus();
            }
        }

        public IAccount AddDepositAccount(Client _client, double _sum, DateTime _contractEndTime)
        {
            IAccount account = new Deposit(accountIdCounter, BankCondition, _client.Status, _contractEndTime, _sum);
            _client.AddAccount(account);
            accountIdCounter++;
            return account;
        }

        public IAccount AddCreditAccount(Client _client, double _sum)
        {
            IAccount account = new Credit(accountIdCounter, BankCondition, _client.Status, _sum);
            _client.AddAccount(account);
            accountIdCounter++;
            return account;
        }

        public IAccount AddDebitAccount(Client _client, double _sum)
        {
            IAccount account = new Debit(accountIdCounter, BankCondition, _client.Status, _sum);
            _client.AddAccount(account);
            accountIdCounter++;
            return account;
        }

        public void CancelTransaction(Transaction _transaction)
        {
            if (_transaction.Mode == TransactionMode.Delete)
            {
                Console.WriteLine("This transaction has already been deleted");
            }
            else
            if (_transaction.Type == TransactionType.Transfer)
            {
                _transaction.Account.Replenishment(_transaction.Value);
                _transaction.Account.Withdrawal(_transaction.Value);
                _transaction.ChangeMode();
            }
            else
            if (_transaction.Type == TransactionType.Withdrawal)
            {
                _transaction.Account.Replenishment(_transaction.Value);
                _transaction.ChangeMode();
            }
            else
            {
                _transaction.Account.Withdrawal(_transaction.Value);
                _transaction.ChangeMode();
            }
        }

        public void GetAccountUpDateNotify(IAccount _account)
        {
            _account.DateCheck(DateTime.Now.AddMonths(1));
        }

        public void ChangeBankCondition(BankCondition _bankCondition)
        {
            BankCondition = _bankCondition;
            foreach (Client _client in clients)
            {
                foreach (IAccount _account in _client.Accounts)
                {
                    _account.ChangeBankCondition(_bankCondition);
                }
                if (_client.Notifications != null)
                {
                    foreach (INotify _notification in _client.Notifications)
                    {
                        _notification.SendNotify();
                    }
                }
            }
        }

        public void NotifySubscribe(Client _client, INotify _notify)
        {
            _client.AddNotify(_notify);
        }
    }
}
