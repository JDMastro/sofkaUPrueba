using FluentValidation.AspNetCore;
using SofkaUPrueba.Core.Interfaces;
using SofkaUPrueba.Infrastructure;
using SofkaUPrueba.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//INYECCIONES DE INFRASTRUCTURE
builder.Services.AddInfrastructure(builder.Configuration);

//REGISTRAR AUTOMAPPER
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//REGISTRAR INYECCIONES
builder.Services.AddTransient<IPlayersRepository, PlayersRepository>();
builder.Services.AddTransient<ICategoriesRepository, CategoriesRepository>();
//builder.Services.AddTransient<IGamesRepository, GamesRepository>();
builder.Services.AddTransient<IOptionsRepository, OptionsRepository>();
builder.Services.AddTransient<IQuestionsRepositorycs, QuestionsRepository>();

//REGISTRAR VALIDATIONS
builder.Services.AddFluentValidation(options =>
{
    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});


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
