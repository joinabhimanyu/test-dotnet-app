using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using test_dotnet_app.DTO;
using test_dotnet_app.Entities;

namespace test_dotnet_app.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    private readonly ILogger<AuthenticationService> _logger;
    private readonly IConfiguration _configuration;

    public AuthenticationService(UserManager<User> userManager, IMapper mapper, ILogger<AuthenticationService> logger, IConfiguration configuration)
    {
        _userManager = userManager;
        _mapper = mapper;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userRegistrationDto)
    {
        var user = _mapper.Map<User>(userRegistrationDto);
        var result = await _userManager.CreateAsync(user, userRegistrationDto!.Password!);

        if (result.Succeeded)
        {
            await _userManager.AddToRolesAsync(user, userRegistrationDto!.Roles!);
        }
        return result;
    }

    public async Task<bool> ValidateUserAsync(UserLoginDto userLoginDto)
    {
        var user = await _userManager.FindByNameAsync(userLoginDto.UserName!);
        if (user != null)
        {
            var result = await _userManager.CheckPasswordAsync(user, userLoginDto.Password!);
            if (!result)
            {
                _logger.LogError($"{nameof(ValidateUserAsync)}: Validation failed. Wrong username or password.");
            }
            return result;
        }
        return false;
    }

    public async Task<string> GenerateJwtTokenAsync(UserLoginDto userLoginDto)
    {
        var claims = await GetClaimsAsync(userLoginDto);
        var signingCredentials = GetSigningCredentials();
        var tokenOptions = GenerateTokenAsync(signingCredentials, claims);
        return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings")["Secret"]!));
        return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }

    private async Task<List<Claim>> GetClaimsAsync(UserLoginDto userLoginDto)
    {
        var user = await _userManager.FindByNameAsync(userLoginDto.UserName!);
        if (user != null)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!),
            }.Union(roles.Select(role => new Claim(ClaimTypes.Role, role))).ToList();
        }
        return new List<Claim>();
    }

    private JwtSecurityToken GenerateTokenAsync(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var tokenOptions = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpirationMinutes"])),
            claims: claims
        );
        return tokenOptions;
    }
}
