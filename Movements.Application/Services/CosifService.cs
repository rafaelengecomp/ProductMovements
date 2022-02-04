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
    public class CosifService : ICosifService
    {
        private readonly IMapper mapper;
        private readonly ICosifRepository repository;

        public CosifService(IMapper mapper, ICosifRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
            

        }
       
        public List<CosifViewModel> Get()
        {
            return mapper.Map<List<CosifViewModel>>(repository.Get());
        }

    }
}
