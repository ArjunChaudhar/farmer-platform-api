namespace farmer_platform_api.Models
{
    public class Farmer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public string Village { get; set; }

        public string State { get; set; }

        public decimal LandArea { get; set; }

        public long CreatedDate { get; set; }
    }
}
