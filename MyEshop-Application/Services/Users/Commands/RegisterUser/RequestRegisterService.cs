namespace MyEshop_Application.Services.Users.Commands.RegisterUser
{
    public class RequestRegisterService
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public List<RoleInRegisterUserDto> roles { get; set; }
    } 
}
