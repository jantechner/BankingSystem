using System;
using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Bank
    {
        public string Name { get; }
        public string CountryCode { get; }
        public string Swift { get; }
        private readonly List<Tuple<Customer, BankingProduct>> _products = new List<Tuple<Customer, BankingProduct>>();
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
            var foundAccount =
                (Account) _products.FirstOrDefault(product => product.Item2 is Account a && a.Number == accountNumber)
                    ?.Item2;
            if (foundAccount == null) return false;
            account = foundAccount;
            return true;
        }

        public IEnumerable<T> GetCustomerProducts<T>(Customer customer) where T : BankingProduct
        {
            return _products.Where(item => item.Item1 == customer && item.Item2 is T)
                .Select(item => (T) item.Item2).ToList();
        }

        public void AddNewProduct(Customer customer, BankingProduct product)
        {
            _products.Add(new Tuple<Customer, BankingProduct>(customer, product));
        }

        public Report Generate(Report report)
        {
            foreach (var account in _products.Select(item => item.Item2))
            {
                account.Accept(report);
            }

            return report;
        }
    }
}