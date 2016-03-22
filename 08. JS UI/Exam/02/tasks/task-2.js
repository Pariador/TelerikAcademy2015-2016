function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };

        // you are welcome :)
        var date = new Date();
        // console.log(date.getDayName());
        // console.log(date.getMonthName());
        // ===========================

        var i,
            j,
            len,
            CLASSES = {
                WRAPPER: 'datepicker-wrapper',
                DATE_PICKER:'datepicker',
                PICKER: 'picker',
                PICKER_VISIBLE: 'picker-visible',
                CURRENT_DATE_LINK: 'current-date-link',
                CURRENT_DATE: 'current-date',
                BUTTON: 'btn',
                CURRENT_MONTH: 'current-month',
                ANOTHER_MONTH: 'another-month',
                CALENDAR: 'calendar',
                CONTROLS: 'controls',
            },
            COLS = 7,
            ROWS = 6,
            $this = this,
            $wrapper = $('<div>'),
            $picker,
            $currentDateLink,
            $controls,
            $leftButton,
            $rightButton,
            $currentMonth,
            $calendarBody,
            $calendarHead,
            $headRow,
            $currentRow,
            $currentCol,
            $calendar;

        $wrapper.addClass(CLASSES.WRAPPER)
                .insertBefore($this)
                .append($this);

        $this.addClass(CLASSES.DATE_PICKER);

        $picker = $('<div>')
                .addClass(CLASSES.PICKER)
                .addClass(CLASSES.PICKER_VISIBLE)
                .appendTo($wrapper);

        $controls = $('<div>')
                    .addClass(CLASSES.CONTROLS)
                    .appendTo($picker);

        $leftButton = $('<button>')
                    .addClass(CLASSES.BUTTON)
                    .text('<')
                    .appendTo($controls);

        $currentMonth = $('<span>')
                        .addClass(CLASSES.CURRENT_MONTH)
                        .text('asdasd')
                        .appendTo($controls);

        $rightButton = $('<button>')
                    .addClass(CLASSES.BUTTON)
                    .text('>')
                    .appendTo($controls);

        $calendar = $('<table>')
                    .addClass(CLASSES.CALENDAR)
                    .appendTo($picker);

        $calendarHead = $('<thead>')
                        .appendTo($calendar);

        $headRow = $('<tr>')
                    .appendTo($calendarHead);

        for (i = 0; i < COLS; i += 1) {
            $('<th>')
            .text(WEEK_DAY_NAMES[i])
            .appendTo($headRow);
        }

        $calendarBody = $('<tbody>')
                        .appendTo($calendar);

        for (i = 0; i < ROWS; i+=1) {
            $currentRow = $('<tr>')
                        .appendTo($calendarBody);

            for (j = 0; j < COLS; j+=1) {
                $currentCol = $('<td>')
                            .text('as')
                            .appendTo($currentRow);

                if (i === 0 || i === ROWS - 1) {
                    $currentCol.addClass(CLASSES.ANOTHER_MONTH);
                } else {
                    $currentCol.addClass(CLASSES.CURRENT_MONTH);
                }

            }
        }

        $currentDateLink = $('<a>')
                            .addClass(CLASSES.CURRENT_DATE_LINK)
                            .addClass(CLASSES.CURRENT_DATE)
                            .appendTo($picker)
                            .text('TODAY');

        return this;
    };
}

// module.exports = solve;