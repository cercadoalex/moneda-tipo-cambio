using Api.Entities;
using Api.Interfaces;
using Api.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddScoped<IDivisa, DivisaRepository>();
builder.Services.AddScoped<ITablaConversion, TablaConversionRepository>();
builder.Services.AddScoped<IConversionTipoCambio, ConversionTipoCambioRepository>();


var AppSettingSeccion = configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(AppSettingSeccion);


//jwt
var appsetting = AppSettingSeccion.Get<AppSettings>();
var KeyValue = Encoding.ASCII.GetBytes(appsetting.KeyApi);
builder.Services.AddAuthentication(d =>
{
    d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(d =>
    {
        d.RequireHttpsMetadata = false;
        d.SaveToken = true;
        d.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(KeyValue),
            ValidateIssuer = false,
            ValidateAudience = false,
            //RequireExpirationTime=true,
            ValidateLifetime = false,
            //ClockSkew = TimeSpan.Zero
        };
    });

//builder.Services.AddAuthorization();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("corsapp");
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
