using BCrypt.Net;
using farmer_platform_api.DTOs.Auth;
using farmer_platform_api.Entities;
using farmer_platform_api.Helpers;
using farmer_platform_api.Interfaces;
using farmer_platform_api.Models;
using FarmerPlatform.API.Data;
using Microsoft.EntityFrameworkCore;

namespace farmer_platform_api.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public AuthService(
            ApplicationDbContext context,
            JwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto request)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(x => x.Mobile == request.Mobile);

            if (existingUser != null)
            {
                return new ApiResponse<AuthResponseDto>
                {
                    Success = false,
                    Message = "User already exists"
                };
            }

            var user = new User
            {
                Name = request.Name,
                Mobile = request.Mobile,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                CreatedDate = DateTime.Now.Ticks
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new ApiResponse<AuthResponseDto>
            {
                Success = true,
                Message = "Registration successful",
                Data = new AuthResponseDto
                {
                    Token = token
                }
            };
        }

        public async Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Mobile == request.Mobile);

            if (user == null)
            {
                return new ApiResponse<AuthResponseDto>
                {
                    Success = false,
                    Message = "Invalid mobile number"
                };
            }

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash);

            if (!isPasswordValid)
            {
                return new ApiResponse<AuthResponseDto>
                {
                    Success = false,
                    Message = "Invalid password"
                };
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new ApiResponse<AuthResponseDto>
            {
                Success = true,
                Message = "Login successful",
                Data = new AuthResponseDto
                {
                    Token = token
                }
            };
        }
    }
}
