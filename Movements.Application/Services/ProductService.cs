using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Application.ViewModels.Users;
using Template.Domain.Interfaces;


namespace Template.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IProductRepository repository;

        public ProductService(IMapper mapper, IProductRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
            

        }
       
        public List<ProductsViewModel> Get()
        {
            return mapper.Map<List<ProductsViewModel>>(repository.Get());
        }

    }
}
