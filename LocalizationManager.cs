using System.Globalization;
using System.Resources;

namespace Naidis_TARpe24;

public static class LocalizationManager
{
    private static readonly ResourceManager _rm =
        new ResourceManager("Naidis_TARpe24.Resources.Localization.AppResources", typeof(LocalizationManager).Assembly);

    private static CultureInfo _culture = new CultureInfo("et");

    public static string CurrentLanguage => _culture.TwoLetterISOLanguageName;

    public static string Get(string key)
    {
        return _rm.GetString(key, _culture) ?? key;
    }

    public static void SetLanguage(string languageCode)
    {
        _culture = new CultureInfo(languageCode);
    }
}