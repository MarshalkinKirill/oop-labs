using System;
using System.Collections.Generic;
using System.Text;

namespace Banks.Core.SystemObjects.Types.BankObjects
{
    public class BankCondition
    {
        private double debitPersent { get; }
        public double DebitPersent { get { return debitPersent; } }
        private double creditCommision { get; }
        public double CreditCommision { get { return creditCommision; } }
        private double creditLimit { get; }
        public double CreditLimit { get { return creditLimit; } }
        private Dictionary<double, double> depositPersents { get; }
        public Dictionary<double, double> DepositPersents { get { return depositPersents; } }
        private double suspendedAccountLimit { get; }
        public double SuspendedAccountLimit { get { return suspendedAccountLimit;} }

        public BankCondition(double _debitPersent, double _creditCommision, double _creditLimit, double _suspendedAccountLimit, Dictionary<double, double> _depositPersents)
        {
            debitPersent = _debitPersent;
            creditCommision = _creditCommision;
            creditLimit = _creditLimit;
            suspendedAccountLimit = _suspendedAccountLimit;
            depositPersents = _depositPersents;
        }
    }
}