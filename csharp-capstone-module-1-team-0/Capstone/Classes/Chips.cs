using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Chips : VendingItem
    {

        public Chips(string itemName, decimal itemPrice, int itemsRemaining) : base(itemName, itemPrice, itemsRemaining, Message)
        {


        }

        public const string Message = "Crunch, Crunch, Yum!";


    }
}
