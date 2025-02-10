using HairSaloon.DataAccess.Data;
using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;

namespace HairSaloon.DataAccess.Repository;

public class BlogImageRepository : Repository<BlogImage>, IBlogImageRepository
{
    private ApplicationDbContext _db { get; set; }
    public BlogImageRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
    public void Update(BlogImage obj)
    {
        _db.BlogImages.Update(obj);
    }
}
