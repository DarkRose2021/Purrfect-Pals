var nav = document.getElementById("navbar");
var h1 = document.getElementById("header");
var body = document.body;


function ToggleDarkMode() {
	nav.classList.toggle("navDarkMode");
	h1.classList.toggle("headerDarkMode");
	body.classList.toggle("darkmode");
}