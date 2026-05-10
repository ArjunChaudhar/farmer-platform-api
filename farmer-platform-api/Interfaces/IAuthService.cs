using farmer_platform_api.DTOs.Auth;
using farmer_platform_api.Models;

namespace farmer_platform_api.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto request);

        Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto request);
    }

}
