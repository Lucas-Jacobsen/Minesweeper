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
                
                var  cord= $(this).val ();
                console.log("Cell [" + cord + "]" +  " + " + "was left clicked");
                doButtonUpdate(i,j, "/login/displayboard/ShowOneCell");
                break;
            case 3:
                event.preventDefault();
                var cord = $(this).val();
                console.log("Cell " + cord + " was Right clicked");
                doButtonUpdate(cord, "/login/displayboard/RightClickShowOneCell");
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