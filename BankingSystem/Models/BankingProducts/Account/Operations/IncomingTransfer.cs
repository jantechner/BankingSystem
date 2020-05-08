namespace Models
{
    public class IncomingTransfer : Transfer
    {
        private readonly Account _toAccount;
        
        public IncomingTransfer(string from, Account account, double amount) : base(from, account.Number, amount)
        {
            _toAccount = account;
            _toAccount.History.Add(this);
            Description = $"Incoming transfer from account {from}, amount: {amount}";
        }

        public override bool Execute()
        {
            _toAccount.Bank.Execute(new IncreaseBalance(_toAccount, Amount));
            Status = TransferStatus.Executed;
            return true;
        }
    }
}