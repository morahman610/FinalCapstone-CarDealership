using FinalCapstone.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FinalCapstone.Controllers
{
    public class HomeController : Controller
    {
        private CarEntities db = new CarEntities();
        public ActionResult Index()
        {
           

            HttpWebRequest WR = WebRequest.CreateHttp("http://localhost:54016/api/Cars/GetCars/");
            WR.UserAgent = ".NET Framework Test Client";

            HttpWebResponse Response;

            try
            {
                Response = (HttpWebResponse)WR.GetResponse();
            }
            catch (WebException e)
            {
                ViewBag.Error = "Exception";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

            if (Response.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.Error = Response.StatusCode;
                ViewBag.ErrorDescription = Response.StatusDescription;
                return View();
            }

            StreamReader reader = new StreamReader(Response.GetResponseStream());
            string CarData = reader.ReadToEnd();

            try
            {
                JArray JsonData = JArray.Parse(CarData);

                ViewBag.Cars = JsonData;
                //ViewBag.Make = JsonData["Make"];
                //ViewBag.Model = JsonData["Model"];
                //ViewBag.Year = JsonData["Year"];
                //ViewBag.Color = JsonData["Color"];
                //ViewBag.Price = JsonData["Price"];


            }
            catch (Exception e)
            {
                ViewBag.Error = "JSON Issue";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchResultsByMake(string make)
        {
            ViewBag.Test = make;


            HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:54016/api/Cars/GetCarByMake?id={make}");
            WR.UserAgent = ".NET Framework Test Client";

            HttpWebResponse Response;

            try
            {
                Response = (HttpWebResponse)WR.GetResponse();
            }
            catch (WebException e)
            {
                ViewBag.Error = "Exception";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

            if (Response.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.Error = Response.StatusCode;
                ViewBag.ErrorDescription = Response.StatusDescription;
                return View();
            }

            StreamReader reader = new StreamReader(Response.GetResponseStream());
            string CarData = reader.ReadToEnd();



            try
            {

                JArray jsonData = JArray.Parse(CarData);
                ViewBag.Cars = jsonData;

            }
            catch (Exception e)
            {
                ViewBag.Error = "JSON Issue";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }


            return View("SearchResults");
        }



        public ActionResult SearchResultsByModel(string model)
        {


            HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:54016/api/Cars/GetCarByModel?id={model}");
            WR.UserAgent = ".NET Framework Test Client";

            HttpWebResponse Response;

            try
            {
                Response = (HttpWebResponse)WR.GetResponse();
            }
            catch (WebException e)
            {
                ViewBag.Error = "Exception";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

            if (Response.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.Error = Response.StatusCode;
                ViewBag.ErrorDescription = Response.StatusDescription;
                return View();
            }

            StreamReader reader = new StreamReader(Response.GetResponseStream());
            string CarData = reader.ReadToEnd();



            try
            {

                JArray jsonData = JArray.Parse(CarData);
                ViewBag.Cars = jsonData;

            }
            catch (Exception e)
            {
                ViewBag.Error = "JSON Issue";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }


            return View("SearchResults");
        }

        public ActionResult SearchResultsByYear(string year)
        {


            HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:54016/api/Cars/GetCarByYear?id={year}");
            WR.UserAgent = ".NET Framework Test Client";

            HttpWebResponse Response;

            try
            {
                Response = (HttpWebResponse)WR.GetResponse();
            }
            catch (WebException e)
            {
                ViewBag.Error = "Exception";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

            if (Response.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.Error = Response.StatusCode;
                ViewBag.ErrorDescription = Response.StatusDescription;
                return View();
            }

            StreamReader reader = new StreamReader(Response.GetResponseStream());
            string CarData = reader.ReadToEnd();



            try
            {

                JArray jsonData = JArray.Parse(CarData);
                ViewBag.Cars = jsonData;

            }
            catch (Exception e)
            {
                ViewBag.Error = "JSON Issue";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }


            return View("SearchResults");
        }

        public ActionResult SearchResultsByColor(string color)
        {


            HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:54016/api/Cars/GetCarByColor?id={color}");
            WR.UserAgent = ".NET Framework Test Client";

            HttpWebResponse Response;

            try
            {
                Response = (HttpWebResponse)WR.GetResponse();
            }
            catch (WebException e)
            {
                ViewBag.Error = "Exception";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

            if (Response.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.Error = Response.StatusCode;
                ViewBag.ErrorDescription = Response.StatusDescription;
                return View();
            }

            StreamReader reader = new StreamReader(Response.GetResponseStream());
            string CarData = reader.ReadToEnd();



            try
            {

                JArray jsonData = JArray.Parse(CarData);
                ViewBag.Cars = jsonData;

            }
            catch (Exception e)
            {
                ViewBag.Error = "JSON Issue";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }


            return View("SearchResults");
        }
        [HttpGet]
        public ActionResult SearchCarAll(string make, string model, int? year, string color)
        {
            HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:52043/api/Cars/GetCarByAll?make={make}&model={model}&year={year}&color={color}");

            HttpWebResponse Response;

            try
            {
                Response = (HttpWebResponse)WR.GetResponse();
            }
            catch (WebException e)
            {
                ViewBag.Error = "Exception";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }

            if (Response.StatusCode != HttpStatusCode.OK)
            {
                ViewBag.Error = Response.StatusCode;
                ViewBag.ErrorDescription = Response.StatusDescription;
                return View();
            }

            StreamReader reader = new StreamReader(Response.GetResponseStream());
            string CarData = reader.ReadToEnd();

            try
            {
                JArray JsonData = JArray.Parse(CarData);
                ViewBag.Cars = JsonData;

              
            }
            catch (Exception e)
            {
                ViewBag.Error = "JSON Issue";
                ViewBag.ErrorDescription = e.Message;
                return View();
            }
            return View("SearchResults");
        }



        public ActionResult SearchResults()
        {
            return View();
        }

    }
}