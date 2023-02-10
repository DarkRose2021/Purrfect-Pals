const nav = document.getElementById("navbar");
const header = document.getElementsByClassName("header");


function ToggleDarkMode() {
	DarkMode();
}

function DarkMode() {
	var body = document.body;
	body.classList.toggle("darkmode");	
}