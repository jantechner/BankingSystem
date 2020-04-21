namespace Models
{
    public class InterestRate
    {
        public double Value { get; }
        public int Period { get; } // in months
        public int CapitalizationPeriod { get; } // also in months

        public InterestRate(double value, int period, int capitalizationPeriod)
        {
            Value = value;
            Period = period;
            CapitalizationPeriod = capitalizationPeriod;
        }
    }
}