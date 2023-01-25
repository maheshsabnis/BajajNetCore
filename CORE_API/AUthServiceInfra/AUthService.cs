using CORE_API.MOdels;
using Microsoft.AspNetCore.Identity;

namespace CORE_API.AUthServiceInfra
{
    public class AUthService
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        public AUthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
            ResponseObject<LoginUser> response= null;   
            // 1. Create IdentityUSer Object
            var identityUser = new IdentityUser()
            {
                 Email = user.UserName,
                 UserName= user.UserName
            }; 


            var loginStatus = await _signInManager.PasswordSignInAsync(identityUser, user.Password, false,false);

            if (loginStatus.Succeeded)
            {
                // Write Loginc to Generate Token
            }
            else
            { 
                // Authentication Failure Message
            }
            return response;
        }

    }
}
