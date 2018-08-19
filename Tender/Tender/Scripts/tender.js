//Initiate calendar in filter zone
$('.datepicker').datepicker({
    weekStart: 1,
    daysOfWeekHighlighted: "6,0",
    autoclose: true,
    todayHighlight: true,
});

/**
 * Used for sending start or finish dates or checked checkboxes (organisators or kinds) for filtration
 */
function sendAjaxAndReplaceContent(sendingDate) {
    $.ajax({
        type: "GET",
        url: '/Tenders/Indexx',
        contentType: "application/json; charset=utf-8",
        data: sendingDate,
        success: function (data) {
            $('#resultBlock').html(data);
        },
        error: function (jqXHR, exception) {
            alert('A error');
        }
    });
}
$(".checkbox").change(function () {
    sendAjaxAndReplaceContent({
        filterParam: $(this).attr("name"),
        isFilterChecked: ($(this).val() == "on" ? true : false)
    });
});
$("input[name='startDate']").change(function () {
    var s = $("input[name='startDate']").val();
    var f = $("input[name='finishDate']").val();
    var startdate = s ? new Date(s) : "";
    var finishdate = f ? new Date(f) : "";
    if (finishdate - startdate > 0 || !startdate || !finishdate)
        sendAjaxAndReplaceContent({
            startDate: startdate.toDateString()
        });
    else {
        alert("Start day (finish day) must be lower (greater) for finish day (start day)");
    }
});
$("input[name='finishDate']").change(function () {
    var s = $("input[name='startDate']").val();
    var f = $("input[name='finishDate']").val();
    var startdate = s ? new Date(s) : "";
    var finishdate = f ? new Date(f) : "";
    if (finishdate - startdate > 0 || !startdate || !finishdate)
        sendAjaxAndReplaceContent({
            finishDate: finishdate.toDateString()
        });
    else {
        alert("Start day (finish day) must be lower (greater) for finish day (start day)");
    }
});
/*
 *Provide remembering current sort-parameter for sort list while using other filters or search
 */
$("#sortList").change(function () {
    var sortBy = $("#sortOrder").val();
    var newParamForSort = $(this).val();
    $("#sortOrder").val(newParamForSort);
    $("#formSorting").submit();
});
/*
 * pagination
 */
$(document).ready(function () {
    $("#Previous").click(function () {
        if (CalculateAndSetPage("Previous"))
            $("#formPagination").submit();
    });
    $("#Next").click(function () {
        if (CalculateAndSetPage("Next"))
            $("#formPagination").submit();
    });
})
function CalculateAndSetPage(movingType) {
    var currentPage = parseInt($("#CurrentPage").val());
    if (currentPage == 1 && movingType == "Previous")
        return false;
    if (currentPage == parseInt($("#LastPage").val()) && movingType == "Next")
        return false;
    if (movingType == "Previous") {
        currentPage--;
    }
    else if (movingType == "Next") {
        currentPage++;
    }
    else {
        alert("Something wrong");
    }
    $("#CurrentPage").val(currentPage);
    return true;
}