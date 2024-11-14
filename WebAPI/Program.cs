using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Bussines.Abstract;
using Bussines.Concrete;
using Bussines.DependencyResolvers.Autofac;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Hosting;
using Core.Extensions;
using Core.DependencyResolvers;



var builder = WebApplication.CreateBuilder(args);
//.Net Core yerine baska bir IoC container kullanmak istersem ---> 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());
            });

// Add services to the container.
//Ioc Container : Autofac(AOP imkaný sunar), Ninject, CastleWindsor, StructureMap, LightInject, DryInject
//AOP
builder.Services.AddControllers();
//builder.Services.AddSingleton<IProductService,ProductManager>();
//builder.Services.AddSingleton<IProductDal,EfProductDal>();




//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

// Authentication servisini ekle
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });
//ServiceTool.Create(builder.Services);


builder.Services.AddDependencyResolvers(new ICoreModule[] {new CoreModule() });



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // JWT için Security Definition ekleme
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token as 'Bearer {token}'",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Security Requirement ekleme
    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
            {
                new OpenApiSecurityScheme{
                    Reference = new OpenApiReference{
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }});
});
var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Show detailed errors in dev environment
    app.UseSwagger();                 // Enable Swagger middleware
    app.UseSwaggerUI();              // Enable Swagger UI for API documentation
}
else
{
    // Use secure error handling in production environment
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // Adds HTTP Strict Transport Security (HSTS) in production
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
