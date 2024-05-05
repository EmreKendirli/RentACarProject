﻿using Application.Services.Respositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
    {
        //services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("nArtitecture"));//memoryde çalışır
        //services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RentACar")));

        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RentACar")));

        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();

		services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
		services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
		services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
		services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
		return services;
    }
}
