using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPConsole.Models
{
    public interface IATM
    {
        void ExecuteMenu(User user);
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

        private void DisplayMenu(User user)
        {
            Console.WriteLine("Press any key");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"Welcome user: {user.Name} at {RegularATMName}");
            Console.WriteLine("1. Authenticate ");
            Console.WriteLine("2. Withdraw ");
            Console.WriteLine("3. ShowTransactions - for user ");
            Console.WriteLine("4. ShowTransactions - for all users ");
            Console.WriteLine("5. Eject card");
            Console.WriteLine("6. Leave atm");
            Console.WriteLine("--Choose a number\n");
        }

        public void ExecuteMenu(User user)
        {
            DisplayMenu(user);
            int k = int.Parse(Console.ReadLine());
            if (k == 1) Authenticate(user);
            if (k == 2) 
            {
                Console.WriteLine("\nAmount\n");
                decimal amount = decimal.Parse(Console.ReadLine());
                WithDraw(user, amount);
            }
            if (k == 3) ShowTransactions(user);
            if (k == 4) ShowAllTransactions(user);
            if (k == 5) EjectCard(user);
            if (k == 6) return;            
        }


        private void Authenticate(User user)
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
            ExecuteMenu(user);
        }

        private void WithDraw(User user, decimal amount)
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
            ExecuteMenu(user);
        }

        private void EjectCard(User user)
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
            ExecuteMenu(user);
        }


        private void Deposit(User user, decimal amount)
        {
            Console.WriteLine($"{RegularATMName}  cannot be used for deposits at regular ATM.");
        }


        private void ShowTransactions(User user)
        {
            var filteredTransactions = Transactions.Where(x=> x.User == user).ToList();
            Console.WriteLine($"{RegularATMName}  Transactions for User {user.Name} at regular ATM");
            foreach (var transaction in filteredTransactions)
            {
                Console.WriteLine(transaction.Print);
            }
            Console.WriteLine("----------");
            ExecuteMenu(user);
        }


        private void ShowAllTransactions(User user)
        {            
            Console.WriteLine($"{RegularATMName} Transactions for All Users at regular ATM");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine(transaction.Print);
            }
            Console.WriteLine("----------");
            ExecuteMenu(user);
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

        private void DisplayMenu(User user)
        {
            Console.WriteLine("Press any key");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"Welcome {user.Name} at special Deposit ATM: {DepositATMName}");
            Console.WriteLine("1. Authenticate ");
            Console.WriteLine("2. Withdraw ");
            Console.WriteLine("3. ShowTransactions - for user ");
            Console.WriteLine("4. ShowTransactions - for all users ");
            Console.WriteLine("5. Deposit ");
            Console.WriteLine("6. Eject card");
            Console.WriteLine("7. Leave atm");
            Console.WriteLine("--Choose a number\n");
        }

        public void ExecuteMenu(User user)
        {
            DisplayMenu(user);
            int k = int.Parse(Console.ReadLine());
            if (k == 1) Authenticate(user);
            if (k == 2)
            {
                Console.WriteLine("\nAmount\n");
                decimal amount = decimal.Parse(Console.ReadLine());
                WithDraw(user, amount);
            }
            if (k == 3) ShowTransactions(user);
            if (k == 4) ShowAllTransactions(user);
            if (k == 5) 
            {
                Console.WriteLine("\nAmount for deposit:\n");
                decimal amount = decimal.Parse(Console.ReadLine());
                Deposit(user, amount);
            }
            if (k == 6) EjectCard(user);
            if (k == 7) return;
        }
        private void Authenticate(User user)
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
            ExecuteMenu(user);
        }

        private void WithDraw(User user, decimal amount)
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
            ExecuteMenu(user);
        }

        private void EjectCard(User user)
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
            ExecuteMenu(user);
        }


        private void Deposit(User user, decimal amount)
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
            ExecuteMenu(user);
        }


        private void ShowTransactions(User user)
        {
            var filteredTransactions = Transactions.Where(x => x.User == user).ToList();
            Console.WriteLine($"{DepositATMName}  Transactions for User {user.Name} at deposit ATM");
            foreach (var transaction in filteredTransactions)
            {
                Console.WriteLine(transaction.Print);
            }
            Console.WriteLine("----------");
            ExecuteMenu(user);
        }


        private void ShowAllTransactions(User user)
        {
            Console.WriteLine($"{DepositATMName} Transactions for All Users at deposit ATM");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine(transaction.Print);
            }
            Console.WriteLine("----------");
            ExecuteMenu(user);
        }
    }
}
