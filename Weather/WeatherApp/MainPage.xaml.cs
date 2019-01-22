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


        public MainPage(ContentPage content)
        {
            InitializeComponent();
            _restService = new RestService();
        }


        // funtion for button action to send request 
        async void OnGetWeatherButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }
        }

        // function to change units imperial / metric
        async void Handle_Toggled_UnitsAsync(object sender, Xamarin.Forms.ToggledEventArgs e)
        {

            metricValues = e.Value;

            if (metricValues == true)
            {
                unitsValue = Constants.unitsValueMetric;
                unitsMetImp.Text = Constants.unitsMetImpMpS;
                tempMetImp.Text = Constants.tempMetImpC;
            }
            else
            {
                unitsValue = Constants.unitsValueImperial;
                unitsMetImp.Text = Constants.unitsMetImpMpH;
                tempMetImp.Text = Constants.tempMetImpF;
            }


            if (!string.IsNullOrWhiteSpace(_cityEntry.Text))
            {
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }
        }

        // function to change laguage
        void Handle_Toggled_Lang(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            langPolish = e.Value;
            if (langPolish == true)
            {
                headerLabel.Text = Constants.headerLabelPl;
                cityLabel.Text = Constants.cityLabelPl;
                searchButton.Text = Constants.searchButtonPl;
                locationLabel.Text = Constants.locationLabelPl;
                temperatureLabel.Text = Constants.temperatureLabelPl;
                windSpeedLabel.Text = Constants.windSpeedLabelPl;
                humidityLabel.Text = Constants.humidityLabelPl;
                visibilityLabel.Text = Constants.visibilityLabelPl;
                timeOfSunriseLabel.Text = Constants.timeOfSunriseLabelPl;
                timeOfSunsetLabel.Text = Constants.timeOfSunsetLabelPl;
                optLang.Text = Constants.optLangPl;
                optUnits.Text = Constants.optUnitsPl;
                optColor.Text = Constants.optColorPl;
            }
            else
            {
                headerLabel.Text = Constants.headerLabelEng;
                cityLabel.Text = Constants.cityLabelEng;
                searchButton.Text = Constants.searchButtonEng;
                locationLabel.Text = Constants.locationLabelEng;
                temperatureLabel.Text = Constants.temperatureLabelEng;
                windSpeedLabel.Text = Constants.windSpeedLabelEng;
                humidityLabel.Text = Constants.humidityLabelEng;
                visibilityLabel.Text = Constants.visibilityLabelEng;
                timeOfSunriseLabel.Text = Constants.timeOfSunriseLabelEng;
                timeOfSunsetLabel.Text = Constants.timeOfSunsetLabelEng;
                optLang.Text = Constants.optLangEng;
                optUnits.Text = Constants.optUnitsEng;
                optColor.Text = Constants.optColorEng;
            }
        }


        // function to change color theme
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


        // funtion to generate proper request 
        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={_cityEntry.Text}";
            requestUri += "&units=" + unitsValue; // units =metric / imperial
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }

    }
}
