using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using Template.Application.Interfaces;
using Template.Application.ViewModels.Users;
using Template.CrossCutting.Auth.Interfaces;
using Template.CrossCutting.Auth.ViewModels;
using Template.CrossCutting.ExceptionHandler.Extensions;
using Template.CrossCutting.Notification.Interfaces;
using Template.CrossCutting.Notification.ViewModels;
using Template.Domain.Entities;
using Template.Domain.Interfaces;
using Profile = Template.Domain.Entities.Profile;

namespace Template.Application.Services
{
    public class MovementService : IMovementService
    {
        private readonly IMapper mapper;
        private readonly IMovementRepository repository;

        public MovementService(IMapper mapper, IMovementRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
            

        }
       
        public List<MovementViewModel> Get()
        {
            return mapper.Map<List<MovementViewModel>>(repository.Get());
        }

    }
}
