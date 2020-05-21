using System;
using Models;
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
            var customer = new Customer("");
            customer.Open<RegularAccount>(bank);
            var accout = customer.Get<Account>()[0];
            customer.DepositMoney(accout, 1000);
            bank.Execute((new CalculateInterest(accout)));
            // Leaving this in here in case somebody needs a proper way to debug tests :D 
            // _output.WriteLine($"accout.Balance: {accout.Balance}"); 
            Assert.Equal(1050, accout.Balance);
        }

        [Fact]
        public void InterestRate_AccountCalculateCustomRate()
        {
            var bank = new Bank("testBank", "", "");
            var customer = new Customer("");
            customer.Open<RegularAccount>(bank);
            var accout = customer.Get<Account>()[0];
            customer.DepositMoney(accout, 1000);
            bank.Execute(new ChangeInterestRate(accout, new AnotherInterestRate(0.02)));
            bank.Execute((new CalculateInterest(accout)));
            _output.WriteLine($"accout.Balance: {accout.Balance}");
            Assert.Equal(1020, accout.Balance);
        }

        [Fact]
        public void InterestRate_AccountCalculateCompoundInterest()
        {
            // Simplified compound interest calculation
            // 10 periods with capitalization on the end of each period
            var bank = new Bank("testBank", "", "");
            var customer = new Customer("");
            customer.Open<RegularAccount>(bank);
            var accout = customer.Get<Account>()[0];
            customer.DepositMoney(accout, 1000);
            bank.Execute(new ChangeInterestRate(accout, new AnotherInterestRate(0.02)));
            for (var i = 0; i < 10; i++)
            {
                bank.Execute((new CalculateInterest(accout)));
            }
            Assert.Equal(Math.Round(1000 * Math.Pow(1.02, 10), 10), Math.Round((accout.Balance), 10));
        }
        
        [Fact]
        public void InterestRate_DebitCalculateDefaultRate()
        {
            var bank = new Bank("testBank", "", "");
            var customer = new Customer("");
            customer.Open<DebitAccount>(bank);
            var accout = customer.Get<Account>()[0];
            customer.DepositMoney(accout, 1000);
            bank.Execute((new CalculateInterest(accout)));
            Assert.Equal(1050, accout.Balance);
        }

        [Fact]
        public void InterestRate_DebitCalculateCustomRate()
        {
            var bank = new Bank("testBank", "", "");
            var customer = new Customer("");
            customer.Open<DebitAccount>(bank);
            var accout = customer.Get<Account>()[0];
            customer.DepositMoney(accout, 1000);
            bank.Execute(new ChangeInterestRate(accout, new AnotherInterestRate(0.02)));
            bank.Execute((new CalculateInterest(accout)));
            _output.WriteLine($"accout.Balance: {accout.Balance}");
            Assert.Equal(1020, accout.Balance);
        }

        [Fact]
        public void InterestRate_DebitCalculateCompoundInterest()
        {
            var bank = new Bank("testBank", "", "");
            var customer = new Customer("");
            customer.Open<DebitAccount>(bank);
            var accout = customer.Get<Account>()[0];
            customer.DepositMoney(accout, 1000);
            bank.Execute(new ChangeInterestRate(accout, new AnotherInterestRate(0.02)));
            for (var i = 0; i < 10; i++)
            {
                bank.Execute((new CalculateInterest(accout)));
            }
            Assert.Equal(Math.Round(1000 * Math.Pow(1.02, 10), 10), Math.Round((accout.Balance), 10));
        }
    }
}