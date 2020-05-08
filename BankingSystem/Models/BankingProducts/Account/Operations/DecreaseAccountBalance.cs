using System;

namespace Models
{
    public class DecreaseBalance : Operation
    {
        private readonly double _amount;
        private readonly Account _account;

        public DecreaseBalance(Account account, double amount)
        {
            _amount = amount;
            _account = account;
            Description = "Decrease balance by " + amount;
        }

        public override bool Execute()
        {
            _account.History.Add(this);
            _account.DecreaseBalance(_amount);
            return true;
        }
    }
}