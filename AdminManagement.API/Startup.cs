using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AdminManagement.Infrastructure.Data.Contexts;
using AdminManagement.Domain.Interfaces;
using AdminManagement.Domain.Aggregates.AdminAggregate;
using AdminManagement.Infrastructure.Repositories;

namespace AdminManagement.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors();
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddControllers();
            services.AddDbContext<AdminMAnagementContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRepository<Department>, Repository<Department>>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Admin Management API",
                    Description = "In This Api , There are Endpoints for department creating , updating , Deleting.",
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "Jwt",
                    In = ParameterLocation.Header,
                    Description = "Jwt token for authorized user"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {new OpenApiSecurityScheme(){Reference=new OpenApiReference{ Id="Bearer", Type=ReferenceType.SecurityScheme}}, new string[]{ } }
                });
            });

            var issuer = Configuration["JWT:issuer"];
            var audience = Configuration["JWT:audience"];
            var key = Configuration["JWT:key"];
            byte[] keyBytes = Encoding.ASCII.GetBytes(key);
            SecurityKey securityKey = new SymmetricSecurityKey(keyBytes);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = securityKey
                };
            });

        }

    
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("v1/swagger.json", "Admin Management API"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
