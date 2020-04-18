using System.Collections.Generic;

namespace Models
{
    public class Customer
    {   
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; }
        public List<Bank> Banks { get; } = new List<Bank>();
        
        public Customer(string pesel) 
        {
            Pesel = pesel;
        }

        public void addBank(Bank bank) {
            Banks.Add(bank);
        }

        public void openAccount(Bank bank) 
        {
            if (Banks.Contains(bank))
            {
                bank.openAccount(this);
                System.Console.WriteLine("New account opened!");
            }
        }

        public override string ToString()
        {
            return $"Customer: {Name} {Surname}, pesel {Pesel}";
        }
    }
}