using System.Threading.Tasks;
using AspNetCorePlayground.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCorePlayground.Controllers
{
    public class TestController : Controller
    {
        private readonly PlaygroundContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public TestController(PlaygroundContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Get()
        {
            return Ok(this.context.Installations);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string test = null)
        {
            var user = new IdentityUser()
            {
                UserName = "test",
                Email = "test@test.com",
                PhoneNumber = "0987654356"
            };

            var userCreateResult = await this.userManager.CreateAsync(user, "Password1");
            if (userCreateResult.Succeeded)
            {
                return Ok();
            }

            return this.BadRequest(userCreateResult.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest();
            }

            var createRoleResult = await this.roleManager.CreateAsync(new IdentityRole()
            {
                Name = roleName
            });
            if (createRoleResult.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}