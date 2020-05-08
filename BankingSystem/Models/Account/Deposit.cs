namespace Models
{
    public class Deposit : BankingProduct
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

        public override void Accept(Report report)
        {
            report.Create(this);
        }
    }
}