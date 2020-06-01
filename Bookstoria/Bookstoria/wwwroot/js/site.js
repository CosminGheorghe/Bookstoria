
function loadServerPartialView(container, baseUrl) {
    return $.get(baseUrl, function (responseData) {
        $(container).html(responseData);
    });
}