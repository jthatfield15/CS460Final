function makeAjaxCall(id) {
    document.getElementById('output').innerHTML = null;

    $.ajax({
        url: "/Items/getDetails/" + id,
        type: "POST",
        //datatype: "json",
        success: function (returnData) { 
            returnData.arr.forEach(function (item) {
                $('#output').append(item);
            }
            )
        }
    });
}

var interval = 1000 * 5;

window.setInterval(makeAjaxCall, interval);