using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstoria.AplicationLogic.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public Guid EntityId { get; private set; }
        public string Title { get; private set; }

        public BookNotFoundException(Guid id) : base($"Book with id {id} was not found")
        {
        }

        public BookNotFoundException(string title) : base($"Book with title {title} was not found")
        {
        }
    }
}
