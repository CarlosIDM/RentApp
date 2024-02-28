using System.Text.RegularExpressions;

namespace RentApp.BussinesLayer.Helpers
{
	public class RulesValidations : IRulesValidations
	{
		public bool IsValidPassword(string password)
		{
			try
			{
				Regex rg = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-.]).{8,}$");
				if (rg.IsMatch(password))
					return true;
				else
					return false;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
