using BloggingSystem.BL.Bases;
using BloggingSystem.BL.Interfaces;
using BloggingSystem.BL.Services;
using BloggingSystem.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSystem.WebApi
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling =
Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //services.AddDbContext<applicationDbContext>(option => {

            //    option.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("CS"),
            //        options => options.EnableRetryOnFailure());
            //});

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<AccountServices>();
            services.AddTransient<ArticleServices>();
            services.AddTransient<CategoryServices>();
            services.AddTransient<CommentServices>();
            services.AddTransient<RoleServices>();
            


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            

            


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BloggingSystem.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BloggingSystem.WebApi v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(
                options => options
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
