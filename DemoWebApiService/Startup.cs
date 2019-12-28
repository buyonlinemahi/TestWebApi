using AutoMapper;
using Demo.Core.Data.SQLServer;
using DemoWebApiService.Helper;
using DemoWebApiService.Mapper;
using DemoWebApiService.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace DemoWebApiService
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
            var config = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
             .Build();

            services.AddDbContext<DemoDbContext>(opt =>
            opt.UseSqlServer(config["ConnectionStrings"]));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => {
                    var resolver = options.SerializerSettings.ContractResolver;
                    if (resolver != null)
                        (resolver as DefaultContractResolver).NamingStrategy = null;
                });
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes("1234567890123456");
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
           /// services.AddCors();
            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            //  app.UseCors(options =>
            //options.WithOrigins("http://localhost:4200")
            //.AllowAnyMethod()
            //.AllowAnyHeader());


            app.UseCors("Cors");

            app.UseMvc();
            app.UseAuthentication();
        }
    }
}
