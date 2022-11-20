using Microsoft.EntityFrameworkCore;
using TodoList.BLL.Interfaces;
using TodoList.BLL.Services;
using TodoList.DAL;
using TodoList.DAL.Entities;
using TodoList.DAL.Repositories;
using TodoList.DAL.Repositories.Interfaces;
using TodoList.DAL.Repositories.Realizations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoListDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("TodoListDBConnection")));

builder.Services.AddTransient(typeof(IRepositoryBase<TodoItem>), typeof(TodoItemRepository));
builder.Services.AddScoped<ITodoItemService, TodoItemService>();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontendURL = configuration.GetValue<string>("frontend_url");

    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
