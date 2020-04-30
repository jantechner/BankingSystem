using System;

namespace Models
{
    public class AccountsReport : Report
    {
        public AccountsReport(Bank bank) : base(bank)
        {
        }

        public override Report Create()
        {
            //TODO implement actual report generating
            Console.WriteLine("New Account Report generated");
            return this;
        }
    }
}