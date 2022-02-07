using Microsoft.EntityFrameworkCore;
using Movements.Domain.Entities;
using System;
using System.Linq;
using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(SqlServerContext context)
			: base(context) { }

		public IQueryable<Product> Get()
		{
			return Query(x => x.Status == "A");
		}
    }
}
