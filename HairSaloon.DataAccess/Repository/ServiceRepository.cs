using HairSaloon.DataAccess.Data;
using HairSaloon.DataAccess.Repository.IRepository;
using HairSaloon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HairSaloon.DataAccess.Repository;

public class ServiceRepository : IServiceRepository
{
	private readonly ApplicationDbContext _db;

    public ServiceRepository(ApplicationDbContext db)
    {
        _db = db;
    }

	public void Add(Service entity)
	{
		_db.Services.Add(entity);
	}

	public void Remove(Service entity)
	{
		_db.Services.Remove(entity);
	}

	public Service Get(Expression<Func<Service, bool>> filter) 
	{
		Service? obj = _db.Services.FirstOrDefault(filter);

		return obj;
	}
	public IEnumerable<Service> GetAll()
	{
		IQueryable<Service> query = _db.Services.AsQueryable();
		return query.ToList();
	}

	public void Update(Service entity)
	{
		_db.Services.Update(entity);
	}
}
