using System;
using Xunit;
using Models;

namespace BankingSystem.Tests
{
    public class PlainAccountTests
    {
        [Fact]
        public void PlainAccount_IncreaseBalance()
        {
            var account = new RegularAccount(null, 0, null, "", null);
            account.IncreaseBalance(100);
            Assert.Equal(100, account.Balance);
        }
    }
}
