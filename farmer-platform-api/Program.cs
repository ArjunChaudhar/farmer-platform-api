
using FarmerPlatform.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using farmer_platform_api.Helpers;
using farmer_platform_api.Interfaces;
using farmer_platform_api.Services;

namespace farmer_platform_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //  Add services to the container BEFORE builder.Build()

            // Controllers
            builder.Services.AddControllers();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            // Authentication + JWT
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
                };
            });

            // Custom services
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<JwtTokenGenerator>();

            // Authorization
            builder.Services.AddAuthorization();

            // Build the app AFTER all services are registered
            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        //        public static void Main(string[] args)
        //        {
        //            var builder = WebApplication.CreateBuilder(args);

        //            // Add services to the container.

        //            builder.Services.AddControllers();
        //            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        //            builder.Services.AddEndpointsApiExplorer();
        //            builder.Services.AddSwaggerGen();

        //            var app = builder.Build();

        //            // Configure the HTTP request pipeline.
        //            if (app.Environment.IsDevelopment())
        //            {
        //                app.UseSwagger();
        //                app.UseSwaggerUI();
        //            }
        //            builder.Services.AddDbContext<ApplicationDbContext>(options =>
        //    options.UseSqlServer(
        //        builder.Configuration.GetConnectionString("DefaultConnection")));

        //            builder.Services.AddAuthentication(options =>
        //            {
        //                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //            })
        //.AddJwtBearer(options =>
        //{
        //    options.TokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateIssuer = true,
        //        ValidateAudience = true,
        //        ValidateLifetime = true,
        //        ValidateIssuerSigningKey = true,

        //        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        //        ValidAudience = builder.Configuration["JwtSettings:Audience"],

        //        IssuerSigningKey = new SymmetricSecurityKey(
        //            Encoding.UTF8.GetBytes(
        //                builder.Configuration["JwtSettings:Key"]))
        //    };
        //});
        //            builder.Services.AddScoped<IAuthService, AuthService>();

        //            builder.Services.AddScoped<JwtTokenGenerator>();

        //            builder.Services.AddAuthorization();

        //            app.UseAuthentication();

        //            app.UseAuthorization();

        //            app.UseHttpsRedirection();

        //            //app.UseAuthorization();


        //            app.MapControllers();

        //            app.Run();
        //        }
    }
}