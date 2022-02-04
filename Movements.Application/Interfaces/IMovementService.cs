using System.Collections.Generic;
using Template.Application.ViewModels.Users;

namespace Template.Application.Interfaces
{
	public interface IMovementService
	{
        List<MovementViewModel> Get();
    }
}
