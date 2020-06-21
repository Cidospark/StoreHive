using StoreHive.API.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System;

namespace StoreHive.API.Data
{
    public static class Seed
    {
        public static void Seeder(AppDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager){

            // ensure database is created
            context.Database.EnsureCreated();

            // add roles to database only if role table is empty
            if(!roleManager.Roles.Any()){
                var listOfRoles = new List<Role>{
                    new Role{Name = "Admin"},
                    new Role{Name = "Store Owner"},
                    new Role{Name = "Member"}
                };

                foreach (var role in listOfRoles)
                {
                    roleManager.CreateAsync(role).Wait();
                }
            }

            // add categories to database only if categories table is empty
            if (!context.Categories.Any())
            {
                // read data from file and convert back to object
                var seedData = System.IO.File.ReadAllText("Data/SeedDataForCategory.json");
                var categoryData = JsonConvert.DeserializeObject<List<Category>>(seedData);

                foreach (var category in categoryData)
                {
                    context.Categories.AddAsync(category).Wait();
                }
            }

            // add users to database only if users table is empty
            if(!userManager.Users.Any()){
                var admin = new User
                {
                    UserName = "admin@sample.com",
                    Email = "admin@sample.com",
                    FullName = "John Doe",
                    Gender = Gender.Male,
                    DateRegistered = DateTime.Now,
                    IsPremiumUser = false,
                    City = "Lagos",
                    Country = "Nigeria"
                };
                userManager.CreateAsync(admin, "P@$$w0rd").Wait();
                userManager.AddToRolesAsync(admin, new[] { "Admin" }).Wait();

                // read user data from file and convert back to object
                var userSeedData = System.IO.File.ReadAllText("Data/SeedDataForUser.json");
                var usersData = JsonConvert.DeserializeObject<List<User>>(userSeedData);

                foreach (var user in usersData)
                {
                    userManager.CreateAsync(user, "password").Wait();

                    if(user.Stores != null)
                      {
                        userManager.AddToRoleAsync(user, "Store Owner").Wait();
                      }else{
                        userManager.AddToRoleAsync(user, "Member").Wait();
                      }
                }
            }


        }
    }
}