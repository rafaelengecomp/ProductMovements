using AutoMapper;
using Movements.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Application.ViewModels.Users;
using Template.CrossCutting.ExceptionHandler.Extensions;
using Template.Domain.Interfaces;

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

               var productMovementList = mapper.Map<List<MovementViewModel>>(repository.Get());

                ValidationService.IsValidMonthOrYear(productMovement.Month, productMovement.Year);

                _productMovement.EntryNumber = Convert.ToInt32(UtilsService.GenerateReleaseNumber(productMovementList, productMovement.Year, productMovement.Month));
                _productMovement.CodProduct = _productMovement.CodProduct.Substring(0, 4);
                _productMovement.CodCosif = _productMovement.CodCosif.PadLeft(11, '0').Substring(0, 11);
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
