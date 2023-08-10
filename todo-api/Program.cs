using Microsoft.EntityFrameworkCore;
using todo_api.Data.Context;

string MyAngularFrontend = "MyAngularFrontend";

var builder = WebApplication.CreateBuilder(args);

var databaseConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ToDoDbContext>(options => options.UseSqlServer(databaseConnectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAngularFrontend, policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAngularFrontend);

app.UseAuthorization();

app.MapControllers();

app.Run();
