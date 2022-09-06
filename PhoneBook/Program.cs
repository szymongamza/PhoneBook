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
                string menuOption = InputNotNull("Choose option from menu:");
                switch (menuOption)
                {
                    case "0":
                        exit = true;
                        break;
                    case "1":
                        Console.Clear();
                        string tempName = InputNotNull("Enter name: ");
                        string tempSurname = InputNotNull("Enter surname: ");
                        string tempPhoneNumber = InputNotNull("Enter phone number: ");
                        string tempEmail = InputNotNull("Enter email: ");
                        Contact tempContact = new Contact {
                            Name = tempName,
                            Surname = tempSurname,
                            PhoneNumber = tempPhoneNumber,
                            EmailAdress = tempEmail
                        };
                        await ContactsController.CreateContact(tempContact);
                        break;
                    case "2":
                        string deleteId = InputNotNull("Enter Id of contact that you want to delte: ");
                        var contact = await ContactsController.GetContact(Int32.Parse(deleteId));
                        if (contact != null)
                        {
                            await ContactsController.DeleteContact(contact);
                        }
                        else
                        {
                            Console.WriteLine("Null");
                        }

                        break;
                    case "3":
                        //change
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Choose option from menu!");
                        break;
                }
            }

        }
        static string InputNotNull(string info)
        {
            Console.Write(info);
            string input = Console.ReadLine();
            while(input == null)
            {
                input = Console.ReadLine();
            }
            return input;
        }
    }
}