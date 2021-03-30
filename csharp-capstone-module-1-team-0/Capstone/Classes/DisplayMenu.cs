using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class DisplayMenu
    {

        private const string FEEDMONEY = "1";

        public void Display()
        {


            Money moneyInMachine = new Money();
            VendingMachine vendingMachine = new VendingMachine();
            Money.Balance = moneyInMachine.MoneyInitial;


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Welcome to the Virtual Vending Machine!");
                Console.WriteLine();
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase Item");
                Console.WriteLine("(3) Exit");

                string userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    
                    vendingMachine.DisplayAllItems();
                    Console.WriteLine();
                    Console.WriteLine("Please press ENTER to go back to the MAIN MENU.");

                }
                else if (userInput == "2")
                {
                    Console.WriteLine("(1) Feed Money");
                    Console.WriteLine("(2) Select Product");
                    Console.WriteLine("(3) Finish Transaction");
                    Console.WriteLine($"Current Money Provided: {Money.Balance:C2}");



                    string userInput2 = Console.ReadLine();
                    if (userInput2 == FEEDMONEY)
                    {
                        Console.WriteLine("How much money in dollars do you want to insert?");
                        while (true)
                        {
                            // current money provided indicates how much money the customer has fed into the machine
                            Console.WriteLine("$1, $2, $5, or $10 dollars?");
                            decimal amountInserted = decimal.Parse(Console.ReadLine()); // need a try catch 
                            if (amountInserted == 1.0M || amountInserted == 2.0M || amountInserted == 5.0M || amountInserted == 10.0M)
                            {
                                // get the amount of money input
                                Console.WriteLine($"You have {moneyInMachine.AddMoney(amountInserted):C2} to spend.");
                                Log.LogFeedMoney(Money.Balance, amountInserted);
                                Console.WriteLine();
                                Console.WriteLine("Please press ENTER to continue with your purchase.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("INVALID AMOUNT");
                            }

                        }
                    }
                    else if (userInput2 == "2")
                    {
                        while (true)
                        {

                            Console.WriteLine();
                            Console.WriteLine("Which item would you like to purchase?");
                            Console.WriteLine();
                            // display all items
                            
                            vendingMachine.DisplayAllItems();

                            string itemChosen = Console.ReadLine();
                            // if item exists and itemPrice < MoneyInitial, able to give it
                            if (vendingMachine.ItemExists(itemChosen) && vendingMachine.VendingItems[itemChosen].ItemsRemaining > 0 && vendingMachine.VendingItems[itemChosen].ItemPrice < Money.Balance) 
                            {
                                Console.WriteLine($"Yay! You selected {itemChosen}!");
                                Console.Beep(588, 200);
                                Console.WriteLine("Beep...");
                                Console.WriteLine();
                                Console.Beep(440, 200);
                                Console.WriteLine("...Boop...");
                                Console.WriteLine();
                                Console.Beep(370, 200);
                                Console.WriteLine("......Beep...");
                                Console.WriteLine();
                                Console.Beep(294, 200);
                                Console.WriteLine(".........Boop...");
                                Console.WriteLine();
                                Console.WriteLine($"............... You got a {vendingMachine.VendingItems[itemChosen].ItemName}!");
                                Console.WriteLine("Enjoy!!!");
                                Console.WriteLine($"{vendingMachine.VendingItems[itemChosen].VendingMessage}");


                                Log.LogItem(vendingMachine.VendingItems[itemChosen].ItemName, itemChosen, Money.Balance, Money.Balance -= vendingMachine.VendingItems[itemChosen].ItemPrice);
                                //Money.Balance = Money.Balance - vendingMachine.VendingItems[itemChosen].ItemPrice;
                                vendingMachine.VendingItems[itemChosen].ItemsRemaining--;

                                break;
 
                            }
                            // else if !item exists Console.Writeline("Item does not exist.") and return to purchase menu
                            else if (!vendingMachine.ItemExists(itemChosen))
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("Whoops! The item does not exist!");
                                Console.WriteLine("GAME OVER!");
                                Console.WriteLine("Please try again!");
                                Console.WriteLine();
                                Console.WriteLine($"Your remaining balance is {Money.Balance:C2}");

                            }
                            // else if !item sold out Console.Writeline("Item is SOLD OUT." and return to purchase menu.
                            // ItemsRemaining <= 0;
                            else if (vendingMachine.ItemExists(itemChosen) && vendingMachine.VendingItems[itemChosen].ItemsRemaining < 1 && vendingMachine.VendingItems[itemChosen].ItemPrice < Money.Balance)// see if money works
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine($"Again... {itemChosen} is SOLD OUT! Sorry boo thang!");
                                Console.WriteLine();
                                Console.WriteLine($"Your remaining balance is {Money.Balance:C2}");

                            }
                            else if (vendingMachine.ItemExists(itemChosen) && vendingMachine.VendingItems[itemChosen].ItemPrice > Money.Balance)
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("Insufficient Funds... Please select another item.");
                                Console.WriteLine();
                                Console.WriteLine($"Your remaining balance is {Money.Balance:C2}");
                                break;
                            }
                           
                        }
                    }
                    else if (userInput2 == "3")
                    {
                        Console.WriteLine("Finishing Transaction");
                        //give back change here in nickels, dimes, quarters (decimal)
                        // update the machine's balance to 0 remaining
                        Log.LogGiveChange(Money.Balance, 0M);
                        Money.ChangeGiven();
                        Console.WriteLine();
                        Console.WriteLine($"Your remaining balance is {Money.Balance:C2}");
                        
                    }

                }
                else if (userInput == "3")
                {
                    Console.WriteLine("Please come again soon! Have a nice day!");
                    break;
                 
                }

                Console.ReadLine();
                Console.Clear();

            }


        }


    }
}
