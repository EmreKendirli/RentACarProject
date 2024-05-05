using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Respositories;

public interface IOperationClaimRepository : IAsyncRepository<OperationClaim, int>,IRepository<OperationClaim,int> { }
