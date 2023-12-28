using Microsoft.EntityFrameworkCore;
using pMan.BAL;
using pMan.DAL;
using pMan.DAL.Interfaces;
using pMan.BAL.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

/*------Database Connection------*/
builder.Services.AddDbContext<pManDBContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("pManDBConnection"),
        ////options => options.CommandTimeout(999)
        options => options.EnableRetryOnFailure(10, TimeSpan.FromSeconds(5), null)
    ),
    ServiceLifetime.Transient
);

/*--------------AAA-------------*/
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
//Repositories
builder.Services.AddTransient<IUserRepo, UserRepo>();
builder.Services.AddTransient<ICardAssignedToUserRepo, CardAssignedToUserRepo>();
builder.Services.AddTransient<IBoardRepo, BoardRepo>();
builder.Services.AddTransient<IListRepo, ListRepo>();
builder.Services.AddTransient<ICardRepo, CardRepo>();
//Services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICardAssignedToUserService, CardAssignedToUserService>();
builder.Services.AddTransient<IBoardService, BoardService>();
builder.Services.AddTransient<IListService, ListService>();
builder.Services.AddTransient<ICardService, CardService>();
// builder.Services.AddTransient<ITransactionRepo, TransactionRepo>();

builder.Services.AddControllers();
// builder.Services.AddApiVersioning(x =>
// {
//     x.DefaultApiVersion = new ApiVersion(1, 0);
//     x.AssumeDefaultVersionWhenUnspecified = true;
//     x.ReportApiVersions = true;
// });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "pMan - version_1.0.0",
            Version = "v1",
            Description = "An .NET Core Web API for managing pMan. Docs Guide: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/",

        }
    );
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
        Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
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
