using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Handlers
{
    public class TransferHandler : BaseHandler
    {
        public TransferHandler()
        {
            _requiredParams = new List<string> {"account", "to", "amount"};
        }

        public override bool Handle(RequestType type, Dictionary<string, object> data)
        {
            if (type != RequestType.Transfer) return base.Handle(type, data);
            ValidateRequest(data);

            var account = (Account) data["account"];
            var to = (string) data["to"];
            var amount = (double) data["amount"];

            return account.Bank.Execute(new OutgoingTransfer(account, to, amount));
        }
    }
}