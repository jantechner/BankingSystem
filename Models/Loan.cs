namespace Models
{
    public class Loan
    {
        public double RemainingAmount { get; private set; }
        public InterestRate InterestRate { get; }

        public Loan(double remainingAmount, InterestRate interestRate)
        {
            RemainingAmount = remainingAmount;
            InterestRate = interestRate;
        }

        public void UpdateLoanAmount(double amount)
        {
            RemainingAmount -= amount;
        }
    }
}