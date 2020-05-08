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
            var account = new PlainAccount(null, 0, null, "", null);
            account.IncreaseBalance(100);
            Assert.Equal(100, account.Balance);
        }
        
        [Fact]
        public void PlainAccount_DecreaseMoreThanHas()
        {
            var account = new PlainAccount(null, 0, null, "", null);

            var exception = Assert.Throws<Exception>(() => account.DecreaseBalance(100));
            Assert.Equal("Not enough funds", exception.Message);
        }
    }
}
