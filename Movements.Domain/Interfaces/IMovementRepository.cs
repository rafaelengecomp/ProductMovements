using Movements.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces
{
    public interface IMovementRepository : IRepository<Movement>
	{
		IEnumerable<Movement> Get();
	}
}
