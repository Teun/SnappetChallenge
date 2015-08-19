"use strict";

var sc = sc || {};

sc.utils = function() {

    var getIsoDateTimeString = function (date, time) {
        var timeInParts = time.split(":");
        var parsedDate = moment(date, "DD-MM-YYYY");

        parsedDate.hour(timeInParts[0]);
        parsedDate.minute(timeInParts[1]);
        parsedDate.second(timeInParts[2]);

        return parsedDate.toISOString();
    }

    var isScrollable = function(elm) {
        var docViewTop = $(window).scrollTop();
        var docViewBottom = docViewTop + $(window).height();

        var elmTop = $(elm).offset().top;
        var elmBottom = elmTop + $(elm).height();

        return ((elmBottom <= docViewBottom) && (elmTop >= docViewTop));
    }

    return {
        getIsoDateTimeString: getIsoDateTimeString,
        isScrollable: isScrollable
    }
}();