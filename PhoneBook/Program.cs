using PhoneBook.Data;
using PhoneBook.Data.Entities;
using ConsoleTables;

namespace PhoneBook
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var dbContext = new PhoneBookDBContext();
            //var contact = new Contact { Name = "Arletta", Surname = "Gamża", PhoneNumber = "+48123456789", EmailAdress = "xyz@gmail.com"};
            //dbContext.Contacts.Add(contact);
            //_ = await dbContext.SaveChangesAsync();

            Contact tempContact = dbContext.Contacts.Find(3);
            dbContext.Remove(tempContact);
            dbContext.SaveChanges();

            var contacts = dbContext.Contacts;
            Console.WriteLine(ConsoleTable.From(contacts));

        }
    }
}