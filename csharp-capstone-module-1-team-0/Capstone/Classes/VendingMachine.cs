using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {

        public Dictionary<string, VendingItem> VendingItems = new Dictionary<string, VendingItem>(); // want to protect it so use private

        ImportingCSV LetsGetCSV = new ImportingCSV();


        public VendingMachine()
        {
            // takes in dictionary from CSV and assigns to the current dictionary VendingItems
            VendingItems = LetsGetCSV.ImportingVendingItems();
        }
 

        public void DisplayAllItems()
        {
            Console.WriteLine("Below is the list of items in the Virtual Vending Machine!");
            foreach (KeyValuePair<string, VendingItem> kvp in VendingItems)
            {

                string itemCode = kvp.Key;
                int itemsRemaining = kvp.Value.ItemsRemaining; // should equal 5, set in ImportingVendingItems();
                string itemName = kvp.Value.ItemName;
                decimal itemPrice = kvp.Value.ItemPrice;

                if (itemsRemaining > 0)
                {
                    Console.WriteLine($"{itemCode} | {itemName} Costs: {itemPrice:C2} each, Stock Left: {itemsRemaining}"); // can do .padright
                }
                else
                {
                    Console.WriteLine($"{itemCode} | {itemName} is SOLD OUT.");
                }
            }
        }


        public bool ItemExists(string itemCode)
        {
            return VendingItems.ContainsKey(itemCode);
        }


    }
}
