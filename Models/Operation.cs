using System;

namespace Models
{
    public class Operation
    {
        public DateTime Date { get; } = DateTime.Now;

        public String Description { get; }

        public Operation(string description)
        {
            Description = description;
        }

        public override string ToString()
        {
            return "Operation - {Description} ({Date})";
        }
    }
}