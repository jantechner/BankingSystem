using System;
using System.Collections.Generic;
using Models;
using Models.Handlers;
using Xunit;

namespace BankingSystem.Tests
{
    public class CustomerTests
    {
        [Fact]
        public void Customer_RegularAccount()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            Assert.NotEmpty(customer.Get<RegularAccount>());
        }

        [Fact]
        public void Customer_NoAccount()
        {
            var customer = new Customer("", new EntryPoint());
            Assert.Empty(customer.Get<RegularAccount>());
        }

        [Fact]
        public void Customer_RegularButNoDebitAccount()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            Assert.Empty(customer.Get<DebitAccount>());
        }

        [Fact]
        public void Customer_DepositMoney()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<RegularAccount>()[0];
            // customer.DepositMoney(account, 12.34);
            customer.Request(RequestType.DepositMoney,
                new Dictionary<string, object> {{"account", account}, {"amount", 12.34}});

            Assert.Equal(12.34, account.Balance);
        }

        [Fact]
        public void Customer_WithdrawMoney()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<RegularAccount>()[0];
            // customer.DepositMoney(account, 2.5);
            customer.Request(RequestType.DepositMoney,
                new Dictionary<string, object> {{"account", account}, {"amount", 2.5}});

            // customer.WithdrawMoney(account, 1.25);
            customer.Request(RequestType.WithdrawMoney,
                new Dictionary<string, object> {{"account", account}, {"amount", 1.25}});
            Assert.Equal(1.25, account.Balance);
        }

        [Fact]
        public void Customer_WithdrawNoMoney()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<RegularAccount>()[0];
            // Assert.Throws<System.Exception>(() => customer.WithdrawMoney(account, 12.34));
            Assert.Throws<System.Exception>(() => customer.Request(RequestType.WithdrawMoney,
                new Dictionary<string, object> {{"account", account}, {"amount", 12.34}}));
        }

        [Fact]
        public void Customer_DepositNegativeMoney()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<RegularAccount>()[0];
            Assert.Throws<System.Exception>(() => customer.Request(RequestType.DepositMoney,
                new Dictionary<string, object> {{"account", account}, {"amount", -1.0}}));
        }

        [Fact]
        public void Customer_WithdrawNegativeMoney()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<RegularAccount>()[0];
            Assert.Throws<System.Exception>(() => customer.Request(RequestType.WithdrawMoney,
                new Dictionary<string, object> {{"account", account}, {"amount", -1.0}}));
        }

        [Fact]
        public void Customer_RequestLoan()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<RegularAccount>()[0];
            Assert.True(customer.Request(RequestType.RequestLoan,
                new Dictionary<string, object> {{"account", account}, {"amount", 10000.0}}));
        }

        [Fact]
        public void Customer_RequestLoanNoAccount()
        {
            var customer = new Customer("", new EntryPoint());
            var account = new RegularAccount(null, 0, null, "", null);
            Assert.Throws<NullReferenceException>(() => customer.Request(RequestType.RequestLoan,
                new Dictionary<string, object> {{"account", account}, {"amount", 10.0}}));
        }

        [Fact]
        public void Customer_RequestLoanNegativeAmount()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<RegularAccount>()[0];
            Assert.Throws<System.Exception>(() => customer.Request(RequestType.RequestLoan,
                new Dictionary<string, object> {{"account", account}, {"amount", -1.0}}));
        }

        //TODO
        /*
        [Fact]
        public void Customer_RepayLoan()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("");
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<RegularAccount>()[0];
            customer.RequestLoan(account, 1.5, bank);
            var loan = customer.Get<Loan>()[0];
            Assert.True(customer.RepayLoan(account, loan, 1.5, bank));
        }
        */

        [Fact]
        public void Customer_OpenDeposit()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<RegularAccount>()[0];
            // customer.DepositMoney(account, 1.5);
            customer.Request(RequestType.DepositMoney,
                new Dictionary<string, object> {{"account", account}, {"amount", 1.5}});

            Assert.True(customer.Request(RequestType.OpenDeposit,
                new Dictionary<string, object> {{"account", account}, {"amount", 1.5}}));
        }

        [Fact]
        public void Customer_OpenDepositNoMoney()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<RegularAccount>()[0];
            Assert.Throws<System.Exception>(() => customer.Request(RequestType.OpenDeposit,
                new Dictionary<string, object> {{"account", account}, {"amount", 1.0}}));
        }

        [Fact]
        public void Customer_OpenDepositNoAccount()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            var account = new RegularAccount(null, 0, null, "", null);
            Assert.Throws<NullReferenceException>(() => customer.Request(RequestType.OpenDeposit,
                new Dictionary<string, object> {{"account", account}, {"amount", 1.5}}));
        }

        [Fact]
        public void Customer_OpenDepositNegativeAmount()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<RegularAccount>()[0];
            Assert.Throws<System.Exception>(() => customer.Request(RequestType.OpenDeposit,
                new Dictionary<string, object> {{"account", account}, {"amount", -1.0}}));
        }

        [Fact]
        public void Customer_CloseDeposit()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var account = customer.Get<RegularAccount>()[0];
            customer.Request(RequestType.DepositMoney,
                new Dictionary<string, object> {{"account", account}, {"amount", 1.5}});
            // customer.OpenDeposit(account, 1.5);
            customer.Request(RequestType.OpenDeposit,
                new Dictionary<string, object> {{"account", account}, {"amount", 1.5}});
            var deposit = customer.Get<Deposit>()[0];
            Assert.True(customer.Request(RequestType.CloseDeposit,
                new Dictionary<string, object> {{"deposit", deposit}}));
        }
    }
}