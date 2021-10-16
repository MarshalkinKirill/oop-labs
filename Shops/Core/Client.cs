using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shops.Core
{
    public class Client
    {
        public int money;
        public readonly string name;

        public Client(string _name, int _money)
        {
            money = _money;
            name = _name;
        }
    }
}