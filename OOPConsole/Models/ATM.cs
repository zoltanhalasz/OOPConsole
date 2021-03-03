using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPConsole.Models
{
    public interface IATM
    {
        void WithDraw(User user, decimal amount);
        void Deposit(User user, decimal amount);
        void Authenticate(User user);
        void EjectCard(User user);
        void ShowTransactions(User user);        
        void ShowTransactions();
    }

    public class RegularATM: IATM
    {
        private bool isAuthenticated;
        private List<Transaction> Transactions;
        private string RegularATMName;   

        public RegularATM(string name)
        {
            RegularATMName = name;
            Transactions = new List<Transaction>();
        }
        public void Authenticate(User user)
        {
            if (user.PIN>100 && user.PIN<1000)
            {
                Console.WriteLine($"{user.Name} is authenticated at regular ATM {RegularATMName}");
                isAuthenticated = true;
            }
            else
            {
                Console.WriteLine($"{user.Name} could not be authenticated at  regulare {RegularATMName}");
                isAuthenticated = false;
            }
            
        }        

        public void WithDraw(User user, decimal amount)
        {
            if (isAuthenticated)
            {
                var transaction = new Transaction() { User = user, TimeStamp = DateTime.Now, Amount = amount, Category = "WithDraw" };
                Transactions.Add(transaction);
                Console.WriteLine($"Following transaction happened: {transaction.Print}");
            }
            else
            {
                Console.WriteLine($"{user.Name} could not be authenticated at  {RegularATMName}");
            }
        }

        public void EjectCard(User user)
        {
            if (isAuthenticated == true)
            {
                Console.WriteLine($"{user.CardNumber} is ejected at {RegularATMName}");
                isAuthenticated = false;
            }
            else
            {
                Console.WriteLine($"{user.CardNumber} has to authenticate first at {RegularATMName}");
            }
            
        }


        public void Deposit(User user, decimal amount)
        {
            Console.WriteLine($"{RegularATMName}  cannot be used for deposits at regular ATM.");
        }


        public void ShowTransactions(User user)
        {
            var filteredTransactions = Transactions.Where(x=> x.User == user).ToList();
            Console.WriteLine($"{RegularATMName}  Transactions for User {user.Name} at regular ATM");
            foreach (var transaction in filteredTransactions)
            {
                Console.WriteLine(transaction.Print);
            }
            Console.WriteLine("----------");
        }


        public void ShowTransactions()
        {            
            Console.WriteLine($"{RegularATMName} Transactions for All Users at regular ATM");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine(transaction.Print);
            }
            Console.WriteLine("----------");
        }
    }


    public class DepositATM : IATM
    {
        private bool isAuthenticated;
        private List<Transaction> Transactions;
        private string DepositATMName;

        public DepositATM(string name)
        {
            DepositATMName = name;
            Transactions = new List<Transaction>();
        }
        public void Authenticate(User user)
        {
            if (user.PIN > 200 && user.PIN < 800)
            {
                Console.WriteLine($"{user.Name} is authenticated at deposit ATM {DepositATMName}");
                isAuthenticated = true;
            }
            else
            {
                Console.WriteLine($"{user.Name} could not be authenticated at  {DepositATMName}");
                isAuthenticated = false;
            }

        }

        public void WithDraw(User user, decimal amount)
        {
            if (isAuthenticated)
            {
                var transaction = new Transaction() { User = user, TimeStamp = DateTime.Now, Amount = amount, Category = "WithDraw" };
                Transactions.Add(transaction);
                Console.WriteLine($"Following transaction happened: {transaction.Print}");
            }
            else
            {
                Console.WriteLine($"{user.Name} could not be authenticated at  {DepositATMName}");
            }
        }

        public void EjectCard(User user)
        {
            if (isAuthenticated == true)
            {
                Console.WriteLine($"{user.CardNumber} is ejected at {DepositATMName}");
                isAuthenticated = false;
            }
            else
            {
                Console.WriteLine($"{user.CardNumber} has to authenticate first at {DepositATMName}");
            }

        }


        public void Deposit(User user, decimal amount)
        {
            if (isAuthenticated)
            {
                var transaction = new Transaction() { User = user, TimeStamp = DateTime.Now, Amount = amount, Category = "Deposit" };
                Transactions.Add(transaction);
                Console.WriteLine($"Following transaction happened: {transaction.Print}");
            }
            else
            {
                Console.WriteLine($"{user.Name} could not be authenticated at  {DepositATMName}");
            }
        }


        public void ShowTransactions(User user)
        {
            var filteredTransactions = Transactions.Where(x => x.User == user).ToList();
            Console.WriteLine($"{DepositATMName}  Transactions for User {user.Name} at deposit ATM");
            foreach (var transaction in filteredTransactions)
            {
                Console.WriteLine(transaction.Print);
            }
            Console.WriteLine("----------");
        }


        public void ShowTransactions()
        {
            Console.WriteLine($"{DepositATMName} Transactions for All Users at deposit ATM");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine(transaction.Print);
            }
            Console.WriteLine("----------");
        }
    }
}
