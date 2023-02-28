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
using System.IO;


namespace Purrfect_Pals.Controllers
{

    public class HomeController : Controller
    {

		IDateAccessLayer dal;

        public HomeController(IDateAccessLayer indal) {

            dal = indal;

        }

        /*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger){

            _logger = logger;

        }*/

        [HttpGet]
        public IActionResult Index(){

            //example grab

            /*string s;

            HttpContext.Session.SetString("Id", "grab info here");//get info

            s = HttpContext.Session.GetString("Id");*/

            return View();
        }

        public IActionResult ProfilePage(PetBio bio){
        
            return View(bio);
        
        }

		public IActionResult Login(){

			return View();

		}

		public IActionResult Matches(){

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

                return RedirectToAction("Index", "Home");

            }else{

                return View();

            }
        
        }

        [HttpPost]

        public IActionResult Login(LoginInfo l){ 

            if (dal.LoginCheck(l.Username, l.Password) == true){

				TempData["success"] = "Logged In!";

				HttpContext.Session.SetString("Id", l.Id.ToString());//get info

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

            string id = HttpContext.Session.GetString("Id");
            
			if (bio.Id == int.Parse(id)) {

                dal.EditBio(bio);

            }

            return RedirectToAction("ProfilePage", bio);

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
            
            return result[0]["url"].ToString();
        }

        public string MagicllyGetCatBio() {

            string path = "Data/bios/catbios.json";

            string json = System.IO.File.ReadAllText(path);

            JArray result = JArray.Parse(json);

            Random random = new Random();
            string bioID = "b" + random.Next(1, 37).ToString();
            return result[0][bioID].ToString();
        }

        public string MagicllyGetDogBio() {

            string path = "Data/bios/dogbios.json";

            string json = System.IO.File.ReadAllText(path);

            JArray result = JArray.Parse(json);

            Random random = new Random();
            string bioID = "b" + random.Next(1, 40).ToString();
            return result[0][bioID].ToString();
        }*/
       
    }
}