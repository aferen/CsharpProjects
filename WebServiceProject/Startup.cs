using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebServiceProject.Persistence;
using WebServiceProject.Repository;
using WebServiceProject.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebServiceProject.Models;
using WebServiceProject.Security.Tokens;
using WebServiceProject.Repositories;
using WebServiceProject.Security.Hashing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


namespace WebServiceProject
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
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            //for mssql server
            services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection1")));

            //for mysql server
            //services.AddDbContext<AppDbContext>(options =>
            // options.UseMySql(Configuration.GetConnectionString("DefaultConnection2")));

            //for in memory database
            //services.AddDbContext<AppDbContext>(options => {
            //    options.UseInMemoryDatabase("api-in-memory");
            //});

            services.AddControllers();

            services.AddScoped<IRepository<MainCategory>, CategoryRepository>();
            services.AddScoped<IService<MainCategory>, CategoryService>();
            services.AddScoped<IRepository<Slider>, SliderRepository>();
            services.AddScoped<IService<Slider>, SliderService>();
            services.AddScoped<IRepository<Currency>, CurrencyRepository>();
            services.AddScoped<IService<Currency>, CurrencyService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<ITokenHandler, Security.Tokens.TokenHandler>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        IssuerSigningKey = signingConfigurations.Key,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddAutoMapper(this.GetType().Assembly);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseMvc();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
