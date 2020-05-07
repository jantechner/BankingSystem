namespace Models
{
    public class AnotherInterestRate : InterestMechanism
    {
        private double _value;

        public AnotherInterestRate(double value)
        {
            _value = value;
        }

        public double Calculate(double balance)
        {
            //TODO more sophisticated calculations
            return balance * _value;
        }
    }
}