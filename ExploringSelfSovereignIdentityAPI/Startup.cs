using ExploringSelfSovereignIdentityAPI.Data;
using ExploringSelfSovereignIdentityAPI.Repositories.Example;
using ExploringSelfSovereignIdentityAPI.Repositories.SessionRepository;
using ExploringSelfSovereignIdentityAPI.Repositories.Transactions;
using ExploringSelfSovereignIdentityAPI.Repositories.UserDataRepository;
using ExploringSelfSovereignIdentityAPI.Services;
using ExploringSelfSovereignIdentityAPI.Services.blockChain;
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "exploring_self_sovereign_identity_api", Version = "v1" });
            });


            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);


            //Adding my service
            services.AddTransient<IExampleRepository, ExampleRepository>();
            services.AddTransient<IExampleService, ExampleService>();
            services.AddTransient<ISessionRepository, SessionRepository>();
            services.AddTransient<ISessionService, SessionService>();     
            services.AddTransient<IUserDataRepository, UserDataRepository>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IUserDataService, UserdataService>();
            services.AddTransient<IBlockchainService, BlockchainService>();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            //services.AddScoped(typeof(IUniversityRepository), typeof(UniversitySqlServerRepository));


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
            app.UseCors(app =>
            {
                app.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
