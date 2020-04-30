using System;

namespace Models
{
    public class IncreaseBalance : Operation
    {
        private double _amount;
        private Account _account;

        public IncreaseBalance(Account account, double amount)
        {
            _amount = amount;
            _account = account;
        }

        public override bool Execute()
        {
            _account.IncreaseBalance(_amount);
            return true;
        }
    }
}