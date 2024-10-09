using System;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services
{
	public class MenuRepository : IMenuRepository
	{
        private static List<Menu> MenuList = new List<Menu>()
        {
            new Menu(){Id = 1, Name = "Burger", Description = "A juicy chicken burger with Lettuce and cheese", Price = 8.99 },
            new Menu(){Id = 1, Name = "Pizza", Description = "Tomato, mozzarella and basil pizza", Price = 10.50 },
            new Menu(){Id = 1, Name = "Grilled Chicken Salad", Description = "Fresh garden salada with grilled chicken", Price = 7.95 },
            new Menu(){Id = 1, Name = "Pasta Alfredo", Description = "Cremy Alfredo sauce with fettuccine pasta", Price = 12.75 },
            new Menu(){Id = 1, Name = "Chocolate Brownie", Description = "Warm chocolate brownie with ice cream and fudge", Price = 6.99}
        };

        public Menu AddMenu(Menu menu)
        {
            MenuList.Add(menu);
            return menu;
        }

        public void DeleteMenu(int id)
        {
            MenuList.RemoveAt(id);
        }

        public List<Menu> GetAllMenu()
        {
            return MenuList;
        }

        public Menu GetMenuById(int id)
        {
            return MenuList.Find(x => x.Id == id);
        }

        public Menu UpdateMenu(int id, Menu menu)
        {
            MenuList[id] = menu;
            return menu;
        }
    }
}

