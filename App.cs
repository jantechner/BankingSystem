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
            customer2.Open<PlainAccount>(millenium);
            var account1 = customer1.GetAccounts()[0];
            var account2 = customer2.GetAccounts()[0];
            
            globalBank.Execute(new IncreaseBalance(account1, 1000));
            globalBank.Execute(new DecreaseBalance(account1, 500));
            globalBank.Execute(new DecreaseBalance(account1, 600));
            globalBank.Execute(new IncreaseBalance(account1, 400));

            customer1.RequestLoan(account1, 10000, globalBank);
            customer1.RepayLoan(account1, account1.Loans[0], 100, globalBank);

            globalBank.Execute(new Transfer(account1, "97021500531", 200));
            // account1.OutgoingTransfer("97021500531", 200);

            InterBankPaymentManager.ExecuteTransfers();

            Console.WriteLine(account1);
            Console.WriteLine(account2);

            foreach (var loan in account1.Loans)
            {
                Console.WriteLine(loan);
            }

            globalBank.Execute(new CalculateInterest(account1));
            globalBank.Execute(new ChangeInterestRate(account1, new AnotherInterestRate(0.01)));
            globalBank.Execute(new CalculateInterest(account1));

            Console.WriteLine(globalBank.Generate(new AccountsReport()).ToString());
            
        }
    }
}