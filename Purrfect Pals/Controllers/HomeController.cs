using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Purrfect_Pals.Interfaces;
using Purrfect_Pals.Models;
using System.Diagnostics;
using System.Net;

/*using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using Purrfect_Pals.Data;
using Purrfect_Pals.Models;
using Purrfect_Pals.Interfaces;
using System.IO;*/


namespace Purrfect_Pals.Controllers
{

	public class HomeController : Controller
	{

		IDateAccessLayer dal;

		public HomeController(IDateAccessLayer indal)
		{

			dal = indal;

		}

		/*private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger){

            _logger = logger;

        }*/

		[HttpGet]

		public IActionResult Index()
		{

			//example grab

			/*string s;

            HttpContext.Session.SetString("Id", "grab info here");//get info

            s = HttpContext.Session.GetString("Id");*/

			//createAiUsers(1, "allen", "TotallyStrongPasswordBro");

			return View();
		}

		public IActionResult ProfilePage(PetBio bio)
		{

			return View(bio);

		}

		public IActionResult Login()
		{

			return View();

		}

		[HttpGet]

		public IActionResult Matches(PetBio bio)
		{

			return View(bio);

		}

		public IActionResult NewMatch()
		{

			return RedirectToAction("Matches", "Home");

		}

		public IActionResult Chat()
		{

			ViewBag.bot = startChat();

			ViewBag.user = startChat();

			return View();

		}

		[HttpGet]

		public IActionResult Signup()
		{

			return View();

		}

		[HttpPost]

		public IActionResult Signup(LoginInfo l)
		{

			if (ModelState.IsValid)
			{

				dal.AddUser(l); // adds user to database 

				TempData["success"] = "User Added";

				return RedirectToAction("EditBio", "Home");

			}
			else
			{

				return View();

			}

		}

		[HttpPost]

		public IActionResult Login(LoginInfo l)
		{

			if (dal.LoginCheck(l.Username, l.Password) == true)
			{

				TempData["success"] = "Logged In!";

				HttpContext.Session.SetString("Id", l.Id.ToString());//get info

				PetBio bio = dal.GetBio(dal.getUserID(l.Username, l.Password));

				return RedirectToAction("EditBio", "Home", bio);

			}
			else
			{

				//spit out bad read or something idk.

				return View();

			}

		}

		public IActionResult EditBio()
		{

			return View();

		}

		[HttpPost]

		public IActionResult EditBio(PetBio bio)
		{

			Random rand = new Random();

			int breed = rand.Next(0, 1);

			if (breed == 1)
			{

				bio.Image = MagicallyGetCat();

			}
			else
			{

				bio.Image = MagicallyGetDog();

			}

			string id = HttpContext.Session.GetString("Id");

			if (bio.Id == int.Parse(id))
			{

				dal.EditBio(bio);

			}

			return RedirectToAction("ProfilePage", bio);

		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

		public IActionResult Error()
		{

			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

		}

		public IActionResult createAiUsers()
		{

			LoginInfo ai = new LoginInfo();

			PetBio aiBio = new PetBio();

			string petname = "";

			Random random = new Random();

			int i = random.Next(1, 42000);

			ai.Username = "aibot" + i.ToString();

			ai.Password = "Password" + i.ToString();

			petname = GetRadomName();

			ai.PetName = petname;

			dal.AddUser(ai);

			aiBio.PetName = petname;

			aiBio.PetAge = random.Next(4, 13);

			int animalChek = random.Next(0, 1);

			if (animalChek == 0)
			{ //cat versions

				aiBio.Biography = MagicllyGetCatBio();

				aiBio.Image = MagicallyGetCat();

			}
			else
			{ //dog versions

				aiBio.Biography = MagicllyGetDogBio();

				aiBio.Image = MagicallyGetDog();

			}

			aiBio.Likes = GetLike();

			aiBio.Dislikes = GetDisLike();

			if (ai.Id == dal.getUserID(ai.Username, ai.Password))
			{

				dal.EditBio(aiBio);

			}

			return RedirectToAction("Index");

		}

		public string startChat()
		{

			Random random = new Random();

			int personChoice = random.Next(1, 2);

			string tempToPass = "";

			if (personChoice == 1)
			{

				tempToPass = "in1";

			}
			else
			{

				tempToPass = "in2";

			}

			tempToPass = Chating(random.Next(0, 5), tempToPass);


			return tempToPass;

		}

		public string MagicallyGetCat()
		{

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


			return result[0]["url"].ToString();

		}

		public string MagicllyGetCatBio()
		{

			string path = "Data/bios/catbios.json";

			string json = System.IO.File.ReadAllText(path);

			JArray result = JArray.Parse(json);

			Random random = new Random();

			string bioID = "b" + random.Next(1, 37).ToString();

			return result[0][bioID].ToString();

		}

		public string GetRadomName()
		{

			string path = "Data/bios/names.json";

			string json = System.IO.File.ReadAllText(path);

			JArray result = JArray.Parse(json);

			Random random = new Random();

			string bioID = "b" + random.Next(1, 28).ToString();

			return result[0][bioID].ToString();

		}

		public string MagicllyGetDogBio()
		{

			string path = "Data/bios/dogbios.json";

			string json = System.IO.File.ReadAllText(path);

			JArray result = JArray.Parse(json);

			Random random = new Random();

			string bioID = "b" + random.Next(1, 40).ToString();

			return result[0][bioID].ToString();

		}

		public string GetLike()
		{

			string path = "Data/bios/likes.json";

			string json = System.IO.File.ReadAllText(path);

			JArray result = JArray.Parse(json);

			Random random = new Random();
			string bioID = "b" + random.Next(1, 40).ToString();
			return result[0][bioID].ToString();
		}

		public string GetDisLike()
		{

			string path = "Data/bios/dislikes.json";

			string json = System.IO.File.ReadAllText(path);

			JArray result = JArray.Parse(json);

			Random random = new Random();
			string bioID = "b" + random.Next(1, 40).ToString();
			return result[0][bioID].ToString();
		}

		//type = out, in1, in2
		//out is what we put out
		//in1 and in2 are the two options to put in aka the buttons.
		public string Chating(int randomVal_0to5, string type)
		{

			string path = "Data/bios/chats.json";

			string json = System.IO.File.ReadAllText(path);

			JArray result = JArray.Parse(json);

			return result[randomVal_0to5][type].ToString();

		}

		public string Chatting2(string[] usedstuff)
		{

			string path = "Data/bios/chat2.json";

			string json = System.IO.File.ReadAllText(path);

			JArray result = JArray.Parse(json);

			string foundResult = "";
			bool repeats = true;
			Random random = new Random();
			do
			{
				string bioID = "b" + random.Next(1, 40).ToString();
				foundResult = result[0][bioID].ToString();
				repeats = false;
				foreach (string s in usedstuff)
				{
					if (foundResult == s)
					{
						repeats = true;
					}
				}
			} while (!repeats);


			return foundResult;
		}

	}
}
