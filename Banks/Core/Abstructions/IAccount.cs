using System;
using System.Collections.Generic;
using System.Text;
using Banks.Core.SystemObjects.Types.BankObjects;

namespace Banks.Core.Abstructions
{
    public interface IAccount
    {
        public void Withdrawal(double _sum);
        public void Replenishment(double _sum);
        public void Transfer(double _sum, IAccount _transferAccount);
        public void DateCheck(DateTime _date);

        public DateTime GetCreationDate();
        public void ChangeBankCondition(BankCondition _bankCondition);
        public void ChangeClientStatus();
        public void ShowValueAmount();
    }
}
