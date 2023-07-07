using Microsoft.EntityFrameworkCore;
using Tarefas.Data;
using Tarefas.Service.Interface;
using Tarefas.Service;
using Products.Repository;
using Tarefas.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database
var connString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<TarefasContext>(options => options.UseSqlite(connString));
#endregion

builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<ITarefaRepository, ProductRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
