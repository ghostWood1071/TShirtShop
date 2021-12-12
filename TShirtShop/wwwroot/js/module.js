var myApp = angular.module("myapp", ['ui.bootstrap']);
function getParameter(parameterName) {
    var result = null,
        tmp = [];
    location.search
        .substr(1)
        .split("&")
        .forEach(function (item) {
            tmp = item.split("=");
            if (tmp[0] === parameterName) result = decodeURIComponent(tmp[1]);
        });
    return result;
}

function getLocalData(item) {
    var raw = localStorage.getItem(item);
    if (raw == null)
        localStorage.setItem(item, "[]");
    var data = JSON.parse(localStorage.getItem(item));
    return data;
}

function saveToLocal(item, data) {
    var value = JSON.stringify(data);
    console.log(value);
    localStorage.setItem(item, value);
}
