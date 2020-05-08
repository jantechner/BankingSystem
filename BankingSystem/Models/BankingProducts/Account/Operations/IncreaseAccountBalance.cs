using System;

namespace Models
{
    public class IncreaseBalance : Operation
    {
        private readonly double _amount;
        private readonly Account _account;

        public IncreaseBalance(Account account, double amount)
        {
            _amount = amount;
            _account = account;
            Description = "Increase balance by " + amount;
        }

        public override bool Execute()
        {
            _account.History.Add(this);
            _account.IncreaseBalance(_amount);
            Description += $", Balance after: {_account.Balance}";
            return true;
        }
    }
}