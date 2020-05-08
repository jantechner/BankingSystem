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
            Account.Balance -= amount;
            if (Account.Balance >= 0) return;
            _debit = _debit == 0.0 ? Math.Abs(Account.Balance) : _debit + amount;
            Account.Balance = 0;
        }

        public override void IncreaseBalance(double amount)
        {
            _debit -= amount;
            if (_debit >= 0) return;
            Account.Balance = Account.Balance == 0.0 ? Math.Abs(_debit) : Account.Balance + amount;
            _debit = 0;
        }

        public override void Accept(Report report)
        {
            report.Create(this);
        }

        public override string ToString()
        {
            return base.ToString() + $"\nDebit: {_debit}\n";
        }
    }
}