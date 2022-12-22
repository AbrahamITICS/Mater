using examen_backend_AbrahamHernandezGonzalez.Models.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UsuariosContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));
    });


////CORS//
builder.Services.AddCors(options =>
{


    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                         .AllowAnyMethod().AllowAnyHeader();
                      });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//var conexion = builder.Configuration.GetConnectionString("Conexion");
//builder.Services.AddDbContext<UsuariosContext>(x => x.UseSqlServer(conexion));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
