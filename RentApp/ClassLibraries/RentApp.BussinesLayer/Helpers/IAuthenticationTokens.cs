using RentApp.Models.Tokens;

namespace RentApp.BussinesLayer.Helpers
{
    public interface IAuthenticationTokens
    {
        public TokenModel GenerateToken(string userName, string role);
        public Task<bool> TokenValidate(string token);
    }
}
