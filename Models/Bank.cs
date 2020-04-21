using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Models
{
    public class Bank
    {
        private static int _accountCounter = 0;

        public string Name { get; }
        public string CountryCode { get; }
        public string SWIFT { get; }
        private Dictionary<Customer, Account> _accounts = new Dictionary<Customer, Account>();
        public IEnumerable InterestRates { get; } // co to ma robić?
        public ReportingManager ReportingManager { get; }
        public IList _history = new OperationsHistory();

        public void Open<T>(Customer customer) where T : Account
        {
            //simplest version, but a possible code smell -> for discussion
            // var newAccount = (T)Activator.CreateInstance(typeof(T), new Account(_accountCounter++, customer, "number", new InterestRate(0.05, 24, 6)))

            Account newAccount;
            if (typeof(T) == typeof(Account))
            {
                newAccount = new PlainAccount(_accountCounter++, customer, "109010140000071219812874", new InterestRate(0.05, 24, 6));
            }
            else if (typeof(T) == typeof(DebitAccount))
            {
                newAccount = new DebitAccount(_accountCounter++, customer, "109010140000071219812874", new InterestRate(0.05, 24, 6));
            }
            else
            {
                throw new Exception("incorrect ");
            }

            _accounts.Add(customer, newAccount);
            
            Console.WriteLine($"Opening account for {customer}");
        }

        public Account GetCustomerAccount(Customer customer)
        {
            return _accounts[customer];
        }

        // public void innerBankTransfer(string from, string to, double amount, string givenPassword)
        // {
        //     if (!accountId2account.TryGetValue(from, out Account sender))
        //         throw new SystemException("There is no such sender account");
        //     if (!accountId2account.TryGetValue(to, out Account receiver))
        //         throw new SystemException("There is no such receiver account");
        //     if (!accountId2password.TryGetValue(from, out string savedPassword))
        //         throw new SystemException("There is no password saved for sender account");
        //     if (givenPassword != savedPassword)
        //         throw new SystemException("Wrong password");
        //
        //     sender.WithdrawMoney(amount);
        //     receiver.DepositMoney(amount);
        // }
    }
}