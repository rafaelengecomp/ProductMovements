using Movements.Domain.Entities;
using Template.Application.Services;
using Template.Application.ViewModels;
using Template.Application.ViewModels.Users;

using Profile = AutoMapper.Profile;


namespace Template.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {

            #region "ViewModel To Domain"

            CreateMap<CreateProductMovementViewModel, Movement>();

            #endregion

            #region "Domain to ViewModel"
 
            CreateMap<Movement, MovementViewModel>();
            
            CreateMap<Product, ProductsViewModel>();
            CreateMap<Cosif, CosifViewModel>();

            #endregion
        }
    }
}
