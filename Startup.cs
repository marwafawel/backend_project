using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjectPFE.Controllers;
using ProjectPFE.Interface.IController;
using ProjectPFE.Interface.IRepositories;
using ProjectPFE.Interface.IServices;
using ProjectPFE.Models.DBContext;
using ProjectPFE.Repository;
using ProjectPFE.Services;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPFE
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
            //confg identity
            services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddIdentity<Models.Employee, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();
            //config jwt

            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context => {
                        /*var userService = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetbyId(userId);
                        if (user == null) {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }*/
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context => {
                        return Task.CompletedTask;
                    }
                };
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["SecretKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "Management Tool", Version = "v1" });
            //});

            services.AddMvc();
            services.AddDbContext<ApplicationContext>(item => item.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // DI Repository
            //faire la laison entre interface et classe de couche repository 
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IConstatRepository, ConstatRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<ISiteRepository, SiteRepository>();
            services.AddScoped<IVehiculeRepository, VehiculeRepository>();
            services.AddScoped<IAmendeRepository, AmendeRepository>();

            // configuration des services DI Service
            //services.Add(new ServiceDescriptor(typeof(IEmpolyeeServices), typeof(EmployeeServices), ServiceLifetime.Transient));
            services.AddScoped<IEmpolyeeServices, EmployeeServices>();
            services.AddScoped<IContractServices, ContratServices>();
            services.AddScoped<IConstatServices, ConstatServices>();
            services.AddScoped<IDocumentServices, DocumentServices>();
            services.AddScoped<IVehiculeServices, VehiculeServices>();
            services.AddScoped<ISiteServices, SiteServices>();
            services.AddScoped<IAmendeServices, AmendesServices>();
            //controller
            services.AddScoped<IEmployeeController, EmployeeController>();
            services.AddScoped<ISiteController, SiteController>();
            services.AddScoped<IContractController, ContractController>();
            services.AddScoped<IConstatController, ConstatController>();
            services.AddScoped<IAmendeController, AmendeController>();
            services.AddScoped<IVehiculeController, VehiculeController>();
            services.AddScoped<IDocumentController, DocumentController>();
            //config avec app web angular
            services.AddCors();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseAuthentication();
            //app.UseIdentity();

            //conf with angular
            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
          .AllowAnyMethod()
          .AllowAnyHeader());




            app.UseHttpsRedirection();
            app.UseMvc();


            //// Enable middleware to serve generated Swagger as a JSON endpoint.
            //app.UseSwagger();

            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            //// specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{

            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Management Tool V1");
            //});

        }
    }
}
