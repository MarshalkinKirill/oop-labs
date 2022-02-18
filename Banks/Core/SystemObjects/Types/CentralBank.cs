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
    public class CentralBank
    {
        private List<Bank> Banks { get; }

        public CentralBank()
        {
            Banks = new List<Bank>();
        }

        public void CreateBank(string _name, BankCondition _bankCondition)
        {
            Banks.Add(new Bank(_name, _bankCondition));
        }

        public void AddBankClient(Bank _bank, Client _client)
        {
            _bank.AddClient(_client);
        }

        public void InterbankTransaction(IAccount account_1, double sum, Bank _bank, IAccount account_2)
        {
            if (!Banks.Contains(_bank))
            {
                Console.WriteLine("Bank doesnt registr at Centralbank");
            }
            foreach (Client _client in _bank.Clients)
            {
                foreach (IAccount _account in _client.Accounts)
                {
                    if (_account == account_2)
                    {
                        account_1.Transfer(sum, _account);
                    }
                }
            }
        }

        public void AccountDataCheck()
        {
            foreach (Bank _bank in Banks)
            {
                foreach (Client _client in _bank.Clients)
                {
                    foreach (IAccount _account in _client.Accounts)
                    {
                        double months = (_account.GetCreationDate() - DateTime.Now).TotalDays / 30;
                        for (int i = 0; i < months; i++)
                        {
                            _bank.GetAccountUpDateNotify(_account);
                        }
                    }
                }
            }
        }

        public List<Bank> GetBanksList()
        {
            return Banks;
        }
    }
}
