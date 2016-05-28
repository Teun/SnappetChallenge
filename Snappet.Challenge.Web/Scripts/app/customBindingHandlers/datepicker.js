/// <reference path="~/Scripts/lib/knockout-3.4.0.js" />
/// <reference path="~/Scripts/lib/jquery-1.10.2.js" />

define(["jquery", "knockout", "jqueryUI"], function ($, ko) {
    ko.bindingHandlers.datepicker = {
        init: function (element, valueAccessor, allBindingsAccessor) {
            //initialize datepicker with some optional options
            var options = allBindingsAccessor().datepickerOptions || {};

            // update observable value on select
            options.onClose = function () {
                var observable = valueAccessor();
                observable($(element).datepicker("getDate"));
            };

            $(element).datepicker(options);

            //handle the field changing
            ko.utils.registerEventHandler(element, "change", function () {
                var observable = valueAccessor();
                observable($(element).datepicker("getDate"));
            });

            //handle disposal (if KO removes by the template binding)
            ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
                $(element).datepicker("destroy");
            });

        }
    };

    ko.bindingHandlers.minDate = {
        update: function(element, valueAccessor) {
            if ($(element).data("datepicker") !== null) {
                var value = ko.utils.unwrapObservable(valueAccessor());
                $(element).datepicker("option", "minDate", value);
            }
        }
    };

    ko.bindingHandlers.maxDate = {
        update: function (element, valueAccessor) {
            if ($(element).data("datepicker") !== null) {
                var value = ko.utils.unwrapObservable(valueAccessor());
                $(element).datepicker("option", "maxDate", value);
            }
        }
    }
});