using Microsoft.AspNetCore.Mvc;
using Purrfect_Pals.Models;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace Purrfect_Pals.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult ProfilePage()
        {
            return View();
        }

        public IActionResult Matches()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public string MagicallyGetCat() {

            String url = "https://api.thecatapi.com/v1/images/search";
            WebClient client = new WebClient();

            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data); 
            
            String json = reader.ReadToEnd();
            data.Close();
            reader.Close();

            JArray result = JArray.Parse(json);
;

            return result[0]["url"].ToString();
        }

        public string MagicallyGetDog()
        {

            String url = "https://api.thedogapi.com/v1/images/search";
            WebClient client = new WebClient();

            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);

            String json = reader.ReadToEnd();
            data.Close();
            reader.Close();

            JArray result = JArray.Parse(json);
            ;

            return result[0]["url"].ToString();
        }
       
    }
}