using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Interfaces
{
    internal interface IAcceptMoney
    {
        int AcceptCoins(int money);      
    }
}
