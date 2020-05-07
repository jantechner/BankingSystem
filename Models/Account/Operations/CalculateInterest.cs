using System;

namespace Models
{
    public class CalculateInterest : Operation
    {
        private Account _account;

        public CalculateInterest(Account account)
        {
            _account = account;
        }

        public override bool Execute()
        {
            var interest = _account.InterestRate.Calculate(_account.Balance);
            Console.WriteLine(interest);
            return true;
        }
    }
}