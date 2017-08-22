using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UwpThemeManager
{
    sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
        }

        public static ThemeManager ThemeManager => (ThemeManager)App.Current.Resources["ThemeManager"];

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            
            if (rootFrame == null)
            {
                rootFrame = new Frame();
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                ThemeManager.LoadTheme(ThemeManager.DarkThemePath);

                if (rootFrame.Content == null)
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);

                Window.Current.Activate();
            }
        }
    }
}
