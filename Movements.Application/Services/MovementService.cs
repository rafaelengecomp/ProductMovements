using AutoMapper;
using Movements.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
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

        public bool Post(CreateProductMovementViewModel productMovement)
        {
            try
            {
                Movement _productMovement = mapper.Map<Movement>(productMovement);

               var A = mapper.Map<List<MovementViewModel>>(repository.Get());

                //_productMovement.EntryNumber = UtilsService.GenerateCode(8);
                _productMovement.CodProduct = _productMovement.CodProduct.Substring(0, 4);
                _productMovement.UserCode = "TESTE";
                _productMovement.MovimentDate = DateTime.Now;

                repository.Create(_productMovement);

                return true;
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message, HttpStatusCode.BadRequest);
            }
        }

    }
}
