using DbUndervisning.Context;
using DbUndervisning.Model.Enums;
using DbUndervisning.Services;
using DbUndervisning.Services.Interfaces;
using EF_InteractionFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IWorldService,WorldService>();
builder.Services.AddTransient<IGuidService, GuidService>();
builder.Services.AddTransient<IRegionService, RegionService>();
builder.Services.AddTransient<IHumanoidService, HumanoidService>();
builder.Services.AddTransient<IMobService, MobService>();
builder.Services.AddTransient<IPlayerService, PlayerService>();

//var datasourcebuilder = new NpgsqlDataSourceBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));
//datasourcebuilder.MapEnum<ClassType>();
//datasourcebuilder.MapEnum<RarityLevel>();
//datasourcebuilder.MapEnum<StatType>();
//var dataSource = datasourcebuilder.Build();
//builder.Services.AddDbContext<WorldContext>();
//builder.Services.AddDbContextFactory<WorldContext>(opt => opt.UseNpgsql(dataSource));

builder.Services.AddDbContextFactory<WorldContext>();
builder.Services.AddTransientAsyncRepository<WorldContext>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
	var services = scope.ServiceProvider;
	var context = services.GetRequiredService<WorldContext>();

    await context.Database.EnsureCreatedAsync();
}
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
