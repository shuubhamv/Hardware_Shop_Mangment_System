using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using CRMSystem.Models;

using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartupAttribute(typeof(CRMSystem.Startup))]
namespace CRMSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Set up OWIN context
            app.CreatePerOwinContext<ApplicationDbContext>(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            ConfigureAuth(app);
            CreateRolesAndUsers();
        }


        private void CreateRolesAndUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                // Create Admin Role
                if (!roleManager.RoleExists("Admin"))
                {
                    var role = new IdentityRole("Admin");
                    roleManager.Create(role);

                    // Create a default Admin user
                    var adminUser = new ApplicationUser { UserName = "admin@crm.com", Email = "admin@crm.com" };
                    string adminPassword = "Admin@123"; // Change this in production
                    var chkUser = userManager.Create(adminUser, adminPassword);

                    if (chkUser.Succeeded)
                    {
                        userManager.AddToRole(adminUser.Id, "Admin");
                    }
                }

                // Create Employee Role
                if (!roleManager.RoleExists("Employee"))
                {
                    var role = new IdentityRole("Employee");
                    roleManager.Create(role);
                }

                // Create Customer Role
                if (!roleManager.RoleExists("Customer"))
                {
                    var role = new IdentityRole("Customer");
                    roleManager.Create(role);
                }
            }
        }
    }
}