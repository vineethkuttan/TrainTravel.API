namespace TrainTravel.API.Model.DTO
{
    public class LoginResponseDto
    {
        public string JwtAccessToken { get; set; }
        public string JwtRefreshToken { get; set; }
        public string UserId { get; set; }
    }
}
