using Application.Common.Interfaces.Movies;
using Application.Extensions;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using Server.Contexts;
using Server.Extensions;
using Server.Services.Movies;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddFastEndpoints();
builder.Services.AddApplicationServices();
builder.Services.AddRepos();
builder.Services.AddSwaggerDoc();

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run();
