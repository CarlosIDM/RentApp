using RentApp.BussinesLayer.Helpers;
using RentApp.Entities.Tables;
using RentApp.Models.Login;
using RentApp.Repository;
using System.Linq;
using RentApp.ViewModels.Login;
using RentApp.Languages;

namespace RentApp.BussinesLayer.Login
{
    public class LoginBL
    {
        private IGenericRepository<User> user;
        private IAuthenticationTokens authTokens;
        IRulesValidations rules;
		public LoginBL(IGenericRepository<User> user,IAuthenticationTokens tokens, IRulesValidations rules) 
        {
            this.user = user;
            this.rules = rules;
            this.authTokens = tokens;
        }
        
        public LoginViewModel Init()
        {
            var vm = new LoginViewModel();
            return vm;
        }

        public async Task<Response<AuthenticationUserModel>>LoginAsync(LoginModel lg)
        {
            try
            {
                var searchEmail = await user.FindAsync(c => c.Email == lg.Email && c.IsActive,includeProperties:"Roles");
                if(searchEmail != null)
                {
                    if (!rules.IsValidPassword(lg.Password))
                    {
                        return new Response<AuthenticationUserModel>
                        {
                            Result = null,
                            Message = Language.Instance.GetString("LABEL_ERROR_PASSWORD")
                        };
                    }
                    var validatePassword = PasswordHash.ValidatePassword(lg.Password, searchEmail.Password);
                    if(validatePassword)
                    {
                        var token = authTokens.GenerateToken($"{searchEmail.Name} {searchEmail.LastName}", searchEmail.Roles.RolName);
                        return new Response<AuthenticationUserModel>
                        {
                            Result = new AuthenticationUserModel
                            {
                                UserId = searchEmail.Id,
                                Name = searchEmail.Name,
                                LastName = searchEmail.LastName,
                                RolName = searchEmail.Roles.RolName,
                                Token = token.Token,
                                DateExpiredToken = token.DateExpires
                            }
                        };
                    }
                    else
                    {
                        return new Response<AuthenticationUserModel> { Result = null,Message = Language.Instance.GetString("LABEL_PASSWORD_INVALID") };
                    }
                }
                return new Response<AuthenticationUserModel>
                {
                    Result = null,
                    Message = Language.Instance.GetString("LABEL_NOT_FOUND_USER")
                };
            }
            catch(Exception ex)
            {
                return new Response<AuthenticationUserModel>
                {
                    Result = null,
                    Message = ex.Message
                };
            }
        }
    }
}
