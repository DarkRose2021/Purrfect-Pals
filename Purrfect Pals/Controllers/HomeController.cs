using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using Purrfect_Pals.Data;
using Purrfect_Pals.Models;
using Purrfect_Pals.Interfaces;

namespace Purrfect_Pals.Controllers
{
    public class HomeController : Controller
    {

        int loggedInUserID = 2;

        IDateAccessLayer dal;

        public HomeController(IDateAccessLayer indal) {

            dal = indal;

        }

        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger){

            _logger = logger;

        }*/

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult ProfilePage(){
        
            return View();
        
        }

		public IActionResult Login()
		{

			return View();

		}

		public IActionResult Matches()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Signup() {

            return View();

        }

        [HttpPost]

        public IActionResult Signup(LoginInfo l){ 
        
            if (ModelState.IsValid){

                dal.AddUser(l); // adds user to database 

                TempData["success"] = "User Added";

                return RedirectToAction("ProfilePage", "Home");

            }else{

                return View();

            }
        
        }

        [HttpPost]

        public IActionResult Login(LoginInfo l){ 

            if (dal.LoginCheck(l.Username, l.Password) == true){

                loggedInUserID = dal.getUser(l.Username).Id;

                TempData["success"] = "Logged In!";

                return RedirectToAction("EditBio", "Home");

            }else{
                
                //spit out bad read or something idk.

                return View();

            }
        
        }

        public IActionResult EditBio(){ 
        
            return View();
        
        }

        [HttpPost]

        public IActionResult EditBio(PetBio bio){

                bio.Image = MagicallyGetCat();

                dal.EditBio(loggedInUserID, bio);

                return RedirectToAction("UserBio", "Home");

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