using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Beverages : VendingItem
    {

        public Beverages(string itemName, decimal itemPrice, int itemsRemaining) : base(itemName, itemPrice, itemsRemaining, Message)
        {


        }

        public const string Message = "Glug, Glug, Yum!";


    }

}

