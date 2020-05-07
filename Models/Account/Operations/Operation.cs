using System;

namespace Models
{
    public abstract class Operation : IReportable
    {
        public DateTime Date { get; } = DateTime.Now;
        public string Description { get; set; } 
        //TODO set operation description in Operation subclasses
        //TODO add executed operations to Bank and Account history

        public abstract bool Execute();
        public override string ToString()
        {
            return $"Operation - {Description} ({Date})";
        }

        public void Accept(Report report)
        {
            report.Create(this);
        }
    }
}