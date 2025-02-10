using HairSaloon.Models;

namespace HairSaloon.DataAccess.Repository.IRepository;

public interface IBlogImageRepository : IRepository<BlogImage>
{
    void Update(BlogImage obj);
}
