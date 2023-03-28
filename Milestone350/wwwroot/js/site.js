$(function () {
    console.log("Page is ready");

    $(document).bind("contextmenu", function (e) {
       e.preventDefault();
        var cord = $(this).val();

    });

    $(document).on("mousedown", ".game-button", function (event) {
        switch (event.which)
        {
            case 1:
                event.preventDefault();
                
                var  cord= $(this).val();
                console.log("Cell [" + cord + "]" +  " + " + "was left clicked");
                doButtonUpdate(cord, "/login/ShowOneCell");
                break;
            case 3:
                event.preventDefault();
                var cord = $(this).val();
                console.log("Cell " + cord + " was Right clicked");
                doButtonUpdate(cord, "/login/RightClickShowOneCell");
                break;

        }
    });
});

function doButtonUpdate(cord, urlString) {
    $.ajax({
        datatype: "json",   
        method: "POST",
        url: urlString,
        data: { "Cord": cord},
        success: function (data) {
            
            $("#" + cord).html(data);
        }
    });
};

function handleButtonContextMenu(event, button) {

    // oncontextmenu is when this method is called
    $.ajax({
        url: "/login/displayboard/RightClickShowOneCell",
        type: 'POST',
        data: { bN: button.Col },
        success: function (result) {
            console.log('Button right-click detected: ' + button.Row + button.Col );
            $("#grid").html(result);
        }
    });
};