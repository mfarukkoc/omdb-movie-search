using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MovieSearch.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            string url = "http://omdbapi.com/?apikey=";
            string key = "650e046a";
            WebClient client = new WebClient() { Encoding = Encoding.UTF8 };
            var jsonString = client.DownloadString(url + key + "&s=" + fc["str"]);
            ViewBag.result = JsonConvert.DeserializeObject(jsonString);
            return View("Index");
        }
        public ActionResult Details(string movieId)
        {
            string url = "http://omdbapi.com/?apikey=";
            string key = "952eb1f3";
            WebClient client = new WebClient() { Encoding = Encoding.UTF8 };
            var jsonString = client.DownloadString(url + key + "&i=" + movieId);
            ViewBag.details = JsonConvert.DeserializeObject(jsonString);

            return View();
        }
    }
}