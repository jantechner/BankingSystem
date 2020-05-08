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
        
        [Fact]
        public void PlainAccount_GetLoan()
        {
            var globalBank = new Bank("PKO BP", "PL", "BPKOPLPW");

            InterBankPaymentManager.RegisterBank(globalBank);
            var customer1 = new Customer("87040500342") {Name = "Jan", Surname = "Kowalski"};
            customer1.Open<DebitAccount>(globalBank);
            var account1 = customer1.GetAccounts()[0];
            
            Console.WriteLine(customer1.RequestLoan(account1, 10000, globalBank));

            Assert.Equal(10000, account1.Loans[0].RemainingAmount);
        }
    }
}
