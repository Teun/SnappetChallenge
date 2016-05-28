/// <reference path="~/Scripts/lib/knockout-3.4.0.js" />
/// <reference path="~/Scripts/lib/jquery-1.10.2.js" />

define(["jquery", "knockout", "jqueryUI"], function ($, ko) {
    ko.bindingHandlers.autocomplete = {
        init: function (element, params) {
            var options = $.extend({
                focus: function(event) { event.preventDefault(); }
            }, params());

            var selectCallback = options.select;
            options.select = function(event, ui) {
                selectCallback(event, ui);

                event.preventDefault();
                $(this).val(ui.item.label);
            }

            $(element).autocomplete(options);
        },
        update: function (element, params) {
            $(element).autocomplete("option", "source", params().source);
        }
    };
});