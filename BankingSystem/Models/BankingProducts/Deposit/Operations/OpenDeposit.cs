using System;

namespace Models
{
    public class OpenDeposit : Operation
    {
        private readonly Account _account;
        private readonly double _amount;
        private readonly IInterestMechanism _interestRate;

        public OpenDeposit(Account account, double amount, IInterestMechanism interestRate)
        {
            _account = account;
            _amount = amount;
            _interestRate = interestRate;
            Description = "Opening a deposit, amount: " + amount;
        }

        public override bool Execute()
        {
            if (_account.Balance < _amount) throw new Exception("Account balance too small to open this deposit");
            var deposit = new Deposit(_account, _amount, _interestRate);
            _account.DecreaseBalance(_amount);
            _account.Deposits.Add(deposit);
            _account.Bank.AddNewProduct(_account.Owner, deposit);
            Description += $", Balance after: {_account.Balance}";
            _account.History.Add(this);
            deposit.History.Add(this);

            return true;
        }
    }
}