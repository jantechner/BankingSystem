using System.Collections;

namespace Models
{
    public class Bank
    {
        public string Name { get; }
        public string CountryCode { get; }
        public string SWIFT { get; }
        private IDictionary accounts = new AccountsStore();
        public IEnumerable InterestRates { get; }



        public ReportingManager ReportingManager { get; }
        public void openAccount(Customer customer)
        {
            accounts.Add(customer, this);
            System.Console.WriteLine($"Opening account for {customer.ToString()}");
        }
    }
}