using System;

namespace Models
{
    public class AssetsReport : Report
    {
        public AssetsReport(Bank bank) : base(bank)
        {
        }

        public override Report Create()
        {
            //TODO implement actual report generating
            Console.WriteLine("New Assets Report generated");
            return this;
        }
    }
}