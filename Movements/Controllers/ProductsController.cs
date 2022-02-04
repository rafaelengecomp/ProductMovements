using Microsoft.AspNetCore.Mvc;
using System;
using Template.Application.Interfaces;

namespace Movements.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;

        public ProductsController(IProductService service)
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

    }
}
