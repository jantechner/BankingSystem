using System;
using System.Collections.Generic;
using System.Data;

namespace Models
{
    public class AccountsReport : Report
    {
        private bool _isInsideAccount = false;
        public AccountsReport()
        {
            Content.Add("Accounts report:");
        }

        public override void Create(RegularAccount account)
        {
            Content.AddRange(new List<string> {"Account:", "\tNumber " + account.Number});
            AddAccountDetails(account);
        }

        public override void Create(DebitAccount account)
        {
            Content.AddRange(new List<string> {"Debit account:", "\tNumber " + account.Number});
            AddAccountDetails(account);
        }
        
        public override void Create(Loan loan)
        {
            if (_isInsideAccount) Content.Add("\t\tLoan - remaining amount: " + loan.Amount);
        }

        public override void Create(Deposit deposit)
        {
            if (_isInsideAccount) Content.Add($"\t\tDeposit - amount: {deposit.Amount}, interest rate: {deposit.InterestRate}");
        }

        public override void Create(Operation operation)
        {
            Content.Add("\t\t" + operation);
        }

        private void AddAccountDetails(Account account)
        {
            _isInsideAccount = true;
            Content.Add("\tLoans");
            foreach (var loan in account.Loans)
            {
                loan.Accept(this);
            }
            Content.Add("\tDeposits");
            foreach (var deposit in account.Deposits)
            {
                deposit.Accept(this);
            }
            Content.Add("\tOperations");
            foreach (var operation in account.History)
            {
                operation.Accept(this);
            }

            _isInsideAccount = false;
        }
        
        
    }
}