using Bussines.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // Kullanıcının yetkilerini getirmek için endpoint
        [HttpGet("getclaims")]
        public IActionResult GetClaims([FromQuery] int userId)
        {
            var user = _userService.GetById(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // `user` nesnesini `GetClaims` metoduna gönderiyoruz.
            var claims = _userService.GetClaims(user);
            return Ok(claims);
        }

        // Yeni bir kullanıcı eklemek için endpoint
        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            _userService.Add(user);
            return Ok("User added successfully.");
        }

        // E-posta ile kullanıcı aramak için endpoint
        [HttpGet("getbymail")]
        public IActionResult GetByMail([FromQuery] string email)
        {
            var user = _userService.GetByMail(email);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

    }
    }
