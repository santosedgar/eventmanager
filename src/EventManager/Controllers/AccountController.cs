using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Core.Interfaces;
using EventManager.Helpers;
using EventManager.Helpers.AuthProvider;
using EventManager.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        private readonly UserManager userManager;

        public AccountController(IAccountRepository accountRepository, UserManager userManager)
        {
            this.accountRepository = accountRepository;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Post(
            [FromBody] LoginRequest loginRequest,
            [FromServices] SigningConfiguration signingConfigurations,
            [FromServices] TokenConfiguration tokenConfigurations)
        {
            try
            {
                var currentUser = await this.accountRepository.SignInAsync(loginRequest.Username, loginRequest.Password);

                if (currentUser != null) //Login successful
                {
                    return Ok(this.userManager.GetToken(currentUser, signingConfigurations, tokenConfigurations));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
