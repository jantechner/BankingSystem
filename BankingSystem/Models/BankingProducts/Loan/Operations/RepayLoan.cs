namespace Models
{
    public class RepayLoan : Operation
    {
        private readonly Loan _loan;
        private readonly int _amount;

        public RepayLoan(Loan loan, int amount)
        {
            _loan = loan;
            _amount = amount;
            Description = "Repaying a loan, amount: " + amount;
        }

        public override bool Execute()
        {
            _loan.Account.DecreaseBalance(_amount);
            _loan.Amount -= _amount;
            Description += $", Balance after: {_loan.Account.Balance}";

            _loan.Account.History.Add(this);
            _loan.History.Add(this);
            return true;
        }
    }
}