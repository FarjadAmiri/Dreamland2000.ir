function FillOrderWage() {
    //alert("run");
    var requestCount = $('#RequestCount').val();
    if (requestCount === "" || requestCount === "0") {
        requestCount = 0;
    }
    var actionUrl ="/Base/FillOrderWage";
    $.ajax({
        type: "GET",
        url: actionUrl,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: { id: requestCount },
        success: function (response) {
            //alert("success");
            $('#WageAmount').val(response.WagePrice);
        }
    });
};