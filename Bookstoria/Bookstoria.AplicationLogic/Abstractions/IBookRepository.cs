using Bookstoria.AplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstoria.AplicationLogic.Abstractions
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetBookByID(Guid bookID);
    }
}
