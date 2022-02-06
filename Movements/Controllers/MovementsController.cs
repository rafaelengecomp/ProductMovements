using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Template.Application.Interfaces;
using Template.Application.ViewModels.Users;

namespace Movements.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class MovementsController : ControllerBase
    {
        private readonly IMovementService service;

        public MovementsController(IMovementService service)
        {
            this.service = service;
        }
  
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(service.Get());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Post(CreateProductMovementViewModel productMoviment)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(service.Post(productMoviment));
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
