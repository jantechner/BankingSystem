using System;

namespace Models
{
    public abstract class Report
    {
        public DateTime Date { get; }

        public String Entity { get; }

        public Bank _bank;

        public Report(Bank bank)
        {
            _bank = bank;
        }

        public abstract Report Create();
    }
}