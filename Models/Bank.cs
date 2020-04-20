using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Models
{
    public class Bank
    {
        public string Name { get; }
        public string CountryCode { get; }
        public string SWIFT { get; }
        private IDictionary accounts = new AccountsStore();
        public IEnumerable InterestRates { get; }
        private Dictionary<string, Account> accountId2account = new Dictionary<string, Account>();
        private Dictionary<string, string> accountId2password = new Dictionary<string, string>();
        private double accountCounter = 0;
        public ReportingManager ReportingManager { get; }
        public void openAccount2(Customer customer)
        {
            accounts.Add(customer, this);
            System.Console.WriteLine($"Opening account for {customer}");
        }

        public (string accountId, string password) openAccount(Customer customer)
        {
            //create new account
            accountCounter++;
            string accountId = accountCounter.ToString();
            accountId2account.Add(accountId, new Account(customer, accountId));

            //generate random password
            string password = Path.GetRandomFileName();
            accountId2password.Add(accountId, password);

            return (accountId, password);
        }
        public void showBalance(string accountId, string givenPassword)
        {
            if (!accountId2account.TryGetValue(accountId, out Account account))
                throw new SystemException("There is no such account");
            if (!accountId2password.TryGetValue(accountId, out string savedPassword))
                throw new SystemException("There is no password saved for such account");
            if (givenPassword != savedPassword)
                throw new SystemException("Wrong password");

            account.getBalance();
        }
        public void depositMoney(string accountId, double amount)
        {
            if (!accountId2account.TryGetValue(accountId, out Account account))
                throw new SystemException("There is no such account");
            if (amount < 0)
                throw new ArgumentException("You can't deposit negative amount of money");

            account.giveMoney(amount);
        }
        public void innerBankTransfer(string from, string to, double amount, string givenPassword)
        {
            if (!accountId2account.TryGetValue(from, out Account sender))
                throw new SystemException("There is no such sender account");
            if (!accountId2account.TryGetValue(to, out Account receiver))
                throw new SystemException("There is no such receiver account");
            if (!accountId2password.TryGetValue(from, out string savedPassword))
                throw new SystemException("There is no password saved for sender account");
            if (givenPassword != savedPassword)
                throw new SystemException("Wrong password");

            sender.takeMoney(amount);
            receiver.giveMoney(amount);
        }
    }
}