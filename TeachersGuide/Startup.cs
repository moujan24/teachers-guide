using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeachersGuide.Models;

namespace TeachersGuide
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IBehaviorPageTowRepository, BehaviorPageTowRepository>();
            services.AddTransient<IBehaviourPageOneRepository,BehaviourPageOneRepository>();
            services.AddTransient<IFeedBackRepository,FeedBackRepository>();
            services.AddTransient<IInterventionsModifiedRepository, InterventionsModifiedRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            //services.AddTransient<IUsers, MockUsers>();
            //services.AddTransient<IInterventionsRepository,InterventionRepository>();
            //services.AddTransient<IFeedBackRepository,FeedBackRepository>();
            // [Asma Khalid]: Register SQL database configuration context as services. 

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            app.UseMvc(ConfigRoutes);
            app.UseStaticFiles();
            
        }
        private static void ConfigRoutes(IRouteBuilder routes)
        {
            routes.MapRoute(name:"Default", template:"{controller=home}/{action=index}/{id?}/{Data?}");
        }
    }
}
