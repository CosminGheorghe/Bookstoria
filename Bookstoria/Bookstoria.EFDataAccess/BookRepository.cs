using Bookstoria.AplicationLogic;
using Bookstoria.AplicationLogic.Abstractions;
using Bookstoria.AplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Dynamic;

namespace Bookstoria.EFDataAccess
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookstoriaDbContext dbContext) : base(dbContext)
        {

        }
        
        public Book GetBookByID(Guid id)
        {
            return dbContext.Books
                            .Where(book => book.ID == id)
                            .SingleOrDefault();
        }
        
        public Book GetBookByTitle(string title)
        {
            return dbContext.Books
                            .Where(book => book.Title == title)
                            .SingleOrDefault();
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
            return dbContext.Books.Where(book => book.ID == Guid.Parse(bookID)).SingleOrDefault().Category;
        }
    }
}
