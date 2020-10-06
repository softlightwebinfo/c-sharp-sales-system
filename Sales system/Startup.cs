using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Sales_system.Interfaces;
using Sales_system.Interfaces.Repository.Business;
using Sales_system.Interfaces.Repository.Suppliers;
using Sales_system.Interfaces.Services.Business;
using Sales_system.Interfaces.Services.Suppliers;
using Sales_system.Models.Common;
using Sales_system.Repository.Business;
using Sales_system.Repository.Suppliers;
using Sales_system.Services;
using Sales_system.Services.Business;
using Sales_system.Services.Suppliers;

namespace Sales_system
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSetting>(appSettingSection);

            // JWT
            var appSettings = appSettingSection.Get<AppSetting>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(d =>
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
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddScoped<IAuthService, AuthService>();
            // Business Injection Services
            services.AddScoped<IBusinessService, BusinessPublishService>();
            services.AddScoped<IBusinessUpdateService, BusinessUpdateService>();
            services.AddScoped<IBusinessDeleteService, BusinessDeleteService>();
            
            // Suppliers Injection Services
            services.AddScoped<ISuppliersService, SuppliersPublishService>();
            services.AddScoped<ISuppliersUpdateService, SuppliersUpdateService>();
            services.AddScoped<ISuppliersGetAllService, SuppliersGetAllService>();
            services.AddScoped<ISuppliersGetService, SuppliersGetService>();
            services.AddScoped<ISuppliersDeleteService, SuppliersDeleteService>();
            
            // Repositories
            services.AddScoped<IBusinessRepository, BusinessRepository>();
            services.AddScoped<ISuppliersRepository, SuppliersRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}