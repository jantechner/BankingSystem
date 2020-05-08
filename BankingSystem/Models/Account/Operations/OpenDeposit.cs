namespace Models
{
    public class OpenDeposit : Operation
    {
        private Account _account;
        private double _amount;

        public OpenDeposit(Account account, double amount)
        {
            _account = account;
            _amount = amount;
            Description = "Opening a deposit for " + amount;
        }

        public override bool Execute()
        {
            _account.History.Add(this);
            _account.Deposits.Add(new Deposit(_amount, new InterestRate(0.03, 36, 12)));
            return true;
        }
        
    }
}