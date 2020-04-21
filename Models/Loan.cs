namespace Models
{
    public class Loan
    {
        public double RemainingAmount { get; private set; }
        public InterestRate InterestRate { get; }
        
        //TODO obliczanie rzeczywistej wysokości pożyczki uwzględniając stopy procentowe

        public Loan(double remainingAmount, InterestRate interestRate)
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
    }
}