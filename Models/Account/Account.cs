using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Models
{
    public abstract class Account
    {
        protected Bank bank;
        protected int id;
        protected Customer owner;
        private readonly DateTime _openingDate = DateTime.Now;
        protected Currency currency;
        protected string number;
        protected InterestMechanism interestRate;
        protected double balance;
        protected IList<Loan> loans = new LoansStore();
        protected List<Operation> history = new List<Operation>();
        
        // private IList Deposits = new DepositsStore();    // nie jestem pewien jak to ma wyglądać
        public abstract double Balance { get; set; }
        public abstract IList<Loan> Loans { get; }
        public abstract List<Operation> History { get; }
        public abstract Bank Bank { get; }
        public abstract Currency Currency { get; }
        public abstract string Number { get; }
        public abstract InterestMechanism InterestRate { get; set; }

        public abstract void DecreaseBalance(double amount);

        public abstract void IncreaseBalance(double amount);

        public override string ToString()
        {
            return $"ID: {id}\n" +
                   $"Owner: {owner}\n" +
                   $"Number: {number}\n" +
                   $"Opening date: {_openingDate}\n" +
                   $"Currency: {currency}\n" +
                   $"Balance: {balance}\n" +
                   $"InterestRate: {interestRate}\n" +
                   $"Loans: {loans}\n" +
                   $"History: {history}";
        }
    }
}