using System;

namespace Models
{
    public class Transfer : Operation
    {
        public enum Status
        {
            Created,
            Forwarded,
            Executed
        }

        private readonly Account _fromAccount;
        private Account _toAccount;
        private readonly string _toNumber;
        private readonly double _amount;
        private Status _status;

        public Transfer(Account from, String to, double amount)
        {
            _fromAccount = from;
            _toNumber = to;
            _status = Status.Created;
            _amount = amount;
        }

        public void SetTargetAccount(Account account)
        {
            _toAccount = account;
        }

        public string GetTargetNumber()
        {
            return _toNumber;
        }

        public override bool Execute()
        {
            if (_status == Status.Created)
            {
                _fromAccount.Bank.Execute(new DecreaseBalance(_fromAccount, _amount));
                _status = Status.Forwarded;
                if (_fromAccount.Bank.HasAccount(_toNumber, out _toAccount))
                {
                    _status = Status.Executed;
                    _fromAccount.Bank.Execute(new IncreaseBalance(_toAccount, _amount));
                }
                else
                {
                    InterBankPaymentManager.OrderToTransfer(this);
                }
            }
            else
            {
                _status = Status.Executed;
                _toAccount.Bank.Execute(new IncreaseBalance(_toAccount, _amount));
            }

            return true;
        }
    }
}