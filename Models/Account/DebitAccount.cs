using System;

namespace Models
{
    public class DebitAccount : AccountDecorator
    {
        public DebitAccount(Account account) : base(account)
        {
        }

        private double _debit;

        public override void DecreaseBalance(double amount)
        {
            account.Balance -= amount;
            if (account.Balance >= 0) return;
            _debit = _debit == 0.0 ? Math.Abs(account.Balance) : _debit + amount;
            account.Balance = 0;
        }

        public override void IncreaseBalance(double amount)
        {
            _debit -= amount;
            if (_debit >= 0) return;
            account.Balance = account.Balance == 0.0 ? Math.Abs(_debit) : account.Balance + amount;
            _debit = 0;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nDebit: {_debit}\n";
        }
    }
}