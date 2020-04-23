using System;

namespace Models
{
    public class DebitAccount : Account
    {
        public DebitAccount(Bank bank, int id, Customer customer, string number, InterestRate interestRate,
            Currency currency = Currency.PL)
            : base(bank, id, customer, number, interestRate, currency)
        {
        }

        public double Debit { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Debit: {Debit}\n";
        }
    }
}