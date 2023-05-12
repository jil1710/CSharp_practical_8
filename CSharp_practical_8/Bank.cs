using CSharp_practical_8.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_practical_8
{
    internal class Bank : IBankAction
    {
        public bool Session = false;
        public bool CreateAccount(BankAccount bankAccount)
        {
            DBContext.db.Add(bankAccount);
            return true;
        }

        public bool DeleteAccount(long accountNumber)
        {
            BankAccount? bankAccount = DBContext.db.FirstOrDefault(e => e.AccountNumber == accountNumber);
            if (bankAccount != null)
            {
                DBContext.db.Remove(bankAccount!);
                return true;
            }
            return false;
        }

        public BankAccount GetAccountDetails(long accountNumber)
        {
            BankAccount? bankAccount = DBContext.db.FirstOrDefault(e => e.AccountNumber == accountNumber);
            if (bankAccount != null)
            {
                return bankAccount;
            }
            return null;
        }

        public bool Login(long accnum, string accesskey)
        {
            var bankaccount = DBContext.db.FirstOrDefault(e => e.AccountNumber == accnum && e.AccessKey == accesskey);
            if (bankaccount != null)
            {
                Session = true;
            }
            else
            {
                Session = false;
            }
            return Session;
        }

        public bool RequestATMCard(long accnum)
        {
            var bankaccount = DBContext.db.FirstOrDefault(e => e.AccountNumber == accnum);

            if (bankaccount != null)
            {
                CardDetail cardDetail = new CardDetail() { CardNumber = accnum, CVV = new Random().Next(100, 999) };
                bankaccount.CardDetails = cardDetail;
                bankaccount.HasATMCard = true;
                return true;
            }
            return false;

        }

        public bool UpdateAccountDetails(long accountNumber)
        {
            throw new NotImplementedException();
        }

        public void CalculateInterest(long accountNumber, double balance)
        {
            BankAccount? data = DBContext.db.FirstOrDefault(e => e.AccountNumber == accountNumber);
            if (data != null)
            {
                DateTime dateTime = data.CreateAt.AddYears(1);
                if (dateTime.Year - DateTime.Now.Year == 0)
                {
                    balance *= 2.7;
                    data.BankBalance = balance;
                }
            }
        }
        public void CalculateInterest(long accountNumber)
        {
            BankAccount? data = DBContext.db.FirstOrDefault(e => e.AccountNumber == accountNumber);
            if (data != null)
            {
                DateTime dateTime = data.CreateAt.AddYears(1);
                if (dateTime.Year - DateTime.Now.Year == 0)
                {

                    data.BankBalance *= 4.7;

                }
            }
        }
    }
}
