using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public abstract class Report
    {
        public DateTime Date { get; } = DateTime.Now;

        protected List<string> Content { get; } = new List<string>();

        public abstract void Create(RegularAccount account);
        public abstract void Create(DebitAccount account);
        public abstract void Create(Loan loan);
        public abstract void Create(Deposit deposit);
        public abstract void Create(Operation operation);

        public override string ToString()
        {
            return Content.Aggregate("", (current, content) => current + (content + "\n"));
        }
    }
}