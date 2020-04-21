namespace Models
{
    public class AccountOperation : Operation
    {
        public Account Account { get; } // nie wiem czy potrzebne 
        public AccountOperation(string description, Account account) : base(description)
        {
            Account = account;
        }
    }
}