using System;

namespace Models
{
    public abstract class Transfer : Operation
    {
        protected enum Status
        {
            Created,
            Forwarded,
            Executed,
            Rejected
        }

        public string TargetAccountNumber { get; }
        public string SenderAccountNumber { get; }
        public double Amount { get; }
        protected Status _status;

        protected Transfer(string from, string to, double amount)
        {
            TargetAccountNumber = to;
            SenderAccountNumber = from;
            Amount = amount;
            _status = Status.Created;
        }

        public abstract override bool Execute();
        
        
    }
}