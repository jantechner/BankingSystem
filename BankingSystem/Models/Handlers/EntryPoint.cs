namespace Models.Handlers
{
    public class EntryPoint : BaseHandler
    {
        public EntryPoint()
        {
            SetNext(new DepositMoneyHandler())
                .SetNext(new WithdrawMoneyHandler())
                .SetNext(new TransferHandler())
                .SetNext(new RequestLoanHandler())
                .SetNext(new RepayLoanHandler())
                .SetNext(new OpenDepositHandler())
                .SetNext(new CloseDepositHandler());
        }
    }
}