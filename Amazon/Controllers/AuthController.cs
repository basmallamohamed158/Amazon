using Amazon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
namespace Amazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(AmazonDbContext context) : ControllerBase
    {0
        [HttpGet]
        public IActionResult login (User user)
        {
            var loginuser = context.users.FirstOrDefault(u => u.Username== user.User_Name && u.Password == user.User_Password);
            if (loginuser == null)
            {
                return Unauthorized(); //status code
            }
        }
    }
}
