﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace UwpThemeManager
{
    public sealed class ThemeManager : INotifyPropertyChanged
    {
        public const string DarkThemePath = "ms-appx:///Themes/Theme.Dark.xaml";
        public const string LightThemePath = "ms-appx:///Themes/Theme.Light.xaml";

        public event PropertyChangedEventHandler PropertyChanged;

        public ThemeManager()
        {
            if (DesignMode.DesignModeEnabled)
            {
                _currentThemeDictionary = ThemeManagerDesign.DesignThemeDictionary;
                _currrentTheme = ThemeManagerDesign.CurrentTheme;
            }
        }

        public string CurrentTheme => _currrentTheme;
        public Brush BackgroundBrush => _currentThemeDictionary[nameof(BackgroundBrush)] as Brush;
        public Brush ChromeBrush => _currentThemeDictionary[nameof(ChromeBrush)] as Brush;
        public Brush ForegroundBrush => _currentThemeDictionary[nameof(ForegroundBrush)] as Brush;

        public void LoadTheme(string path)
        {
            _currentThemeDictionary = new ResourceDictionary();
            App.LoadComponent(_currentThemeDictionary, new Uri(path));
            _currrentTheme = Path.GetFileNameWithoutExtension(path);

            RaisePropertyChanged();
        }

        public async Task LoadThemeFromFile(StorageFile file)
        {
            string xaml = await FileIO.ReadTextAsync(file);
            _currentThemeDictionary = XamlReader.Load(xaml) as ResourceDictionary;
            _currrentTheme = Path.GetFileNameWithoutExtension(file.Path);

            RaisePropertyChanged();
        }

        private void RaisePropertyChanged()
        {
            OnPropertyChanged(nameof(BackgroundBrush));
            OnPropertyChanged(nameof(ChromeBrush));
            OnPropertyChanged(nameof(ForegroundBrush));
            OnPropertyChanged(nameof(CurrentTheme));
        }

        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private ResourceDictionary _currentThemeDictionary;
        private string _currrentTheme;
    }
}