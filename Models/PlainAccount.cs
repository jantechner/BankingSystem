using System;

namespace Models
{
    public class PlainAccount : Account
    {
        public PlainAccount(Bank bank, int id, Customer customer, string number, InterestRate interestRate, Currency currency = Currency.PL) : base(bank, id, customer, number, interestRate, currency)
        {
        }
    }
}