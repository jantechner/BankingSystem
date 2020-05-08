namespace Models
{
    public class Loan : IReportable
    {
        public double RemainingAmount { get; set; }
        public IInterestMechanism InterestRate { get; }
        
        //TODO obliczanie rzeczywistej wysokości pożyczki uwzględniając stopy procentowe

        public Loan(double remainingAmount, IInterestMechanism interestRate)
        {
            RemainingAmount = remainingAmount;
            InterestRate = interestRate;
        }

        public void RepayLoan(double amount)
        {
            RemainingAmount -= amount;
        }

        public override string ToString()
        {
            return $"Loan: {RemainingAmount}, InterestRate: {InterestRate}\n";
        }

        public void Accept(Report report)
        {
            report.Create(this);
        }
    }
}