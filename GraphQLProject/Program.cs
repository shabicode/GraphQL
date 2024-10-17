using GraphQLProject.Services;
using GraphQLProject.Interfaces;
using GraphQLProject.Query;
using GraphQLProject.Type;
using GraphQLProject.Schema;
using GraphQLProject.Mutation;
using GraphQLProject.Models;
using GraphQL.Types;
using GraphQL;
using GraphiQl;
using GraphQLProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IMenuRepository, MenuRepository>();
builder.Services.AddTransient<IReservationRepository, ReservationRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<MenuType>();
builder.Services.AddTransient<CategoryType>();
builder.Services.AddTransient<ReservationType>();

builder.Services.AddTransient<MenuQuery>();
builder.Services.AddTransient<CategoryQuery>();
builder.Services.AddTransient<ReservationQuery>();
builder.Services.AddTransient<RootQuery>();


//builder.Services.AddTransient<MenuMutation>();
//builder.Services.AddTransient<MenuInputType>();

builder.Services.AddTransient<ISchema, RootSchema>();

builder.Services.AddGraphQL(b => b.AddAutoSchema<ISchema>().AddSystemTextJson());
builder.Services.AddDbContext<GraphQLDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("GraphQLDbContextConnection")));
builder.Services.AddDbContext<GraphQLDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("GraphQLDbContextConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();

app.UseAuthorization();

app.MapControllers();

app.Run(); 

