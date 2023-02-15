var nav = document.getElementById("navbar");
var h1 = document.getElementById("header");
var body = document.body;
var darkOn = false;

function ToggleDarkMode() {
	localStorage.setItem("dark", darkOn ? "true" : "false");

	if (darkOn) {
		nav.classList.remove("nav");
		body.classList.remove("lightmode");
		h1.classList.remove("headerLightMode");
		nav.classList.add("navDarkMode");
		body.classList.add("darkmode");
		h1.classList.add("headerDarkMode");
	} else {
		nav.classList.add("nav");
		body.classList.add("lightmode");
		h1.classList.add("headerLightMode");
		nav.classList.remove("navDarkMode");
		body.classList.remove("darkmode");
		h1.classList.remove("headerDarkMode");
	}

}

function toggle() {
	darkOn = !darkOn;
	ToggleDarkMode();
}