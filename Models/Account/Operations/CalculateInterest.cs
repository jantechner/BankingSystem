using System;

namespace Models
{
    public class CalculateInterest : Operation
    {
        private Account _account;

        public CalculateInterest(Account account)
        {
            _account = account;
            Description = "Calculate interest rate";
        }

        public override bool Execute()
        {
            _account.History.Add(this);
            var interest = _account.InterestRate.Calculate(_account.Balance);
            Console.WriteLine(interest);
            return true;
        }
    }
}