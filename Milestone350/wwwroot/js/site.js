$(function () {
    console.log("Page is ready");

    $(document).bind("contextmenu", function (e) {
       e.preventDefault();
        var buttonNumber = $(this).val();

    });

    $(document).on("mousedown", ".game-button", function (event) {
        switch (event.which)
        {
            case 1:
                event.preventDefault();
                var i = $(this).find("Row")
                var j = $(this).val ();
                console.log("Cell [" + i + "," + j + "]" +" + " + "was left clicked");
                doButtonUpdate(i,j, "/login/displayboard/ShowOneCell");
                break;
            case 3:
                event.preventDefault();
                var buttonNumber = $(this).val();
                console.log("Cell " + buttonNumber + " was Right clicked");
                doButtonUpdate(buttonNumber, "/login/displayboard/RightClickShowOneCell");
                break;

        }
    });
});

function doButtonUpdate(i, j, urlString) {
    $.ajax({
        datatype: "json",
        method: "POST",
        url: urlString,
        data: { "i": i , "j": j },
        success: function (data) {
            
            $("#" + i + j).html(data);
        }
    });
};