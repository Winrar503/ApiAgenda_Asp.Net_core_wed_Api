using Agenda.WedApi.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeptosES", Version = "v1" });

    // *** Incluir  JWT Authentication ***
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Ingresar tu token de JWT Authentication",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement { { jwtSecurityScheme, Array.Empty<string>() } });
    // ******************************************
});

// *** Reducir el tamaño del JSON quitando las propiedades nulas o con valores por defecto ***
builder.Services.AddControllers()
   .AddJsonOptions(options =>
   {
       options.JsonSerializerOptions.IgnoreNullValues = true;
       options.JsonSerializerOptions.WriteIndented = true;
   });
//****************************************************************

#region Seguridad por token JWT
var key = "8c8fbc6b-f62c-4100-9faf-3808590e57b8"; // Agregar la llave   

// Configurar el JWT
builder.Services
 .AddAuthentication(x =>
 {
     // Configurar la autentificaion de JWT por defecto en la Web API
     x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
     x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
 })
 .AddJwtBearer(x =>
 {
     // Agregar las configuracion por defecto al JWT
     x.RequireHttpsMetadata = false;
     x.SaveToken = true;
     x.TokenValidationParameters = new TokenValidationParameters
     {
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
         ValidateAudience = false,
         ValidateIssuerSigningKey = true,
         ValidateIssuer = false
     };
 });

// Aplicar la inyeccion de dependencia para JWT
builder.Services.AddSingleton<IJwtAuthenticationService>(new JwtAuthenticationService(key));
#endregion

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Habilitar los Cors para todo tipo de origenes
app.UseCors(options =>
{
    options.WithOrigins("*");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});
//*****************************


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); //agregar la autenticación
app.UseAuthorization();

app.MapControllers();

app.Run();
