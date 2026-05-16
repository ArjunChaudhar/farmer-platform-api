using farmer_platform_api.DTOs.Farmer;
using farmer_platform_api.Models;

namespace farmer_platform_api.Interfaces
{
    public interface IFarmerService
    {
        Task<ApiResponse<string>> AddFarmerAsync(CreateFarmerDto request);
        Task<ApiResponse<List<Farmer>>> GetFarmersAsync();
        Task<ApiResponse<string>> UpdateFarmerAsync(
        int id,
        UpdateFarmerDto request);
        Task<ApiResponse<string>> DeleteFarmerAsync(int id);

    }
}
