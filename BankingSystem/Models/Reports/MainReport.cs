using System;

namespace Models
{
    public class MainReport : Report
    {
        public MainReport()
        {
            Content.Add("Main report:");
        }

        public override void Create(PlainAccount account)
        {
            Content.Add("Report from account with number " + account.Number);
        }

        public override void Create(DebitAccount account)
        {
            Content.Add("Report from debit account with number " + account.Number);
        }

        public override void Create(Operation operation)
        {
        }
    }
}