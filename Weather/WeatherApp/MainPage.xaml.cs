using System;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;
        bool langPolish = false;
        bool darkColor = false;
        bool metricValues = false;
        String unitsValue;


        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }
        }

        void Handle_Toggled_Lang(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            langPolish = e.Value;
            if (langPolish == true)
            {
                headerLabel.Text = "Szukaj po mieście";
                cityLabel.Text = "Miasto:";
                searchButton.Text = "Szukaj";
                locationLabel.Text = "Lokalizacja";
                temperatureLabel.Text = "Temperatura";
                windSpeedLabel.Text = "Prędkość wiatru";
                humidityLabel.Text = "Wilgotność";
                visibilityLabel.Text = "Widoczność";
                timeOfSunriseLabel.Text = "Czas wschodu";
                timeOfSunsetLabel.Text = "Czas zachodu";
                optLang.Text = "Język ENG/PL";
                optUnits.Text = "Jednostki Imperialne/Metryczne";
                optColor.Text = "Motyw Jasny/Ciemny";
            }
            else
            {
                headerLabel.Text = "Search by City";
                cityLabel.Text = "City:";
                searchButton.Text = "Search";
                locationLabel.Text = "Location";
                temperatureLabel.Text = "Temperature";
                windSpeedLabel.Text = "Wind Speed";
                humidityLabel.Text = "Humidity";
                visibilityLabel.Text = "Visibility";
                timeOfSunriseLabel.Text = "Time of Sunrise";
                timeOfSunsetLabel.Text = "Time of Sunset";
                optLang.Text = "Language ENG/PL";
                optUnits.Text = "Units Imperial/Metric";
                optColor.Text = "Theme Light/Dark";
            }
        }

        void Handle_Toggled_Units(object sender, Xamarin.Forms.ToggledEventArgs e)
        {

            metricValues = e.Value;
            if (metricValues == true)
            {
                unitsValue = "metric";
                unitsMetImp.Text = "m/s";
            }
            else
            {
                unitsValue = "imperial";
                unitsMetImp.Text = "mph";

            }
        }
            void Handle_Toggled_Color(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            darkColor = e.Value;
            if (darkColor == true)
            {
                BackgroundColor = Color.Black;

            }
            else
            {
                BackgroundColor = Color.White;

            }

        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units="+unitsValue; // units=metric / imperial
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }

    }
}
