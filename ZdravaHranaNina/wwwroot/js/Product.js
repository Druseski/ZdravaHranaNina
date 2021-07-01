$(document).ready(function () {
    console.log("Document Ready from included JS Script!!!!!");
});


$("#CategoryID").change(function () {
    var optionSelected = $("option:selected", this);
    var optionName = optionSelected.text();
    $("#CategoryName").val(optionName);
});

$("#addNewCategory").click(function () {

    var data = { Name: $("#CategoryNameDTO").val() };

    $.ajax({
        type: "POST",
        url: "/Categories/CreateCategoryAJAX",
        data: data,
        dataType: "json",
        success: function (data) {
            if (data.data == '') {
                $('#categoryModal').modal('toggle');
                setTimeout(() => {
                    alert("Error: Category has NOT been added! Please enter data in all the fields!");
                }, 500);
            } else {
                $("#CategoryID").append("<option value=" + data.data.id + ">" + data.data.name + "</option>");
                $("#CategoryID").val(data.data.id);
                var newOptionSelected = $("#CategoryID option:selected").text();
                $("#CategoryName").val(newOptionSelected);
                $('#categoryModal').modal('toggle');
            }
        },
        error: function () { alert("Error Adding New Category!"); }
    });
});

$("#uploadPhoto").click(function () {
    var data = new FormData();
    var files = $("#photoUpload").get(0).files;

    if (files.length > 0) {
        data.append("UploadedImage", files[0]);
        console.log(data);
    }
    $.ajax({
        type: "POST",
        url: "/Products/UploadPhoto",
        data: data,
        contentType: false,
        processData: false,
        success: function (data) {
            console.log(data.dbPath);
            $("#PhotoURL").val(data);

        },
        error: function () {
            alert("Error Uploading Photo ");
        }
    });


});