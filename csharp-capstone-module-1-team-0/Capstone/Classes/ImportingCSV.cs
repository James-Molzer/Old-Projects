using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class ImportingCSV 
    {

        // string is going to equal the itemCode
        // VendingItem will equal all the other values

        public Dictionary<string, VendingItem> ImportingVendingItems()
        {

            Dictionary<string, VendingItem> vendingItems = new Dictionary<string, VendingItem>();

            string directory = @"..\..\..\..";
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, fileName);


            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] itemSection = line.Split("|");
                        string itemName = itemSection[1];
                        decimal itemPrice = decimal.Parse(itemSection[2]);
                        int itemsRemaining = 5;

                        VendingItem itemType; // call new variable itemType

                        switch (itemSection[3]) // switch out type with all the values
                        {
                            case "Beverages":
                                itemType = new Beverages(itemName, itemPrice, itemsRemaining);
                                break;
                            case "Candy":
                                itemType = new Candy(itemName, itemPrice, itemsRemaining);
                                break;
                            case "Chips":
                                itemType = new Chips(itemName, itemPrice, itemsRemaining);
                                break;
                            case "Gum":
                                itemType = new Gum(itemName, itemPrice, itemsRemaining);
                                break;
                            default: // don't forget this
                                itemType = new Gum(itemName, itemPrice, itemsRemaining);
                                break;
                        }

                        vendingItems.Add(itemSection[0], value: itemType);
                       
                    }
                }
            }
            catch
            {
                Console.WriteLine("Can't import CSV.");
            }

            return vendingItems; // updated dictionary
        }

    }
}
