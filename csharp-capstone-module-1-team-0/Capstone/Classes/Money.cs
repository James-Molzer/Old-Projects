using System;
using System.Collections.Generic;
using System.Text;


namespace Capstone.Classes
{
    public class Money
    {


        public Money()
        {
            MoneyInitial = 0M;

        }

        // setting initial money
        public decimal MoneyInitial { get; private set; }

        public static decimal Balance = 0.0M;


        public decimal AddMoney(decimal amountInserted)
        {
            
            Balance += amountInserted;
            return Balance;
        }

        public static decimal MachineTookMoney(decimal amountTaken) // static: only accessed through static method of parent class
        {
            if (Balance >= amountTaken)
            {
                Balance -= amountTaken;
            }
            return Balance;
        }

        // make sure the amount taken is positive

        public static void ChangeGiven()
        {
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            while (Balance > 0M)
            {
                if (Balance >= 0.25M)
                {
                    MachineTookMoney(0.25M);
                    quarters++;
                    
                }
                else if (Balance >= 0.10M)
                {
                    MachineTookMoney(0.10M);
                    dimes++;
                    
                }
                else if (Balance >= 0.05M)
                {
                    MachineTookMoney(0.05M);
                    nickels++;
                   
                }
                
            }
            Console.Write($"Quarters: {quarters}, Dimes: {dimes}, Nickels: {nickels}");
        }
    }
}
