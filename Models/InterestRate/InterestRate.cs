namespace Models
{
    public class InterestRate : InterestMechanism
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

        public double Calculate(double balance)
        {
            //TODO more sophisticated calculations 
            return balance * _value;
        }

        public override string ToString()
        {
            return $"({_value * 100}% for {_period} months, cap. period {_capitalizationPeriod})";
        }
    }
}