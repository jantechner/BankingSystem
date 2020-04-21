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
        public ReportingManager ReportingManager { get; }
        public IList _history = new OperationsHistory();

        //TODO zaimplementować ReportingManagera
        public Bank(string name, string countryCode, string swift)
        {
            Name = name;
            CountryCode = countryCode;
            SWIFT = swift;
        }

        public void Open<T>(Customer customer) where T : Account
        {
            //simplest version, but a possible code smell -> for discussion
            // var newAccount = (T)Activator.CreateInstance(typeof(T), new Account(_accountCounter++, customer, "number", new InterestRate(0.05, 24, 6)))

            Account newAccount;
            if (typeof(T) == typeof(Account))
            {
                newAccount = new PlainAccount(this, _accountCounter++, customer, customer.Pesel,
                    new InterestRate(0.05, 24, 6));
            }
            else if (typeof(T) == typeof(DebitAccount))
            {
                newAccount = new DebitAccount(this, _accountCounter++, customer, customer.Pesel,
                    new InterestRate(0.05, 24, 6));
            }
            else
            {
                throw new Exception("incorrect ");
            }

            _accounts[customer] = newAccount;

            Console.WriteLine($"Opening account for {customer}");
        }

        public void OutgoingTransfer(Transfer transfer)
        {
            var localAccount = _accounts.Values.FirstOrDefault(a => a.Number == transfer.To);
            if (localAccount != null)
            {
                localAccount.IncomingTransfer(transfer);
            }
            else
            {
                Console.WriteLine("Not local");
                InterBankPaymentManager.OrderToTransfer(transfer);
            }
        }

        public void IncomingTransfer(Transfer transfer)
        {
            var account = _accounts.Values.FirstOrDefault(a => a.Number == transfer.To);
            account?.IncomingTransfer(transfer);
        }

        public bool RaiseLoan(Customer customer, int amount)
        {
            _accounts[customer].RaiseLoan(new Loan(amount, new InterestRate(0.1, 24, 12)));
            return true; // confirmation
            // return false; -> Bank can refuse to give a loan
        }

        public Account GetCustomerAccount(Customer customer)
        {
            return _accounts[customer];
        }

        public bool HasAccountWithNumber(string number)
        {
            return _accounts.Values.Any(account => account.Number == number);
        }

        // public void innerBankTransfer(string from, string to, double amount, string givenPassword)
        // {
        //     if (!accountId2account.TryGetValue(from, out Account sender))
        //         throw new SystemException("There is no such sender account");
        //     if (!accountId2account.TryGetValue(to, out Account receiver))
        //         throw new SystemException("There is no such receiver account");
        //     if (!accountId2password.TryGetValue(from, out string savedPassword))
        //         throw new SystemException("There is no password saved for sender account");
        //     if (givenPassword != savedPassword)
        //         throw new SystemException("Wrong password");
        //
        //     sender.WithdrawMoney(amount);
        //     receiver.DepositMoney(amount);
        // }
    }
}