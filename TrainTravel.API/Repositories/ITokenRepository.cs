using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using TrainTravel.API.Model.Domain;

namespace TrainTravel.API.Repositories
{
    public interface ITokenRepository
    {
        (string accessToken, string refreshToken) CreateJWTToken(TrainTravelUser user,List<string> roles);

        string CreateJWTAccessToken(TrainTravelUser user, List<string> roles);
    }
}
