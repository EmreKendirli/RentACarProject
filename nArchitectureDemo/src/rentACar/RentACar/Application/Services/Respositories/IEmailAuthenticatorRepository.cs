using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Respositories;

public interface IEmailAuthenticatorRepository : IAsyncRepository<EmailAuthenticator,int>,IRepository<EmailAuthenticator,int> { }
