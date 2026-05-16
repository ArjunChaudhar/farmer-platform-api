using farmer_platform_api.DTOs.Farmer;
using farmer_platform_api.Interfaces;
using farmer_platform_api.Models;
using FarmerPlatform.API.Data;
using Microsoft.EntityFrameworkCore;

namespace farmer_platform_api.Services
{
    public class FarmerService : IFarmerService
    {
        private readonly ApplicationDbContext _context;

        public FarmerService(
            ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<string>> AddFarmerAsync(
            CreateFarmerDto request)
        {
            var farmer = new Farmer
            {
                Name = request.Name,
                Mobile = request.Mobile,
                Village = request.Village,
                State = request.State,
                LandArea = request.LandArea,
                CreatedDate = DateTime.Now.Ticks
            };

            _context.Farmers.Add(farmer);

            await _context.SaveChangesAsync();

            return new ApiResponse<string>
            {
                Success = true,
                Message = "Farmer added successfully"
            };
        }

        public async Task<ApiResponse<List<Farmer>>> GetFarmersAsync()
        {
            var farmers = await _context.Farmers
.OrderByDescending(x => x.Id)
.ToListAsync();
            return new ApiResponse<List<Farmer>>
            {
                Success = true,
                Data = farmers
            };

        }
        public async Task<ApiResponse<string>> UpdateFarmerAsync(
int id,
UpdateFarmerDto request)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null)
            {
                return new ApiResponse<string>
                {
                    Success = false,
                    Message = "Farmer not found"
                };
            }
            farmer.Name = request.Name;
            farmer.Mobile = request.Mobile;
            farmer.Village = request.Village;
            farmer.State = request.State;
            farmer.LandArea = request.LandArea;
            await _context.SaveChangesAsync();
            return new ApiResponse<string>
            {
                Success = true,
                Message = "Farmer updated successfully"
            };

        }

        public async Task<ApiResponse<string>> DeleteFarmerAsync(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null)
            {
                return new ApiResponse<string>
                {
                    Success = false,
                    Message = "Farmer not found"
                };
            }
            _context.Farmers.Remove(farmer);
            await _context.SaveChangesAsync();
            return new ApiResponse<string>
            {
                Success = true,
                Message = "Farmer deleted successfully"
            };
        }
    }
}

