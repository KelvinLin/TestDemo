using APIService;
using DBFactory;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TestDemo.Models;

namespace TestDemo.Controllers
{   
    public class HomeController : Controller
    {
        public BLFactory Factory = new BLFactory();
        public ActionResult Index()
        {
            APICaller api = new APICaller();
            M_FC0032001 data = api.GetFC0032001Data();

            WeatherData_ViewModel result = new WeatherData_ViewModel();
            result.Titlte = data.records.datasetDescription;
            foreach (var loc in data.records.location)
            {
                List<WeatherInfo> wetInfo = new List<WeatherInfo>();
                foreach (var wet in loc.weatherElement.Where(v => v.elementName == "Wx"))
                {
                    foreach (var detail in wet.time)
                    {
                        WeatherInfo info = new WeatherInfo()
                        {
                            TimeInfo = $"{detail.startTime}~{detail.endTime}",
                            Weather = detail.parameter.parameterName
                        };
                        wetInfo.Add(info);
                    }
                }

                result.LocationInfo.Add(loc.locationName, wetInfo);                
            }

            // 
            List<tblWeatherInfo> entities = new List<tblWeatherInfo>();
            foreach (var loc in result.LocationInfo)
            {
                foreach (var wetInfo in loc.Value)
                {
                    tblWeatherInfo entity = new tblWeatherInfo()
                    {
                        CityName = loc.Key,
                        StartTime = wetInfo.TimeInfo.Split('~')[0],
                        EndTime = wetInfo.TimeInfo.Split('~')[1],
                        Weather = wetInfo.Weather
                    };
                    entities.Add(entity);
                }                
            }
            Factory.CwbDataRepository.AddWeatherInfos(entities);

            return View(result);
        }
    }
}