using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ProyectoBibliotecaAPI.Repositorios.Libro;
using ProyectoBibliotecaAPI.Servicios.Libro;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region -- Injeccion -
builder.Services.AddScoped<ILibroService, LibroService>();
builder.Services.AddScoped<ILibroRepository, LibroRepository>();

#endregion

#region -- SUPABASE --

var url = builder.Configuration["Supabase:Url"];
var key = builder.Configuration["Supabase:ServiceRoleKey"];
var options = new Supabase.SupabaseOptions
{
    AutoConnectRealtime = true
};
var supabase = new Supabase.Client(url, key, options);
await supabase.InitializeAsync();

builder.Services.AddSingleton(supabase);
#endregion

#region -- JWT --
//OBTENER LOS VALORES QUE HAY EN EL APPSETTINGS
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!))
        };
    });
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication(); //Middleware. VALIDA EL TOKEN EN CADA PETICIÓN.
app.UseAuthorization();

app.MapControllers();

app.Run();
