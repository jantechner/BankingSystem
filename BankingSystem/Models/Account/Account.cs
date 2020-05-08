using System;
using System.Collections.Generic;

namespace Models
{
    public abstract class Account : BankingProduct
    {
        private static int _accountCounter = 0;

        // protected Bank bank;
        protected int Id;
        protected Customer Owner;
        private readonly DateTime _openingDate = DateTime.Now;
        // protected Currency currency;
        // protected string number;
        // protected IInterestMechanism interestRate;
        // protected double balance;
        // protected IList<Loan> loans = new LoansStore();
        // protected IList<Deposit> deposits = new List<Deposit>();
        // protected List<Operation> history = new List<Operation>();

        public abstract Bank Bank { get; }
        public abstract string Number { get; }
        public abstract Currency Currency { get; }
        public abstract IInterestMechanism InterestRate { get; set; }
        public abstract double Balance { get; set; }
        public abstract IList<Loan> Loans { get; }
        public abstract IList<Deposit> Deposits { get; }
        public abstract List<Operation> History { get; }

        public abstract void IncreaseBalance(double amount);
        
        public abstract void DecreaseBalance(double amount);

        public override void Accept(Report report)
        {
        }

        public override string ToString()
        {
            return $"ID: {Id}\n" +
                   $"Owner: {Owner}\n" +
                   $"Number: {Number}\n" +
                   $"Opening date: {_openingDate}\n" +
                   $"Currency: {Currency}\n" +
                   $"Balance: {Balance}\n" +
                   $"InterestRate: {InterestRate}\n" +
                   $"Loans: {Loans}\n" +
                   $"History: {History}";
        }

        public static int NextAccountId()
        {
            return _accountCounter++;
        }
    }
}