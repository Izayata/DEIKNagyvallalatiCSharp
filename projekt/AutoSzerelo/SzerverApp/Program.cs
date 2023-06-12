using Serilog;
using SzerverApp;

var builder = WebApplication.CreateBuilder(args);


//LOGLOLÁSHOZ A KÓD
builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration.MinimumLevel.Debug().WriteTo.Console()); //.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day) --> Log fájlba iratása

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IGuidService, GuidService>();
builder.Services.AddSingleton<IPersonRepository, PersonRepository>();

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
