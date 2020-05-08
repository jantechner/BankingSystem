using System;
using System.Collections.Generic;

namespace Models
{
    public class PlainAccount : Account
    {
        public PlainAccount(Bank bank, int id, Customer customer, string number, IInterestMechanism interestRate,
            Currency currency = Currency.PL)
        {
            this.bank = bank;
            this.id = id;
            owner = customer;
            this.currency = currency;
            this.number = number;
            this.interestRate = interestRate;
        }

        public override double Balance
        {
            get => balance;
            set => balance = value;
        }

        public override IList<Loan> Loans => loans;
        public override List<Operation> History => history;
        public override IInterestMechanism InterestRate 
        { 
            get => interestRate;
            set => interestRate = value;
        }

        public override void Accept(Report report)
        {
            report.Create(this);
        }

        public override Bank Bank => bank;
        public override Currency Currency => currency;
        public override string Number => number;

        public override void DecreaseBalance(double amount)
        {
            if (Balance < amount) throw new Exception("Not enough funds");
            Balance -= amount;
        }

        public override void IncreaseBalance(double amount)
        {
            Balance += amount;
        }
    }
}