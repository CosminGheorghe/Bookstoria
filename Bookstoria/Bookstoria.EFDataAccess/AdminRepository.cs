using Bookstoria.AplicationLogic.Abstractions;
using Bookstoria.AplicationLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookstoria.EFDataAccess
{
    public class AdminRepository : BaseRepository<Admin>, IAdminRepository
    {
        public AdminRepository(BookstoriaDbContext dbContext) : base(dbContext)
        {

        }
        public Admin GetAdminByUserID(Guid id)
        {
            return dbContext.Admins
                            .Where(admin => admin.UserID == id)
                            .SingleOrDefault();
        }
    }
}
