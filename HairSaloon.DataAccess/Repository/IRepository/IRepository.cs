using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSaloon.DataAccess.Repository.IRepository;

public interface IRepository<T> where T : class
{
	IEnumerable<T> GetAll();
	void Add(T entity);
	void Update(T entity);
	void Delete(T entity);
}
