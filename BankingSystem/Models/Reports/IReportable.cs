namespace Models
{
    public interface IReportable
    {
        public void Accept(Report report);
    }
}