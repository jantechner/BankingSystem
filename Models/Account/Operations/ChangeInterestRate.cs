namespace Models
{
    public class ChangeInterestRate: Operation
    {
        private Account _account;
        private InterestMechanism _interestRate;

        public ChangeInterestRate(Account account, InterestMechanism interestRate)
        {
            _account = account;
            _interestRate = interestRate;
        }

        public override bool Execute()
        {
            _account.InterestRate = _interestRate;
            return true;
        }
    }
}