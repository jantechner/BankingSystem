namespace Models
{
    public class OpenDeposit : Operation
    {
        private readonly Account _account;
        private readonly double _amount;
        private readonly IInterestMechanism _interestRate;

        public OpenDeposit(Account account, double amount, IInterestMechanism interestRate)
        {
            _account = account;
            _amount = amount;
            _interestRate = interestRate;
            Description = "Opening a deposit, amount: " + amount;
        }

        public override bool Execute()
        {
            _account.History.Add(this);
            _account.Deposits.Add(new Deposit(_account, _amount, _interestRate));
            return true;
        }
        
    }
}