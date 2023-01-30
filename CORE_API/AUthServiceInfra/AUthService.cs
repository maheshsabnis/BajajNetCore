using CORE_API.MOdels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CORE_API.AUthServiceInfra
{
    public class AUthService
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        IConfiguration _configuration;
        public AUthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        /// <summary>
        /// A Method to CReate New USer
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public async Task<ResponseObject<RegisterNewUser>> CreateUserAsync(RegisterNewUser newUser)
        {
            ResponseObject<RegisterNewUser> response = null;

            // 1. Create an IDentityUSer object from RegisterNewUser class
            IdentityUser user = new IdentityUser() {Email=newUser.Email, UserName=newUser.Email };
            // 2. Create New USer
            // The PAssword will be Auto-Hashed by the CreateAsync() method 
           var result =   await _userManager.CreateAsync(user, newUser.Password);
            // If the user Creation is Successfull
            if (result.Succeeded)
            {
                response = new ResponseObject<RegisterNewUser>()
                {
                     StatusCode= 200,
                     StatusMessage = $"User {newUser.Email} is registered SUccfully"
                };
            }
            else 
            {
                response = new ResponseObject<RegisterNewUser>()
                {
                    StatusCode = 500,
                    StatusMessage = $"The Error Occured while Registering user {newUser.Email}"
                };
            }
           
            return response;
        }

        public async Task<ResponseObject<LoginUser>> AuthenticateAsync(LoginUser user)
        {
            ResponseObject<LoginUser> response= new ResponseObject<LoginUser>();   
            // 1. Create IdentityUSer Object
            var identityUser = new IdentityUser()
            {
                // Email = user.UserName,
                 UserName= user.UserName
            };

            // 2. Sign IN the user using PAssword HAsh
            // var loginStatus = await _signInManager.PasswordSignInAsync(identityUser, user.Password, true,false);

            var loginStatus = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, true, false);


            if (loginStatus.Succeeded)
            {
                // Write Login to Generate Token

                // Read Secret Key
                var secretKey = Convert.FromBase64String(_configuration["JWTSettings:SecretKey"]);
                // Read Expiry
                var expiryTimeSpan = Convert.ToInt32(_configuration["JWTSettings:ExpiryInMinuts"]);

                // SecurityTokenDescriptor: Define the Information for
                // Generating Token
                var securityTokenDescription = new SecurityTokenDescriptor()
                {
                    Issuer = null, // LOcal Hosting ENv.
                    Audience = null,
                    // CUrrently Only USer NAme is addded in Claim
                    // MAke ure that do not put the
                    // Sensetive INfo in CLaims
                    Subject = new ClaimsIdentity(new List<Claim> {
                        new Claim("username",identityUser.UserName.ToString(),ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(expiryTimeSpan),
                    IssuedAt = DateTime.UtcNow,
                    NotBefore = DateTime.UtcNow,
                    // Setting an Algorithm for Encryption
                    // and The Signeture
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
                };
                // Actually GeneratenJSON Web Token
                var jwtHandler = new JwtSecurityTokenHandler();
                // CReate Token based on Description
                var jwToken = jwtHandler.CreateJwtSecurityToken(securityTokenDescription);
                // Write Token in Response
                
                response.Token = jwtHandler.WriteToken(jwToken);
                response.StatusMessage = "THe USer is Authenticated";

            }
            else
            {
                // Authentication Failure Message
                response.StatusMessage = "Invalid USerNAme or Password";
            }
            return response;
        }

    }
}
