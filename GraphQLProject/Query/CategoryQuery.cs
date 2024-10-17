﻿using System;
using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query
{
	public class CategoryQuery : ObjectGraphType
	{
		public CategoryQuery(ICategoryRepository categoryRepository)
		{
			Field<ListGraphType<CategoryQuery>>("Categories").Resolve(context =>
			{
				return categoryRepository.GetCategories();
			});

		}
	}
}

 