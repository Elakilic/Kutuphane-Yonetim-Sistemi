using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyProject
{
    public class Context: DbContext
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Patron> musteriler { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local);DataBase=MyProject;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
