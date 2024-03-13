using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Respositories;

public interface IModelRepository : IAsyncRepository<Model, Guid>, IRepository<Model, Guid>
{
}

