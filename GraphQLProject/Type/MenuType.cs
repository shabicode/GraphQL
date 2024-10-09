﻿using System;
using GraphQL.Types;
using GraphQLProject.Models;

namespace GraphQLProject.Type
{
	public class MenuType : ObjectGraphType<Menu>
	{
		public MenuType()
		{
			Field(m => m.Id);
			Field(m => m.Name);
			Field(m => m.Description);
			Field(m => m.Price);
		}
	}
}

