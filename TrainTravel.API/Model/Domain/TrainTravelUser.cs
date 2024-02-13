using Microsoft.AspNetCore.Identity;

namespace TrainTravel.API.Model.Domain
{
    public class TrainTravelUser : IdentityUser
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string  Gender { get; set; }
        public string Email { get; set; }
    }
}
