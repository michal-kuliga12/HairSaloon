using HairSaloon.DataAccess.Data;
using HairSaloon.DataAccess.Repository.IRepository;

namespace HairSaloon.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    public IServiceRepository Services { get; }
    public IApplicationUserRepository Users { get; }

    public IAppointmentRepository Appointments { get; }

    public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;

        Services = new ServiceRepository(_db);
        Users = new ApplicationUserRepository(_db);
        Appointments = new AppointmentRepository(_db);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}
