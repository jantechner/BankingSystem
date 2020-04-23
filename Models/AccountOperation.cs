namespace Models
{
    public class AccountOperation : Operation
    {
        public Account Account { get; } // nie wiem czy potrzebne 
        public AccountOperation(Account account)
        {
            Account = account;
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}