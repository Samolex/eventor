﻿
$(document).ready(function () {
    $('.datepicker').datepicker({
        format: "mm/dd/yyyy",
        startDate: "+0d",
        language: "ru",
        autoclose: true
    });

    $('[data-toggle="tooltip"]').tooltip();
});

$(document).ready(function () {
    $('.datepicker-all').datepicker({
        format: "mm/dd/yyyy",
        language: "ru",
        autoclose: true
    });
    $('[data-toggle="tooltip"]').tooltip();
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