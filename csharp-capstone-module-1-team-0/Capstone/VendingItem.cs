using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public abstract class VendingItem
    {

        public VendingItem(string itemName, decimal itemPrice, int itemsRemaining, string vendingMessage)
        {
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemsRemaining = itemsRemaining;
            VendingMessage = vendingMessage;
            

        }

        // name of the VendingItem
        public string ItemName { get; set; }


        // price of VendingItem
        public decimal ItemPrice { get; set; }

        
        public int ItemsRemaining { get; set; }


        public string VendingMessage { get; set; }


    }
}
