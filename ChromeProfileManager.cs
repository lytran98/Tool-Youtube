using System.IO;

namespace YoutubeAutomation
{
    public static class ChromeProfileManager
    {
        public static bool LoadCookiesAndCheckLogin(string email, string cookieFilePath)
        {
            return File.Exists(cookieFilePath);
        }
    }
}
