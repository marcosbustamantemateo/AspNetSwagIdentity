namespace PlantillaBack.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PlantillaBack.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PlantillaBack.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PlantillaBack.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var userManager = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "Prueba",
                Email = "prueba@gmail.com",
                EmailConfirmed = true,
                FirstName = "manolo",
                LastName = "perez",
                Level = 1,
                JoinDate = DateTime.Now.AddYears(-3)
            };

            userManager.Create(user, "MySuperP@ssword!");

            roleManager.Create(new IdentityRole { Name = "SuperAdmin" });
            roleManager.Create(new IdentityRole { Name = "Admin" });
            roleManager.Create(new IdentityRole { Name = "User" });

            var adminUser = userManager.FindByName("Prueba");
            userManager.AddToRoles(adminUser.Id, new string[] { "SuperAdmin", "Admin" });
        }
    }
}
