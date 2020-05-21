using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Handlers
{
    public class RepayLoanHandler : BaseHandler
    {
        public RepayLoanHandler()
        {
            _requiredParams = new List<string> {"loan", "amount"};
        }

        public override bool Handle(RequestType type, Dictionary<string, object> data)
        {
            if (type != RequestType.RepayLoan) return base.Handle(type, data);
            ValidateRequest(data);

            var loan = (Loan) data["loan"];
            var amount = (double) data["amount"];
            return loan.Account.Bank.Execute(new RepayLoan(loan, amount));
        }
    }
}