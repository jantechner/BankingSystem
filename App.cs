using System;
using Models;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var globalBank = new Bank();

            var customer1 = new Customer("87040500342") { Name = "Jan", Surname = "Kowalski" };
            var customer2 = new Customer("97021500531") { Name = "Grzegorz", Surname = "Nowak" };
            customer1.Open<DebitAccount>(globalBank);
            customer2.Open<Account>(globalBank);
            var account1 = customer1.GetAccounts()[0];
            var account2 = customer2.GetAccounts()[0];
            
            account1.DepositMoney(1000);
            account1.WithdrawMoney(500);
            account1.WithdrawMoney(600);
            account1.DepositMoney(500);
            
            Console.WriteLine(account1);
            Console.WriteLine(account2);
        }
    }
}
