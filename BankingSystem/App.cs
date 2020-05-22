using System;
using System.Collections.Generic;
using Models;
using Models.Handlers;

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

            var entryPoint = new EntryPoint();

            var customer1 = new Customer("87040500342", entryPoint) {Name = "Jan", Surname = "Kowalski"};
            var customer2 = new Customer("97021500531", entryPoint) {Name = "Grzegorz", Surname = "Nowak"};

            customer1.Open<DebitAccount>(globalBank);
            customer2.Open<RegularAccount>(millenium);
            var account1 = customer1.Get<Account>()[0];
            var account2 = customer2.Get<Account>()[0];

            // customer1.DepositMoney(account1, 1000);
            customer1.Request(RequestType.DepositMoney,
                new Dictionary<string, object> {{"account", account1}, {"amount", 1000.0}});

            // customer1.WithdrawMoney(account1, 500);
            customer1.Request(RequestType.WithdrawMoney,
                new Dictionary<string, object> {{"account", account1}, {"amount", 500.0}});

            // customer1.WithdrawMoney(account1, 600);
            customer1.Request(RequestType.WithdrawMoney,
                new Dictionary<string, object> {{"account", account1}, {"amount", 600.0}});

            // customer1.DepositMoney(account1, 400);
            customer1.Request(RequestType.DepositMoney,
                new Dictionary<string, object> {{"account", account1}, {"amount", 400.0}});

            // customer1.RequestLoan(account1, 10000, globalBank);
            customer1.Request(RequestType.RequestLoan,
                new Dictionary<string, object> {{"account", account1}, {"amount", 10000.0}});

            // customer1.RepayLoan(account1, account1.Loans[0], 100, globalBank);
            customer1.Request(RequestType.RepayLoan,
                new Dictionary<string, object> {{"loan", account1.Loans[0]}, {"amount", 100.0}});

            // customer1.OpenDeposit(account1, 5000);
            customer1.Request(RequestType.OpenDeposit,
                new Dictionary<string, object> {{"account", account1}, {"amount", 5000.0}});
            // customer1.CloseDeposit(account1.Deposits[0]);
            customer1.Request(RequestType.CloseDeposit,
                new Dictionary<string, object> {{"deposit", account1.Deposits[0]}});

            customer1.Request(RequestType.Transfer,
                new Dictionary<string, object> {{"account", account1}, {"to", "97021500531"}, {"amount", 200.0}});
            // globalBank.Execute(new OutgoingTransfer(account1, "97021500531", 200));
            // account1.OutgoingTransfer("97021500531", 200);

            InterBankPaymentManager.ExecuteTransfers();

            // Console.WriteLine(account1);
            // Console.WriteLine(account2);

            globalBank.Execute(new CalculateInterest(account1));
            globalBank.Execute(new ChangeInterestRate(account1, new AnotherInterestRate(0.01)));
            globalBank.Execute(new CalculateInterest(account1));

            Console.WriteLine(globalBank.Generate(new AccountsReport()).ToString());
            Console.WriteLine(millenium.Generate(new AccountsReport()).ToString());
            Console.WriteLine(globalBank.Generate(new ProductsReport()).ToString());
            Console.WriteLine(millenium.Generate(new ProductsReport()).ToString());
            Console.ReadKey();
        }
    }
}