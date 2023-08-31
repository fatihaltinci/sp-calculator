$(document).ready(function () {
    // Fonksiyonlar ve parametreler için seçili dizi tanımlıyoruz
    var selectedFunctions = []; // bu kısımlarda isimlerini tutuyoruz
    var selectedParameters = [];

    var selectedFunctionIds = []; // bu kısımlarda guidlerini tutuyoruz
    var selectedParameterIds = [];

    // Seç butonlarına tıklanınca seçilenleri listelere ekleyen event listener ekliyoruz
    $('#functionSelectButton').on('click', function () {
        var selectedFunctionsModal = Array.from($('#functionListModal').find("option:selected"), option => option.text);
        selectedFunctions = selectedFunctions.concat(selectedFunctionsModal);
        selectedFunctionIds = selectedFunctionIds.concat(Array.from($('#functionListModal').find("option:selected"), option => option.value));
        updateSelectedItems();
        $('#functionModal').modal('hide');
    });

    $('#parameterSelectButton').on('click', function () {
        var selectedParametersModal = Array.from($('#parameterListModal').find("option:selected"), option => option.text);
        selectedParameters = selectedParameters.concat(selectedParametersModal);
        selectedParameterIds = selectedParameterIds.concat(Array.from($('#parameterListModal').find("option:selected"), option => option.value));
        updateSelectedItems();
        $('#parameterModal').modal('hide');
    });

    // Seçilenleri göstermek için fonksiyon
    function updateSelectedItems() {
        var selectedFunctionsHtml = "";
        var selectedParametersHtml = "";

        // Seçilen fonksiyonları gösteriyoruz
        if (selectedFunctions.length > 0) {
            selectedFunctionsHtml += "<ul>";
            selectedFunctions.forEach(function (functionItem) {
                selectedFunctionsHtml += "<li>" + functionItem + "</li>";
            });
            selectedFunctionsHtml += "</ul>";
        }

        // Seçilen parametreleri gösteriyoruz
        if (selectedParameters.length > 0) {
            selectedParametersHtml += "<ul>";
            selectedParameters.forEach(function (parameterItem) {
                selectedParametersHtml += "<li>" + parameterItem + "</li>";
            });
            selectedParametersHtml += "</ul>";
        }

        // Gösterilecek alanı güncelliyoruz
        $('#selectedFunctionsList').html(selectedFunctionsHtml);
        $('#selectedParametersList').html(selectedParametersHtml);

        // Gizli alanlara seçilenlerin ID'lerini atıyoruz
        $('#selectedFunctionIds').val(selectedFunctionIds.join(','));
        $('#selectedParameterIds').val(selectedParameterIds.join(','));
    }

    // Fonksiyon seçim modalı
    $('#functionSelectButton').on('click', function () {
        selectedFunctionIds = Array.from($('#functionListModal').find("option:selected"), option => option.value); // selectedFunctionIds'i doğru alıyoruz
        selectedFunctions = selectedFunctionIds.map(function (functionId) {
            return Model.Functions.find(function (func) {
                return func.Id === functionId;
            }).FunctionName;
        });
        updateSelectedItems(); // Seçim yapıldığında seçilenleri güncelle
        $('#functionModal').modal('hide');
    });

    // Parametre seçim modalı
    $('#parameterSelectButton').on('click', function () {
        selectedParameterIds = Array.from($('#parameterListModal').find("option:selected"), option => option.value); // selectedParameterIds'yi doğru alıyoruz
        selectedParameters = selectedParameterIds.map(function (parameterId) {
            return Model.Parameters.find(function (param) {
                return param.Id === parameterId;
            }).ParameterName;
        });
        updateSelectedItems(); // Seçim yapıldığında seçilenleri güncelle
        $('#parameterModal').modal('hide');
    });

    // Sprint Kaydet butonu işlevi
    $('#sprintSaveButton').on('click', function () {
        // Formu submit etmek için kullanılacak kodlar...
        $('form[asp-controller="Sprint"][asp-action="Add"]').submit();
    });

});
                    