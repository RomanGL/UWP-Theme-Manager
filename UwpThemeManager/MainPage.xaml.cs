using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace UwpThemeManager
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
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
