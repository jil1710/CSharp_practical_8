using CSharp_practical_8.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharp_practical_8.UI
{
    internal static class ATMFeatureUI
    {
        public static void GetATMFeature(long acc)
        {
            ATM atm = new ATM();
            char reset;
            do
            {
                Console.Clear();
                Console.WriteLine("\n ======================== Welcome To ATM Mode =======================");
                Console.WriteLine("\n 1. Check Balance. ");
                Console.WriteLine(" 2. Withdraw Cash. ");
                Console.WriteLine(" 3. Deposit Cash. ");
                Console.WriteLine(" 4. Change Pin. ");
                Console.WriteLine(" 5. Account Details. ");
                Console.WriteLine(" 6. Exit Card. ");

                Console.Write("\n Enter Your Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                var detail = DBContext.db.FirstOrDefault(e => e.AccountNumber == acc);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n Your Current Banalce is : -> " + detail!.BankBalance);
                        break;
                    case 2:
                        Console.Write("\n Enter Amount to deduct From Your Account :  ");
                        long cash = Convert.ToInt64(Console.ReadLine());
                        if (cash < detail?.BankBalance)
                        {
                            detail.BankBalance -= cash;
                            Console.WriteLine($"\n Amount {cash} is successfully withdraw|deducted from account {acc} and Your current balance is {detail.BankBalance} ...");
                        }
                        else
                        {
                            Console.WriteLine("\n Sorry! Amount is not sufficient to proceed...");
                        }
                        break;
                    case 3:
                        Console.Write("\n Enter Amount to deduct From Your Account :  ");
                        long cash1 = Convert.ToInt64(Console.ReadLine());
                        detail!.BankBalance += cash1;
                        Console.WriteLine(" Please wait ......");
                        Thread.Sleep(2000);
                        Console.WriteLine($" Amount {cash1} is successfully added in account {acc} and Your current balance is {detail.BankBalance} ...");
                        break;
                    case 4:
                        if (atm.ChangePin(acc))
                        {
                            Console.WriteLine(" Your Pin Is Successfully Changed!");
                        }
                        else
                        {
                            Console.WriteLine(" Something went wrong! Try Later...");
                        }
                        break;
                    case 5:
                        Console.WriteLine("\n Holder Name : " + detail!.AccountHolderName);
                        Console.WriteLine("\n Account Number : " + detail.AccountNumber);
                        Console.WriteLine("\n Bank Name : " + detail.BankName);
                        Console.WriteLine("\n Customer Phone Number : " + detail.CustomerPhoneNumber);
                        Console.WriteLine("\n Account Balance : " + detail.BankBalance);
                        Console.WriteLine("\n Branch Name : " + detail.BranchName);
                        Console.WriteLine("\n Card Number : " + detail.CardDetails!.CardNumber);
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(" Invalid Choice...");
                        break;
                }
                Console.Write("\n Do you want to continue : [y | n] ");
                reset = Console.ReadKey().KeyChar;
            } while (reset == 'y');

        }
    }
}
