using System;
using System.Reflection;
using core;
using handlers.Commands;
using handlers.Settings;
using igdb.api;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using persistence;

namespace view
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            // Original used Auth0, for reference;
            // string domain = $"https://{Configuration["Auth0:Domain"]}/";
            // https://auth0.com/docs/quickstart/backend/aspnet-core-webapi/01-authorization

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            //}).AddJwtBearer(options =>
            //{
            //    options.Authority = domain;
            //    options.Audience = Configuration["Auth0:ApiIdentifier"];
            //});

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Administrator", policy =>
            //        policy.RequireRole("Administrator"));
            //    options.AddPolicy("Read-Only", policy =>
            //        policy.RequireRole("Read-Only"));
            //});

            services.AddDbContext<GamesContext>(ctx =>
            {
                ctx.UseLazyLoadingProxies();
                ctx.UseSqlServer(Configuration.GetConnectionString("app"));
            });

            services.AddMediatR(Assembly.GetAssembly(typeof(AddNewGameConsole)));

            services.AddHttpClient<IProvideGamesData, IGDBGamesProvider>(cfg =>
                {
                    cfg.BaseAddress = new Uri(Configuration["igdb:url"]);
                    cfg.DefaultRequestHeaders.Add("user-key", Configuration["igdb:key"]);
                });

            services.Configure<SearchSettings>(Configuration.GetSection("search"));

            services.AddControllers();

            //In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist/clientApp";
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            // app.UseAuthorization();
            // app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
