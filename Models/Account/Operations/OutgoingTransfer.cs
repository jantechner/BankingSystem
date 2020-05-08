namespace Models
{
    public class OutgoingTransfer : Transfer
    {
        public Account FromAccount { get; }

        public OutgoingTransfer(Account account, string to, double amount) : base(account.Number, to, amount)
        {
            FromAccount = account;
            FromAccount.History.Add(this);
            Description = $"Outgoing transfer to account {TargetAccountNumber} for {Amount} {FromAccount.Currency}";
        }

        public override bool Execute()
        {
            var bank = FromAccount.Bank;
            bank.Execute(new DecreaseBalance(FromAccount, Amount));
            _status = Status.Forwarded;
            if (bank.HasAccount(TargetAccountNumber, out var targetAccount))
            {
                bank.Execute(new IncomingTransfer(SenderAccountNumber, targetAccount, Amount));
                _status = Status.Executed;
            }
            else
            {
                InterBankPaymentManager.OrderToTransfer(this);
            }

            return true;
        }

        public void Confirm()
        {
            _status = Status.Executed;
            Description += " - Confirmed";
        }

        public void Reject()
        {
            _status = Status.Rejected;
            Description += " - Rejected";
        }
    }
}