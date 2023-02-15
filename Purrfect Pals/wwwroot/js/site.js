var nav = document.getElementById("navbar");
var h1 = document.getElementById("header");
var body = document.body;


function ToggleDarkMode() {
	localStorage.setItem("dark", darkOn ? "true" : "false");
	nav.classList.add("navDarkMode");
	body.classList.add("darkmode");
	h1.classList.add("headerDarkMode");

}
if (darkOn) {
	document.body.setAttribute("theme", "dark");
	togButton.innerHTML = "Turn off dark mode.";
}
else {
	document.body.setAttribute("theme", "light");
	togButton.innerHTML = "Turn on dark mode.";
}
}

var darkOn = false;
function toggle() {
	darkOn = !darkOn;
	setTheme();
}