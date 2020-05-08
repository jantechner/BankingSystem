using System.Collections.Generic;

namespace Models
{
    public class Loan : BankingProduct
    {
        public Account Account { get; }
        public double Amount { get; set; }
        public sealed override IInterestMechanism InterestRate { get; set; }
        public override List<Operation> History { get; } = new List<Operation>();

        //TODO obliczanie rzeczywistej wysokości pożyczki uwzględniając stopy procentowe

        public Loan(Account account, double amount, IInterestMechanism interestRate)
        {
            Account = account;
            Amount = amount;
            InterestRate = interestRate;
        }

        public void RepayLoan(double amount)
        {
            Amount -= amount;
        }

        public override string ToString()
        {
            return $"Loan: {Amount}, InterestRate: {InterestRate}\n";
        }

        public override void Accept(Report report)
        {
            report.Create(this);
        }
    }
}