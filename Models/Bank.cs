namespace Models
{
    public class Bank
    {
        public void openAccount(Customer customer)
        {
            System.Console.WriteLine($"Opening account for {customer.ToString()}");
        }
    }
}