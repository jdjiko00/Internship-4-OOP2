namespace Internship_4_OOP2.Doimain.Entities
{
    public class User
    {
        public const int NameMaxLenght = 100;
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string AddressStreet { get; private set; }
        public string AddressCity { get; private set; }
        public decimal GeoLat { get; private set; }
        public decimal GeoLng { get; private set; }
        public string? Website { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
        public bool IsActive { get; private set; } = true;
    }
}
