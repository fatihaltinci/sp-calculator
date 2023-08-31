
$(document).ready(function () {

    $("#parameterSaveButton").click(function (event) {
        event.preventDefault();

        var addUrl = app.Urls.parameterAddUrl;
        var redirectUrl = app.Urls.sprintAddUrl;

        var parameterAddModel = {
            ParameterName: $("input[id=parameterName]").val(),
            ParameterDesc: $("input[id=parameterDesc]").val(),
            ParameterPoint: $("input[id=parameterPoint]").val()

        }

        var jsonData = JSON.stringify(parameterAddModel);
        console.log(jsonData);

        $.ajax({
            url: addUrl,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: jsonData,
            success: function (data) {
                setTimeout(function () {
                    window.location.href = redirectUrl;
                }, 1500);
            },
            error: function () {
                toast.error("Bir hata oluştu.", "Hata");
            }
        });
    });
});