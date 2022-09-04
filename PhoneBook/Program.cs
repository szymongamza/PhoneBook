using PhoneBook.Data;
using PhoneBook.Data.Entities;
using ConsoleTables;
using PhoneBook.Controllers;

namespace PhoneBook
{
    class Program
    {
        static async Task Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine(ConsoleTable.From(await ContactsController.GetContact()));
                Console.WriteLine("+----------------------------+");
                Console.WriteLine("| Press 0 to exit program    |");
                Console.WriteLine("| Press 1 to add new contact |");
                Console.WriteLine("| Press 2 to delete contact  |");
                Console.WriteLine("| Press 3 to change contact  |");
                Console.WriteLine("+----------------------------+");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        exit = true;
                        break;
                    case "1":
                        Console.Clear();
                        string tempName = Console.ReadLine();
                        string tempSurname = Console.ReadLine();
                        string tempPhoneNumber = Console.ReadLine();
                        string tempEmail = Console.ReadLine();  
                        Contact tempContact = new Contact {
                            Name = tempName,
                            Surname = tempSurname,
                            PhoneNumber = tempPhoneNumber,
                            EmailAdress = tempEmail
                        };
                        await ContactsController.CreateContact(tempContact);
                        break;
                    case "2":
                        
                        break;
                    case "3":
                        //change
                        break;
                    default:
                        Console.WriteLine("Choose option from menu!");
                        break;
                }
            }

        }
    }
}