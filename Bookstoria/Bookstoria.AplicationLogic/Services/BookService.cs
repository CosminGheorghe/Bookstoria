using Bookstoria.AplicationLogic.Abstractions;
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

        public IEnumerable<Book> GetBooks(string customerId)
        {
            return bookRepository.GetAll();
        }
    }
}
