namespace CORE_API.MOdels
{
    /// <summary>
    /// CLass to Register New USer
    /// </summary>
    public class RegisterNewUser
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
    }

    public class LoginUser
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }


}
