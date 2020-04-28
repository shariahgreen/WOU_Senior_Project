function GetSelectedSubject(e) {
    //get label controls to set value/text
    var lblSelectedText = document.getElementById("lblSelectedText");
    var lblSelectedValue = document.getElementById("lblSelectedValue");
    //get selected value and check if subject is selected else show alert box
    var SelectedValue = e.options[e.selectedIndex].value;
    if (SelectedValue > 0) {
        var list = e.options[e.selectedIndex].text;       
        var source = '/Workouts/SearchByMuscle?MuscleGroupsId=' + list;
        $.ajax({
            type: 'GET',
            dataType: 'json',
            url: source,
            success: succedAjaxCalled,
            error: errorOnAjax
        });
    } else {
        //reset label values and show alert
        lblSelectedText.innerHTML = "";
        lblSelectedValue.innerHTML = "";
        alert("Please select valid subject.");
    }
}

function getExercisesbyText() {
    var text = document.getElementById("exercise").value;
    console.log("Searching database for " + text);
    var source = '/Workouts/SearchByText?text=' + text;
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: source,
        success: succedAjaxCalled,
        error: errorOnAjax
    });
}

function errorOnAjax() {
    console.log('Error on AJAX return');
}

function succedAjaxCalled(data) {
    //console.log('We got something');
    $("#result").empty();
    $('#result').append($('<p style="font-size:160%;">Found ' + data.length + ' results:</p>'))
    for (var i = 0; i < data.length; ++i) {
        $('#result').append($('<p id ="exerciseResult">' + data[i] + '</p>'))
    }
}

var compcount = 0;

function createWorkoutSave() {
    var dropdownListElem = document.getElementById("TeamList");
    var woTeam = dropdownListElem.options[dropdownListElem.selectedIndex].value;
    var woDate = document.getElementById("Date").value;
    console.log("Workout created for team " + woTeam + " on date " + woDate);
    console.log("There are " + document.getElementsByClassName("complex").length + " complexes in this workout")
  
    var complexes = []
    for (var i = 0; i < document.getElementsByClassName("complex").length; i++) {
        console.log("Complex number " + i);
        var exTable = "exercises" + i;
        var table = document.getElementById(exTable); 
        var exercises = [];
        for (var j = 1, row; row = table.rows[j]; j++) {            
            var entry =
            {

                "name": row.cells[0].innerText,
                "reps": row.cells[1].innerText,
                "sets": row.cells[2].innerText,
                "weight": row.cells[3].innerText,
                "time": row.cells[4].innerText,
                "speed": row.cells[5].innerText,
                "distance": row.cells[6].innerText

            };
            exercises.push(entry);
            //console.log(JSON.stringify(entry));
        }
        var complexExercises =
        {
            "complex": exercises
        }
        complexes.push(complexExercises);
        //console.log(JSON.stringify(exercises));
    }
    var htmldata =
    {
        "team": woTeam,
        "date": woDate,
        "complexes": complexes
    }
    //console.log(JSON.stringify(complexes));
    console.log(JSON.stringify(htmldata));
    
    var source = 'CreateWorkout';
    $.ajax({
        url: source,
        type: 'POST',
        contentType: "application/json",
        data: JSON.stringify(htmldata),
        success: function (result) {
            alert('Workout successfully created!');
            window.location.href = result.newUrl;
        },
        error: function (result) {
            alert('Workout creation failed, please try again.');
            console.log('Error on AJAX return');
        }
    });
}

function createWorkout() {
    console.log("Adding workout creation functionality to webpage.");
    var workout = document.getElementById("workout");
    if (workout.style.visibility == "hidden") {
        workout.style.visibility = "";
    }
}

function createComplex() {
    console.log("Adding complex creation functionality to webpage.");
    var complexhtml =
        '<div class="row" style="background-color: white; border: 5px solid black; padding: 5px; margin: 5px;">' +
        '<div class="complex" id="complex' + compcount + '">' +
                'Complex' +
        '<table id="exercises' + compcount + '" style="visibility:hidden">' +
            "<tr>" +
                "<th>Exercise</th>" +
                "<th>Reps</th>" +
                "<th>Sets</th>" +
                "<th>Weight</th>" +
                "<th>Time</th>" +
                "<th>Speed</th>" +
                "<th>Distance</th>" +
            "</tr>" +
        '</table>' +  
        '<div class="row" align="right" style="padding: 5px; margin: 5px;">' +
        '<button class="btn btn-primary" onclick="createExercise(' + compcount + ')" style="padding: 5px; margin: 5px;">+ Add an Exercise</button>' +
                '</div>' +
            '</div>' +
        '</div>';

    $('#complexes').append($(complexhtml))
    compcount = compcount + 1;
}

function createExercise(count) {
    console.log("Adding new exercise to the current complex");
    var ex = prompt("Exercise: ");
    var sets = prompt("Number of sets: ");
    var reps = prompt("Number of reps per set: ");
    var weight = prompt("Weight (of lift): ");
    var time = prompt("Time (of run): ");
    var speed = prompt("Speed (of run): ");
    var distance = prompt("Distance (of run): ");

    var tmp = "exercises" + count;
    var table = document.getElementById(tmp);
    
    if (table.style.visibility == "hidden") {
        table.style.visibility = "";
    }

    var row = table.insertRow(-1);

    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);
    var cell4 = row.insertCell(3);
    var cell5 = row.insertCell(4);
    var cell6 = row.insertCell(5);
    var cell7 = row.insertCell(6);

    cell1.innerHTML = ex;
    cell2.innerHTML = reps;
    cell3.innerHTML = sets;
    cell4.innerHTML = weight;
    cell5.innerHTML = time;
    cell6.innerHTML = speed;
    cell7.innerHTML = distance;
}

function contactTeam(team) {
    console.log("Sending notification of new workout to athletes on " + team);
    var source = '/Workouts/ContactTeam?team=' + team;
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: source,
        success: function () {
            alert("Notification sent successfully.")
        },
        error: function (result) {
            alert("Notification sending failed.")
            console.log('Error on AJAX return');
            console.log(result);
        }
    });
}