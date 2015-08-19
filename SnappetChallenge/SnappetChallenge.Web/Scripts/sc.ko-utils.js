"use strict";

/*
 * Thank you very much mister knockout, R.P. Niemeyer.
 * Got it here: http://stackoverflow.com/questions/9877301/knockoutjs-observablearray-data-grouping
 * 
 * Curious about client side performance with larger sets, let give it a spin!
 */

$(function() {
    ko.observableArray.fn.distinct = function (prop) {
        var target = this;
        target.index = {};
        target.index[prop] = ko.observable({});

        ko.computed(function () {
            //rebuild index
            var propIndex = {};

            ko.utils.arrayForEach(target(), function (item) {
                var key = ko.utils.unwrapObservable(item[prop]);
                if (key) {
                    propIndex[key] = propIndex[key] || [];
                    propIndex[key].push(item);
                }
            });

            target.index[prop](propIndex);
        });

        return target;
    };
});