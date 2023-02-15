var nav = document.getElementById("navbar");
var h1 = document.getElementById("header");
var body = document.body;

darkOn = localStorage.getItem("dark") == "true" ? true : false;
ToggleDarkMode();

function ToggleDarkMode() {
	localStorage.setItem("dark", darkOn ? "true" : "false");
	console.log(localStorage.getItem("dark"));

	if (darkOn) {
		nav.classList.remove("navbarLightMode");
		nav.classList.remove("border-bottom");
		body.classList.remove("lightmode");
		h1.classList.remove("headerLightMode");
		nav.classList.add("navDarkMode");
		nav.classList.add("borderDarkMode");
		body.classList.add("darkmode");
		h1.classList.add("headerDarkMode");
	} else {
		nav.classList.add("navbarLightMode");
		nav.classList.add("border-bottom");
		body.classList.add("lightmode");
		h1.classList.add("headerLightMode");
		nav.classList.remove("navDarkMode");
		nav.classList.remove("borderDarkMode");
		body.classList.remove("darkmode");
		h1.classList.remove("headerDarkMode");
	}

}

var darkOn = false;
function toggle() {
	darkOn = !darkOn;
	ToggleDarkMode();
}