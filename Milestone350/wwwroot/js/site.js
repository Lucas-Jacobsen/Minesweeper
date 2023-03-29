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
                
                var userCell = $(this).val();


                console.log("Cell [" + userCell + "]" +  " + " + "was left clicked");
                doButtonUpdate(userCell, "/login/ShowOneCell");
                break;
            case 3:
                event.preventDefault();
                var userCell = $(this).val();
                console.log("Cell " + userCell + " was Right clicked");
                doButtonUpdate(userCell, "/login/RightClickShowOneCell");
                break;

        }
    });
});

function doButtonUpdate(userCell, urlString) {
    $.ajax({
        datatype: "json",   
        method: "POST",
        url: urlString,
        data: { "userCell": userCell},
        success: function (data) {
            console.log("Do button Update : " + userCell);
            $("#" + userCell).html(data);
        }
    });
};

function handleButtonContextMenu(event, button)
{

    // oncontextmenu is when this method is called
    $.ajax({
        url: "/login/HandleButtonFlag",
        type: 'POST',
        data: { "userCell": userCell },
        success: function (result) {
            console.log('Button right-click detected: ');
            $("#" + userCell).html(result);
        }
    }); 
    event.preventDefault();
}