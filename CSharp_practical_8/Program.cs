﻿using CSharp_practical_8.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_practical_8
{
    enum MODE
    {
        BANK = 1,
        ATM
    }
    public class Program
    {


        static void Main(string[] args)
        {
            char reset;
            do
            {

                Console.Clear();
                Console.WriteLine("\n ========================= Welcome To MyBankATM ============================");
                Console.WriteLine("\n 1. Bank");
                Console.WriteLine(" 2. ATM");
                Console.WriteLine(" 3. Exit");
                Console.Write("\n Enter Your Choice : ");
                int choice = Convert.ToInt32(Console.ReadLine());
                MODE mode = (MODE)choice;

                switch (mode)
                {
                    case MODE.BANK:
                        Console.Clear();
                        BankModeUI.GetBankMode();
                        break;
                    case MODE.ATM:
                        Console.Clear();
                        ATMModeUI.GetATMMode();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Choice...");
                        Console.ResetColor();
                        break;
                }
                Console.ForegroundColor= ConsoleColor.Cyan;
                Console.Write("\n Do you want to continue with other modes : [y|n] : ");
                reset = Console.ReadKey().KeyChar;
                Console.ResetColor();
            } while (reset !='n');

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n Thank You Have A Nice Day ...");
            Console.ResetColor();


        }
    }
}
