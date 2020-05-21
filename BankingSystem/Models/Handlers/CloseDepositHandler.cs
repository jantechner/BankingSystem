using System.Collections.Generic;

namespace Models.Handlers
{
    public class CloseDepositHandler : BaseHandler
    {
        public CloseDepositHandler()
        {
            _requiredParams = new List<string>{"deposit"};
        }

        public override bool Handle(RequestType type, Dictionary<string, object> data)
        {
            if (type != RequestType.CloseDeposit) return base.Handle(type, data);
            ValidateRequest(data);

            var deposit = (Deposit) data["deposit"];
            return deposit.Account.Bank.Execute(new CloseDeposit(deposit));
        }
    }
}