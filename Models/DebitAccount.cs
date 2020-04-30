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

        public double Debit { get; private set; }

        public override void DecreaseBalance(double amount)
        {
            Balance -= amount;
            if (Balance >= 0) return;
            Debit = Debit == 0.0 ? Math.Abs(Balance) : Debit + amount;
            Balance = 0;
        }

        public override void IncreaseBalance(double amount)
        {
            Debit -= amount;
            if (Debit >= 0) return;
            Balance = Balance == 0.0 ? Math.Abs(Debit) : Balance + amount;
            Debit = 0;
        }


        public override string ToString()
        {
            return base.ToString() + $"Debit: {Debit}\n";
        }
    }
}