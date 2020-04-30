using System;

namespace Models
{
    public abstract class Operation
    {
        public DateTime Date { get; } = DateTime.Now;
        public String Description { get; } 
        //TODO set operation description in Operation subclasses
        //TODO add executed operations to Bank and Account history

        public abstract bool Execute();
        public override string ToString()
        {
            return $"Operation - {Description} ({Date})";
        }
    }
}