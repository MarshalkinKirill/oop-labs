using System;
using System.Collections.Generic;
using System.Text;
using Banks.Core.Abstructions;
using Banks.Core.Enums;
using Banks.Core.SystemObjects.Types.BankObjects.Accounts.AccountObjects;
using System.Linq;

namespace Banks.Core.SystemObjects.Types.BankObjects.Accounts
{
    public class Deposit : IAccount
    {
        private int id;
        private AccountStatus status;
        private double accountValue;
        private DateTime createDate { get; }
        public DateTime CreateDate { get { return createDate; } }
        private BankCondition bankCondition;
        private Status clientStatus;
        private List<Transaction> transactions { get; }
        public List<Transaction> Transactions { get { return transactions; } }
        private DateTime contractEnd;
        private double depositPersent;

        public Deposit(int _id, BankCondition _bankCondition, Status _clientStatus, DateTime _contractEnd)
        {
            id = _id;
            status = AccountStatus.Active;
            createDate = DateTime.Now;
            bankCondition = _bankCondition;
            clientStatus = _clientStatus;
            transactions = new List<Transaction>();
            contractEnd = _contractEnd;
            depositPersent = bankCondition.DepositPersents.ToList()[0].Value;
        }

        public Deposit(int _id, BankCondition _bankCondition, Status _clientStatus, DateTime _contractEnd, double _accountValue)
        {
            id = _id;
            status = AccountStatus.Active;
            accountValue = _accountValue;
            createDate = DateTime.Now;
            bankCondition = _bankCondition;
            clientStatus = _clientStatus;
            transactions = new List<Transaction>();
            contractEnd = _contractEnd;
            foreach (KeyValuePair<double, double> pair in bankCondition.DepositPersents)
            {
                if (_accountValue > pair.Key)
                {
                    depositPersent = pair.Value;
                }
            }
        }

        public void ChangeClientStatus()
        {
            if (clientStatus == Status.Suspended)
                clientStatus = Status.Active;
            else
                clientStatus = Status.Suspended;
        }

        public void ChangeAccountStatus()
        {
            if (status == AccountStatus.Blocked)
                status = AccountStatus.Active;
            else
                status = AccountStatus.Blocked;
        }

        public void Withdrawal(double _sum)
        {
            if (DateTime.Now < contractEnd)
            {
                Console.WriteLine("Time of the end of account contract doesnt come yet");
            } 
            else
            if (clientStatus == Status.Suspended && bankCondition.SuspendedAccountLimit < _sum)
            {
                Console.WriteLine("Client account have no full info to withdrawal this ammount");
            }
            else
            {
                accountValue -= _sum;
                transactions.Add(new Transaction(_sum, this, TransactionType.Withdrawal));
            }
        }

        public void Replenishment(double _sum)
        {
            accountValue += _sum;
            transactions.Add(new Transaction(_sum, this,  TransactionType.Replenishment));
        }

        public void Transfer(double _sum, IAccount _transferAccount)
        {
            if (DateTime.Now < contractEnd)
            {
                Console.WriteLine("Time of the end of account contract doesnt come yet");
            }
            else
            if (clientStatus == Status.Suspended && bankCondition.SuspendedAccountLimit < _sum)
            {
                Console.WriteLine("Client account have no full info to transfer this ammount");
            }
            else
            {
                accountValue -= _sum;
                _transferAccount.Replenishment(_sum);
                transactions.Add(new Transaction(_sum, this, TransactionType.Transfer, _transferAccount));
            }
        }

        public void DateCheck(DateTime _time)
        {
            double months = (createDate - _time).TotalDays / 30;
            if (months > 1)
            {
                for (int i = 0; i < months; i++)
                {
                    accountValue += accountValue * depositPersent;
                }
            }
        }

        public DateTime GetCreationDate()
        {
            return createDate;
        }

        public void ChangeBankCondition(BankCondition _bankCondition)
        {
            bankCondition = _bankCondition;
        }

        public void ShowValueAmount()
        {
            Console.WriteLine(this.accountValue);
        }
    }
}
