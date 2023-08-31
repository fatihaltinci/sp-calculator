$(document).ready(function () {

    $("#functionSaveButton").click(function (event) {
        event.preventDefault();

        var addUrl = app.Urls.functionAddUrl;
        var redirectUrl = app.Urls.sprintAddUrl;

        var functionAddModel = {
            FunctionName: $("input[id=functionName]").val()
        }

        var jsonData = JSON.stringify(functionAddModel);
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