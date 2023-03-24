$(function () {
    console.log("Page is ready");

    $(document).bind("contextmenu", function (e) {
       e.preventDefault();
        var buttonNumber = $(this).val();
        console.log("Button " + buttonNumber + " was Right clicked");

    });

    $(document).on("mousedown", ".game-button", function (event) {
        switch (event.which)
        {
            case 1:
                event.preventDefault();
                var buttonNumber = $(this).val();
                console.log("Button " + buttonNumber + " was left clicked");
                doButtonUpdate(buttonNumber, "/Login/DisplayGameBoard/flag");
                break;
            case 3:
                event.preventDefault();
                var buttonNumber = $(this).val();
                console.log("Button " + buttonNumber + " was Right clicked");
                doButtonUpdate(buttonNumber, "/Login/DisplayGameBoard/flag"); break;
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
            console.log(data);
            $("#" + buttonNumber).html(data);
        }
    });
};