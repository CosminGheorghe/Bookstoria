using Bookstoria.AplicationLogic.Abstractions;
using Bookstoria.AplicationLogic.Exceptions;
using Bookstoria.AplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstoria.AplicationLogic.Services
{
    public class BookService
    {
        IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetBooks()
        {
            var books = bookRepository.GetAll();
            foreach(var book in books)
            {
                book.Category = bookRepository.GetCategory(book.ID.ToString());
                book.Discount = bookRepository.GetDiscount(book.ID.ToString());
            }
            return books;
        }

        public Book GetBook(string BookID)
        {
            Guid bookID = Guid.Empty;
            if (!Guid.TryParse(BookID, out bookID))
            {
                throw new Exception("Invalid Guid Format");
            }
            var cat =  bookRepository.GetCategory(BookID);
            var discount = bookRepository.GetDiscount(BookID);
            var book = bookRepository.GetBookByID(bookID);
            
            if (book == null)
            {
                throw new EntityNotFoundException(bookID);
            }
            book.Category = cat;
            book.Discount = discount;
            return book;
        }
    }
}
