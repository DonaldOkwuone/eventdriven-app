using Microsoft.EntityFrameworkCore;
using PlatformService.Repository;
using AutoMapper;
using PlatformService.Dtos;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAutoMapper();
builder.Services.AddDbContext<AppDbContext>(
    opt => opt.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("PlatformDb"))
);
builder.Services.AddAutoMapper(
    cfg => { cfg.AddProfile<CreatePlatformProfile>(); }
);
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDb.PrePopulation(app, app.Environment.IsProduction());

app.Run();
