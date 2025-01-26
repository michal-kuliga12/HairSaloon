const currentDate = document.querySelector(".current-date");
weekTag = document.querySelector(".weeks");
weekHeaderTag = document.querySelector(".week-header");
prevNextIcon = document.querySelectorAll(".icons span");

let date = new Date();
currYear = date.getFullYear();
currMonth = date.getMonth();

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

const dummyHours = [
    "8:00",
    "8:30",
    "9:00",
    "9:30",
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

const getCalendarHTML = () => {
    let firstDayOfMonth = new Date(currYear, currMonth, 1).getDay();
    let lastDateOfMonth = new Date(currYear, currMonth + 1, 0).getDate();
    let lastDayOfMonth = new Date(currYear, currMonth, lastDateOfMonth).getDay();
    let lastDateofLastMonth = new Date(currYear, currMonth, 0).getDate();
    let ulTag = `<ul class="row">`;
    let dayCounter = 0;

    for (let i = firstDayOfMonth - 1; i > 0; i--) {
        ulTag += `<li class="inactive col">${lastDateofLastMonth - i + 1}</li>`;
        dayCounter++;
    }

    for (let i = 1; i <= lastDateOfMonth; i++) {
        let isToday =
            i === date.getDate() &&
                currMonth === new Date().getMonth() &&
                currYear === new Date().getFullYear()
                ? "active"
                : "";
        ulTag += `<li class="${isToday} col day-selector">${i}</li>`;
        dayCounter++;

        if (dayCounter % 7 == 0)
            ulTag += `</ul><ul class="row">`
    }

    for (let i = lastDayOfMonth; i < 7; i++) {
        ulTag += `<li class="inactive col">${i - lastDayOfMonth + 1}</li>`;
        dayCounter++;
        if (dayCounter % 7 == 0) break;
    }

    ulTag += "</ul>"
    currentDate.innerText = `${months[currMonth]} ${currYear}`;
    return ulTag;
}

const renderCalendar = () => {
    weekTag.innerHTML = getCalendarHTML();
};
renderCalendar();

const renderAvailableHours = (date) => {
    console.log(date)
    let hoursTag = "";
    let temphoursCounter = 1
    dummyHours.forEach((hour) => {
        if (temphoursCounter % 3 == 0) {
            hoursTag += `<a class="hour occupied" type="button">${hour}</a>`
        }
        hoursTag += `<a class="hour open" type="button">${hour}</a>`
        temphoursCounter++;
    })

    document.querySelector(".hours").innerHTML = hoursTag;
}

prevNextIcon.forEach((icon) => {
    icon.addEventListener("click", () => {
        currMonth = icon.id === "prev" ? currMonth - 1 : currMonth + 1;

        if (currMonth < 0 || currMonth > 11) {
            date = new Date(currYear, currMonth);
            currYear = date.getFullYear();
            currMonth = date.getMonth();
        } else {
            date = new Date();
        }

        renderCalendar();
    });
});