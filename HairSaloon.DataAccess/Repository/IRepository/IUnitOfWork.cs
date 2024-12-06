namespace HairSaloon.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    IServiceRepository Services { get; }
    IApplicationUserRepository Users { get; }
    void Save();
}
