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
            var loan = new Loan(_account, _amount, _interestRate);
            _account.IncreaseBalance(_amount);
            Description += $", Balance after: {_account.Balance}";
            _account.Loans.Add(loan);
            _account.History.Add(this);
            loan.History.Add(this);
            return true;
        }
    }
}