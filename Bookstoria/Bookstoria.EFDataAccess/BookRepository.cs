using Bookstoria.AplicationLogic;
using Bookstoria.AplicationLogic.Abstractions;
using Bookstoria.AplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
    }
}
