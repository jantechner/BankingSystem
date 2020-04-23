using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; }
        public IList Banks { get; } = new List<Bank>();

        public Customer(string pesel)
        {
            Pesel = pesel;
        }

        public void Open<T>(Bank bank) where T : Account
        {
            bank.Execute(new OpenAccount<T>(this, bank));
            // bank.Open<T>(this);
            Banks.Add(bank);
        }

        public List<Account> GetAccounts()
        {
            var accounts = new List<Account>();
            foreach (Bank bank in Banks)
            {
                accounts.Add(bank.GetCustomerAccount(this));
            }

            return accounts;
        }

        public void WithdrawMoney(Account account, double amount)
        {
            account.Bank.Execute(new DecreaseBalance(account, amount));
        }
        
        public void DepositMoney(Account account, double amount)
        {
            account.Bank.Execute(new IncreaseBalance(account, amount));
        }

        public bool RequestLoan(int amount, Bank bank)
        {
            return Banks.Contains(bank) && bank.RaiseLoan(this, amount);
        }

        // public void innerBankTransfer(Bank bank, string from, string to, double amount)
        // {
        //     if (!accounts.TryGetValue((bank, from), out string password))
        //         throw new SystemException("You don't have such account");
        //
        //     bank.innerBankTransfer(from, to, amount, password);
        // }

        public override string ToString()
        {
            return $"Customer: {Name} {Surname}, pesel {Pesel}";
        }
    }
}