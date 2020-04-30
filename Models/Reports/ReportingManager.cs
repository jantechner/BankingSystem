namespace Models
{
    public class ReportingManager
    {
        public Report Generate(Report report)
        {
            return report.Create();
        }
        
        
    }
}