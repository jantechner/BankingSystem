using System;
using System.Collections.Generic;

namespace Models
{
    public abstract class Account : BankingProduct
    {
        private static int _accountCounter = 0;

        protected int Id;
        private readonly DateTime _openingDate = DateTime.Now;
        public abstract Customer Owner { get; }
        public abstract Bank Bank { get; }
        public abstract string Number { get; }
        public abstract Currency Currency { get; }
        public abstract double Balance { get; set; }
        public abstract IList<Loan> Loans { get; }
        public abstract IList<Deposit> Deposits { get; }

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