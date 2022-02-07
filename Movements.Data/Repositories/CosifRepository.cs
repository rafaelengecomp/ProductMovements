using Microsoft.EntityFrameworkCore;
using Movements.Domain.Entities;
using System;
using System.Linq;
using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class CosifRepository : Repository<Cosif>, ICosifRepository
	{
		public CosifRepository(SqlServerContext context)
			: base(context) { }

		public IQueryable<Cosif> Get()
		{
			return Query(x => x.Status == "A");
		}
    }
}
