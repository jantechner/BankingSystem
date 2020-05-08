using System;

namespace Models
{
    public class OpenAccount<T> : Operation
    {
        private Bank _bank;
        private Customer _customer;
        private Type _accountType;

        public OpenAccount(Customer customer, Bank bank)
        {
            _bank = bank;
            _customer = customer;
            _accountType = typeof(T);
        }

        public override bool Execute()
        {
            Account newAccount;
            if (typeof(T) == typeof(PlainAccount))
            {
                newAccount = new PlainAccount(_bank, Bank.NextAccountId(), _customer, _customer.Pesel,
                    new InterestRate(0.05, 24, 6));
            }
            else if (typeof(T) == typeof(DebitAccount))
            {
                var account = new PlainAccount(_bank, Bank.NextAccountId(), _customer, _customer.Pesel,
                    new InterestRate(0.05, 24, 6));
                newAccount = new DebitAccount(account);
            }
            else
            {
                throw new Exception("incorrect ");
            }
            _bank.AddNewAccount(_customer, newAccount);

            Console.WriteLine($"Opening account for {_customer}");
            return true;
        }
    }
}