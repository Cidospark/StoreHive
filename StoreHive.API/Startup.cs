using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StoreHive.API.Data;
using StoreHive.API.Models;

namespace StoreHive.API
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
            // add connection string to the database
            services.AddDbContext<AppDbContext>(option => option.UseSqlite(Configuration.GetConnectionString("Default")));

            //------------------- authentication settings ----------------------------------//
            // add identity core and set password complexity
            IdentityBuilder builder = services.AddIdentityCore<User>(option => {
                option.Password.RequireDigit = false;
                option.Password.RequiredLength = 4;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredUniqueChars = 0;
            });


            // add role validator, role manager, signIn manager, entity framworkstores
            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<AppDbContext>(); // user dbcontext as the store
            builder.AddRoleValidator<RoleValidator<Role>>(); //user identity to manage role validation
            builder.AddRoleManager<RoleManager<Role>>(); // user identity to manage role
            builder.AddSignInManager<SignInManager<User>>();


            //------------------- authentication settings ----------------------------------//
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext cntxt,
                    UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
            }

            Seed.Seeder(cntxt, userManager, roleManager);
            app.UseMvc();
        }
    }
}
