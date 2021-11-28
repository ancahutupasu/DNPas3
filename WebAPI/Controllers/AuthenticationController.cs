using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Authentication;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IAccountService accountService;

        public AuthenticationController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult<Account>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var account = await accountService.ValidateUserAsync(username, password);
                return Ok(account);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}