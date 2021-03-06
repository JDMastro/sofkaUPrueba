using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SofkaUPrueba.Core.Interfaces;
using SofkaUPrueba.Core.Services;
using SofkaUPrueba.Infrastructure;
using SofkaUPrueba.Infrastructure.Filters;
using SofkaUPrueba.Infrastructure.Options;
using SofkaUPrueba.Infrastructure.Repositories;
using System.Text;
using SofkaUPrueba.Infrastructure.Services;
using SofkaUPrueba.Infrastructure.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//string Micors = "Micors";

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllOrigins",
        builder =>
        {
            builder.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials();
        });
});

// Add services to the container.

builder.Services.AddControllers(options => { options.Filters.Add<GlobalExceptionFilter>(); }).AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
   {
     new OpenApiSecurityScheme
     {
       Reference = new OpenApiReference
       {
         Type = ReferenceType.SecurityScheme,
         Id = "Bearer"
       }
      },
      new string[] { }
    }
  });
});

//CONFIG CIFRADO DE PASS
builder.Services.Configure<PasswordOptions>(builder.Configuration.GetSection("PasswordOptions"));

//INYECCIONES DE INFRASTRUCTURE
builder.Services.AddInfrastructure(builder.Configuration);

//REGISTRAR AUTOMAPPER
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//REGISTRAR INYECCIONES
builder.Services.AddTransient<IPlayersService, PlayersService>();
builder.Services.AddTransient<IPlayersRepository, PlayersRepository>();
builder.Services.AddTransient<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddTransient<IOptionsRepository, OptionsRepository>();
builder.Services.AddTransient<IQuestionsService, QuestionsService>();
builder.Services.AddTransient<IQuestionsRepository, QuestionsRepository>();
builder.Services.AddTransient<IHistoryRepository, HistoryRepository>();
builder.Services.AddTransient<IHistoryService, HistoryService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddSingleton<IPasswordService, PasswordService>();

//REGISTRAR JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretKey"]))
    };
});


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllOrigins");


app.UseAuthentication();

app.UseAuthorization();


app.UseHttpsRedirection();

app.MapControllers();

app.Run();
