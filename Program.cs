using Microsoft.EntityFrameworkCore;
using TpiBarberShop;
using TpiBarberShop.Data;
using TpiBarberShop.DBContexts;
using TpiBarberShop.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using TpiBarberShop.Utils;
using TpiBarberShop.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); //Esto hay que agregarlo para que no haga referencias circulares al serializar.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("ConsultaAlumnosApiBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Ac� pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ConsultaAlumnosApiBearerAuth" } //Tiene que coincidir con el id seteado arriba en la definici�n
                }, new List<string>() }
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<ProductosData>();
builder.Services.AddSingleton<UsuariosData>();

//builder.Services.AddDbContext<Context>(dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:InfoCiudadesDBConnectionString"]));
builder.Services.AddDbContext<Context>(dbContextOptions => dbContextOptions.UseSqlite("Filename=./BarberShop.db"));

//builder.Services.AddDbContext<Context>(dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:BarberDBConnectionString"]));
//builder.Services.AddDbContext<Context>(dbContextOptions => dbContextOptions.UseSqlServer(builder.Configuration["ConnectionStrings:BarberDBConnectionString"]));

//buide.services.Configure<MercadoPagoOptions>(Configuration.GetSection("MercadoPago"));
builder.Services.Configure<MercadoPagoOptions>(builder.Configuration.GetSection("MercadoPago"));


builder.Services.AddScoped<IProductosRepository, ProductosRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IComprasRepository, ComprasRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IOrdenCompraRepository, OrdenCompraRepository>();
builder.Services.AddScoped<IDetalleCompraRepository, DetalleCompraRepository>();
builder.Services.AddScoped<IImagesRepository, ImagesRepository>();
builder.Services.AddScoped<PayPalClientApi>();






builder.Services.AddAuthentication("Bearer") //"Bearer" es el tipo de auntenticaci�n que tenemos que elegir despu�s en PostMan para pasarle el token
   .AddJwtBearer(options => //Ac� definimos la configuraci�n de la autenticaci�n. le decimos qu� cosas queremos comprobar. La fecha de expiraci�n se valida por defecto.
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    }
);
builder.Services.AddAuthorization();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
if (app.Environment.IsDevelopment())

    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
