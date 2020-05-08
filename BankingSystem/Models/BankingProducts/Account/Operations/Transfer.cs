namespace Models
{
    public enum TransferStatus
    {
        Created,
        Forwarded,
        Executed,
        Rejected
    }
    public abstract class Transfer : Operation
    {
        public string TargetAccountNumber { get; }
        public string SenderAccountNumber { get; }
        public double Amount { get; }
        public TransferStatus Status { get; set; }

        protected Transfer(string from, string to, double amount)
        {
            TargetAccountNumber = to;
            SenderAccountNumber = from;
            Amount = amount;
            Status = TransferStatus.Created;
        }

        public abstract override bool Execute();
        
        
    }
}