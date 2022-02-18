using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.Core.Enums
{
    public enum Status
    {
        Suspended, Active
    }

    public enum AccountStatus
    {
        Active, Blocked
    }

    public enum TransactionType
    {
        Withdrawal, Replenishment, Transfer
    }

    public enum TransactionMode
    {
        Active, Delete
    }
}
