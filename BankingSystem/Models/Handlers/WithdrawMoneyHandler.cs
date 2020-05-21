using System;
using System.Collections.Generic;

namespace Models.Handlers
{
    public class WithdrawMoneyHandler : BaseHandler
    {
        public override bool Handle(RequestType type, Dictionary<string, object> data)
        {
            if (type != RequestType.WithdrawMoney) return base.Handle(type, data);
            if (!data.ContainsKey("account") || !data.ContainsKey("amount")) throw new ArgumentException();
            var account = (Account) data["account"];
            var amount = (double) data["amount"];
            return account.Bank.Execute(new DecreaseBalance(account, amount));
        }
    }
}