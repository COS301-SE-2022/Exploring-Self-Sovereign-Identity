using ExploringSelfSovereignIdentityAPI.Data;
using ExploringSelfSovereignIdentityAPI.Repositories.Example;
using ExploringSelfSovereignIdentityAPI.Repositories.SessionRepository;
using ExploringSelfSovereignIdentityAPI.Repositories.Transactions;
using ExploringSelfSovereignIdentityAPI.Repositories.UserDataRepository;
using ExploringSelfSovereignIdentityAPI.Services;
using ExploringSelfSovereignIdentityAPI.Services.blockChain;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using ExploringSelfSovereignIdentityAPI.Services.Example;
using ExploringSelfSovereignIdentityAPI.Services.Transactions;
using ExploringSelfSovereignIdentityAPI.Services.UserDataService;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Steeltoe.Connector.OAuth;
using System.Reflection;
using ExploringSelfSovereignIdentityAPI.Services.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace exploring_self_sovereign_identity_api
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
            services.AddOAuthServiceOptions(Configuration);

            //Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audiance"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))

                    };
                });

            services.AddMvc();
            services.AddControllers();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "exploring_self_sovereign_identity_api", Version = "v1" });
            });


            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);


            //Services
            services.AddTransient<IExampleRepository, ExampleRepository>();
            services.AddTransient<IExampleService, ExampleService>();
            services.AddTransient<ISessionRepository, SessionRepository>();
            services.AddTransient<ISessionService, SessionService>();     
            services.AddTransient<IUserDataRepository, UserDataRepository>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<ExploringSelfSovereignIdentityAPI.Services.UserDataService.IUserDataService, UserdataService>();
            services.AddTransient<IBlockchainService, BlockchainService>();
            services.AddTransient<ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain.IUserDataService, UserDataService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            //services.AddScoped(typeof(IUniversityRepository), typeof(UniversitySqlServerRepository));

            //Cors
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "exploring_self_sovereign_identity_api"));
            }

            //Cors
            app.UseCors(app =>
            {
                app.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });

            //Auth
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
