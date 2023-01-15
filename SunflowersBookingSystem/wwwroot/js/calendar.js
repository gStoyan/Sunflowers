
$(document).ready(function () {
    toggle()
});

function toggle(event) {
    const callingDiv = $(event);
    const dateText = callingDiv.find('span').text()
    console.log(dateText);
    let date = new Date("20" + dateText.split('/')[2], dateText.split('/')[1] -1, dateText.split('/')[0]);
    var day = ("0" + date.getDate()).slice(-2);
    var month = ("0" + (date.getMonth() + 1)).slice(-2);

    var selectedDate = date.getFullYear() + "-" + (month) + "-" + (day);
    console.log(selectedDate);
    $('#startDate').val(selectedDate);
    $('#endDate').val(selectedDate);
    $('#month').val(month);
    document.getElementById("collapse").classList.toggle("hide");
}
