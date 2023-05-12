using CSharp_practical_8.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_practical_8.UI
{
    internal static class ATMModeUI
    {
        public static void GetATMMode()
        {
            char reset;
            do
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n ======================== Welcome To ATM Mode =======================");

                Console.Write(" \n Enter or Insert Card|Number : ");
                long accNum = Convert.ToInt64(Console.ReadLine());

                var holdername = DBContext.db.FirstOrDefault(e => e.AccountNumber == accNum && e.HasATMCard == true);
                if (holdername != null)
                {
                    if (holdername.CardDetails!.isActivate)
                    {
                        Console.Write(" Enter Pin : ");
                        int pin = Convert.ToInt32(Console.ReadLine());
                        if (holdername.CardDetails!.Pin == pin)
                        {
                            ATMFeatureUI.GetATMFeature(holdername.AccountNumber);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Invalid Pin! Try Again...");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\n Your Account Is Not Activate To Activate Your Account Enter Your AccessKey Of Your Bank... : ");

                        if (holdername.AccessKey!.Equals(Console.ReadLine(), StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine("\n Please Wait We are Activating Your Account .....");
                            holdername.CardDetails!.isActivate = true;
                            Thread.Sleep(2000);
                            Console.WriteLine(" Your Account Is Activated ........");
                            Console.Write("\n Set Your Pin : ");
                            holdername.CardDetails.Pin = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(" Your Pin Is Set Now You Can Proceed ..... !");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" Invalid Access Key !");
                            Console.ResetColor();
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"\n ATM Card Is Not Issue To This Account {accNum}... Please Request ATM Card From Your Bank...! ");
                }
                Console.Write("\n Do you want to continue : [y|n] : ");
                reset = Console.ReadKey().KeyChar;
            } while (reset!='n');
        }
    }
}
