using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Extensions;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        // public Startup(IConfiguration configuration)           // THIS IS Microsoft WAY
        // {                                                      // THIS IS Microsoft WAY
        //     Configuration = configuration;                     // THIS IS Microsoft WAY
        // }                                                      // THIS IS Microsoft WAY
        // public IConfiguration Configuration { get; }           // THIS IS Microsoft WAY


        private readonly IConfiguration _config;   // THIS IS OUR WAY. The IConfiguration is injected into the class when it is constucted.
        public Startup(IConfiguration config)      // We'll have access to this configuration whereever we need it inside the class.
        {
            _config = config;                      // THIS IS OUR WAY. The IConfiguration is injected into the class when it is constucted.
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddScoped<ITokenService, TokenService>();      // The interface is helpful for unit testing purposes. It is easy to mock an interface with test data
            
            // services.AddDbContext<DataContext>(options => {
            //     // options.UseSqlite("Connection string");
            //     options.UseSqlite(_config.GetConnectionString("DefaultConnection"));        // MOVED TO ApplicationServiceExtensions.cs
            // });
            services.AddApplicationServices(_config);


            services.AddControllers();
            services.AddCors();

            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)     // MOVED TO IdentityServiceExtensions.cs
            //     .AddJwtBearer(options =>
            //     {
            //         options.TokenValidationParameters = new TokenValidationParameters
            //             {
            //                 ValidateIssuerSigningKey = true,
            //                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"])),
            //                 ValidateIssuer = false,   // Issuer: API Server
            //                 ValidateAudience = false  // Audience: Angular application
            //             };
            //     });
            services.AddIdentityServices(_config);
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)       // MIDDLEWARE SECTION
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));    // added manually

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
