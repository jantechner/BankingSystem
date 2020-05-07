using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public abstract class Report
    {
        public DateTime Date { get; } = DateTime.Now;

        public List<String> Content { get; } = new List<string>();

        public abstract void Create(PlainAccount account);
        public abstract void Create(DebitAccount account);

        public void Create(Loan loan)
        {
            Content.Add("\tLoan report - remaining amount: " + loan.RemainingAmount);
        }

        public abstract void Create(Operation operation);

        public override string ToString()
        {
            return Content.Aggregate("", (current, content) => current + (content + "\n"));
        }
    }
}