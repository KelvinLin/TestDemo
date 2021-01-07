using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestDemo.Models
{
    public class WeatherData_ViewModel
    {
        public WeatherData_ViewModel()
        {
            this.LocationInfo = new Dictionary<string, List<WeatherInfo>>();
        }
        public string Titlte { get; set; }
        
        public Dictionary<string, List<WeatherInfo>> LocationInfo { get; set; }
    }

    public class WeatherInfo
    { 
        public string TimeInfo { get; set; }
        public string Weather { get; set; }
    }
}