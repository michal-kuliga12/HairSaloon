using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HairSaloon.DataAccess.Repository.IRepository;

// TODO - Dodać implementacje Repository która będzie zawierać metody generyczne
public interface IRepository<T> where T : class
{
	IEnumerable<T> GetAll();
	T Get(Expression<Func<T, bool>> predicate);
	void Add(T entity);
	void Update(T entity);
	void Remove(T entity);
}
