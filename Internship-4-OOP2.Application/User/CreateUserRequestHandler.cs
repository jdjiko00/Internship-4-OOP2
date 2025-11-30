using Internship_4_OOP2.Application.Common.Model;

namespace Internship_4_OOP2.Application.User
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public decimal GeoLat { get; set; }
        public decimal GeoLng { get; set; }
        public string? Website { get; set; }
    }
    internal class CreateUserRequestHandler : RequestHandler<CreateUserRequest, SuccessPostResponse>
    {

    }
}
