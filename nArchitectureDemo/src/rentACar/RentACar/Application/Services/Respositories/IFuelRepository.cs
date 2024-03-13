using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Respositories;

public interface IFuelRepository : IAsyncRepository<Fuel, Guid>, IRepository<Fuel, Guid>
{
}

