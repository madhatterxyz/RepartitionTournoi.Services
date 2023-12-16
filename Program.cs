using RepartitionTournoi.Domain;
using RepartitionTournoi.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
            .AddScoped<ITournoiDomain, TournoiDomain>()
            .AddScoped<IMatchDomain, MatchDomain>()
            .AddScoped<IJoueurDomain, JoueurDomain>()
            .AddScoped<IJeuDomain, JeuDomain>()
            .AddScoped<IScoreDomain, ScoreDomain>()
            .RegisterDALServices();
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
