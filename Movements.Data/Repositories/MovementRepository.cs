using Microsoft.EntityFrameworkCore;
using Movements.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class MovementRepository : Repository<Movement>, IMovementRepository
	{
		public MovementRepository(MySQLContext context)
			: base(context) { }

		public IEnumerable<Movement> Get()
		{
			return GetAll();
		}
    }
}
