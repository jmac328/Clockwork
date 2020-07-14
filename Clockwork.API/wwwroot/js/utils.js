window.onload = GetAllTimeZones()

function GetAllTimeZones() {
    var xhttp = new XMLHttpRequest();

    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200 && !this.hasTimeZones) {
            var selector = document.getElementById('timeZoneDropdown');
            selector.innerHTML = TimeZoneList(JSON.parse(this.responseText));
            this.hasTimeZones = true;
        }
    };

    xhttp.open("GET", "http://localhost:5000/api/timeZones", true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();
}

function TimeZoneList(timeZones) {
    var list = "";

    for (var i = 0; i < timeZones.length; i++) {
        list += "<option value='" + timeZones[i] + "'>" + timeZones[i];
    }
    return list;
}

function UserAction() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("output").innerHTML = this.responseText;
        }
    };
    xhttp.open("GET", "http://localhost:5000/api/currenttime", true);
    xhttp.setRequestHeader("Content-type", "application/json");
    xhttp.send();

}