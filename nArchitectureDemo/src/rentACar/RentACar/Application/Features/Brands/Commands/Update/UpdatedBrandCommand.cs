﻿using Application.Services.Respositories;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Core.Application.Pipelines.Caching;
namespace Application.Features.Brands.Commands.Update;

public class UpdatedBrandCommand:IRequest<UpdatedBrandResponse>, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }

	public string? CacheKey => "";
	public bool BypassCache => false;
	public string? CacheGroupKey => "GetBrands";
	public class UpdatedBrandCommandHandler:IRequestHandler<UpdatedBrandCommand, UpdatedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public UpdatedBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedBrandResponse> Handle(UpdatedBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id ,cancellationToken:cancellationToken);

            brand = _mapper.Map(request,brand);

            await _brandRepository.UpdateAsync(brand);

            UpdatedBrandResponse response = _mapper.Map<UpdatedBrandResponse>(brand);

            return response;
        }
    }
}
