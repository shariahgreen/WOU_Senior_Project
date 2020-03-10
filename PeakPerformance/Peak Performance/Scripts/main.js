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
    $('#result').append($('<p>Found ' + data.length + ' results:</p>'))
    for (var i = 0; i < data.length; ++i) {
        $('#result').append($('<p id ="exerciseResult">' + data[i] + '</p>'))
    }
}