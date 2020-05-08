namespace Models
{
    public class OutgoingTransfer : Transfer
    {
        public Account FromAccount { get; }

        public OutgoingTransfer(Account account, string to, double amount) : base(account.Number, to, amount)
        {
            FromAccount = account;
            FromAccount.History.Add(this);
            Description = $"Outgoing transfer to account {TargetAccountNumber}, amount: {amount}";
        }

        public override bool Execute()
        {
            var bank = FromAccount.Bank;
            bank.Execute(new DecreaseBalance(FromAccount, Amount));
            Status = TransferStatus.Forwarded;
            if (bank.HasAccount(TargetAccountNumber, out var targetAccount))
            {
                bank.Execute(new IncomingTransfer(SenderAccountNumber, targetAccount, Amount));
                Status = TransferStatus.Executed;
            }
            else
            {
                InterBankPaymentManager.OrderToTransfer(this);
            }

            return true;
        }

        public override string ToString()
        {
            return $"{Description} - {Status} ({Date})";
        }
    }
}