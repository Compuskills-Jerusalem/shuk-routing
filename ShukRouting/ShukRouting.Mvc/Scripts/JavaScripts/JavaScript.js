$(document).ready(function () {

    $("body").on("keypress", function (e) {
        if (e.which == 13) {
            SearchFunction();
            return false;
        }
    });

    $("#search").on("click", function (e) {
        SearchFunction();
        return false;
    });

    function SearchFunction() {
        var input = $("#itemInput").val();

        if (input == "") {
            alert("Item name cannot be empty !!");
        }
        else {
            $.ajax({
                type: "GET",
                url: "/CommodityStall/Details",
                contentType: "application/json; charset=utf-8",
                data: { name: input },
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