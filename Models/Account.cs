using System;
using System.Collections;
using System.Collections.Generic;

namespace Models
{
    public abstract class Account
    {
        public Bank Bank { get; }
        private readonly int _id;
        private readonly Customer _owner;
        public DateTime OpeningDate { get; } = DateTime.Now;
        public Currency Currency { get; }
        public double Balance { get; set; }
        public string Number { get; }

        // private IList Deposits = new DepositsStore();    // nie jestem pewien jak to ma wyglądać

        public IList<Loan> Loans { get; } = new LoansStore();
        public InterestRate InterestRate { get; } // jak użyć stopy procentowej w koncie???
        public List<Operation> History { get; } = new List<Operation>();

        protected Account(Bank bank, int accountId, Customer customer, string number, InterestRate interestRate,
            Currency currency = Currency.PL)
        {
            Bank = bank;
            _id = accountId;
            _owner = customer;
            Currency = currency;
            Number = number;
            InterestRate = interestRate;
        }

        public void RaiseLoan(Loan loan)
        {
            Loans.Add(loan);
        }

        // public void OutgoingTransfer(string accountNumber, double amount)
        // {
        //     DecreaseBalance(amount);
        //     Bank.OutgoingTransfer(new Transfer(this.Number, accountNumber, amount));
        //     History.Add(new AccountOperation(this));
        // }
        //
        // public void IncomingTransfer(Transfer transfer)
        // {
        //     IncreaseBalance(transfer.Amount);
        //     History.Add(new AccountOperation(this));
        // }

        public override string ToString()
        {
            return $"ID: {_id}\n" +
                   $"Owner: {_owner}\n" +
                   $"Number: {Number}\n" +
                   $"Opening date: {OpeningDate}\n" +
                   $"Currency: {Currency}\n" +
                   $"Balance: {Balance}\n" +
                   $"InterestRate: {InterestRate}\n" +
                   $"Loans: {Loans}\n" +
                   $"History: {History}";
        }
    }
}