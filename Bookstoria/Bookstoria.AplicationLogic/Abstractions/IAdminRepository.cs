using Bookstoria.AplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstoria.AplicationLogic.Abstractions
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Admin GetAdminByUserID(Guid userID);
    }
}
