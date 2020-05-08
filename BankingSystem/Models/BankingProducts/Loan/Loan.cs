namespace Models
{
    public class Loan : IBankingProduct
    {
        public Account Account { get; }
        public double RemainingAmount { get; set; }
        public IInterestMechanism InterestRate { get; }
        
        //TODO obliczanie rzeczywistej wysokości pożyczki uwzględniając stopy procentowe

        public Loan(Account account, double amount, IInterestMechanism interestRate)
        {
            Account = account;
            RemainingAmount = amount;
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