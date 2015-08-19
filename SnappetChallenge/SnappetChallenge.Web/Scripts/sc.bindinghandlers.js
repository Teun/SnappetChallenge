"use strict";

var sc = sc || {}; // snappetChallenge namespace

// self invoking pattern
// we use an initializer function, on script load there are no dependencies on external scripts
// this initializer is called in sc.main.js on DOM ready when all libs are available
sc.bindingsHandlers = (function () {
    var registerHandlers = function() {
        ko.bindingHandlers.datepicker = {
            init: function (element, valueAccessor, allBindingsAccessor) {
                var options = allBindingsAccessor().datepickerOptions || { autoclose: true, language: "nl", orientation: "top left" }; // default

                $(element).datepicker(options).on("changeDate", function (ev) {
                    var observable = valueAccessor();
                    observable(moment(ev.date).format("DD-MM-YYYY"));
                });

                if (allBindingsAccessor().endDate !== undefined) {
                    var $elm1 = $(element); // better to figure out how to keep track of the proper scope instead of making a copy
                    $elm1.datepicker('setEndDate', allBindingsAccessor().endDate()); // initial range
                    allBindingsAccessor().endDate.subscribe(function (newVal) {
                        $elm1.datepicker('setEndDate', newVal);
                    });
                }

                if (allBindingsAccessor().startDate !== undefined) {
                    var $elm2 = $(element);
                    $elm2.datepicker('setStartDate', allBindingsAccessor().startDate()); // initial range
                    allBindingsAccessor().startDate.subscribe(function (newVal) {
                        $elm2.datepicker('setStartDate', newVal);
                    });
                }
            },
            update: function (element, valueAccessor) {
                var value = ko.utils.unwrapObservable(valueAccessor());
                $(element).datepicker("setDate", value);
            }
        };

        ko.bindingHandlers.timepicker = {
            init: function (element, valueAccessor, allBindingsAccessor) {
                var options = allBindingsAccessor().timepickerOptions || { showMeridian: false, showSeconds: true, disableFocus: true };
                $(element).timepicker(options).on("changeTime.timepicker", function (ev) {
                    var observable = valueAccessor();
                    observable(ev.time.value);
                });
            },
            update: function (element, valueAccessor) {
                var value = ko.utils.unwrapObservable(valueAccessor());
                $(element).timepicker('setTime', value);
            }
        };
    }

    var initialize = function() {
        registerHandlers();
    };

    return {
        initialize: initialize
    }
})();