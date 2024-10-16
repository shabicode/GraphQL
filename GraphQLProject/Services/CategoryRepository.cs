using System;
using GraphQLProject.Interfaces;
using GraphQLProject.Data;
using GraphQLProject.Models;

namespace GraphQLProject.Services
{
	public class CategoryRepository : ICategoryRepository
	{
        private GraphQLDbContext graphQLDbContext;
		public CategoryRepository(GraphQLDbContext graphQLDbContext)
		{
            this.graphQLDbContext = graphQLDbContext;
		}

        public Category AddCategory(Category category)
        {
            graphQLDbContext.Categories.Add(category);
            graphQLDbContext.SaveChanges();
            return category;
        }

        public void DeleteCategory(int id)
        {
            var categoryResult = graphQLDbContext.Categories.Find(id);
            graphQLDbContext.Remove(categoryResult);
            graphQLDbContext.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return graphQLDbContext.Categories.ToList();
        }

        public Category UpdateCategory(int id, Category category)
        {
            var categoryResult = graphQLDbContext.Categories.Find(id);
            categoryResult.Name = category.Name;
            categoryResult.ImageUrl = category.ImageUrl;
            graphQLDbContext.SaveChanges();
            return category;
        }
    }
}

