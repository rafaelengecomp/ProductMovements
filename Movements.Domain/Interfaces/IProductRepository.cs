using Movements.Domain.Entities;
using System.Linq;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
	{
		IQueryable<Product> Get();
	}
}
