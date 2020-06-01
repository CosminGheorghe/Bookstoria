using Bookstoria.AplicationLogic;
using Bookstoria.AplicationLogic.Abstractions;
using Bookstoria.AplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Dynamic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Bookstoria.EFDataAccess
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        SqlConnection conn;
        public BookRepository(BookstoriaDbContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            conn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        
        public Book GetBookByID(Guid id)
        {
            var ID = id.ToString();
            var cat = GetCategory(ID);
            var discount = GetDiscount(ID);
            var book = dbContext.Books
                            .Where(b => b.ID == id)
                            .SingleOrDefault();
            book.Discount = discount;
            book.Category = cat;
            return book;
        }
        
        public Book GetBookByTitle(string title)
        {
            var book = dbContext.Books
                            .Where(b => b.Title == title)
                            .SingleOrDefault();
            var id = book.ID.ToString();
            var cat = GetCategory(id);
            var discount = GetDiscount(id);
            book.Category = cat;
            book.Discount = discount;
            return book;
        }
        
        public string GetAuthorByBookID(Guid bookID)
        {
            return dbContext.Books.Where(b => b.ID == bookID).SingleOrDefault().Author;
        }

        public string GetTitle(string bookID)
        {
            return dbContext.Books.Where(book => book.ID == Guid.Parse(bookID)).SingleOrDefault().Title;
        }

        public double GetPrice(string bookID)
        {
            return dbContext.Books.Where(book => book.ID == Guid.Parse(bookID)).SingleOrDefault().Price;
        }

        public Category GetCategory(string bookID)
        {
            SqlDataReader rdr = null;
            Category category = new Category();
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("GetCategory", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Guid guid = Guid.Parse(bookID);
                cmd.Parameters.Add(new SqlParameter("@BookID", guid));
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    category.ID = rdr.GetGuid(0);
                    category.Type = rdr.GetString(1);
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
            return category;
        }
        public Discount GetDiscount(string bookID)
        {
            SqlDataReader rdr = null;
            Discount discount = new Discount();
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("GetDiscount", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                Guid guid = Guid.Parse(bookID);
                cmd.Parameters.Add(new SqlParameter("@BookID", guid));
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    discount.ID = rdr.GetGuid(0);
                    var v = rdr.GetDouble(1);
                    discount.Value = v;
                }
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
                if (rdr != null)
                {
                    rdr.Close();
                }
            }
            return discount;
        }
    }
}
