using RentApp.Languages;
using RentApp.Models.Login;

namespace RentApp.ViewModels.Login
{
    public class LoginViewModel : LoginModel
    {
        public string m_Email { get; set; }
        public string m_Password { get; set; }
        public string m_SignIn {  get; set; }
        public string m_Forgot_Password { get; set; }
        public string m_Login { get; set; }
        public string m_Twitter { get; set; }
        public string m_Facebook { get; set; }
        public string m_Google {  get; set; }
        public string m_Or {  get; set; }

        public LoginViewModel()
        {
            InitLabels();
        }

        #region LABELS
        private void InitLabels()
        {
            var languages = Language.Instance;
            m_Email = languages.GetString("LABEL_EMAIL");
            m_Password = languages.GetString("LABEL_PASSWORD");
            m_SignIn = languages.GetString("LABEL_SIGNIN");
            m_Forgot_Password = languages.GetString("LABEL_FORGOT_PASSWORD");
            m_Login = languages.GetString("LABEL_BTN_LOGIN");
            m_Or = languages.GetString("LABEL_OR");
            m_Twitter = languages.GetString("LABEL_TWITTER");
            m_Facebook = languages.GetString("LABEL_FACEBOOK");
            m_Google = languages.GetString("LABEL_GOOGLE");
        }
        #endregion
    }
}
