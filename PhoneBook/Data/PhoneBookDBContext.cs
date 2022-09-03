using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data
{
    public class PhoneBookDBContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\FlashCardsDB;Database=PhoneBookDb;Trusted_Connection=True;MultipleActiveResultSets=true;");

        }
    }
}
