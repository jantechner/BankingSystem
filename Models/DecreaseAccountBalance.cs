using System;

namespace Models
{
    public class DecreaseBalance : Operation
    {
        private double _amount;
        private Account _account;

        public DecreaseBalance(Account account, double amount)
        {
            _amount = amount;
            _account = account;
        }

        public override void Execute()
        {
            if (_account is PlainAccount)
            {
                if (_account.Balance < _amount)
                    throw new Exception("Not enough funds");
                _account.Balance -= _amount;
            }
            else if (_account is DebitAccount a)
            {
                a.Balance -= _amount;
                if (a.Balance >= 0) return;
                a.Debit = a.Debit == 0.0 ? Math.Abs(a.Balance) : a.Debit + _amount;
                a.Balance = 0;
            }
        }
    }
}