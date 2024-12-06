using HairSaloon.DataAccess.Data;
using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;

namespace HairSaloon.DataAccess.Repository;

public class ServiceRepository : Repository<Service>, IServiceRepository
{
    private readonly ApplicationDbContext _db;

    public ServiceRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
}
