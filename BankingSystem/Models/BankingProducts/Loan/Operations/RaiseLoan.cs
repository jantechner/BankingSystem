namespace Models
{
    public class RaiseLoan : Operation
    {
        private readonly Account _account;
        private readonly double _amount;
        private readonly IInterestMechanism _interestRate;

        public RaiseLoan(Account account, double amount, IInterestMechanism interestRate)
        {
            _account = account;
            _amount = amount;
            _interestRate = interestRate;
            Description = "Raising a loan, amount: " + amount;
        }

        public override bool Execute()
        {
            _account.History.Add(this);
            _account.Loans.Add(new Loan(_account, _amount, _interestRate));
            return true;
        }
    }
}