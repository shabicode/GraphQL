
using System;
using GraphQL.Types;

namespace GraphQLProject.Models
{
	public class MenuInputType : InputObjectGraphType
	{
		public MenuInputType()
		{
			Field<IntGraphType>("id");
			Field<StringGraphType>("name");
			Field<StringGraphType>("description");
			Field<FloatGraphType>("price");
			Field<StringGraphType>("imageurl");
			Field<StringGraphType>("categoryid");
		}
	}
}

