using System;
using Models;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var globalBank = new Bank();

            var c1 = new Customer("87040500342") { Name = "Jan", Surname = "Kowalski" };
            c1.openAccount(globalBank);
            var account = c1.getAccounts()[0];
            account.bank.depositMoney(account.accountId, 100);
            c1.showBalance(account.bank, account.accountId);

            var c2 = new Customer("17040500342") { Name = "Tomasz", Surname = "Nowak" };
            c2.openAccount(globalBank);
            var account2 = c2.getAccounts()[0];

            c1.innerBankTransfer(globalBank, account.accountId, account2.accountId, 50);
            c2.showBalance(account2.bank, account2.accountId);

            Console.ReadKey();
        }
    }
}
