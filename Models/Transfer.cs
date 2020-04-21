using System;

namespace Models
{
    public class Transfer : Operation
    {
        public enum TransferStatus
        {
            Pending,
            Executed // TODO not used
        }

        public String From { get; }

        public String To { get; }

        public TransferStatus Status { get; }

        public double Amount { get; }

        public Transfer(String from, String to, double amount, string description) : base(description)
        {
            From = from;
            To = to;
            Status = TransferStatus.Pending;
            Amount = amount;
        }
    }
}