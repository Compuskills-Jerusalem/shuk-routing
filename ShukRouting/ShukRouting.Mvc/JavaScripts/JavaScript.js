$(document).ready(function () {

    $("body").on("keypress", function (e) {
        if (e.which == 13) {
            alert("POPOPOPOP!!!");
            SearchFunction();
        }
    });

    $("#search").on("click", function (e) {
        SearchFunction();
    });


    function SearchFunction(e) {
        if ($("#itemInput").val() == "") {
            alert("Item name cannot be empty !!");
        }
        else {
            $.ajax({
                type: "GET",
                url: "/Stall/Details",
                contentType: "application/json; charset=utf-8",
                data: { stallName: $("#itemInput").val() },
                dataType: "html",
                success: function (result, status, xhr) {
                    $("#body").html(result);
                },
                error: function (xhr, status, error) {
                    alert("it was nooot a  success !!!");
                }
            });
        };
        return false;
    };

});
