using System;

namespace Models
{
    public class DebitAccount : Account
    {
        public DebitAccount(int id, Customer customer, string number, InterestRate interestRate,
            Currency currency = Currency.PL)
            : base(id, customer, number, interestRate, currency)
        {
        }

        public double Debit { get; private set; }

        override public void WithdrawMoney(double amount)
        {
            Balance -= amount;
            if (Balance >= 0) return;
            Debit = Debit == 0.0 ? Math.Abs(Balance) : Debit + amount;
            Balance = 0;
        }

        override public void DepositMoney(double amount)
        {
            Debit -= amount;
            if (Debit >= 0) return;
            Balance = Balance == 0.0 ? Math.Abs(Debit) : Balance + amount;
            Debit = 0;
        }


        public override string ToString()
        {
            return $"ID: {id}\n" +
                   $"Owner: {owner}\n" +
                   $"Number: {Number}\n" +
                   $"Opening date: {OpeningDate}\n" +
                   $"Currency: {Currency}\n" +
                   $"Balance: {Balance}\n" +
                   $"Debit: {Debit}\n" +
                   $"InterestRate: {InterestRate}";
        }
    }
}