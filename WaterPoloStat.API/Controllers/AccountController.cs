using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WaterPoloStat.API.Dtos;
using WaterPoloStat.API.Dtos.Account;
using WaterPoloStat.API.Dtos.Auth;
using WaterPoloStat.API.Extensions;
using WaterPoloStat.Domain;

namespace WaterPoloStat.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AspNetUser> _signInManager;
        private readonly UserManager<AspNetUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IUserClaimsPrincipalFactory<AspNetUser> _claimsPrincipalFactory;
        public AccountController(UserManager<AspNetUser> userManager,
        SignInManager<AspNetUser> signInManager,
            IConfiguration configuration,
            IUserClaimsPrincipalFactory<AspNetUser> claimsPrincipalFactory)
        {

        }
        [AllowAnonymous]
        [HttpPost("registrazione")]
        public async Task<ActionResult> Registrazione([FromBody] RegistrazioneDto model, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid) return BadRequest("Dati inviati non validi.");

            var result = await _userManager.CreateAsync(new AspNetUser() { 
                Nome = model.Nome,
                Cognome = model.Cognome,
                Email = model.Email,
                UserName = model.Email,
                EmailConfirmed = true
            }, model.Password);
            if (result.Succeeded) return Ok();

            return BadRequest(result.Errors.FirstOrDefault().Description);
        }


            [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto model, CancellationToken cancellationToken = default)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.IsPersistente, false);

            if (result.Succeeded)
            {
                var user = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);                
                return Ok(await GenerateJwtToken(model.Email, user, Request.Headers["Origin"]));
            }
            return BadRequest();
        }

        private async Task<AppUserAuth> GenerateJwtToken(string email, AspNetUser user, string audience)
        {

            //string loginSessionId = await UpdateLoginSessionIdAsync(user.Id);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                //new Claim(JwtRegisteredClaimNames.Sid, loginSessionId),
                new Claim(JwtRegisteredClaimNames.Aud, audience),
                new Claim(ClaimTypeExtension.LicenzaId, user.LicenzaId)
            };

            // get user roles
            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList());

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings::Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtSettings::ExpireDays"]));

            //imposta la scadenza del token alle 4 di mattina del giorno seguente
            DateTime expDate = DateTime.UtcNow.AddDays(1);
            var expires = new DateTime(expDate.Year, expDate.Month, expDate.Day, 4, 0, 0);

            var token = new JwtSecurityToken(
                _configuration["JwtSettings::Issuer"],
                _configuration["JwtSettings::Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new AppUserAuth
            {
                BearerToken = tokenString,
                IsAuthenticated = true,
            };
        }
    }
}