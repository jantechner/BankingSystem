using Models;
using Models.Handlers;
using Xunit;

namespace BankingSystem.Tests
{
    public class BankTests
    {
        [Fact]
        public void Bank_HasAccount()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            var accountNumber = customer.Get<Account>()[0].Number;            
            Assert.True(bank.HasAccount(accountNumber, out Account _));
        }

        [Fact]
        public void Bank_HasNoAccount()
        {
            var bank = new Bank("", "", "");
            Assert.False(bank.HasAccount("", out Account _));
        }

        [Fact]
        public void Bank_NoRegularAccounts()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            Assert.Empty(bank.GetCustomerProducts<DebitAccount>(customer));
        }

        [Fact]
        public void Bank_GetCustomerProducts()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            Assert.NotEmpty(bank.GetCustomerProducts<RegularAccount>(customer));
        }

        [Fact]
        public void Bank_RegularButNoDebitAccounts()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            customer.Open<RegularAccount>(bank);
            Assert.Empty(bank.GetCustomerProducts<DebitAccount>(customer));
        }

        [Fact]
        public void Bank_Generate()
        {
            var bank = new Bank("", "", "");
            var report = bank.Generate(new AccountsReport());
            Assert.NotNull(report);
        }

        [Fact]
        public void Bank_Execute()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("", new EntryPoint());
            var operation = new OpenAccount<RegularAccount>(customer, bank);
            Assert.True(bank.Execute(operation));
        }
    }
}
