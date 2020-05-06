using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstoria.AplicationLogic.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public Guid EntityId { get; private set; }
        public BookNotFoundException(Guid id) : base($"Book with id {id} was not found")
        {
        }
    }
}
