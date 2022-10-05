using DAO;
using DAO.interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Model;
using Model.ConfigModel;
using MongoDB_In_DotnetCoreAPI.Middleware;
using Service;
using Service.helper;
using Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_In_DotnetCoreAPI
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
            var mongoDbConfig = Configuration.GetSection("MongoDBSettings")
                                          .Get<MongoDbSettingModel>(c => c.BindNonPublicProperties = true);


            services.AddSingleton(mongoDbConfig);

            #region DAO DI
            services.AddSingleton<IAppUserDao, AppUserDao>();
            #endregion

            #region Service DI
            services.AddTransient<IAppUserService, AppUserService>();
            #endregion

            #region Helper DI
            services.AddTransient<AppUserHelper>();
            #endregion

            services.AddControllers()
                    .AddNewtonsoftJson();
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

            app.UseMiddleware<ExceptionHandleMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
