using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DS.API.Models;
using DS.API.ViewModels.ViewModels.EmployeeViewModels;
using DS.Services.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace DS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IMapper _mapper;
        private readonly IOptions<AuthOptions> _authOptions;

        public AuthController(
            IEmployeesService employeesService,
            IMapper mapper, 
            IOptions<AuthOptions> authOptions
            )
        {
            _employeesService = employeesService;
            _mapper = mapper;
            _authOptions = authOptions;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login request)
        {
            var user = await AuthenticateUser(request.Email, request.Password);

            if (user != null)
            {
                var token = GenerateJwt(user);
                return Ok(new {access_token = token});
            }

            return Unauthorized();
        }

        private async Task<EmployeeViewModel> AuthenticateUser(string email, string password)
        {
            var userDto = await _employeesService.AuthenticateUser(email, password);
            var userViewModel = _mapper.Map<EmployeeViewModel>(userDto);
            return userViewModel;
        }

        private string GenerateJwt(EmployeeViewModel user)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.FirstName),
                new Claim(JwtRegisteredClaimNames.PhoneNumber, user.PhoneNumber),
                new Claim("role", user.Position.Name)
            };

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
