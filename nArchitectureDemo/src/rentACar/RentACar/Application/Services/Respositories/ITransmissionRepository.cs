using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Respositories;

public interface ITransmissionRepository : IAsyncRepository<Transmission, Guid>, IRepository<Transmission, Guid>
{
}

