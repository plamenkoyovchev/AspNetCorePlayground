using System.Threading.Tasks;
using AspNetCorePlayground.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCorePlayground.Controllers
{
    public class TestController : Controller
    {
        private readonly PlaygroundContext context;
        private readonly UserManager<IdentityUser> userManager;

        public TestController(PlaygroundContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult Get()
        {
            return Ok(this.context.Installations);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser()
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

            return BadRequest();
        }
    }
}