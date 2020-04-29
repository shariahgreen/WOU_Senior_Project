$(document).ready(function () {
    
    $("#registerModal").modal('show');

    $("#registerBtn").click(function () {
        $("#registerModal").modal('show');
    });
    //registerBtn

    $("#subAndClose").click(function () {
        $("#registerModal").modal('hide');
    });
}); 

function myFunction1() {
    var x = document.getElementById("myDIV1");
    var y = document.getElementById("myDIV2");
    var z = document.getElementById("myDIV3");
    x.style.display = "block";
    y.style.display = "none";
    z.style.display = "none";
}
function myFunction2() {
    var x = document.getElementById("myDIV2");
    var y = document.getElementById("myDIV1");
    var z = document.getElementById("myDIV3");
    x.style.display = "block";
    y.style.display = "none";
    z.style.display = "none";
}

function myFunction3() {
    var x = document.getElementById("myDIV1");
    var y = document.getElementById("myDIV2");
    var z = document.getElementById("myDIV3");
    z.style.display = "block";
    y.style.display = "none";
    x.style.display = "none";
}