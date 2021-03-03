using System;
using OOPConsole.Models;
namespace OOPConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //definire useri care fac operatii la bancomate
            var User1 = new User() { Name = "Albert", PIN = 123, Address = "Oradea", CardNumber = "99" };
            var User2 = new User() { Name = "Bartolomeo", PIN = 333, Address = "Oradea", CardNumber = "98" };
            var User3 = new User() { Name = "Cosmin", PIN = 456, Address = "Oradea", CardNumber = "997" };

            // primul tip de bancomat, regular, care poate doar retrage bani
            IATM regularAtm = new RegularATM("RegularATM");            
            regularAtm.ExecuteMenu(User1);  

             //al doilea tip de bancomat, care poate si depune bani
            IATM depositAtm = new DepositATM("DepositATM");
            depositAtm.ExecuteMenu(User2);          

        }
    }
}
