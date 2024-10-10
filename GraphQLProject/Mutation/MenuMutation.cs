﻿using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;
using GraphQLProject.Models;

namespace GraphQLProject.Mutation
{
	public class MenuMutation : ObjectGraphType
	{
		public MenuMutation(IMenuRepository menuRepository)
		{
            Field<MenuType>("CreateMenu").Arguments(new QueryArguments(
                new QueryArgument<MenuInputType> { Name = "menu" })).Resolve(context =>
            {
                return menuRepository.AddMenu(context.GetArgument<Menu>("menu"));
            });

            Field<MenuType>("UpdateMenu").Arguments(new QueryArguments(
                new QueryArgument<IntGraphType> { Name = "menuId" },
                new QueryArgument<MenuInputType> { Name = "menu" })).Resolve(context =>
            {
                var menu = context.GetArgument<Menu>("menu");
                var menuId = context.GetArgument<int>("menuId");
                return menuRepository.UpdateMenu(menuId,menu);
            });

            Field<StringGraphType>("DeleteMenu").Arguments(new QueryArguments(
                new QueryArgument<IntGraphType> { Name = "menuId" })).Resolve(context =>
            {
                var menuId = context.GetArgument<int>("menuId");
                menuRepository.DeleteMenu(menuId);
                return "the menu was deleted";
            });
        }
	}
}

