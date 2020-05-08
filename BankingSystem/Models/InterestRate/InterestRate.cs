using System;

namespace Models
{
    public class InterestRate : IInterestMechanism
    {
        private double _value { get; }
        private int _period { get; } // in months
        private int _capitalizationPeriod { get; } // also in months

        public InterestRate(double value, int period, int capitalizationPeriod)
        {
            _value = value;
            _period = period;
            _capitalizationPeriod = capitalizationPeriod;
        }

        public double Calculate(BankingProduct product)
        {
            var interest = product switch
            {
                Account account => account.Balance * _value,
                Deposit deposit => deposit.Amount * _value,
                Loan loan => loan.Amount * _value,
                _ => 0
            };
            return interest;
        }

        public override string ToString()
        {
            return $"({_value * 100}% for {_period} months, cap. period {_capitalizationPeriod})";
        }
    }
}