using System;
using System.Collections.Generic;
using System.Text;
using Banks.Core.Abstructions;
using Banks.Core.Enums;

namespace Banks.Core.SystemObjects.Types.BankObjects.Accounts.AccountObjects
{
    public class Transaction
    {
        private int id;
        private double value { get; }
        public double Value { get { return value; } }
        private IAccount transferAccount { get; }
        public IAccount TransferAccount { get { return transferAccount; } }
        private TransactionType type { get; }
        public TransactionType Type { get { return type; } }
        private IAccount account { get; }
        public IAccount Account { get { return account; } }
        private TransactionMode mode { get; set; }
        public TransactionMode Mode { get { return mode; } }

        public Transaction (double _value, IAccount _account, TransactionType _transactionType)
        {
            id = GetHashCode();
            value = _value;
            type = _transactionType;
            account = _account;
            mode = TransactionMode.Active;
        }

        public Transaction (double _value, IAccount _account, TransactionType _transactionType, IAccount _transferAccount)
        {
            id = GetHashCode();
            value = _value;
            transferAccount = _transferAccount;
            type = _transactionType;
            account = _account;
            mode = TransactionMode.Active;
        }
        
        public void ChangeMode()
        {
            mode = TransactionMode.Delete;
        }
    }
}
