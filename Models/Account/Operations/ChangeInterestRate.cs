namespace Models
{
    public class ChangeInterestRate: Operation
    {
        private Account _account;
        private IInterestMechanism _interestRate;

        public ChangeInterestRate(Account account, IInterestMechanism interestRate)
        {
            _account = account;
            _interestRate = interestRate;
            Description = "Change interest rate to " + interestRate;
        }

        public override bool Execute()
        {
            _account.History.Add(this);
            _account.InterestRate = _interestRate;
            return true;
        }
    }
}