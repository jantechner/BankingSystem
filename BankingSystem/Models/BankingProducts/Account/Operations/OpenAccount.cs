using System;

namespace Models
{
    public class OpenAccount<T> : Operation
    {
        private readonly Bank _bank;
        private readonly Customer _customer;

        public OpenAccount(Customer customer, Bank bank)
        {
            _bank = bank;
            _customer = customer;
            Description = $"Opening new {typeof(T).Name} for {customer.Name} {customer.Surname}";
        }

        public override bool Execute()
        {
            Account newAccount;
            if (typeof(T) == typeof(PlainAccount))
            {
                newAccount = new PlainAccount(_bank, Account.NextAccountId(), _customer, _customer.Pesel,
                    new InterestRate(0.05, 24, 6));
            }
            else if (typeof(T) == typeof(DebitAccount))
            {
                var account = new PlainAccount(_bank, Account.NextAccountId(), _customer, _customer.Pesel,
                    new InterestRate(0.05, 24, 6));
                newAccount = new DebitAccount(account);
            }
            else
            {
                throw new Exception("incorrect ");
            }

            _bank.AddNewAccount(_customer, newAccount);
            newAccount.History.Add(this);
            return true;
        }
    }
}