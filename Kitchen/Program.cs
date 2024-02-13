using Kitchen.Common;
using Kitchen.Filters;
using Kitchen.Infrastructure;
using Kitchen.Infrastructure.Configurations;
using Kitchen.Infrastructure.Repositories;
using Kitchen.UseCases.Configurations;
using Kitchen.UseCases.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Kitchen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var authSection = builder.Configuration.GetSection("Auth");
            var authOptions = authSection.Get<AuthOptions>();
            var connectionString = builder.Configuration.GetConnectionString("DBConnection");

            builder.Services.Configure<AuthOptions>(authSection);
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(x =>
            {
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Authorization header using the Bearer scheme.\n" +
                        "Instuction! Write 'Bearer', add space and set token.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                x.DocumentFilter<SwaggerSecurityRequirementsDocumentFilter>();
            });
            builder.Services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            builder.Services.AddDbContext<KitchenDbContext>(options
                => options.UseNpgsql(connectionString));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IKitchenModule, KitchenModule>();
            builder.Services.AddMediatR(config
                => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = authOptions.Issuer,
                        ValidAudience = authOptions.Audience,
                        IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true
                    };
                });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<KitchenDbContext>();
                db.Database.Migrate();
            }

            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseEndpoints(endpoints =>
            {
                app.MapControllers();
            });

            app.Run();
        }
    }
}