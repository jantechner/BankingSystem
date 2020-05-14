using System;
using Xunit;
using Models;
using System.Linq;

namespace BankingSystem.Tests
{
    public class PlainAccountTests
    {
        [Fact]
        public void Bank_HasAccount()
        {
            var bank = new Bank("","",""); 
            var customer = new Customer("");
            customer.Open<RegularAccount>(bank);
            Account account;
            var accountNumber = customer.Get<Account>()[0].Number;
            bank.HasAccount(accountNumber, out account);
            Assert.True(customer.Get<Account>()[0] == account);
        }

        [Fact]
        public void Bank_HasNoAccount()
        {
            var bank = new Bank("", "", "");
            Account account;
            Assert.False(bank.HasAccount("", out account));
        }

        [Fact]
        public void Bank_NoRegularAccounts()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("");
            Assert.Empty(bank.GetCustomerProducts<DebitAccount>(customer));
        }

        [Fact]
        public void Bank_GetCustomerProducts()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("");
            customer.Open<RegularAccount>(bank);
            Assert.NotEmpty(bank.GetCustomerProducts<RegularAccount>(customer));
        }

        [Fact]
        public void Bank_RegularButNoDebitAccounts()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("");
            customer.Open<RegularAccount>(bank);
            Assert.Empty(bank.GetCustomerProducts<DebitAccount>(customer));
        }

        [Fact]
        public void Bank_Generate()
        {
            var bank = new Bank("", "", "");
            var report = new AccountsReport();
            var newReport = bank.Generate(report);
            Assert.NotNull(newReport);
        }

        [Fact]
        public void Bank_Execute()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("");
            var operation = new OpenAccount<RegularAccount>(customer, bank);
            Assert.True(bank.Execute(operation));
        }

        [Fact]
        public void Customer_RegularAccount()
        {
            var bank = new Bank("", "", ""); 
            var customer = new Customer("");
            customer.Open<RegularAccount>(bank);
            Assert.NotEmpty(customer.Get<RegularAccount>());
        }

        [Fact]
        public void Customer_NoAccount()
        {
            var customer = new Customer("");
            Assert.Empty(customer.Get<RegularAccount>());
        }

        [Fact]
        public void Customer_RegularButNoDebitAccount()
        {
            var bank = new Bank("", "", "");
            var customer = new Customer("");
            customer.Open<RegularAccount>(bank);
            Assert.Empty(customer.Get<DebitAccount>());
        }

        [Fact]
        public void Customer_ToString()
        {
            var customer = new Customer("123") { Name = "Jan", Surname = "Kowalski" };
            Assert.Equal("Customer: Jan Kowalski, pesel 123", customer.ToString());
        }

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
            var customer1 = new Customer("87040500342") {Name = "Jan", Surname = "Kowalski"};
            customer1.Open<DebitAccount>(globalBank);
            var account1 = customer1.Get<Account>()[0];
            
            Console.WriteLine(customer1.RequestLoan(account1, 10000, globalBank));

            Assert.Equal(10000, account1.Loans[0].Amount);
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
            customer2.Open<RegularAccount>(millenium);
            var account1 = customer1.Get<Account>()[0];
            var account2 = customer2.Get<Account>()[0];
            globalBank.Execute(new IncreaseBalance(account1, 1000));
            globalBank.Execute(new OutgoingTransfer(account1, "97021500531", 200));
            InterBankPaymentManager.ExecuteTransfers();
            Assert.Equal(200,account2.Balance);
            
        }
    }
}
