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
        public IList<Bank> Banks { get; } = new List<Bank>();

        public Customer(string pesel)
        {
            Pesel = pesel;
        }

        public void Open<T>(Bank bank) where T : Account
        {
            bank.Execute(new OpenAccount<T>(this, bank));
            Banks.Add(bank);
        }

        public List<T> Get<T>() where T : BankingProduct
        {
            return Banks.SelectMany(bank => bank.GetCustomerProducts<T>(this)).ToList();
        }

        public void WithdrawMoney(Account account, double amount)
        {
            account.Bank.Execute(new DecreaseBalance(account, amount));
        }

        public void DepositMoney(Account account, double amount)
        {
            account.Bank.Execute(new IncreaseBalance(account, amount));
        }

        public bool RequestLoan(Account account, double amount, Bank bank)
        {
            return Banks.Contains(bank) && bank.Execute(new RaiseLoan(account, amount, new InterestRate(0.2, 24, 6)));
        }

        public bool RepayLoan(Account account, Loan loan, int amount, Bank bank)
        {
            return Banks.Contains(bank) && bank.Execute(new RepayLoan(loan, amount));
        }

        public bool OpenDeposit(Account account, double amount)
        {
            return Banks.Contains(account.Bank) &&
                   account.Bank.Execute(new OpenDeposit(account, amount, new InterestRate(0.2, 24, 6)));
        }

        public bool CloseDeposit(Deposit deposit)
        {
            return Banks.Contains(deposit.Account.Bank) &&
                   deposit.Account.Bank.Execute(new CloseDeposit(deposit));
        }

        public override string ToString()
        {
            return $"Customer: {Name} {Surname}, pesel {Pesel}";
        }
    }
}