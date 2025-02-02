$(document).ready(function () {
    renderCalendar();

    $(".hours").on("click", ".hour", handleHourSelection);
    $(".icons span").on("click", handleMonthSelection);
})

const today = new Date();
let date = new Date();

let calendar = {
    year: today.getFullYear(),
    month: today.getMonth(),
}

let selectedDate = new Date(calendar.year, calendar.month, today.getDate() + 1);

const getCalendarDate = () => selectedDate;

const months = [
    "Styczeń",
    "Luty",
    "Marzec",
    "Kwiecień",
    "Maj",
    "Czerwiec",
    "Lipiec",
    "Sierpień",
    "Wrzesień",
    "Październik",
    "Listopad",
    "Grudzień",
];

const hours = [
    "08:00",
    "08:30",
    "09:00",
    "09:30",
    "10:00",
    "10:30",
    "11:00",
    "11:30",
    "12:00",
    "12:30",
    "13:00",
    "13:30",
    "14:00",
    "14:30",
    "15:00",
]

const generateCalendar = () => {
    let firstDayOfMonth = new Date(calendar.year, calendar.month, 1).getDay();
    let lastDateOfMonth = new Date(calendar.year, calendar.month + 1, 0).getDate();
    let lastDayOfMonth = new Date(calendar.year, calendar.month, lastDateOfMonth).getDay();
    let lastDateofLastMonth = new Date(calendar.year, calendar.month, 0).getDate();
    let ulTag = `<ul class="row">`;
    let dayCounter = 0;

    // Dni z poprzedniego miesiąca
    for (let i = firstDayOfMonth - 1; i > 0; i--) {
        ulTag += `<li class="inactive col">${lastDateofLastMonth - i + 1}</li>`;
        dayCounter++;
    }

    // Dni z aktualnego miesiąca
    for (let i = 1; i <= lastDateOfMonth; i++) {
        let isTodayClass = getTodayClass(i);
        let isSundayClass = getSundayClass(i);

        i <= today.getDate() && new Date().getMonth() == calendar.month
            ? ulTag += `<li class="${isTodayClass} ${isSundayClass} col day inactive">${i}</li>`
            : ulTag += `<li class="${isTodayClass} ${isSundayClass} col day">${i}</li>`

        dayCounter++;

        if (dayCounter % 7 == 0)
            ulTag += `</ul><ul class="row">`
    }

    // Dni z następnego miesiąca
    for (let i = lastDayOfMonth; i < 7; i++) {
        ulTag += `<li class="inactive col">${i - lastDayOfMonth + 1}</li>`;
        dayCounter++;
        if (dayCounter % 7 == 0) break;
    }

    ulTag += "</ul>"
    $(".month-year-header").text(`${months[calendar.month]} ${calendar.year}`);
    return ulTag;
}

const getTodayClass = function (day) {
    return day === today.getDate()
        && calendar.month === new Date().getMonth()
        && calendar.year === new Date().getFullYear()
        ? "today"
        : "";
}

const getSundayClass = function (day) {
    return new Date(calendar.year, calendar.month, day).getDay() === 0 ? "sunday inactive" : "";
}

const renderCalendar = () => {
    $(".weeks").html(generateCalendar());
    $('.day').on('click', handleDaySelection);
};

const renderHours = function() {
    let occupiedHours = [];
    let employeeId = getEmployeeIdFromLocalStorage();
    let dateString = selectedDate.toISOString();
    
    $.ajax({
        url: "/Customer/Appointment/GetAvailableHours",
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ date: dateString, employeeId: employeeId }),
        dataType: "json",
        success: (data) => {
            occupiedHours = data.data;
            console.log(occupiedHours);  // Sprawdź, co zwrócił serwer

            let hoursTag = "";
            hours.forEach((hour) => {
                // Sprawdzamy, czy godzina jest zajęta
                if (occupiedHours.includes(hour)) {
                    hoursTag += `<a class="hour col-xs-4 occupied" data-hour="${hour}" type="button">${hour}</a>`;
                } else {
                    hoursTag += `<a class="hour col-xs-4" data-hour="${hour}" type="button">${hour}</a>`;
                }
            });

            // Wstaw godziny do DOM
            $(".hours").html(hoursTag);
        }
    }) 
}

const handleDaySelection = function () {
    if (!$(this).hasClass("inactive")) {
        let dayNumber = parseInt($(this).text(), 10);
        selectedDate = new Date(calendar.year, calendar.month, dayNumber,12);
        console.log(selectedDate);
        $(".day").removeClass("selected")
        $(this).addClass("selected");
        renderHours();
    }
}

const handleHourSelection = function () {
    const [hours, minutes] = $(this).data("hour").split(":");
    $('.hour').removeClass('selected');
    $(this).addClass("selected");
    selectedDate.setHours(parseInt(hours) + 1, parseInt(minutes), 0, 0);
}

const handleMonthSelection = function () {
    let newMonth = $(this).attr("id") === "prev" ? calendar.month - 1 : calendar.month + 1;

    if (calendar.year > today.getFullYear() ||
        (calendar.year === today.getFullYear() && newMonth >= today.getMonth()) &&
        newMonth - today.getMonth() < 3) {

        if (newMonth >= 0)
            calendar.month = newMonth;

        // Aktualizuj rok, jeśli nowy miesiąc wykracza poza zakres
        if (calendar.month > 11) {
            date = new Date(calendar.year, calendar.month);
            calendar.year = date.getFullYear();
            calendar.month = date.getMonth();
        }

        renderCalendar();
    } else {
        console.log("Nie możesz cofnąć się do przeszłego miesiąca!");
    }
}