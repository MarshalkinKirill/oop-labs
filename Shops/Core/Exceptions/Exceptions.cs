using System;
using System.Collections.Generic;
using System.Text;

namespace Shops.Core.Exceptions
{
    public class InsufficientQtyProductErrorException : Exception
    {
        public InsufficientQtyProductErrorException(string msg) : base(msg)
        {
        }
    }

    public class UnknownProductErrorException : Exception
    {
        public UnknownProductErrorException(string msg) : base(msg)
        {
        }
    }

    public class UnknownShopErrorException : Exception
    {
        public UnknownShopErrorException(string msg) : base(msg)
        {
        }
    }

    public class NoShopContainsAProductErrorException : Exception
    {
        public NoShopContainsAProductErrorException(string msg) : base(msg)
        {
        }
    }

    public class InsufficientAmountOfMoneyErrorException : Exception
    {
        public InsufficientAmountOfMoneyErrorException(string msg) : base(msg)
        {
        }
    }

    public class ConditionsOfShoppingListNotSatisfiedErrorException : Exception
    {
        public ConditionsOfShoppingListNotSatisfiedErrorException(string msg) : base(msg)
        {
        }
    }

    public class NoShopSatisfyingShopingListErrorException : Exception
    {
        public NoShopSatisfyingShopingListErrorException(string msg) : base(msg)
        {
        }
    }
}
