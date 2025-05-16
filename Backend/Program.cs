
using System;
using System.Text;
using LetterboxdProject.MapperConfig;
using LetterboxdProject.Models;
using LetterboxdProject.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LetterboxdProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string data = "";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(op => op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("LetterboxdDb")));
            builder.Services.AddAutoMapper(typeof(mappConfig));
            builder.Services.AddControllers();
            //builder.Services.AddScoped<DbContext, AppDbContext>();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAuthentication(option =>
            option.DefaultAuthenticateScheme = "mySchema")
                .AddJwtBearer("mySchema", option =>
                {
                    var key = "hellloooooooooooooooooooooooooooo";
                    var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = secretKey,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(data,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            builder.Services.AddScoped<unitOfWork>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(op => op.SwaggerEndpoint("/openapi/v1.json", "v1"));
            }
            app.UseCors(data);
            app.UseHttpsRedirection();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
