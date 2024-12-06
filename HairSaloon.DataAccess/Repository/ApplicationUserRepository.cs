using HairSaloon.DataAccess.Data;
using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;

namespace HairSaloon.DataAccess.Repository;

public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
{
    private ApplicationDbContext _db;

    public ApplicationUserRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }

}
