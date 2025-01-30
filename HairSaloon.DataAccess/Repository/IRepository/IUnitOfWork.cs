﻿namespace HairSaloon.DataAccess.Repository.IRepository;

public interface IUnitOfWork
{
    IServiceRepository Services { get; }
    IApplicationUserRepository Users { get; }
    IAppointmentRepository Appointments { get; }
    void Save();
}
