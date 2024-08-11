using Microsoft.EntityFrameworkCore;
using PROYECTO_2024.BD.DATA;
using System.Text.Json.Serialization;

//----------------------------------------------------------------------------
//configuracion de los servicios en el contructor
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddJsonOptions(
    x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//servicio para conectarse a la bd
builder.Services.AddDbContext<Context>(op => op.UseSqlServer("name=conn"));

//----------------------------------------------------------------------------------

// aca se construye la app 
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
