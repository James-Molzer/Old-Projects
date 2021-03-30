using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Candy : VendingItem
    {

        public Candy(string itemName, decimal itemPrice, int itemsRemaining) : base(itemName, itemPrice, itemsRemaining, Message)
        {


        }

        public const string Message = "Munch, Munch, Yum!";


    }
}

