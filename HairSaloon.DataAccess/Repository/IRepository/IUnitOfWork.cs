using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSaloon.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
	IServiceRepository Services { get; }
	void Save();
}
