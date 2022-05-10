namespace Personal
{
    public static class ThemeHelper
    {
        public const string CookieName = ".AspNetCore.Theme";
        public static List<string> Themes = new()
        {
            "Lux",
            "Minty",
            "Cyborg",
            "Cosmo",
            "United",
            "Quartz",
            "Vapor"
        };
        public static string CurrentTheme(HttpContext context) => context.Request.Cookies[CookieName] ?? "lux";
    }
}