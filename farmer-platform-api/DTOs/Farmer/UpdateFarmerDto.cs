namespace farmer_platform_api.DTOs.Farmer
{
    public class UpdateFarmerDto
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Village { get; set; }
        public string State { get; set; }
        public decimal LandArea { get; set; }
    }
}
