using System;

namespace Models
{
    public abstract class Operation
    {
        public DateTime Date { get; } = DateTime.Now;
        public String Description { get; }

        public abstract void Execute();
        public override string ToString()
        {
            return $"Operation - {Description} ({Date})";
        }
    }
}