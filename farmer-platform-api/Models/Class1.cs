namespace farmer_platform_api.Models
{
    public class User1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}
