using System.Collections.Generic;

namespace Models
{
    public class Deposit : BankingProduct
    {
        public Account Account { get; }
        public double Amount { get; set; }
        public sealed override IInterestMechanism InterestRate { get; set; }
        public override List<Operation> History { get; } = new List<Operation>();

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