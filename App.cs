using System;
using Models;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var globalBank = new Bank("PKO BP", "PL", "BPKOPLPW");
            var millenium = new Bank("Millenium", "PL", "MILL");

            InterBankPaymentManager.RegisterBank(globalBank);
            InterBankPaymentManager.RegisterBank(millenium);

            Console.WriteLine(globalBank.Name + " " + globalBank.CountryCode + " " + globalBank.SWIFT);

            var customer1 = new Customer("87040500342") {Name = "Jan", Surname = "Kowalski"};
            var customer2 = new Customer("97021500531") {Name = "Grzegorz", Surname = "Nowak"};
            customer1.Open<DebitAccount>(globalBank);
            customer2.Open<Account>(millenium);
            var account1 = customer1.GetAccounts()[0];
            var account2 = customer2.GetAccounts()[0];

            account1.IncreaseBalance(1000);
            account1.DecreaseBalance(500);
            account1.DecreaseBalance(600);
            account1.IncreaseBalance(500);

            customer1.RequestLoan(10000, globalBank);
            account1.Loans[0].RepayLoan(100);

            account1.OutgoingTransfer("97021500531", 200);

            InterBankPaymentManager.ExecuteTransfers();

            Console.WriteLine(account1);
            Console.WriteLine(account2);
        }
    }
}