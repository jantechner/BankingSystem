using System;
using System.Collections;

namespace Models
{
    public class Account
    {
        private readonly Customer _owner;
        private readonly DateTime _openingDate = DateTime.Now;
        private readonly Currency _currency;
        private double _balance;
        private readonly string _number; // a to do czego jest?
        // private List<Deposit> deposits = 
        private IList _loans = new LoansStore();

        public Account(Customer customer, string number, Currency currency = Currency.PL)
        {
            _owner = customer;
            _currency = currency;
            _number = number;
        }

        public void WithdrawMoney(double amount)
        {
            if (_balance < amount)
                throw new SystemException("Not enough funds");

            _balance -= amount;
        }

        public void BankMoney(double amount)
        {
            _balance += amount;
        }

        public double GetBalance()
        {
            return _balance;
        }

        public override string ToString()
        {
            return $"Owner: {_owner}\n" +
                   $"Number: {_number}\n" +
                   $"Opening date: {_openingDate}\n" +
                   $"Currency: {_currency}\n" +
                   $"Balance: {_balance}";
        }
    }
}