namespace Models
{
    public class RaiseLoan : Operation
    {
        private Account _account;
        private double _amount;

        public RaiseLoan(Account account, double amount)
        {
            _account = account;
            _amount = amount;
            Description = "Raising a loan for " + amount;
        }

        public override bool Execute()
        {
            _account.History.Add(this);
            _account.Loans.Add(new Loan(_account, _amount, new InterestRate(0.1, 24, 12)));
            return true;
        }
    }
}