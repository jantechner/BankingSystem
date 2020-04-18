using System;
using Models;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var globalBank = new Bank();

            var c1 = new Customer("87040500342"){ Name = "Jan", Surname = "Kowalski" };
            c1.addBank(globalBank);
            c1.openAccount(globalBank);

            Console.WriteLine(c1.ToString());
        }
    }
}
