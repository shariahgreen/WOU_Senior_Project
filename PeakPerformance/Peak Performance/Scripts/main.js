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

function createWorkoutSave() {
    //var dropdownListElem = document.getElementById("TeamList");
    //var woTeam = dropdownListElem.options[dropdownListElem.selectedIndex].value;
    //var woDate = document.getElementById("Date").value;
    //console.log("Workout created for team " + woTeam + " on date " + woDate)
    var htmldata = document.getElementById("EntireWorkoutElement").innerHTML;
    var source = '/Workouts/CreateWorkout';
    var htmldataenc = { "value": htmldata }
    $.ajax({
        url: source,
        type: 'POST',
        processData: false,
        //data: JSON.stringify(data),
        data : htmldataenc,
        success: function (result) {
            alert('the request was successfully sent to the server');
        },
        error: errorOnAjax
    });

    /*$.ajax({
        type: 'GET',
        dataType: 'json',
        url: source,
        success: createWorkoutView,
        error: errorOnAjax
    });*/
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
    var complexhtml = '<div class="row" style="background-color: white; border: 5px solid black; padding: 5px; margin: 5px;">' +
        'Complex' +
        '<button class="btn btn-primary" id="newexercise" onclick="createExercise" style="padding: 5px; margin: 5px;" >' + '+ Add New Exercise' +
        '</button></div> ';

    $('#complexes').append($(complexhtml))
}

function createExercise() {
    console.log("Adding new exercise to the current complex");
}