using System;
using System.Collections.Generic;

namespace Models
{
    public class RegularAccount : Account
    {
        public RegularAccount(Bank bank, int id, Customer customer, string number, IInterestMechanism interestRate,
            Currency currency = Currency.PL)
        {
            this.Id = id;
            Owner = customer;
            Bank = bank;
            Number = number;
            InterestRate = interestRate;
            Currency = currency;
        }

        public override Customer Owner { get; }
        public override Bank Bank { get; }
        public override string Number { get; }
        public override Currency Currency { get; }
        public sealed override IInterestMechanism InterestRate { get; set; }
        public override double Balance { get; set; }
        public override IList<Loan> Loans { get; } = new List<Loan>();
        public override IList<Deposit> Deposits { get; } = new List<Deposit>();
        public override List<Operation> History { get; } = new List<Operation>();
        
        public override void IncreaseBalance(double amount)
        {
            Balance += amount;
        }
        public override void DecreaseBalance(double amount)
        {
            if (Balance < amount) throw new Exception("Not enough funds");
            Balance -= amount;
        }
        public override void Accept(Report report)
        {
            report.Create(this);
        }
    }
}