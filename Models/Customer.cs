using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Customer
    {   
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; }
        public List<Bank> Banks { get; } = new List<Bank>();
        //stores passwords
        private Dictionary<(Bank bank, string accountId), string> accounts = new Dictionary<(Bank bank, string accountId), string>();

        public Customer(string pesel) 
        {
            Pesel = pesel;
        }

        public void addBank(Bank bank) {
            Banks.Add(bank);
        }

        public void openAccount2(Bank bank) 
        {
            if (Banks.Contains(bank))
            {
                bank.openAccount(this);
                System.Console.WriteLine("New account opened!");
            }
        }

        public void openAccount(Bank bank)
        {
            var (accountId, password) = bank.openAccount(this);
            accounts.Add((bank, accountId), password);
        }
        public List<(Bank bank, string accountId)> getAccounts()
        {
            return accounts.Keys.ToList();
        }
        public void showBalance(Bank bank, string accountId)
        {
            if (!accounts.TryGetValue((bank, accountId), out string password))
                throw new SystemException("You don't have such account");

            bank.showBalance(accountId, password);
        }
        public void innerBankTransfer(Bank bank, string from, string to, double amount)
        {
            if (!accounts.TryGetValue((bank, from), out string password))
                throw new SystemException("You don't have such account");

            bank.innerBankTransfer(from, to, amount, password);
        }
        public override string ToString()
        {
            return $"Customer: {Name} {Surname}, pesel {Pesel}";
        }
    }
}