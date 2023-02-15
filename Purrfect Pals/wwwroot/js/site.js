var body = document.body;
var nav = document.getElementById("navbar");
var h1 = document.getElementById("header");
var a = document.getElementById("a");
var a2 = document.getElementById("a2");
var a3 = document.getElementById("a3");
var a4 = document.getElementById("a4");
var a5 = document.getElementById("a5");
var a6 = document.getElementById("a6");

if (document.getElementById("h3")) {
	var h3 = document.getElementById("h3");
}


darkOn = localStorage.getItem("dark") == "true" ? true : false;
ToggleDarkMode();

function ToggleDarkMode() {
	localStorage.setItem("dark", darkOn ? "true" : "false");

	if (darkOn) {
		if (document.getElementById("h3")) {
			h3.classList.remove("h3LightMode");
			h3.classList.add("h3Darkmode");
		}

		nav.classList.remove("navbarLightMode");
		nav.classList.remove("border-bottom");
		body.classList.remove("lightmode");
		h1.classList.remove("headerLightMode");
		
		a.classList.remove("linkLightMode");
		a2.classList.remove("linkLightMode");
		a3.classList.remove("linkLightMode");
		a4.classList.remove("linkLightMode");
		a5.classList.remove("linkLightMode");
		a6.classList.remove("linkLightMode");

		nav.classList.add("navDarkMode");
		nav.classList.add("borderDarkMode");
		body.classList.add("darkmode");
		h1.classList.add("headerDarkMode");
		
		a.classList.add("linkDarkMode");
		a2.classList.add("linkDarkMode");
		a3.classList.add("linkDarkMode");
		a4.classList.add("linkDarkMode");
		a5.classList.add("linkDarkMode");
		a6.classList.add("linkDarkMode");
	} else {
		if (document.getElementById("h3")) {
			h3.classList.remove("h3Darkmode");
			h3.classList.add("h3LightMode");
		}

		nav.classList.add("navbarLightMode");
		nav.classList.add("border-bottom");
		body.classList.add("lightmode");
		h1.classList.add("headerLightMode");
		
		a.classList.add("linkLightMode");
		a2.classList.add("linkLightMode");
		a3.classList.add("linkLightMode");
		a4.classList.add("linkLightMode");
		a5.classList.add("linkLightMode");
		a6.classList.add("linkLightMode");

		nav.classList.remove("navDarkMode");
		nav.classList.remove("borderDarkMode");
		body.classList.remove("darkmode");
		h1.classList.remove("headerDarkMode");
		
		a.classList.remove("linkDarkMode");
		a2.classList.remove("linkDarkMode");
		a3.classList.remove("linkDarkMode");
		a4.classList.remove("linkDarkMode");
		a5.classList.remove("linkDarkMode");
		a6.classList.remove("linkDarkMode");
	}

}

var darkOn = false;
function toggle() {
	darkOn = !darkOn;
	ToggleDarkMode();
}