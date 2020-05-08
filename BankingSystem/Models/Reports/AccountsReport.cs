using System;
using System.Collections.Generic;
using System.Data;

namespace Models
{
    public class AccountsReport : Report
    {
        public AccountsReport()
        {
            Content.Add("Accounts report:");
        }

        public override void Create(PlainAccount account)
        {
            Content.AddRange(new List<string> {"Account:", "\tNumber " + account.Number});
            AddAccountDetails(account);
        }

        public override void Create(DebitAccount account)
        {
            Content.AddRange(new List<string> {"Debit account:", "\tNumber " + account.Number});
            AddAccountDetails(account);
        }

        public override void Create(Operation operation)
        {
            Content.Add("\t\t" + operation);
        }

        private void AddAccountDetails(Account account)
        {
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
        }
    }
}