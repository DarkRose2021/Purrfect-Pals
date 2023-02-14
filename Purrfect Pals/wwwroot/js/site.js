const nav = document.getElementById("navbar");
const header = document.getElementsByClassName("header");


function ToggleDarkMode() {
	var body = document.body;
	nav.classList.toggle("navDarkMode");
	/*header.classList.toggle("headerDarkMode");*/
	body.classList.toggle("darkmode");
}