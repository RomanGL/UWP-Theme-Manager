using System;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpThemeManager
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void DarkThemeButton_Click(object sender, RoutedEventArgs e)
        {
            App.ThemeManager.LoadTheme(ThemeManager.DarkThemePath);
        }

        private void LightThemeButton_Click(object sender, RoutedEventArgs e)
        {
            App.ThemeManager.LoadTheme(ThemeManager.LightThemePath);
        }

        private async void CustomThemeButton_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".xaml");

            var file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                try
                {
                    await App.ThemeManager.LoadThemeFromFile(file);
                }
                catch (Exception ex)
                {
                    var msg = new MessageDialog(ex.ToString(), "Ошибка");
                    await msg.ShowAsync();
                }
            }
        }
    }
}
