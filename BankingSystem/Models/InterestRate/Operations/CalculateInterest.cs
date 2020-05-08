using System;

namespace Models
{
    public class CalculateInterest : Operation
    {
        private readonly BankingProduct _product;

        public CalculateInterest(BankingProduct product)
        {
            _product = product;
            Description = "Calculate interest rate";
        }

        public override bool Execute()
        {
            _product.History.Add(this);
            var interest = _product.InterestRate.Calculate(_product);

            switch (_product)
            {
                case Account account:
                    account.Balance += interest;
                    break;
                case Deposit deposit:
                    deposit.Amount += interest;
                    break;
                case Loan loan:
                    loan.Amount += interest;
                    break;
            }
            return true;
        }
    }
}