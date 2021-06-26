﻿using AirQuality.MWM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Windows.Threading;

namespace AirQuality.MWM.View
{
    /// <summary> 
    /// Interaction logic for HomeView.xaml 
    /// </summary> 

    public partial class HomeView : UserControl
    {
        // private LoginForm form1; 
        AirMetrics metrics;
        WebClient webClient;
        string temperatureUrl, humidityUrl, co2Url, tvocUrl, pressureUrl, pm25Url, pm10Url;

        public HomeView()
        {
            InitializeComponent();
            temperatureUrl = "http://esp32.local/temperature/";
            humidityUrl = "http://esp32.local/humidity/";
            co2Url = "http://esp32.local/co2/";
            tvocUrl = "http://esp32.local/tvoc/";
            pressureUrl = "http://esp32.local/pressure/";
            pm25Url = "http://esp32.local/pm25/";
            pm10Url = "http://esp32.local/pm10/";
            webClient = new WebClient();
            metrics = new AirMetrics();
            updateMetrics();
            updateComponents();
        }
        private void updateMetrics()
        {
            metrics.Temperature = Double.Parse(webClient.DownloadString(temperatureUrl).Replace('.', ','));
            metrics.Humidity = Double.Parse(webClient.DownloadString(humidityUrl).Replace('.', ','));
            metrics.Co2 = Double.Parse(webClient.DownloadString(co2Url).Replace('.', ','));
            metrics.Tvoc = Double.Parse(webClient.DownloadString(tvocUrl).Replace('.', ','));
            metrics.Pressure = Double.Parse(webClient.DownloadString(pressureUrl).Replace('.', ','));
            metrics.Pm25 = Double.Parse(webClient.DownloadString(pm25Url).Replace('.', ','));
            metrics.Pm10 = Double.Parse(webClient.DownloadString(pm10Url).Replace('.', ','));
        }
        private void updateComponents()
        {
            indoorTemperatureValue.Text = metrics.Temperature.ToString();
            indoorHumidityValue.Text = metrics.Humidity.ToString();
            co2IndoorValue.Text = metrics.Co2.ToString();
            tvocIndoorValue.Text = metrics.Tvoc.ToString();
            pressureIndoorValue.Text = metrics.Pressure.ToString();
            particleIndoorValue.Text = metrics.Pm25.ToString();
            //TODO: need two particle fields pm2.5 and pm10
        }
    }
}