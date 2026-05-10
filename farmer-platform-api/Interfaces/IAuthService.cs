using farmer_platform_api.DTOs.Auth;

namespace farmer_platform_api.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);

        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
    }

}
