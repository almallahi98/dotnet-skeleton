using Microsoft.EntityFrameworkCore;
using Presistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContextApp>(opt =>{
    opt.UseSqlite(builder.Configuration.GetConnectionString("ConnString"));
    
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;
try 
{
    var context =service.GetRequiredService<DbContextApp>();
    await context.Database.MigrateAsync();
    await Seeding.DataSeed(context);
}
catch (Exception ex)
{
    
    var logger = service.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex,"massge of error");
}

app.Run();
