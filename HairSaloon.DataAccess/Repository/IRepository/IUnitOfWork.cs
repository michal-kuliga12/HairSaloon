namespace HairSaloon.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    IServiceRepository Services { get; }
    IApplicationUserRepository Users { get; }
    IAppointmentRepository Appointments { get; }
    IBlogRepository Blogs { get; }
    IBlogImageRepository BlogImages { get; }
    void Save();
}
