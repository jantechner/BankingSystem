namespace Models
{
    public class RepayLoan : Operation
    {
        private readonly Account _account;
        private readonly Loan _loan;
        private readonly int _amount;

        public RepayLoan(Account account, Loan loan, int amount)
        {
            _account = account;
            _loan = loan;
            _amount = amount;
            Description = "Repaying a loan, amount: " + amount;
        }

        public override bool Execute()
        {
            _account.History.Add(this);
            _loan.RemainingAmount -= _amount;
            return true;
        }
    }
}