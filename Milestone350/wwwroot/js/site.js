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
                var buttonNumber = $(this).val();
                console.log("Cell " + buttonNumber + " was left clicked");
                doButtonUpdate(buttonNumber, "/ShowOneCell");
                break;
            case 3:
                event.preventDefault();
                var buttonNumber = $(this).val();
                console.log("Cell " + buttonNumber + " was Right clicked");
                doButtonUpdate(buttonNumber, "/Login/DisplayGameBoard/RightClickShowOneCell");
                break;

        }
    });
});

function doButtonUpdate(buttonNumber, urlString) {
    $.ajax({
        datatype: "json",
        method: "POST",
        url: urlString,
        data: { "buttonNumber": buttonNumber },
        success: function (data) {
            
            $("#" + buttonNumber).html(data);
        }
    });
};