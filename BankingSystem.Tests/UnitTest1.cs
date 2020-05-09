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
        
        
        [Fact]
        public void PlainAccount_Outgoing_transfer()
        {
            var globalBank = new Bank("PKO BP", "PL", "BPKOPLPW");
            var millenium = new Bank("Millenium", "PL", "MILL");

            InterBankPaymentManager.RegisterBank(globalBank);
            InterBankPaymentManager.RegisterBank(millenium);
            
            var customer1 = new Customer("87040500342") {Name = "Jan", Surname = "Kowalski"};
            var customer2 = new Customer("97021500531") {Name = "Grzegorz", Surname = "Nowak"};
            customer1.Open<DebitAccount>(globalBank);
            customer2.Open<PlainAccount>(millenium);
            var account1 = customer1.GetAccounts()[0];
            var account2 = customer2.GetAccounts()[0];
            globalBank.Execute(new IncreaseBalance(account1, 1000));
            globalBank.Execute(new OutgoingTransfer(account1, "97021500531", 200));
            InterBankPaymentManager.ExecuteTransfers();
            Assert.Equal(200,account2.Balance);
            
        }
    }
}
