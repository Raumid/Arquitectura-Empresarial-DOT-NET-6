using Pacagroup.Ecommerce.Services.WebApi.Helpers;
using System.Text;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Swagger;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Authentication;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Validator;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Mapper;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Injection;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Versioning;

var builder = WebApplication.CreateBuilder(args);

//Settings
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Config"));

builder.Services.AddMapper();

builder.Services.AddInjection(builder.Configuration);

builder.Services.AddAuthentication(builder.Configuration);

//./Modules/Swagger/ConfigureSwaggerOptions.cs
builder.Services.AddVersioning();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwagger();

builder.Services.AddValidator();

var app = builder.Build();

// Configure the HTTP request pipeline. 
if (app.Environment.IsDevelopment())
{

}

app.UseCors(builder =>
{
    // Cualquier Origen
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
});

app.UseAuthentication();

app.UseSwagger();
app.UseSwaggerUI(o => 
{
    o.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    o.SwaggerEndpoint("/swagger/v2/swagger.json", "API v2");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
