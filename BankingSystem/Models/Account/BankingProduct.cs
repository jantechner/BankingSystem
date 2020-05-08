namespace Models
{
    public abstract class BankingProduct : IReportable
    {
        public abstract void Accept(Report report);
    }
}