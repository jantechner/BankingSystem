using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Models.Handlers;
using Xunit;

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

        [Fact]
        public void PlainAccount_DecreaseMoreThanHas()
        {
            var account = new RegularAccount(null, 0, null, "", null);

            var exception = Assert.Throws<Exception>(() => account.DecreaseBalance(100));
            Assert.Equal("Not enough funds", exception.Message);
        }

        [Fact]
        public void PlainAccount_GetLoan()
        {
            var globalBank = new Bank("PKO BP", "PL", "BPKOPLPW");

            InterBankPaymentManager.RegisterBank(globalBank);
            var customer1 = new Customer("87040500342", new EntryPoint()) { Name = "Jan", Surname = "Kowalski" };
            customer1.Open<DebitAccount>(globalBank);
            var account1 = customer1.Get<Account>()[0];

            customer1.Request(RequestType.RequestLoan,
                new Dictionary<string, object> {{"account", account1}, {"amount", 10000.0}});

            Assert.Equal(10000, account1.Loans[0].Amount);
        }

        [Fact]
        public void PlainAccount_Outgoing_transfer()
        {
            var globalBank = new Bank("PKO BP", "PL", "BPKOPLPW");
            var millenium = new Bank("Millenium", "PL", "MILL");
            var entryPoint = new EntryPoint();
            InterBankPaymentManager.RegisterBank(globalBank);
            InterBankPaymentManager.RegisterBank(millenium);

            var customer1 = new Customer("87040500342", entryPoint) { Name = "Jan", Surname = "Kowalski" };
            var customer2 = new Customer("97021500531", entryPoint) { Name = "Grzegorz", Surname = "Nowak" };
            customer1.Open<DebitAccount>(globalBank);
            customer2.Open<RegularAccount>(millenium);
            var account1 = customer1.Get<Account>()[0];
            var account2 = customer2.Get<Account>()[0];
            customer1.Request(RequestType.DepositMoney,
                new Dictionary<string, object> {{"account", account1}, {"amount", 1000.0}});
            // globalBank.Execute(new IncreaseBalance(account1, 1000));
            customer1.Request(RequestType.Transfer, 
                new Dictionary<string, object> {{"account", account1}, {"to", "97021500531"}, {"amount", 200.0}});
            // globalBank.Execute(new OutgoingTransfer(account1, "97021500531", 200));
            InterBankPaymentManager.ExecuteTransfers();
            Assert.Equal(200, account2.Balance);
        }
    }
}
