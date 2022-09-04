using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Controllers
{
    public class ContactsController
    {
        static PhoneBookDBContext dbContext = new PhoneBookDBContext(); 
        public static async Task CreateContact(Contact contact)
        {
            dbContext.Add(contact);
            await dbContext.SaveChangesAsync();
        }
        public static async Task<List<Contact>> GetContact()
        {
            var contacts = await dbContext.Contacts.ToListAsync();
            return contacts;
        }        
        public static async Task<Contact?> GetContact(int id)
        {
            var contact = await dbContext.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if( contact != null)
            {
                return contact;
            }
            return null;
        }
        public static async Task Update()
        {
            dbContext = new PhoneBookDBContext();
        }
        public static async Task DeleteContact(Contact contact)
        {
            dbContext.Remove(contact);
            await dbContext.SaveChangesAsync();
        }
    }
}
