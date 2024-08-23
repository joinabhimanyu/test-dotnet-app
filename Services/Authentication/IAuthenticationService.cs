using System;
using Microsoft.AspNetCore.Identity;
using test_dotnet_app.DTO;

namespace test_dotnet_app.Services.Authentication;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userRegistrationDto);
    Task<bool> ValidateUserAsync(UserLoginDto userLoginDto);
    Task<string> GenerateJwtTokenAsync(UserLoginDto userLoginDto);
}
