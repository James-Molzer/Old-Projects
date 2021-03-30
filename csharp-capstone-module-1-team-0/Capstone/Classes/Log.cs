using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Log
    {

        public static void WriteLog(string log)
        {
            string outputDirectory = @"..\..\..\..";
            string outputFile = "Log.txt";
            string outputFullPath = Path.Combine(outputDirectory, outputFile);

            try
            {
                using (StreamWriter sw = new StreamWriter(outputFullPath, true))
                {
                    sw.WriteLine(log);
                }
            }
            catch
            {
                Console.WriteLine("Unable to write Log.txt");
            }
        }

        // can have one method 

        public static void LogFeedMoney(decimal moneyInMachine, decimal moneyAfterAction)
        {

            string log = ($"{DateTime.Now} FEED MONEY: {moneyInMachine:C2} {moneyAfterAction:C2}");
            WriteLog(log);
        }

        public static void LogGiveChange(decimal moneyInMachine, decimal moneyAfterAction)
        {
            string log = ($"{DateTime.Now} GIVE CHANGE: {moneyInMachine:C2} {moneyAfterAction:C2}");
            WriteLog(log);
        }


        public static void LogItem(string item, string itemCode, decimal moneyInMachine, decimal moneyAfterAction)
        {
            string log = ($"{DateTime.Now} {item} {itemCode}: {moneyInMachine:C2} {moneyAfterAction:C2}");
            WriteLog(log);
        }
    }
}
