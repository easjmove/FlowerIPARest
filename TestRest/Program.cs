using Microsoft.EntityFrameworkCore;
using TestRest;
using TestRest.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string allowAllPolicy = "AllowAll";

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAllPolicy,
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                  .WithMethods("GET", "POST")
                                  .AllowAnyHeader();
                              });
});

builder.Services.AddDbContext<IpaContext>(opt =>
opt.UseSqlServer(Secrets.IpaConnectionString));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseCors(allowAllPolicy);

app.MapControllers();

app.Run();
