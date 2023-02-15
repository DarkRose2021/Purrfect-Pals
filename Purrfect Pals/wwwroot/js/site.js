var body = document.body;
var nav = document.getElementById("navbar");
var h1 = document.getElementById("header");
var a = document.getElementById("a");
var h3 = document.getElementById("h3");

darkOn = localStorage.getItem("dark") == "true" ? true : false;
ToggleDarkMode();

function ToggleDarkMode() {
	localStorage.setItem("dark", darkOn ? "true" : "false");

	if (darkOn) {
		nav.classList.remove("navbarLightMode");
		nav.classList.remove("border-bottom");
		body.classList.remove("lightmode");
		h1.classList.remove("headerLightMode");
		h3.classList.remove("h3LightMode");
		a.classList.remove("linkLightMode");

		nav.classList.add("navDarkMode");
		nav.classList.add("borderDarkMode");
		body.classList.add("darkmode");
		h1.classList.add("headerDarkMode");
		h3.classList.add("h3Darkmode");
		a.classList.add("linkDarkMode");
	} else {
		nav.classList.add("navbarLightMode");
		nav.classList.add("border-bottom");
		body.classList.add("lightmode");
		h1.classList.add("headerLightMode");
		h3.classList.add("h3LightMode");
		a.classList.add("linkLightMode");

		nav.classList.remove("navDarkMode");
		nav.classList.remove("borderDarkMode");
		body.classList.remove("darkmode");
		h1.classList.remove("headerDarkMode");
		h3.classList.remove("h3Darkmode");
		a.classList.remove("linkDarkMode");
	}

}

var darkOn = false;
function toggle() {
	darkOn = !darkOn;
	ToggleDarkMode();
}