
namespace RentApp.Models.Login
{
    public class AuthenticationUserModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string RolName { get; set; }
        public string Token { get; set; }
        public DateTime DateExpiredToken { get; set; }
    }
}
