﻿using HairSaloon.Models;

namespace HairSaloon.DataAccess.Repository.IRepository;

public interface IServiceRepository : IRepository<Service>
{
    void Update(Service service);
}
