
$(document).ready(function () {
    
    $('.datepicker').datepicker({
        format: "dd/mm/yyyy",
        startDate: "+0d",
        language: "ru",
        autoclose: true
    });
});

function getQueryVariable(variable) {
    var query = window.location.search.substring(1);
    var vars = query.split('&');
    for (var i = 0; i < vars.length; i++) {
        var pair = vars[i].split('=');
        if (decodeURIComponent(pair[0]) == variable) {
            return decodeURIComponent(pair[1]);
        }
    }
};

function ajaxReq(url, method, data, cb) {
    $.ajax({
        url: url,
        type: method,
        data: data,
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            cb(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            cb(null, jqXHR, textStatus, errorThrown);
        }
    });
}