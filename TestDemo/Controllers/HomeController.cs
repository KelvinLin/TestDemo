using APIService;
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
        public ActionResult Index()
        {
            APICaller api = new APICaller();
            M_FC0032001 data = api.GetFC0032001Data();

            WeatherData_ViewModel result = new WeatherData_ViewModel();
            result.Titlte = data.records.datasetDescription;

            return View(result);
        }


    }
}