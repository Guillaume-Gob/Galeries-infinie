using GaleriesInfinieAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GaleriesInfinieAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UtilisateursController : ControllerBase
    {
        readonly UserManager<User> UserManager;


        public UtilisateursController(UserManager<User> userManager)
        {
            UserManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO register)
        {
            if (register.Password != register.PasswordConfirm) 
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Les deux mots de passe ne sont pas identiques" });
            }

            User user = new User()
            {
                UserName = register.Username,
                Email = register.EmailAddress
            };
            IdentityResult identityResult = await this.UserManager.CreateAsync(user, register.Password);
            if (!identityResult.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                         new { Message = identityResult.Errors.ToString() });
            }
            
            return Ok( new {Message = "Inscription réussie ! :)" });

        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO login)
        {
            User user = await UserManager.FindByNameAsync(login.Username);
            if (user != null && await UserManager.CheckPasswordAsync(user, login.Password))
            {
                IList<string> roles = await UserManager.GetRolesAsync(user);
                List<Claim> authClaim = new List<Claim>();
                foreach (string role in roles)
                {

                    authClaim.Add(new Claim(ClaimTypes.Role, role));
                }
                authClaim.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Cette Phrase est tellement longue quelle va empêcher les hackers de passer"));
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "https://localhost:7183",
                    audience: "http://localhost:4200",
                    claims: authClaim,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature));





                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    validTo = token.ValidTo,
                Message = "Connection Réussie :)"
                }) ;
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Le nom d'utilisateur ou le mot de passe est invalide" });
            }
            
          
        
        }


    }
}
