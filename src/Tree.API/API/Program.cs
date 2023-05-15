using API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureAPI()
       .ConfigureOptions()
       .AddApplication()
       .AddPersistence()
       .AddInfrastructure()
       .ConfigureSwagger();

var app = builder.Build();

//app.UseDbMigrations();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
