using Bookstoria.AplicationLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstoria.EFDataAccess
{
    public class BookstoriaDbContext : DbContext
    {
        public BookstoriaDbContext(DbContextOptions<BookstoriaDbContext> options): base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
