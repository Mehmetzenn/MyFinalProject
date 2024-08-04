using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstracts;
using Business.Concretes;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
        public class Program
        {
            public static void Main(string[] args)
            {
                var builder = WebApplication.CreateBuilder(args);

                builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                });

                // Add services to the container.

                builder.Services.AddControllers();
                builder.Services.AddCors();

                builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

                var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

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
                builder.Services.AddDependencyResolvers(new ICoreModule[]
                {
                new CoreModule()
                });
                //builder.Services.AddSingleton<IProductService, ProductManager>();
                //builder.Services.AddSingleton<IProductDal , EfProductDal>();
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();


                var app = builder.Build();

                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.ConfigureCustomExceptionMiddleware();

                app.UseCors(builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
                
                app.UseAuthorization();
    
                app.UseHttpsRedirection();
            
                app.UseAuthentication();

                app.MapControllers();   

                app.Run();
            }
        }
}

