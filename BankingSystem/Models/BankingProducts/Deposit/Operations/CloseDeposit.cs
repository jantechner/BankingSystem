using System;

namespace Models
{
    public class CloseDeposit : Operation
    {
        private readonly Deposit _deposit;

        public CloseDeposit(Deposit deposit)
        {
            _deposit = deposit;
            Description = "Close deposit";
        }

        public override bool Execute()
        {
            _deposit.Account.Bank.Execute(new CalculateInterest(_deposit));
            _deposit.Account.IncreaseBalance(_deposit.Amount);
            Description += $", Balance after: {_deposit.Account.Balance}";
            _deposit.Amount = 0;
            _deposit.History.Add(this);
            _deposit.Account.History.Add(this);
            return true;
        }
    }
}