using System;

namespace Models
{
    public class PlainAccount : Account
    {
        public PlainAccount(Bank bank, int id, Customer customer, string number, InterestRate interestRate, Currency currency = Currency.PL) : base(bank, id, customer, number, interestRate, currency)
        {
        }

        public override void DecreaseBalance(double amount)
        {
            if (Balance < amount)
                throw new Exception("Not enough funds");
            Balance -= amount;
        }

        public override void IncreaseBalance(double amount)
        {
            Balance += amount;
        }
    }
}