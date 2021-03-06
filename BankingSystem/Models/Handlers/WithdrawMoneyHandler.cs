using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Handlers
{
    public class WithdrawMoneyHandler : BaseHandler
    {
        public WithdrawMoneyHandler()
        {
            _requiredParams = new List<string> {"account", "amount"};
        }

        public override bool Handle(RequestType type, Dictionary<string, object> data)
        {
            if (type != RequestType.WithdrawMoney) return base.Handle(type, data);
            ValidateRequest(data);

            var account = (Account) data["account"];
            var amount = (double) data["amount"];
            return account.Bank.Execute(new DecreaseBalance(account, amount));
        }
    }
}