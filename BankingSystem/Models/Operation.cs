using System;

namespace Models
{
    public abstract class Operation : IReportable
    {
        protected DateTime Date { get; } = DateTime.Now;
        protected string Description;

        public abstract bool Execute();

        public override string ToString()
        {
            return $"{Description} ({Date})";
        }

        public void Accept(Report report)
        {
            report.Create(this);
        }
    }
}