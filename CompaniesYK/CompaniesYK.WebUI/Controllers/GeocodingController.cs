using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace CompaniesYK.WebUI.Controllers
{
    public class GeocodingController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GeocodeInput()
        {
            string CountryInp = Request.Form["CountryField"];
            string CityInp = Request.Form["CityField"];
            string AdressInp = Request.Form["AdressField"];
            string ZipInp = Request.Form["ZipField"];
            string address = $"{ZipInp} {AdressInp}, {CityInp}, {CountryInp}";
            string adressb = Request.Form["adressb"];

            string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyC7t-mN9B320kc-cG7mFrN0ptTMtFE4iPo&address=Kungsgatan+2+Stockholm&sensor=false", Uri.EscapeDataString(adressb));

            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());

            XElement result = xdoc.Element("GeocodeResponse").Element("result");
            XElement locationElement = result.Element("geometry").Element("location");
            XElement lat = locationElement.Element("lat");
            XElement lng = locationElement.Element("lng");
            

            return PartialView(locationElement);
        }

    }
}