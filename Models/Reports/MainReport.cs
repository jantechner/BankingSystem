using System;

namespace Models
{
    public class MainReport : Report
    {
        public MainReport(Bank bank) : base(bank)
        {
        }

        public override Report Create()
        {
            //TODO implement actual report generating
            Console.WriteLine("New Main Report generated");
            return this;
        }
    }
}