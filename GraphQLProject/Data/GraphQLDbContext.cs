using System;
using GraphQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.Data
{
	public class GraphQLDbContext : DbContext
    {
		public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) : base(options)
		{
		}

		public DbSet<Menu> Menus { get; set; }
	}
}

