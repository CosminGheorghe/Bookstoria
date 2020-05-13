﻿using Bookstoria.AplicationLogic.Abstractions;
using Bookstoria.AplicationLogic.Exceptions;
using Bookstoria.AplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookstoria.AplicationLogic.Services
{
    public class AdminService
    {
        private readonly IAdminRepository adminRepository;
        private readonly IBookRepository bookRepository;

        public AdminService(IAdminRepository adminRepository, IBookRepository bookRepository)
        {
            this.adminRepository = adminRepository;
            this.bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetBooks()
        {
            return bookRepository.GetAll().AsEnumerable();
        }

        public Admin GetAdminByUserId(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var admin = adminRepository.GetAdminByUserID(userIdGuid);
            if (admin == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }

            return admin;
        }

        public void AddBook(string title, string author, string categoryType, double discountValue, byte[] image, string isbn, double price)
        {
            bookRepository.Add(new Book()
            {
                ID = Guid.NewGuid(),
                Title = title,
                Author = author,
                Category = new Category() { ID = Guid.NewGuid(), Type = categoryType },
                Discount = new Discount() { ID = Guid.NewGuid(), Value = discountValue },
                Image = image,
                ISBN = isbn,
                Price = price
            });
        }

        public void DeleteBook(string bookID)
        {
            if (!Guid.TryParse(bookID, out Guid bookIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var book = bookRepository.GetBookByID(bookIdGuid);
            if (book == null)
            {
                throw new BookNotFoundException(bookIdGuid);
            }

            bookRepository.Delete(book);
        }

        public void DeleteBookByTitle(string bookTitle)
        {

            var book = bookRepository.GetBookByTitle(bookTitle);
            if (book == null)
            {
                throw new BookNotFoundException(bookTitle);
            }

            bookRepository.Delete(book);
        }

    }
}
