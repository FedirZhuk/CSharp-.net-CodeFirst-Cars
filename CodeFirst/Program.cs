using Kolokwium2.Entities;
using Kolokwium2.Services;
using Microsoft.EntityFrameworkCore;
using PrzykladowyKolok2.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IWorkshopDbService, WorkshopDbServices>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WorkshopDbContext>(opt =>
{
    //Kolokwium2Database
    string connString = builder.Configuration.GetConnectionString("DbConnString");
    opt.UseSqlServer(connString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseWorkshopErrorHandling();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();