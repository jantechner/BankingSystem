using System;

namespace Models
{
    public class IncreaseBalance : Operation
    {
        private double _amount;
        private Account _account;

        public IncreaseBalance(Account account, double amount)
        {
            _amount = amount;
            _account = account;
        }

        public override bool Execute()
        {
            _account.History.Add(this);
            if (_account is PlainAccount)
            {
                _account.Balance += _amount;
            }
            else if (_account is DebitAccount a)
            {
                a.Debit -= _amount;
                if (a.Debit >= 0) return true;
                a.Balance = a.Balance == 0.0 ? Math.Abs(a.Debit) : a.Balance + _amount;
                a.Debit = 0;
            }

            return true;
        }
    }
}