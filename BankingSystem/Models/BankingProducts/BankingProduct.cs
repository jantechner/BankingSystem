using System.Collections.Generic;

namespace Models
{
    public abstract class BankingProduct : IReportable
    {
        public abstract void Accept(Report report);

        public abstract List<Operation> History { get; }
        public abstract IInterestMechanism InterestRate { get; set; }
    }
}