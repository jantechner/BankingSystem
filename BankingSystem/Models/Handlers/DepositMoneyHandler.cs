using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Handlers
{
    public class DepositMoneyHandler : BaseHandler
    {
        public DepositMoneyHandler()
        {
            _requiredParams = new List<string> {"account", "amount"};
        }

        public override bool Handle(RequestType type, Dictionary<string, object> data)
        {
            if (type != RequestType.DepositMoney) return base.Handle(type, data);
            ValidateRequest(data);
            var account = (Account) data["account"];
            var amount = (double) data["amount"];
            return account.Bank.Execute(new IncreaseBalance(account, amount));
        }
    }
}