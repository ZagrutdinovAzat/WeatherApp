using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void getWeather(object sender, RoutedEventArgs e)
        {
            // апи ключ 
            var apiKey = "6b284cb6d4f38e2292bb6bcecea8f194";
            // получаем введенный город
            var city = cityTextBox.Text.Trim();

            // создаем запрос с параметрами
            var client = new RestClient("http://api.openweathermap.org/data/2.5");
            var request = new RestRequest("weather", Method.Get);
            request.AddParameter("q", city);
            request.AddParameter("appid", apiKey);

            // получаем ответ в JSON формате
            var response = client.Execute(request);

            // если ответ успешен
            if (response.IsSuccessful)
            {
                // распарсим ответ
                var jsonResponse = JObject.Parse(response.Content);
                var temperature = (double)jsonResponse["main"]["temp"];
                var weatherDescription = jsonResponse["weather"][0]["description"].ToString();
                var windSpeed = jsonResponse["wind"]["speed"].ToString();

                // выведем данные
                weatherDescriptionTextBlock.Text = "Weather Description: " + weatherDescription;
                windSpeedTextBlock.Text = "Wind Speed: " + windSpeed + "m/s";
                temperatureTextBlock.Text = "Temperature: " + KelvinToCelsius(temperature).ToString("0.00") + "°C";
            }
            else
            {
                // проверка на корректность ввода города пуст/нет
                if (string.IsNullOrWhiteSpace(city))
                {
                    MessageBox.Show("Error: Enter the name of the city.");
                }
                // проверка на отсутствие интернета
                else if (!NetworkInterface.GetIsNetworkAvailable())
                {
                    MessageBox.Show("Error: There is no internet connection.");
                }
                // возможно ли получить данные по заданному городу
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show("Error: The specified city was not found.");
                }
                // другие ошибки
                else
                {
                    MessageBox.Show("Error: " + response.ErrorMessage);
                }
            }
        }
        // функция перевода температуры из К в °C
        private double KelvinToCelsius(double kelvin)
        {
            return kelvin - 273.15;
        }
    }
}
