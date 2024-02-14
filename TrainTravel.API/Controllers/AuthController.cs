using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrainTravel.API.Model.Domain;
using TrainTravel.API.Model.DTO;
using TrainTravel.API.Repositories;

namespace TrainTravel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<TrainTravelUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ILogger<AuthController> logger;
        private readonly ITokenRepository tokenRepository;
        private readonly ITimeTableRepository timeTableRepository;

        public AuthController(UserManager<TrainTravelUser> userManager, RoleManager<IdentityRole> roleManager,ILogger<AuthController> logger, ITokenRepository tokenRepository,ITimeTableRepository timeTableRepository)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.logger = logger;
            this.tokenRepository = tokenRepository;
            this.timeTableRepository = timeTableRepository;
        }
        //POST :/api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new TrainTravelUser
            {
                Name = registerRequestDto.Name,
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username,
                DateOfBirth = registerRequestDto.DateOfBirth,
                PhoneNumber = registerRequestDto.PhoneNumber,
                Gender = registerRequestDto.Gender
            };
            /*
             '{
                  "name": "tempAdmin",
                  "username": "admin@example.com",
                  "password": "admin1",
                  "dateOfBirth": "2024-01-24",
                  "gender": "Male",
                  "phoneNumber": "7092270853",
                  "roles": [
                    "Admin"
                  ]
                }'*/
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);
            if (identityResult.Succeeded)
            {
                //Add roles to the user
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered");
                    }
                }
            }
            return BadRequest("Something went wrong");
        }

        //POST : api/Auth/login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByNameAsync(loginRequestDto.Username);//FindByEmailAsync(loginRequestDto.Username);
            //FindByEmailAsync(loginRequestDto.Username);
            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtAccessToken = jwtToken.accessToken,
                            JwtRefreshToken = jwtToken.refreshToken
                        };
                        return Ok(response);
                    }

                }
            }
            return BadRequest("Username or Password incorrect");
        }

        //POST : api/Auth/tokenrefresh
        [HttpPost]
        [Route("TokenRefresh")]
        public async Task<IActionResult> TokenRefresh([FromBody] RefreshTokenDto refreshTokenDto)
        {
            var user = await userManager.FindByIdAsync(refreshTokenDto.UserId);//FindByEmailAsync(loginRequestDto.Username);
            //FindByEmailAsync(loginRequestDto.Username);
            if (user != null)
            {
                var roles= await userManager.GetRolesAsync(user);
                if (roles != null)
                {
                    var jwtToken = tokenRepository.CreateJWTAccessToken(user, roles.ToList());
                    var response = new LoginResponseDto
                    {
                        JwtAccessToken = jwtToken,
                        JwtRefreshToken = refreshTokenDto.JwtRefreshToken
                    };
                    return Ok(response);
                }
            }
            return BadRequest("Refresh token expired! Login Again");
        }
    }
}
