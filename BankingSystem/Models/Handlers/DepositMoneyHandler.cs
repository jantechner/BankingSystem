using System;
using System.Collections.Generic;

namespace Models.Handlers
{
    public class DepositMoneyHandler : BaseHandler
    {
        public override void Handle(string requestType, Dictionary<string, object> data)
        {
            if (requestType != "deposit money")
            {
                base.Handle(requestType, data);
                return;
            }
            if (!data.ContainsKey("account") || !data.ContainsKey("amount")) throw new ArgumentException();
            var account = (Account) data["account"];
            var amount = (double) data["amount"];
            account.Bank.Execute(new IncreaseBalance(account, amount));
        }
    }
}