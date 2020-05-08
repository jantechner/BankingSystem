﻿using System;
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

            var customer1 = new Customer("87040500342") {Name = "Jan", Surname = "Kowalski"};
            var customer2 = new Customer("97021500531") {Name = "Grzegorz", Surname = "Nowak"};
            
            customer1.Open<DebitAccount>(globalBank);
            customer2.Open<PlainAccount>(millenium);
            var account1 = customer1.GetAccounts()[0];
            var account2 = customer2.GetAccounts()[0];
            
            customer1.DepositMoney(account1, 1000);
            customer1.WithdrawMoney(account1, 500);
            customer1.WithdrawMoney(account1, 600);
            customer1.DepositMoney(account1, 400);

            customer1.RequestLoan(account1, 10000, globalBank);
            customer1.RepayLoan(account1, account1.Loans[0], 100, globalBank);

            customer1.OpenDeposit(account1, 10000);

            globalBank.Execute(new OutgoingTransfer(account1, "97021500531", 200));
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
            Console.WriteLine(millenium.Generate(new AccountsReport()).ToString());
            
        }
    }
}