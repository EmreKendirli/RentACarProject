using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Respositories;

public interface IOtpAuthenticatorRepository : IAsyncRepository<OtpAuthenticator,int>,IRepository<OtpAuthenticator, int> { }
