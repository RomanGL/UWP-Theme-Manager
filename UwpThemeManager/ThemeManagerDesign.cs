using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace UwpThemeManager
{
#if DEBUG
    public static class ThemeManagerDesign
    {
        static ThemeManagerDesign()
        {
            DesignThemeDictionary = new ResourceDictionary();

            DesignThemeDictionary[nameof(ThemeManager.BackgroundBrush)] = 
                new SolidColorBrush(Color.FromArgb(255, 26, 26, 26));
            DesignThemeDictionary[nameof(ThemeManager.ForegroundBrush)] =
                new SolidColorBrush(Colors.White);
            DesignThemeDictionary[nameof(ThemeManager.ChromeBrush)] =
                new SolidColorBrush(Color.FromArgb(255, 35, 35, 35));
        }

        public static ResourceDictionary DesignThemeDictionary { get; }

        public static string CurrentTheme => "DesignTheme";
    }
#endif
}
