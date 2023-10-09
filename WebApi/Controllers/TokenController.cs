using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using WebApi.Models;
using WebApi.Token;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public TokenController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/Login")]
        public async Task<IActionResult> CreateToken([FromBody] Login login)
        {
            if(string.IsNullOrWhiteSpace(login.Email)  || string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest();
            }

            var result = await signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);

            if(result.Succeeded)
            {
                // Recupera Usuário Logado
                var currentUser = await userManager.FindByEmailAsync(login.Email);
                var userId = currentUser.Id;

                var token = new TokenJwtBuilder()
                    .AddSecurityKey(JwtSecurityKey.Create("Secret_Key-12345678"))
                .AddSubject("Matheus")
                .AddIssuer("Testing.Security.Bearer")
                .AddAudience("Testing.Security.Bearer")
                .AddClaim("userId", userId)
                .AddExpiry(10)
                .Builder();
                return Ok(token.value);
            }
            else
            {
                return Unauthorized("Senha errada.");
            }
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpPost("/api/Register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            if(string.IsNullOrWhiteSpace(model.Email)  || string.IsNullOrWhiteSpace(model.Password))
            {
                return BadRequest("Preencha todos os requisitos");
            }

            ApplicationUser User = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
                CPF = model.CPF,
            };

            var result = await userManager.CreateAsync(User, model.Password);

            if (result.Errors.Any())
            {
                return BadRequest(result.Errors);
            }
            var code = await userManager.GenerateEmailConfirmationTokenAsync(User);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var OResult = await userManager.ConfirmEmailAsync(User, code);

            if (OResult.Succeeded)
                return Ok("Usuário Adicionado com Sucesso");
            else
                return BadRequest(OResult.Errors.ToString());
        }

        [AllowAnonymous]
        [Produces("application/json")]
        [HttpDelete("/api/Delete")]
        public async Task<IActionResult> Delete(Register User)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(User.Email);
            if (user == null)
            {
                return BadRequest("Usuario não reconhecido");                               
            }
            else
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Errors.Any())
                {
                    return BadRequest(result.Errors);
                }
                else { return Ok("usuario deletado com sucesso"); }
            }
        }
    }
}
