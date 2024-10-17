using System;
using GraphQL.Types;
using GraphQLProject.Models;
namespace GraphQLProject.Type
{
	public class CategoryType : ObjectGraphType<Category>
	{
		public CategoryType()
		{
			Field(m => m.Id);
			Field(m => m.Name);
			Field(m => m.ImageUrl);
		}
	}
}

