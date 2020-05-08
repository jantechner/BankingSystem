namespace Models
{
    public class Deposit : IReportable
    {
        public double Amount { get; }
        public IInterestMechanism InterestRate { get; }

        public Deposit(double amount, IInterestMechanism interestRate)
        {
            Amount = amount;
            InterestRate = interestRate;
        }

        public void Accept(Report report)
        {
            report.Create(this);
        }
    }
}