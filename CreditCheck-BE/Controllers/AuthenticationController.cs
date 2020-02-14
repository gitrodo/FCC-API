using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CreditCheck_BE.Data;
using CreditCheck_BE.Dtos;
using CreditCheck_BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CreditCheck_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="configuration"></param>
        public AuthenticationController(IAuthRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerDTO"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Please, verify your information and try again");

            registerDTO.Username = registerDTO.Username.ToLower();
            if (await _repository.ValidateUser(registerDTO.Username, registerDTO.EmailAddress))
                return BadRequest("Username and/or email address already exists in our database");

            var newUser = new User
            {
                Username = registerDTO.Username,
                CompanyName = registerDTO.CompanyName,
                EnrollmentDate = DateTime.Now,
                Pin = registerDTO.Pin,
                EmailAddress = registerDTO.EmailAddress
            };

            var createdUser = await _repository.Register(newUser, registerDTO.Password);
            return Ok(newUser);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var userFromRepo = await _repository.Login(loginDTO.Username.ToLower(), loginDTO.Password);
            if (userFromRepo == null)
                return Unauthorized("Username or password incorrect, please verify your credentials and try again.");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}