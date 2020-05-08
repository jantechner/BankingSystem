using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Bank
    {
        private static int _accountCounter = 0;

        public string Name { get; }
        public string CountryCode { get; }
        public string SWIFT { get; }
        private IDictionary<Customer, Account> _accounts = new AccountsStore();
        public IEnumerable InterestRates { get; } // co to ma robić?
        public IList<Operation> _history = new OperationsHistory();

        //TODO zaimplementować ReportingManagera
        public Bank(string name, string countryCode, string swift)
        {
            Name = name;
            CountryCode = countryCode;
            SWIFT = swift;
        }

        public bool Execute(Operation operation)
        {
            _history.Add(operation);
            return operation.Execute();
        }

        public static int NextAccountId()
        {
            return _accountCounter++;
        }

        public bool HasAccount(string accountNumber, out Account account)
        {
            account = null;
            var foundAccount = _accounts.Values.FirstOrDefault(a => a.Number == accountNumber);
            if (foundAccount == null) return false;
            account = foundAccount;
            return true;
        }

        public Account GetCustomerAccount(Customer customer)
        {
            return _accounts[customer];
        }

        public void AddNewAccount(Customer customer, Account account)
        {
            _accounts[customer] = account;
        }

        public Report Generate(Report report)
        {
            foreach (var account in _accounts.Values)
            {
                account.Accept(report);
            }

            return report;
        }
    }
}