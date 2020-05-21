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
        public void InterestRate_CalculateDefaultRate()
        {
            var bank = new Bank("testBank", "", "");
            var customer = new Customer("");
            customer.Open<DebitAccount>(bank);
            var accout = customer.Get<Account>()[0];
            customer.DepositMoney(accout, 1000);
            bank.Execute((new CalculateInterest(accout)));
            // _output.WriteLine($"accout.Balance: {accout.Balance}");
            Assert.Equal(1050, accout.Balance);
        }
    }
}