using EF_InteractionFrameworkCore;
using MultiPlayerDb.Context;
using MultiPlayerDb.Services;
using MultiPlayerDb.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IWorldService, WorldService>();
builder.Services.AddTransient<IGuidService, GuidService>();
builder.Services.AddTransient<IRegionService, RegionService>();
builder.Services.AddTransient<IHumanoidService, HumanoidService>();
builder.Services.AddTransient<IMobService, MobService>();
builder.Services.AddTransient<IPlayerService, PlayerService>();

builder.Services.AddDbContextFactory<WorldContext>();
builder.Services.AddTransientAsyncRepository<WorldContext>();
builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;

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
