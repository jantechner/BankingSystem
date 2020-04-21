using System;
using System.Collections;

namespace Models
{
    public abstract class Account
    {
        protected readonly int id;
        protected readonly Customer owner;
        public DateTime OpeningDate { get; } = DateTime.Now;
        public Currency Currency { get; }
        public double Balance { get; protected set; }

        public string Number { get; } // po co to?

        // private IList Deposits = new DepositsStore();    // nie jestem pewien jak to ma wyglądać
        public IList Loans { get; } = new LoansStore();
        public InterestRate InterestRate { get; }
        public IList History { get; private set; } = new OperationsHistory();

        public Account(int _id, Customer customer, string number, InterestRate interestRate,
            Currency currency = Currency.PL)
        {
            id = _id;
            owner = customer;
            Currency = currency;
            Number = number;
            InterestRate = interestRate;
        }

        abstract public void WithdrawMoney(double amount);

        abstract public void DepositMoney(double amount);

        public override string ToString()
        {
            return $"ID: {id}\n" +
                   $"Owner: {owner}\n" +
                   $"Number: {Number}\n" +
                   $"Opening date: {OpeningDate}\n" +
                   $"Currency: {Currency}\n" +
                   $"Balance: {Balance}\n" +
                   $"InterestRate: {InterestRate}";
        }
    }
}