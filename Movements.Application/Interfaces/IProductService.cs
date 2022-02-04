using System.Collections.Generic;
using Template.Application.ViewModels;
using Template.Application.ViewModels.Users;

namespace Template.Application.Interfaces
{
	public interface IProductService
	{
        List<ProductsViewModel> Get();
    }
}
