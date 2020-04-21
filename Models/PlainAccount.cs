using System;

namespace Models
{
    public class PlainAccount : Account
    {
        public PlainAccount(int id, Customer customer, string number, InterestRate interestRate, Currency currency = Currency.PL) : base(id, customer, number, interestRate, currency)
        {
        }

        public override void WithdrawMoney(double amount)
        {
            if (Balance < amount)
                throw new Exception("Not enough funds");
            Balance -= amount;
        }

        public override void DepositMoney(double amount)
        {
            Balance += amount;
        }
    }
}