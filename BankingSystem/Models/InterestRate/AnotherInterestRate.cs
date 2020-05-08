namespace Models
{
    public class AnotherInterestRate : IInterestMechanism
    {
        private double _value;

        public AnotherInterestRate(double value)
        {
            _value = value;
        }

        public double Calculate(BankingProduct product)
        {
            return product switch
            {
                Account account => account.Balance * _value,
                Deposit deposit => deposit.Amount * _value,
                Loan loan => loan.Amount * _value,
                _ => 0
            };
        }
        
        public override string ToString()
        {
            return $"({_value * 100}%)";
        }
    }
}