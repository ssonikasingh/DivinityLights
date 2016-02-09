(function ($) {
    var editForm = $("#EditForm");
    editForm.dialog({
        autoOpen: false,
        modal: true,
        title: "Edit Item"
        //,
        //close: function () {
        //    var btnSubmit = $("#btnSubmit");
        //    if (btnSubmit.length > 0)
        //        $("#btnSubmit").click();
        //    else
        //        location.reload();
        //}
    });

    $(".js-EditInDialog").click(function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr("url"),
            type: 'Get',
            data: { id: $(this).attr("id") },
            success: function (data) {
                editForm.empty().append(data);
                editForm.dialog({
                    width: $(window).width() * 0.8,
                    height: $(window).height(),
                });
                editForm.dialog("open");
            },
            error: function (error) {
                alert("something seems wrong");
            }
        });
    });

    OpenDialog = function (e, obj) {
        e.preventDefault();
        loadSpinner();
        $.ajax({
            url: obj.attributes["url"].nodeValue,
            type: 'Get',
            data: { id: obj.id },
            success: function (data) {
                editForm.empty().append(data);
                editForm.dialog({
                    width: $(window).width() * 0.8,
                    height: $(window).height(),
                });
                closeSpinner();
                editForm.dialog("open");
            },
            error: function (error) {
                closeSpinner();
                alert("something seems wrong");
            }
        });
    }

    loadSpinner = function()
    {
        $("html").addClass('loading');
    }
    closeSpinner = function () {
        $("html").removeClass('loading');
    }
})(jQuery);