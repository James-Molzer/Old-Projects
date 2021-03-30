using System;
using System.Collections.Generic;
using System.Text;


namespace Capstone.Classes
{
    public class Gum : VendingItem
    {


        public Gum(string itemName, decimal itemPrice, int itemsRemaining) : base(itemName, itemPrice, itemsRemaining, Message)
        {


        }

        public const string Message = "Chew, Chew, Yum!";


    }

}

