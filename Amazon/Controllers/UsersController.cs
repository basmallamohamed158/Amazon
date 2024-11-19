using Amazon.DTOs;
using Amazon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amazon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AmazonDbContext _dbContext;
        // injection 
        public UsersController(AmazonDbContext context)
        {
            _dbContext = context;
        }
        [HttpGet]
        public ActionResult<List<User>> DisplayAllUsers()
        {
            List<User> AllUsers = _dbContext.Users.Include(u =>u.Products).ToList();
            if (AllUsers == null)
            {
                return NotFound();
            }
            return Ok(AllUsers);
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            var userRes = _dbContext.Users.Add(user);
            if (userRes == null) return NotFound();
            _dbContext.SaveChanges();
            return Created("DisplayAllUsers", user);
        }
        [HttpGet("{id:int}")]
        public IActionResult DiplayUser (int id)
        {
            var UserGet =  _dbContext.Users.FirstOrDefault(u => u.User_Id == id);
            UserDTO userDTO = new UserDTO
            {
               
                Name = UserGet.User_Name,
                Email = UserGet.User_Gmail,
            };
            if (UserGet == null) return NotFound(); 
            return Ok(UserGet);
        }
        [HttpGet("{name:alpha}")]
        public IActionResult GetbyName(string name)
        {
            var Username = _dbContext.Users.FirstOrDefault(n => n.User_Name == name);
            if (Username == null) return NotFound();
            return Ok(Username);
        }
        [HttpPut("{id}")]
        public IActionResult Updateuser (int id,User user)
        {
            var OldUser = _dbContext.Users.FirstOrDefault(u => u.User_Id == id);
            OldUser.User_Name = user.User_Name;
            OldUser.User_Password = user.User_Password;
            OldUser.User_Gmail = user.User_Gmail;
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Deleteuser(int id)
        {
            var RemovedUser = _dbContext.Users.FirstOrDefault(u => u.User_Id == id);
            if (RemovedUser == null) return NotFound();
            _dbContext.Users.Remove(RemovedUser);
            _dbContext.SaveChanges();
            return Ok(RemovedUser);
        }
    }
}
