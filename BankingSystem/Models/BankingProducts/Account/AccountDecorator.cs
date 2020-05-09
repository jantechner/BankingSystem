using System.Collections.Generic;

namespace Models
{
    public class AccountDecorator : Account
    {
        protected readonly Account Account;
        
        protected AccountDecorator(Account account)
        {
            Account = account;
        }

        public override Customer Owner => Account.Owner;
        public override Bank Bank => Account.Bank;
        public override string Number => Account.Number;
        public override Currency Currency => Account.Currency;
        public override IInterestMechanism InterestRate 
        { 
            get => Account.InterestRate;
            set => Account.InterestRate = value;
        }
        public override double Balance
        {
            get => Account.Balance;
            set => Account.Balance = value;
        }
        public override IList<Loan> Loans => Account.Loans;
        public override IList<Deposit> Deposits => Account.Deposits;
        public override List<Operation> History => Account.History;

        public override void IncreaseBalance(double amount)
        {
            Account.IncreaseBalance(amount);
        }
        
        public override void DecreaseBalance(double amount)
        {
            Account.DecreaseBalance(amount);
        }
        
        public override void Accept(Report report)
        {
        }

        public override string ToString()
        {
            return Account.ToString();
        }
    }
}