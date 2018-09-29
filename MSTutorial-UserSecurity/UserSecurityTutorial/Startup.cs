using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using UserSecurityTutorial.Models;

[assembly: OwinStartupAttribute(typeof(UserSecurityTutorial.Startup))]
namespace UserSecurityTutorial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                //create admin role
                if (!roleManager.RoleExists("Admin"))
                {

                    // first we create Admin rool   
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);

                    //Here we create a Admin super user who will maintain the website                  

                    var user = new ApplicationUser();
                    user.UserName = "shanu";
                    user.Email = "syedshanumcain@gmail.com";

                    string userPWD = "A@Z200711";

                    var chkUser = UserManager.Create(user, userPWD);

                    //Add default User to Role Admin   
                    if (chkUser.Succeeded)
                    {
                        var result1 = UserManager.AddToRole(user.Id, "Admin");

                    }
                }

                // creating Creating Manager role    
                if (!roleManager.RoleExists("Manager"))
                {
                    var role = new IdentityRole();
                    role.Name = "Manager";
                    roleManager.Create(role);

                }

                // creating Creating Employee role    
                if (!roleManager.RoleExists("Employee"))
                {
                    var role = new IdentityRole();
                    role.Name = "Employee";
                    roleManager.Create(role);

                }
            }
        }
        }
    }

