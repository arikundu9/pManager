using Microsoft.EntityFrameworkCore;
// using pMan.BAL;
using pMan.DAL;
using pMan.DAL.Interfaces;
// using pMan.BAL.Interface;
using Microsoft.AspNetCore.Mvc;

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
//Services
// builder.Services.AddTransient<ITransactionRepo, TransactionRepo>();

builder.Services.AddControllers();
// builder.Services.AddApiVersioning(x =>
// {
//     x.DefaultApiVersion = new ApiVersion(1, 0);
//     x.AssumeDefaultVersionWhenUnspecified = true;
//     x.ReportApiVersions = true;
// });
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
