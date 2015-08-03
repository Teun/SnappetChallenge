(function() {

	// Custom function that transform an array into the wanted nested object
	_.nest = function(collection, keys, _invoke) {
		if (!keys.length) {
			return collection;
		} else {
			return _(collection).groupBy(keys[0]).mapValues(function(values) {
				var key = keys.slice(1);
				var value = _.nest(values, key);

				if(typeof _invoke == "function") {
					value = _invoke(value, values, key);
				}

				return value;
			}).value();
		}
	};

})();
