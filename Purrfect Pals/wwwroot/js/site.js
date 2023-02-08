const nav = document.getElementById("navbar");
const btn = document.getElementsByClassName("btn");


function ToggleDarkMode() {
	DarkMode();
}

function DarkMode() {
	var body = document.body;
	body.classList.toggle("darkmode");
}