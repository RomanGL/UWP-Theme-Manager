using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace UwpThemeManager.BindingHelpers
{
    public static class ForegroundBindingHelper
    {
        public static string GetForeground(DependencyObject obj) 
            => (string)obj.GetValue(ForegroundProperty);

        public static void SetForeground(DependencyObject obj, string value) 
            => obj.SetValue(ForegroundProperty, value);

        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.RegisterAttached("Foreground", typeof(string), 
                typeof(ForegroundBindingHelper), new PropertyMetadata(null, ForegroundPathPropertyChanged));

        private static void ForegroundPathPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var propertyPath = e.NewValue as string;
            if (propertyPath != null)
            {
                var backgroundproperty = Control.ForegroundProperty;
                BindingOperations.SetBinding(obj, backgroundproperty, new Binding
                {
                    Path = new PropertyPath(propertyPath),
                    Source = App.ThemeManager
                });
            }
        }
    }
}
