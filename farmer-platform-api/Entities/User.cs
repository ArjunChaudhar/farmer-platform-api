namespace farmer_platform_api.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Mobile { get; set; }

        public string PasswordHash { get; set; }

        public long CreatedDate { get; set; }
    }
}
