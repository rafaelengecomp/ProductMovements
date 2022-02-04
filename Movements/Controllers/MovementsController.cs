using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Application.Services;
using Template.CrossCutting.Auth.Interfaces;
using Template.CrossCutting.Auth.ViewModels;

namespace Movements.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class MovementsController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IMovementService service;

        public MovementsController(IMovementService service, IAuthService authService)
        {
            this.service = service;
            this.authService = authService;
        }
  
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ContextUserViewModel _user = authService.GetLoggedUser();
                if (_user == null || !UtilsService.IsAdmin(_user.Profile))
                    return Unauthorized();

                return Ok(service.Get());
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
