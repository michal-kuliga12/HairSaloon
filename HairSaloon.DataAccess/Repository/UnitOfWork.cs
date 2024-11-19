using HairSaloon.DataAccess.Data;
using HairSaloon.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSaloon.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    public IServiceRepository Services { get;}

	public UnitOfWork(ApplicationDbContext db)
    {
        _db = db;
        Services = new ServiceRepository(_db);
    }

	public void Save()
    {
        _db.SaveChanges();
    }
}
