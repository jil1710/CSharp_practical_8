using CSharp_practical_8.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_practical_8.UI
{
    internal static class BankFeatureUI
    {
        public static void GetBankFeature(long acc, Bank bankDetail)
        {
            char reset;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"\n ==================== Welcome {acc} ====================");
                Console.WriteLine("\n 1. Check Your Bank Balance.");
                Console.WriteLine(" 2. Withdraw Cash From Account.");
                Console.WriteLine(" 3. Add Cash To Your Account.");
                Console.WriteLine(" 4. Request To Delete Account.");
                Console.WriteLine(" 5. Get All Account Details.");
                Console.WriteLine(" 6. Request For ATM Card.");
                Console.WriteLine(" 7. Exit");
                Console.Write("\n Enter Your Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());

                var detail = DBContext.db.FirstOrDefault(e => e.AccountNumber == acc);

                Console.ForegroundColor = ConsoleColor.Cyan;
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
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.WriteLine($"\n Amount {cash} is successfully withdraw|deducted from account {acc} and Your current balance is {detail.BankBalance} ...");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Sorry! Amount is not sufficient to proceed...");
                        }
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("\n Enter Amount to Deposite Into Your Account :  ");
                        long cash1 = Convert.ToInt64(Console.ReadLine());
                        detail!.BankBalance += cash1;
                        if(detail.AccountType == BankAccount.ACC_TYPE.SAVING)
                        {
                            bankDetail.CalculateInterest(acc,(double)detail.BankBalance!);
                        }
                        else
                        {
                            bankDetail.CalculateInterest(acc);
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" Please wait ......");
                        Thread.Sleep(2000);
                        Console.WriteLine($" Amount {cash1} is successfully added in account {acc} and Your current balance is {detail.BankBalance} by 2.7% Interest ...");
                        break;
                    case 4:
                        Console.Write("\n Are You Sure You Want To Delete Your Account ... [y | n] : ");
                        char v = Console.ReadKey().KeyChar;
                        if (v == 'y')
                        {
                            Console.WriteLine("\n We Got Your Request To Delete Account, Please Wait We Are Deleting your Account....");
                            if (bankDetail.DeleteAccount(acc))
                            {
                                Thread.Sleep(2000);
                                Console.WriteLine($"\n Successfully deleted account {acc} ...");
                                Environment.Exit(0);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n Something went wrong ....");
                                Console.ResetColor();
                            }

                        }
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n Holder Name : " + detail!.AccountHolderName);
                        Console.WriteLine("\n Account Number : " + detail.AccountNumber);
                        Console.WriteLine("\n Bank Name : " + detail.BankName);
                        Console.WriteLine("\n Customer Phone Number : " + detail.CustomerPhoneNumber);
                        Console.WriteLine("\n Account Balance : " + detail.BankBalance);
                        Console.WriteLine("\n Branch Name : " + detail.BranchName);
                        Console.WriteLine("\n Card Number : " + detail.CardDetails?.CardNumber);
                        break;
                    case 6:
                        Console.Write("\n You Want To Request For ATM Card ... [y | n] : ");
                        char y = Console.ReadKey().KeyChar;
                        if(y == 'y')
                        {
                            if (bankDetail.RequestATMCard(acc))
                            {
                                Console.ForegroundColor= ConsoleColor.Green;
                                Console.WriteLine("\n Your ATM Card is Successfully Generate And ATM Card Number Is " + detail?.CardDetails?.CardNumber);
                                Console.WriteLine("\n You can see Cards details by getting account details....");
                            }
                        }
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.Write("\n Do you want to continue : [y | n] ");
                reset = Console.ReadKey().KeyChar;
            } while (reset == 'y');

            Console.WriteLine("\n\n *************************** Thank You ********************************");
        }
    }
}
