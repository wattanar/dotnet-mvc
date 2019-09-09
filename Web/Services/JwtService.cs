using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Web.Services.Interfaces;

namespace Web.Services
{
  public class JwtService : IJwtService
  {
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public string GenerateToken()
    {
      try
      {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
          _configuration["Jwt:Issuer"],
          _configuration["Jwt:Issuer"],
          null,
          expires: DateTime.Now.AddHours(Convert.ToDouble(_configuration["Jwt:Exp"])),
          signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
      }
      catch (System.Exception)
      {

        throw;
      }
    }
  }
}