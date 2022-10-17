using BLL.Interface;
using CrowdFundingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrowdFundingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User : ControllerBase
    {
        private readonly ILocalUserService _LocalUserService;
        public User(ILocalUserService service)
        {
            _LocalUserService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_LocalUserService.GetAll());
        }

        [HttpPost("login")]
        public IActionResult Login(LoginForm form)
        {
            return Ok(_LocalUserService.Login(form.email, form.password));
        }

        [HttpPost("register")]
        public IActionResult Register(UserForm user)
        {
            return Ok(_LocalUserService.RegisterUser(user.NickName, user.Email, user.Password, user.BirthDate));
        }

        [HttpPost("upgradeUser")]
        public IActionResult upgradeUser()
        {
        return null;
        }
        [HttpPost("downgradeUser")]
        public IActionResult downgradeUser()
        {
            return null;
        }
    }
}
