using System;

namespace Models
{
    public class DecreaseBalance : Operation
    {
        private double _amount;
        private Account _account;

        public DecreaseBalance(Account account, double amount)
        {
            _amount = amount;
            _account = account;
        }

        public override bool Execute()
        {
            _account.DecreaseBalance(_amount);
            return true;
        }
    }
}