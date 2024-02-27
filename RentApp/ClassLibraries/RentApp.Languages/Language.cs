using System.Globalization;
using System.Resources;

namespace RentApp.Languages
{
    public class Language
    {

        private const string ESPANOL_MEXICO = "es-MX";
        private const string ENGLISH_USA = "en-US";
        private const string ENGLISH = "en";
        private const string ESPANOL = "es";

        ResourceManager m_ResMan;
        CultureInfo m_Cul;

        public Language(string SystemName)
        {

            //m_Cul = CultureInfo.CreateSpecificCulture(language);

            m_Cul = CultureInfo.CreateSpecificCulture(Thread.CurrentThread.CurrentCulture.Name);
            string path = "RentApp.Language.Resources." + SystemName;

            m_ResMan = new ResourceManager(path, typeof(Language).Assembly);
        }

        public string GetString(string key)
        {
            string label;
            try
            {
                label = m_ResMan.GetString(key, m_Cul);
            }
            catch (Exception)
            {

                label = m_ResMan.GetString("LANGUAGE_LABEL_NOT_FOUND", m_Cul);

            }
            return label;
        }
        public string GetExceptionString(Exception ex)
        {
            string label;
            try
            {
                label = m_ResMan.GetString(ex.Message, m_Cul);
            }
            catch (Exception)
            {
                label = ex.Message;

            }
            return label;
        }

        public void SetLanguage(string p)
        {
            p = ValidateLanguage(p);

            m_Cul = CultureInfo.CreateSpecificCulture(p);

        }

        private string ValidateLanguage(string strLanguage)
        {
            switch (strLanguage)
            {
                case ESPANOL_MEXICO:
                case ESPANOL:
                    return ESPANOL_MEXICO;
                case ENGLISH_USA:
                case ENGLISH:
                    return ENGLISH_USA;
                default:
                    return ESPANOL_MEXICO;
            }
        }

        public string GetLanguage()
        {

            return m_Cul.ToString();

        }
    }
}
