using System;
using System.Collections.Generic;

namespace Models
{
    public class AccountDecorator : Account
    {
        protected Account account;

        public override Bank Bank => account.Bank;
        public override Currency Currency => account.Currency;
        public override string Number => account.Number;
        public override IList<Loan> Loans => account.Loans;
        public override List<Operation> History => account.History;

        public override double Balance
        {
            get => account.Balance;
            set => account.Balance = value;
        }

        public override InterestMechanism InterestRate 
        { 
            get => account.InterestRate;
            set => account.InterestRate = value;
        }

        protected AccountDecorator(Account account)
        {
            this.account = account;
            Console.WriteLine("INTEREST RATE" + account.InterestRate);
        }

        public override void DecreaseBalance(double amount)
        {
            account.DecreaseBalance(amount);
        }

        public override void IncreaseBalance(double amount)
        {
            account.IncreaseBalance(amount);
        }

        public override string ToString()
        {
            return account.ToString();
        }
    }
}