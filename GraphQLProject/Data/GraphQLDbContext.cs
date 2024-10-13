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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Menu>().HasData(
                new Menu() { Id = 1, Name = "Burger", Description = "A juicy chicken burger with lettuce and cheese", Price = 10.50 },
                new Menu() { Id = 2, Name = "Salad", Description = "Tomato and fresh lettuce", Price = 10.50 },
                new Menu() { Id = 3, Name = "Burrito", Description = "Tortilla ", Price = 10.50 },
                new Menu() { Id = 4, Name = "Pasta Alfredo", Description = "Creamy Alfredo sauce with fettuccine pasta", Price = 10.50 },
                new Menu() { Id = 5, Name = "Chocolate", Description = "Warm chocolate brownie with ice cream" , Price = 10.50 }
            );
        }
    }
}

