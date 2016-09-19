/**
 * Base executer of promises. Handles XHR requests and error handling for Archis.
 * Can either accept $http or $resourse promises ($http wraps the result in .data)
 * 
 * When an error occurs (.status !== 'OK') the user is redirected to /error.
 * 
 * The flow of callbacks is as follows:
 *  - @beforeSuccessCallback
 *  - @alterResponseCallback
 *  - @cache (store if present)
 *  - @onSuccessCallback
 * 
 * Parameters:
 * 
 * @promise:
 * The promises to execute when @cachename is not found in @cache, or @cache is null.
 * 
 * @cache:
 * Instance of $cacheFactory which holds cached items.
 * 
 * If <null> caching will be ignored.
 * 
 * @cachename:
 * 'Key' of an item in @cache that will be retrieved if present in @cache. Otherwise 
 * it will be added to @cache with @cachename as 'key'.
 * 
 * If @cache is <null> than this should be too. 
 * 
 * @onSuccessCallback:
 * Function call when result received or item found in cache. Is only called when .status
 * is 'OK'. 
 * 
 * The callback is used to set the returned data to a local variable.
 * 
 * @beforeSuccessCallback:
 * First function to be called after the result is 'OK'. 
 * 
 * Normally used to clear old caches, and/or reset certain variables in the $scope.
 * 
 * @alterResponseCallback:
 * Called after @beforeSuccessCallback. Can be used to change the data from the server 
 * before processing it further (thus the changed data is cached and returned in the
 * @onSuccessCallback's parameter.
 * 
 * Usage:
 *     	var promise = $http.get(URL.PERIODEN, { cache : true });
 *     	baseService.execute(promise, thesaurusCache, PERIODEN, onSuccessCallback, null, function alterResponseCallback(data) {
 *     		var index = 1;
 *     	
 *     		_.forEach(data, function(item) {
 *     			item.index = index++;
 *     		}, this);
 *     	
 *     		return data;
 *     	});
 */

angular.module('snptApp')

.service('baseService', [
    '$rootScope',

    function ($rootScope) {

        this.execute = function (promise, cache, cachename, onSuccessCallback, beforeSuccessCallback, alterResponseCallback) {
            //If cache is null, ignore caching
            var cacheItem = cache ? cache.get(cachename) : null;

            if (!cacheItem) {
                return promise.then(
                    function onSuccess(response) {
                        var _status, _data, _code;

                        if (response.data) {
                            //$http - Wraps the result from the server in .data
                            _data = response.data.body;
                        } else {
                            //$resource - Doesn't wrap the result
                            _data = response;
                        }

                        //Skip top secret code...
                        //if (_status === 'OK') {
                            if (beforeSuccessCallback) {
                                beforeSuccessCallback(_data);
                            }

                            if (alterResponseCallback) {
                                _data = alterResponseCallback(_data);
                            }

                            if (cache) {
                                cache.put(cachename, _data);
                            }

                            if (onSuccessCallback) {
                                onSuccessCallback(_data);
                            }
                        //} else {
                        //    $rootScope.$broadcast(GLOBAL_EVENTS.badRequest, _code);
                        //}
                    });
            } else {
                if (onSuccessCallback) {
                    onSuccessCallback(cacheItem);
                }
            }
        }
    }
]);