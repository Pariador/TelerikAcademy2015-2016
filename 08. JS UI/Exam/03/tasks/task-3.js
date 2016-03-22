function solve() {
    return function (selector) {
        var template = '<div class="events-calendar"><h2 class="header">Appointments for <span class="month">{{month}}</span> <span class="year">{{year}}</span></h2>{{#days}}<div class="col-date"><div class="date">{{day}}</div><div class="events">{{#events}}<div class="event {{importance}}" title="{{comment}}">{{#if title}}<div class="title">{{title}}</div>{{else}}<div class="title">Free slot</div>{{/if}}{{#if time}}<span class="time">{{time}}</span>{{/if}}</div>{{/events}}</div></div>{{/days}}</div>';
        document.getElementById(selector).innerHTML = template;
    };
}

// module.exports = solve;