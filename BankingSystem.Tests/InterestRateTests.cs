using System;
using System.Collections.Generic;
using Models;
using Models.Handlers;
using Xunit;
using Xunit.Abstractions;

namespace BankingSystem.Tests
{
    public class InterestRateTests
    {
        private readonly ITestOutputHelper _output;

        public InterestRateTests(ITestOutputHelper output)
        {
            this._output = output;
        }

        [Fact]
        public void InterestRate_AccountCalculateDefaultRate()
        {
            var bank = new Bank("testBank", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<Account>()[0];
            customer.Request(RequestType.DepositMoney,
                new Dictionary<string, object> {{"account", account}, {"amount", 1000.0}});
            bank.Execute((new CalculateInterest(account)));
            // Leaving this in here in case somebody needs a proper way to debug tests :D 
            // _output.WriteLine($"accout.Balance: {accout.Balance}"); 
            Assert.Equal(1050, account.Balance);
        }

        [Fact]
        public void InterestRate_AccountCalculateCustomRate()
        {
            var bank = new Bank("testBank", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<Account>()[0];
            customer.Request(RequestType.DepositMoney,
                new Dictionary<string, object> {{"account", account}, {"amount", 1000.0}});
            bank.Execute(new ChangeInterestRate(account, new AnotherInterestRate(0.02)));
            bank.Execute((new CalculateInterest(account)));
            _output.WriteLine($"accout.Balance: {account.Balance}");
            Assert.Equal(1020, account.Balance);
        }

        [Fact]
        public void InterestRate_AccountCalculateCompoundInterest()
        {
            // Simplified compound interest calculation
            // 10 periods with capitalization on the end of each period
            var bank = new Bank("testBank", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<Account>()[0];
            customer.Request(RequestType.DepositMoney,
                new Dictionary<string, object> {{"account", account}, {"amount", 1000.0}});
            bank.Execute(new ChangeInterestRate(account, new AnotherInterestRate(0.02)));
            for (var i = 0; i < 10; i++)
            {
                bank.Execute((new CalculateInterest(account)));
            }
            Assert.Equal(Math.Round(1000 * Math.Pow(1.02, 10), 10), Math.Round((account.Balance), 10));
        }
        
        [Fact]
        public void InterestRate_DebitCalculateDefaultRate()
        {
            var bank = new Bank("testBank", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<DebitAccount>(bank);
            var account = customer.Get<Account>()[0];
            customer.Request(RequestType.DepositMoney,
                new Dictionary<string, object> {{"account", account}, {"amount", 1000.0}});
            bank.Execute((new CalculateInterest(account)));
            Assert.Equal(1050, account.Balance);
        }

        [Fact]
        public void InterestRate_DebitCalculateCustomRate()
        {
            var bank = new Bank("testBank", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<DebitAccount>(bank);
            var account = customer.Get<Account>()[0];
            customer.Request(RequestType.DepositMoney,
                new Dictionary<string, object> {{"account", account}, {"amount", 1000.0}});
            bank.Execute(new ChangeInterestRate(account, new AnotherInterestRate(0.02)));
            bank.Execute((new CalculateInterest(account)));
            _output.WriteLine($"accout.Balance: {account.Balance}");
            Assert.Equal(1020, account.Balance);
        }

        [Fact]
        public void InterestRate_DebitCalculateCompoundInterest()
        {
            var bank = new Bank("testBank", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<DebitAccount>(bank);
            var account = customer.Get<Account>()[0];
            customer.Request(RequestType.DepositMoney,
                new Dictionary<string, object> {{"account", account}, {"amount", 1000.0}});
            bank.Execute(new ChangeInterestRate(account, new AnotherInterestRate(0.02)));
            for (var i = 0; i < 10; i++)
            {
                bank.Execute((new CalculateInterest(account)));
            }
            Assert.Equal(Math.Round(1000 * Math.Pow(1.02, 10), 10), Math.Round((account.Balance), 10));
        }
    }
}