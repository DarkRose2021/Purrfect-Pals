var body = document.body;
var nav = document.getElementById("navbar");
var h1 = document.getElementById("header");
var logo = document.getElementById("logo");

if (document.getElementById("h3")) {
	var h3 = document.getElementById("h3");
}
if (document.getElementById("a")) {
	var a = document.getElementById("a");
}
if (document.getElementById("a2")) {
	var a2 = document.getElementById("a2");
}
if (document.getElementById("a3")) {
	var a3 = document.getElementById("a3");
}
if (document.getElementById("a4")) {
	var a4 = document.getElementById("a4");
}
if (document.getElementById("a5")) {
	var a5 = document.getElementById("a5");
}
if (document.getElementById("a6")) {
	var a6 = document.getElementById("a6");
}
if (document.getElementById("a7")) {
	var a7 = document.getElementById("a7");
}
if (document.getElementById("form1")) {
	var f1 = document.getElementById("form1");
}
if (document.getElementById("form2")) {
	var f2 = document.getElementById("form2");
}
if (document.getElementById("profile")) {
	var profile = document.getElementById("profile");
}
if (document.getElementById("match")) {
	var match = document.getElementById("match");
}
if (document.getElementById("bio")) {
	var bio = document.getElementById("bio");
}

darkOn = localStorage.getItem("dark") == "true" ? true : false;
ToggleDarkMode();

function ToggleDarkMode() {
	localStorage.setItem("dark", darkOn ? "true" : "false");

	if (darkOn) {
		
		logo.src = `/assets/logoDark.png`;
		nav.classList.remove("navbarLightMode", "border-bottom");
		body.classList.remove("lightmode");
		h1.classList.remove("headerLightMode");


		if (document.getElementById("h3")) {
			h3.classList.remove("h3LightMode");
			h3.classList.add("h3Darkmode");
		}
		if (a != null ) {
			a.classList.remove("linkLightMode");
			a.classList.add("linkDarkMode");
		}
		if (a2 != null) {
			a2.classList.remove("linkLightMode");
			a2.classList.add("linkDarkMode");
		}
		if (a3 != null) {
			a3.classList.remove("linkLightMode");
			a3.classList.add("linkDarkMode");
		}
		if (a4 != null) {
			a4.classList.remove("linkLightMode");
			a4.classList.add("linkDarkMode");
		}
		if (a5 != null) {
			a5.classList.remove("linkLightMode");
			a5.classList.add("linkDarkMode");
		}
		if (a6 != null) {
			a6.classList.remove("linkLightMode");
			a6.classList.add("linkDarkMode");
		}
		if (a7 != null) {
			a7.classList.remove("linkLightMode");
			a7.classList.add("linkDarkMode");
		}

		if (f1 != null) {
			f1.classList.remove("formLightmode");
			f1.classList.add("formDarkmode");
		}
		if (f2 != null) {
			f2.classList.remove("formLightmode");
			f2.classList.add("formDarkmode");
		}
		if (bio != null) {
			bio.classList.remove("formLightmode");
			bio.classList.add("formDarkmode");
		}
		if (profile != null) {
			profile.classList.remove("profileLightmode");
			profile.classList.add("profileDarkmode");
		}
		if (match != null) {
			match.classList.remove("profileLightmode");
			match.classList.add("profileDarkmode");
		}
		nav.classList.add("navDarkMode", "borderDarkMode");
		body.classList.add("darkmode");
		h1.classList.add("headerDarkMode");
		
	} else {
		if (document.getElementById("h3")) {
			h3.classList.remove("h3Darkmode");
			h3.classList.add("h3LightMode");
		}
		logo.src = `/assets/logoLight.png`;
		nav.classList.add("navbarLightMode", "border-bottom");
		body.classList.add("lightmode");
		h1.classList.add("headerLightMode");
		
		if (a != null) {
			a.classList.add("linkLightMode");
			a.classList.remove("linkDarkMode");
		}
		if (a2 != null) {
			a2.classList.add("linkLightMode");
			a2.classList.remove("linkDarkMode");
		}
		if (a3 != null) {
			a3.classList.add("linkLightMode");
			a3.classList.remove("linkDarkMode");
		}
		if (a4 != null) {
			a4.classList.add("linkLightMode");
			a4.classList.remove("linkDarkMode");
		}
		if (a5 != null) {
			a5.classList.add("linkLightMode");
			a5.classList.remove("linkDarkMode");
		}
		if (a6 != null) {
			a6.classList.add("linkLightMode");
			a6.classList.remove("linkDarkMode");
		}
		if (a7 != null) {
			a7.classList.add("linkLightMode");
			a7.classList.remove("linkDarkMode");
		}
		if (f1 != null) {
			f1.classList.add("formLightmode");
			f1.classList.remove("formDarkmode");
		}
		if (f2 != null) {
			f2.classList.add("formLightmode");
			f2.classList.remove("formDarkmode");
		}
		if (bio != null) {
			bio.classList.add("formLightmode");
			bio.classList.remove("formDarkmode");
		}
		if (profile != null) {
			profile.classList.add("profileLightmode");
			profile.classList.remove("profileDarkmode");
		}
		if (match != null) {
			match.classList.add("profileLightmode");
			match.classList.remove("profileDarkmode");
		}
		nav.classList.remove("navDarkMode", "borderDarkMode");
		body.classList.remove("darkmode");
		h1.classList.remove("headerDarkMode");
	}

}

var darkOn = false;
function toggle() {
	darkOn = !darkOn;
	ToggleDarkMode();
}