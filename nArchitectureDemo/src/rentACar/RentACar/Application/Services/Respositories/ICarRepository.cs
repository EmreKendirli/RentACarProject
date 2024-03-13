using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Respositories;

public interface ICarRepository : IAsyncRepository<Car, Guid>, IRepository<Car, Guid>
{
}

