using System.ComponentModel.DataAnnotations;

namespace TrainTravel.API.Model.DTO
{
    public class RefreshTokenDto
    {
        [Required]
        public string JwtRefreshToken { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
