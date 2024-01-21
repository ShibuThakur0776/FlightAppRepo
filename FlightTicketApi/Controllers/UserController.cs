using FlightTicketApi.Data.Repository.IRepository;
using FlightTicketApi.Models;
using FlightTicketApp.Data.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightTicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var isUniqueUser = _userRepository.IsUniqueUser(user.UserName);
                if (!isUniqueUser)
                {
                    return BadRequest("User is use !!!");
                }
                var userInfo = _userRepository.Register(user.UserName, user.Password);
                if (userInfo == null) return BadRequest();
            }
            return Ok();
        }
        [HttpPost("authenticate")]
        public IActionResult Authentucate([FromBody] UserVM userVM)
        {
            var user = _userRepository.Authenticate(userVM.UserName, userVM.Password);
            if (user == null) return BadRequest("Wrong user/pwd");
            return Ok(user);
        }
    }
}
