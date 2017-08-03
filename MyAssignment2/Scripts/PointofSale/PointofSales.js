/// <reference path="../jquery-1.10.2.min.js" />




$("#ServiceType").change(function () {
    var ServiceType = $("#ServiceType").val();
    if (ServiceType == 0) {
        $("#RooomId").prop("disabled", false);
        $("#TableId").prop("disabled", false);
        $("#RooomId").val("0").change();
        $("#TableId").val("0").change();
    }
    if (ServiceType == 1) {
        $("#TableId").prop("disabled", true);
        $("#TableId").val("0").change();
        $("#RooomId").prop("disabled", false);
    }
    if (ServiceType == 2) {
        $("#RooomId").prop("disabled", true);
        $("#TableId").prop("disabled", false);
        $("#RooomId").val("0").change();
    }
    if (ServiceType == 3) {
        $("#RooomId").prop("disabled", true);
        $("#TableId").prop("disabled", true);
        $("#RooomId").val("0").change();
        $("#TableId").val("0").change();
    }
});

$("#ItemId").change(function () {

    var ItemCode = $("#ItemId").val();


});



