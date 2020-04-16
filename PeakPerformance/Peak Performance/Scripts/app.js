/**
 * This part will get the access token and userid for storing in the database. It will log both in the console area.
 * */
// get the url
var url = window.location.href;
//getting the access token from url
var access_token = url.split("#")[1].split("=")[1].split("&")[0];
// get the userid
var userId = url.split("#")[1].split("=")[2].split("&")[0];
console.log(access_token);
console.log(userId);

/**Setting Up Variables
 * */
var stepsToday = 0;
var milesToday = 0;
var caloriesToday = 0;
var floorsToday = 0;
var sedindaryMinToday = 0;

/**
 * This part will retrieve my FitBit data. It will log it in the console area.
 * */
var xhr = new XMLHttpRequest();
xhr.open('GET', 'https://api.fitbit.com/1/user/' + userId + '/activities/date/today.json');
xhr.setRequestHeader("Authorization", 'Bearer ' + access_token);
xhr.onload = function () {
    if (xhr.status === 200) {
        console.log(xhr.responseText);
        var activities = xhr.responseText;
        var json = JSON.parse(activities);
        stepsToday = json["summary"]["steps"];
        milesToday = json["summary"]["distances"][0]["distance"];
        caloriesToday = json["summary"]["caloriesOut"];
        floorsToday = json["summary"]["floors"];
        sedindaryMinToday = json["summary"]["sedentaryMinutes"];
        sendData();
    }
};
xhr.send();

function sendData() {
    $.ajax({
        url: '/Athlete/Home/FitBit',
        type: 'POST',
        data: { 'steps': stepsToday, 'miles': milesToday, 'calories': caloriesToday, 'floors': floorsToday, 'sedentary': sedindaryMinToday },
        //dataType: 'json',
        //contentType: 'application/json; charset=utf-8',
        success: function () {
            successFitBit()
        },
        error: function (error) {
            alert('error');
        }
    });
}

function successFitBit() {
    //delete fitbit image and button
    var fitBitImage = document.getElementById("fitbitImage");
    fitBitImage.parentNode.removeChild(fitBitImage);

    //replace with table of data
    var table = document.getElementById("myTable");
    table.style.visibility = 'visible';
    $('#myTable').append($('<tr><th>Steps</th><td>' + stepsToday + '</td></tr><tr><th>Miles</th><td>' + milesToday + '</td></tr><tr><th>Calories</th><td>' + caloriesToday + '</td></tr><tr><th>Floors</th><td>' + floorsToday + '</td></tr><th>Sedintary Minutes</th><td>' + sedindaryMinToday + '</td></tr>'));
}