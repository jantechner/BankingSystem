using System.Collections.Generic;

namespace Models.Handlers
{
    public class OpenDepositHandler : BaseHandler
    {
        public OpenDepositHandler()
        {
            _requiredParams = new List<string> {"account", "amount"};
        }

        public override bool Handle(RequestType type, Dictionary<string, object> data)
        {
            if (type != RequestType.OpenDeposit) return base.Handle(type, data);
            ValidateRequest(data);

            var account = (Account) data["account"];
            var amount = (double) data["amount"];
            var interestRate = new InterestRate(0.2, 24, 6);
            return account.Bank.Execute(new OpenDeposit(account, amount, interestRate));
        }
    }
}