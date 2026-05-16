using farmer_platform_api.DTOs.Farmer;
using farmer_platform_api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace farmer_platform_api.Controllers
{
  
        [Route("api/[controller]")]
        [ApiController]
        [Authorize]
        public class FarmersController : ControllerBase
        {
            private readonly IFarmerService _farmerService;

            public FarmersController(
                IFarmerService farmerService)
            {
                _farmerService = farmerService;
            }

            [HttpPost]
            public async Task<IActionResult> AddFarmer(
                CreateFarmerDto request)
            {
                var response =
                    await _farmerService.AddFarmerAsync(request);

                return Ok(response);
            }

        [HttpGet]
        public async Task<IActionResult> GetFarmers()
        {
            var response = await _farmerService
            .GetFarmersAsync();
            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFarmer(
int id,
UpdateFarmerDto request)
        {
            var response = await _farmerService
            .UpdateFarmerAsync(id, request);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmer(int id)
        {
            var response = await _farmerService
            .DeleteFarmerAsync(id);
            return Ok(response);
        }

    }
    }

