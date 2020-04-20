using System;

namespace Models
{
    public class Account
    {
        private readonly Customer owner;
        private readonly string number;
        private double balance = 0;
        //private readonly DateTime openingDate = DateTime.Today;
        //TODO currency
        //private readonly Currency currency = Currency.PLN;

        public Account(Customer _owner, string _number)
        {
            owner = _owner;
            number = _number;
        }
        public void takeMoney(double amount)
        {
            if (balance < amount)
                throw new SystemException("Not enough funds");

            balance -= amount;
        }
        public void giveMoney(double amount)
        {
            balance += amount;
        }
        public void getBalance()
        {
            Console.WriteLine(balance.ToString());
        }

        public override string ToString()
        {
            return $"Owner: {owner}\nNumber: {number}";
        }
    }
}