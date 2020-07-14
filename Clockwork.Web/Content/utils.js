﻿    function UserAction() {
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

    function UpdateTimeZone() {
        var xhttp = new XMLHttpRequest();

        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
        document.getElementById("output").innerHTML = this.responseText;
            }
        };

        var selector = document.getElementById('timeZoneDropdown');
        var uri = "http://localhost:5000/api/timeByZone/" + selector.value

        xhttp.open("GET", uri, true);
        xhttp.setRequestHeader("Content-type", "application/json");
        xhttp.send();
    }

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

        for (var i = 0; i < timeZones.length;) {
        list += "<option value='" + timeZones[i] + "'>" + timeZones[i];
        }
        return list;
    }

    function GetAllRequests() {
        var xhttp = new XMLHttpRequest();

        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200 && !this.hasTimeZones) {
                var response = JSON.parse(this.responseText);

                document.getElementById("output").innerHTML = BuildRequestTable(response);
            }
        };

        xhttp.open("GET", "http://localhost:5000/api/getall", true);
        xhttp.setRequestHeader("Content-type", "application/json");
        xhttp.send();

    }

    function BuildRequestTable(list) {

        var result = "<table class='table table-hover table - striped'>";
        result += "<thead>";
        result += "<tr>";
        result += "<th class='text-center'>Client IP</th>";
        result += "<th class='text-center'>Time</th>";
        result += "<th class='text-center'>UTC Time</th>";
        result += "<th class='text-center'>Selected Time Zone</th>";
        result += "</tr>";
        result += "</thead>";
        result += "<tbody>";
        for (var i = 0; i < list.length;) {
                result += "<tr>";
            result += "<td>" + list[i].clientIp + "</td>";
            result += "<td>" + list[i].time + "</td>";
            result += "<td>" + list[i].utcTime + "</td>";
            result += "<td>" + list[i].selectedTimeZone + "</td>";
            result += "</tr>";
        }
            result += "</tbody>";
        result += "</table>";
return result;
        }

function HideAllRequests() {
    document.getElementById("output").innerHTML = "";
}

window.onload = GetAllTimeZones()

