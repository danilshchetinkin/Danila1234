using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Windows.Data.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Pickers.Provider;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace lab2
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        const string SuscriptionKey = "7db8fe7bd6d14ab3a273dc458b2178ba";
        const string UriBase = "https://cslabbing1.cognitiveservices.azure.com/";

        // Подключение к когнтивиному сервису

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter && 
                    searchbox.Text.Trim().Length > 0 )
            {
                string imageUrL = FindUrlOfImage(searchbox.Text);
                imagebing.Source = new BitmapImage(new Uri(imageUrL, UriKind.Absolute));
            }
        }

        struct SearchResult
        {
            public String jsonResult;
            public Dictionary<String, String> revelantHeaders;
        }

        private string searchbox(string targetString)
        {
            SearchResult result = PerformBingImageSearch(targetString);

        }
    }
}
