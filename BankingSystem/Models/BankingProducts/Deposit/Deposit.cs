namespace Models
{
    public class Deposit : IBankingProduct
    {
        public Account Account { get; }
        public double Amount { get; }
        public IInterestMechanism InterestRate { get; }

        public Deposit(Account account, double amount, IInterestMechanism interestRate)
        {
            Account = account;
            Amount = amount;
            InterestRate = interestRate;
        }

        public void Accept(Report report)
        {
            report.Create(this);
        }
    }
}