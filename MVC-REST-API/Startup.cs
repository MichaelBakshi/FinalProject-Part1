using FinalProject_Part1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MVC_REST_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            GlobalConfig.GetConfiguration(false);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // ...
            //if (MyConfig.UseMicroServices)
            //   services.AddScoped<IAdminFacade, MicroServiceAdminFacade>();
            //else

            //services.AddScoped<ILoggedInAdministratorFacade, LoggedInAdministratorFacade>(); // prepare DI

            services.AddSingleton<ILoggedInAdministratorFacade>(x =>
                new LoggedInAdministratorFacade(false));


            services.AddCors();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            string securityKey = "this_is_our_supper_long_security_key_for_token_validation_project_2018_09_07$smesk.in";

            var symmetricSecurityKey = new
               SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                     JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =
                     JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new
                     TokenValidationParameters
                {
                    //  what to validate
                    //  what to validate
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    // setup validate data
                    ValidIssuer = "smesk.in",
                    ValidAudience = "readers",
                    IssuerSigningKey = symmetricSecurityKey
                };
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title =
               "FlightsManagmentSystemWebAPI",
                    Version = "v1"
                });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Please insert JWT with Bearer into field",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id =
                        JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(securityScheme.Reference.Id,
                 securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                    {securityScheme, new string[] { }}
                });

                // make this work
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //To add:
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                       "FlightsManagmentSystemWebAPI v1");
                c.DocumentTitle = "Flights Managment System API";
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
