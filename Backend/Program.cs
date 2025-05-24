using System.Text;
using CinephileProject.MapperConfig;
using CinephileProject.Models;
using CinephileProject.Services;
using CinephileProject.UnitsOfWork;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CinephileProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string data = "";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(op => op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Db")));
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
            builder.Services.AddScoped<MovieService>();
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
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllers();

            app.Run();
        }
    }
}
