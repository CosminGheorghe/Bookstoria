using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstoria.AplicationLogic.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public Guid EntityId { get; private set; }
        public EntityNotFoundException(Guid id) : base($"Entity with id {id} was not found")
        {
        }
    }
}
