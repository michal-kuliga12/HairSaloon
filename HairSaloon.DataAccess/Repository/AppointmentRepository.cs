using HairSaloon.DataAccess.Data;
using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;

namespace HairSaloon.DataAccess.Repository;

public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
{
    private readonly ApplicationDbContext _db;

    public AppointmentRepository(ApplicationDbContext db) : base(db)
    {
        _db = db;
    }
}
