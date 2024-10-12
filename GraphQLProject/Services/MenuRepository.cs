using System;
using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services
{
	public class MenuRepository : IMenuRepository
	{
        private GraphQLDbContext graphQLDbContext;

        public MenuRepository(GraphQLDbContext graphQLDbContext)
        {
            this.graphQLDbContext = graphQLDbContext;
        }

        private static List<Menu> MenuList = new List<Menu>()
        {
           
        };

        public Menu AddMenu(Menu menu)
        {
            graphQLDbContext.Menus.Add(menu);
            graphQLDbContext.SaveChanges();
            return menu;
        }

        public void DeleteMenu(int id)
        {
            var menuResult = graphQLDbContext.Menus.Find(id);
            graphQLDbContext.Remove(menuResult);
            graphQLDbContext.SaveChanges();
        }

        public List<Menu> GetAllMenu()
        {
            return graphQLDbContext.Menus.ToList();
        }

        public Menu GetMenuById(int id)
        {
            return graphQLDbContext.Menus.Find(id); 
        }

        public Menu UpdateMenu(int id, Menu menu)
        {
            var menuResult = graphQLDbContext.Menus.Find(id);
            menuResult.Name = menu.Name;
            menuResult.Description = menu.Description;
            menuResult.Price = menu.Price;
            graphQLDbContext.SaveChanges();
            return menu;
        }
    }
}

