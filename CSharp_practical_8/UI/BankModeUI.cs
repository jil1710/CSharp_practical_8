using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_practical_8.models;

namespace CSharp_practical_8.UI
{
    public static class BankModeUI
    {
        public static void GetBankMode()
        {
            Bank bank = new Bank();
        bankmode:
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n ==================== Welcome To Bank Mode ====================");
            Console.WriteLine("\n 1. Create New Account.");
            Console.WriteLine(" 2. Login To Your Account.");
            Console.WriteLine(" 3. Exit.");
            Console.Write("\n Enter Your Choice : ");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                
                case 1:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n ********************** Create Account ***********************\n");
                    Console.Write(" Enter Your Name : ");
                    string name = Console.ReadLine()!;
                    Console.Write(" Enter Your Bank Name : ");
                    string bankname = Console.ReadLine()!;
                    Random rnd = new Random();
                    long accNumber = Convert.ToInt64(DateTime.Now.ToString("ddMMyyyyHH00")) + rnd.Next(10, 99);
                    Console.Write(" Enter Your Phone Number : ");
                    long phone = Convert.ToInt64(Console.ReadLine()!);
                    Console.Write(" Enter Your Branch Name : ");
                    string branchname = Console.ReadLine()!;
                    Console.Write(" Select Your Account Type [ 1. Saving | 2. FD ] : ");
                    int opt = Convert.ToInt32(Console.ReadLine()!);
                    Console.Write(" Enter Your Access Key : ");
                    string accesskey = Console.ReadLine()!;
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine("\n Please Wait We are creating Your Account ......................");
                    Thread.Sleep(2000);
                    bool isCreated = bank.CreateAccount(new BankAccount() { AccountType = (opt == 1) ? BankAccount.ACC_TYPE.SAVING : BankAccount.ACC_TYPE.FIXED_DEPOSITE ,AccessKey = accesskey, AccountHolderName = name, AccountNumber = accNumber, BankName = bankname, BranchName = branchname, CustomerPhoneNumber = phone });
                    if (isCreated)
                    {
                        Console.WriteLine($"\n Welcome Your Account is SuccessFully Created In {bankname} and Your Account Number is {accNumber}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Something went wrong!");
                        Console.ResetColor();
                    }
                    goto bankmode;
                case 2:
                    Console.Clear();
                    again:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n *********************** Login Into Account ***********************\n");
                    Console.Write(" Enter Account Number : ");
                    long accnum = Convert.ToInt64(Console.ReadLine()!);
                    Console.Write(" Enter Your Access Key : ");
                    string key = Console.ReadLine()!;
                    bool isValid = bank.Login(accnum, key);
                    if(isValid)
                    {
                        BankFeatureUI.GetBankFeature(accnum,bank);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n Opps! Invalid Credential...");
                        Console.ResetColor();
                        goto again;
                    }
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Invalid Choice....");
                    Console.ResetColor();
                    Console.Clear();
                    goto bankmode;
            }

            

        }
    }
}
