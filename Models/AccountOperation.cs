namespace Models
{
    public class AccountOperation : Operation
    {
        public Account Account { get; }
        public AccountOperation(string description, Account account) : base(description)
        {
            Account = account;
        }
    }
}