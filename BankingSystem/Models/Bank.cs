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
        public string Name { get; }
        public string CountryCode { get; }
        public string Swift { get; }
        private readonly IDictionary<Customer, Account> _accounts = new AccountsStore();
        public IList<Operation> History { get; } = new List<Operation>();
        
        public Bank(string name, string countryCode, string swift)
        {
            Name = name;
            CountryCode = countryCode;
            Swift = swift;
        }

        public bool Execute(Operation operation)
        {
            History.Add(operation);
            return operation.Execute();
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