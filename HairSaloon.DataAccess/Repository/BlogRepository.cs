using HairSaloon.DataAccess.Data;
using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;

namespace HairSaloon.DataAccess.Repository;

public class BlogRepository : Repository<Blog>, IBlogRepository
{
    private readonly ApplicationDbContext _db;
    public BlogRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
}
