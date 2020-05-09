using System;

namespace Models
{
    public class ProductsReport : Report
    {
        public ProductsReport()
        {
            Content.Add("Products report:");
        }

        public override void Create(RegularAccount account)
        {
            Content.Add(
                $"Credit Account, number: {account.Number}, owner: {account.Owner.Name} {account.Owner.Surname}");
        }

        public override void Create(DebitAccount account)
        {
            Content.Add(
                $"Debit Account, number: {account.Number}, owner: {account.Owner.Name} {account.Owner.Surname}");
        }

        public override void Create(Loan loan)
        {
            Content.Add(
                $"Loan, owner: {loan.Account.Owner.Name} {loan.Account.Owner.Surname}, account: {loan.Account.Number}");
        }

        public override void Create(Deposit deposit)
        {
            Content.Add(
                $"Deposit, owner: {deposit.Account.Owner.Name} {deposit.Account.Owner.Surname}, account: {deposit.Account.Number}");
        }

        public override void Create(Operation operation)
        {
        }
    }
}