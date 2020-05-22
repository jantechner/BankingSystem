using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Handlers
{
    public class RequestLoanHandler : BaseHandler
    {
        public RequestLoanHandler()
        {
            _requiredParams = new List<string> {"account", "amount"};
        }

        public override bool Handle(RequestType type, Dictionary<string, object> data)
        {
            if (type != RequestType.RequestLoan) return base.Handle(type, data);
            ValidateRequest(data);

            var account = (Account) data["account"];
            var amount = (double) data["amount"];
            var interestRate = new InterestRate(0.2, 24, 6);
            if (account.Bank == null) throw new NullReferenceException("Account must be assigned to bank");
            return account.Bank.Execute(new RaiseLoan(account, amount, interestRate));
        }
    }
}