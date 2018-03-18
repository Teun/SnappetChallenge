webpackJsonp(["main"],{

/***/ "../../../../../src/$$_gendir lazy recursive":
/***/ (function(module, exports, __webpack_require__) {

var map = {
	"app/modules/admin/admin.module": [
		"../../../../../src/app/modules/admin/admin.module.ts",
		"admin.module"
	]
};
function webpackAsyncContext(req) {
	var ids = map[req];
	if(!ids)
		return Promise.reject(new Error("Cannot find module '" + req + "'."));
	return __webpack_require__.e(ids[1]).then(function() {
		return __webpack_require__(ids[0]);
	});
};
webpackAsyncContext.keys = function webpackAsyncContextKeys() {
	return Object.keys(map);
};
webpackAsyncContext.id = "../../../../../src/$$_gendir lazy recursive";
module.exports = webpackAsyncContext;

/***/ }),

/***/ "../../../../../src/app/api.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Api; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_http__ = __webpack_require__("../../../http/@angular/http.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__auth_auth_service__ = __webpack_require__("../../../../../src/app/auth/auth.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_Observable__ = __webpack_require__("../../../../rxjs/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_Observable___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_3_rxjs_Observable__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_rxjs_Rx__ = __webpack_require__("../../../../rxjs/Rx.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_rxjs_Rx___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_4_rxjs_Rx__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};






var Api = /** @class */ (function () {
    function Api(authService) {
        this.authService = authService;
        this.baseUrl = '/api/';
        this.http = this.authService.http();
    }
    Api.prototype.auth = function (param) {
        if (param === void 0) { param = null; }
        return this.authService.auth(param)
            .map(this.checkForError)
            .catch(this.handleError)
            .map(this.getJson);
    };
    Api.prototype.get = function (path, body) {
        if (body === void 0) { body = null; }
        var fullPath = this.baseUrl + path + this.bodyToQueryString(body);
        return this.http.get(fullPath, this.getOptions())
            .map(this.checkForError)
            .catch(this.handleError)
            .map(this.getJson);
    };
    Api.prototype.post = function (path, param) {
        if (param === void 0) { param = null; }
        var body = JSON.stringify(param);
        var fullPath = this.baseUrl + path;
        return this.http.post(fullPath, body, this.getOptions())
            .map(this.checkForError)
            .catch(this.handleError)
            .map(this.getJson);
    };
    Api.prototype.delete = function (path, body) {
        if (body === void 0) { body = null; }
        var fullPath = this.baseUrl + path + this.bodyToQueryString(body);
        return this.http.delete(fullPath, this.getOptions())
            .map(this.checkForError)
            .catch(this.handleError)
            .map(this.getJson);
    };
    Api.prototype.put = function (path, param) {
        if (param === void 0) { param = null; }
        var body = JSON.stringify(param);
        var fullPath = this.baseUrl + path;
        return this.http.put(fullPath, body, this.getOptions())
            .map(this.checkForError)
            .catch(this.handleError)
            .map(this.getJson);
    };
    Api.prototype.postFile = function (path, param, files) {
        if (param === void 0) { param = null; }
        var fullPath = this.baseUrl + path;
        var formData = new FormData();
        if (files && files.length === 1) {
            formData.append('files', files[0], files[0].name);
        }
        else if (files) {
            // For multiple files
            for (var i = 0; i < files.length; i++) {
                formData.append("files[]", files[i], files[i].name);
            }
        }
        if (param !== '' && param !== undefined && param !== null) {
            for (var property in param) {
                if (param.hasOwnProperty(property)) {
                    if (typeof param[property] === 'number') {
                        formData.append(property, param[property].toString().replace(/[.,]/g, ','));
                    }
                    else {
                        formData.append(property, param[property]);
                    }
                }
            }
        }
        return this.http.post(fullPath, formData)
            .map(this.checkForError)
            .catch(this.handleError)
            .map(this.getJson);
    };
    Api.prototype.getOptions = function () {
        var options = new __WEBPACK_IMPORTED_MODULE_0__angular_http__["RequestOptions"]({ headers: new __WEBPACK_IMPORTED_MODULE_0__angular_http__["Headers"]({ 'Content-Type': 'application/json' }) });
        return this.authService.insertRealtimeToken(options);
        // return this.authService.addTokenHeaderIfAuth(options);
    };
    Api.prototype.bodyToQueryString = function (obj) {
        var parts = [];
        for (var key in obj) {
            if (obj.hasOwnProperty(key)) {
                parts.push(encodeURIComponent(key) + '=' + encodeURIComponent(obj[key]));
            }
        }
        return parts ? '?' + parts.join('&') : '';
    };
    Api.prototype.checkForError = function (response) {
        if (response.status >= 200 && response.status < 300) {
            return response;
        }
        var error = new Error(response.statusText);
        error['response'] = response;
        console.error(error);
        throw error;
    };
    Api.prototype.handleError = function (error) {
        console.log(error);
        if (error.status === 401) {
            // location.reload();
        }
        if (!__WEBPACK_IMPORTED_MODULE_1__environments_environment__["a" /* environment */].production) {
            alert(error);
            console.error(error);
        }
        return __WEBPACK_IMPORTED_MODULE_3_rxjs_Observable__["Observable"].throw(error || 'Server error');
    };
    Api.prototype.getJson = function (response) {
        try {
            return response.json();
        }
        catch (ex) {
            return response.text();
        }
    };
    Api = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_5__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_2__auth_auth_service__["a" /* AuthService */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2__auth_auth_service__["a" /* AuthService */]) === "function" && _a || Object])
    ], Api);
    return Api;
    var _a;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/api.service.js.map

/***/ }),

/***/ "../../../../../src/app/app.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_app_services_Socket_Realtime_service__ = __webpack_require__("../../../../../src/app/services/Socket/Realtime.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__ngrx_store__ = __webpack_require__("../../../../@ngrx/store/@ngrx/store.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__ = __webpack_require__("../../../../../src/app/store/actions/signs/sign.action.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var AppComponent = /** @class */ (function () {
    function AppComponent(socket, store) {
        this.socket = socket;
        this.store = store;
        store.select(function (s) { return s.sign.lastActionOnReducer; })
            .distinctUntilChanged()
            .subscribe(function (data) {
            if (data === __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__["s" /* LOG_IN_COMPLETE */]) {
                __WEBPACK_IMPORTED_MODULE_1_app_services_Socket_Realtime_service__["a" /* RealtimeService */].Open();
            }
        });
    }
    AppComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-root',
            template: "<base href=\"/\"><router-outlet></router-outlet>"
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1_app_services_Socket_Realtime_service__["a" /* RealtimeService */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1_app_services_Socket_Realtime_service__["a" /* RealtimeService */]) === "function" && _a || Object, typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_2__ngrx_store__["b" /* Store */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2__ngrx_store__["b" /* Store */]) === "function" && _b || Object])
    ], AppComponent);
    return AppComponent;
    var _a, _b;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/app.component.js.map

/***/ }),

/***/ "../../../../../src/app/app.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_platform_browser__ = __webpack_require__("../../../platform-browser/@angular/platform-browser.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_platform_browser_animations__ = __webpack_require__("../../../platform-browser/@angular/platform-browser/animations.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_forms__ = __webpack_require__("../../../forms/@angular/forms.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__app_routing__ = __webpack_require__("../../../../../src/app/app.routing.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__api_service__ = __webpack_require__("../../../../../src/app/api.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6_app_auth_auth_guard__ = __webpack_require__("../../../../../src/app/auth/auth.guard.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__auth_auth_module__ = __webpack_require__("../../../../../src/app/auth/auth.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__modules_sign_sign_module__ = __webpack_require__("../../../../../src/app/modules/sign/sign.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__angular_http__ = __webpack_require__("../../../http/@angular/http.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__app_component__ = __webpack_require__("../../../../../src/app/app.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__ngrx_store__ = __webpack_require__("../../../../@ngrx/store/@ngrx/store.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12_app_store_reducers__ = __webpack_require__("../../../../../src/app/store/reducers/index.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_13__ngrx_effects__ = __webpack_require__("../../../../@ngrx/effects/@ngrx/effects.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_14_app_services_Socket_Realtime_service__ = __webpack_require__("../../../../../src/app/services/Socket/Realtime.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
// this part above need to be removed when rxjs update to an fix solution
// ===============================================================================



 // TODO: Nicollas: investigate if it's realy needed
// Routing

// Injection custom services


// Modules that does not need to be on routing


// HTTP and RequestOptions are JTW deeps

// Root component

// Redux ---




var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_4__app_routing__["a" /* AppRouting */],
                __WEBPACK_IMPORTED_MODULE_9__angular_http__["HttpModule"],
                __WEBPACK_IMPORTED_MODULE_9__angular_http__["JsonpModule"],
                __WEBPACK_IMPORTED_MODULE_1__angular_platform_browser__["BrowserModule"],
                __WEBPACK_IMPORTED_MODULE_2__angular_platform_browser_animations__["a" /* BrowserAnimationsModule */],
                __WEBPACK_IMPORTED_MODULE_3__angular_forms__["FormsModule"],
                __WEBPACK_IMPORTED_MODULE_7__auth_auth_module__["a" /* AuthModule */],
                __WEBPACK_IMPORTED_MODULE_8__modules_sign_sign_module__["a" /* SignModule */],
                /**
                 * StoreModule.provideStore is imported once in the root module, accepting a reducer
                 * function or object map of reducer functions. If passed an object of
                 * reducers, combineReducers will be run creating your application
                 * meta-reducer. This returns all providers for an @ngrx/store
                 * based application.
                 */
                __WEBPACK_IMPORTED_MODULE_11__ngrx_store__["c" /* StoreModule */].forRoot(__WEBPACK_IMPORTED_MODULE_12_app_store_reducers__["a" /* reducers */]),
                __WEBPACK_IMPORTED_MODULE_13__ngrx_effects__["c" /* EffectsModule */].forRoot([])
            ],
            providers: [
                __WEBPACK_IMPORTED_MODULE_5__api_service__["a" /* Api */],
                __WEBPACK_IMPORTED_MODULE_6_app_auth_auth_guard__["a" /* AuthGuard */],
                __WEBPACK_IMPORTED_MODULE_14_app_services_Socket_Realtime_service__["a" /* RealtimeService */]
            ],
            declarations: [
                __WEBPACK_IMPORTED_MODULE_10__app_component__["a" /* AppComponent */],
            ],
            bootstrap: [__WEBPACK_IMPORTED_MODULE_10__app_component__["a" /* AppComponent */]]
        })
    ], AppModule);
    return AppModule;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/app.module.js.map

/***/ }),

/***/ "../../../../../src/app/app.routing.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppRouting; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_router__ = __webpack_require__("../../../router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_app_auth_auth_guard__ = __webpack_require__("../../../../../src/app/auth/auth.guard.ts");


var routes = [
    { path: '', loadChildren: 'app/modules/admin/admin.module#AdminModule', canActivate: [__WEBPACK_IMPORTED_MODULE_1_app_auth_auth_guard__["a" /* AuthGuard */]] },
    { path: 'Admin', loadChildren: 'app/modules/admin/admin.module#AdminModule', canActivate: [__WEBPACK_IMPORTED_MODULE_1_app_auth_auth_guard__["a" /* AuthGuard */]] },
];
var AppRouting = __WEBPACK_IMPORTED_MODULE_0__angular_router__["c" /* RouterModule */].forRoot(routes);
//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/app.routing.js.map

/***/ }),

/***/ "../../../../../src/app/auth/auth.guard.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AuthGuard; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_Rx__ = __webpack_require__("../../../../rxjs/Rx.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_Rx___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_rxjs_Rx__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__auth_service__ = __webpack_require__("../../../../../src/app/auth/auth.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_router__ = __webpack_require__("../../../router/@angular/router.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var AuthGuard = /** @class */ (function () {
    function AuthGuard(router, authService) {
        this.router = router;
        this.authService = authService;
    }
    AuthGuard.prototype.canActivate = function (route, state) {
        if (this.baseTest(route)) {
            return true;
        }
        // not logged in so redirect to login page with the return url
        this.router.navigate(['/login', { returnUrl: state.url }]);
        return false;
    };
    AuthGuard.prototype.canActivateChild = function (route, state) {
        if (this.baseTest(route)) {
            return true;
        }
        this.router.navigate([route.data['failUrl'] || '/']);
        return false;
    };
    AuthGuard.prototype.baseTest = function (route) {
        return this.authService.isAuthenticate() && this.HasClaim(route.data['claims'], true);
    };
    AuthGuard.prototype.canLoad = function (route) {
        var url = "/" + route.url;
        return this.authService.isAuthenticate();
    };
    AuthGuard.prototype.HasClaim = function (claims, passIfNoData) {
        if (passIfNoData === void 0) { passIfNoData = false; }
        if (!claims || claims.length === 0) {
            return passIfNoData;
        }
        var token = this.authService.getToken();
        if (!token) {
            return false;
        }
        var _loop_1 = function (claim) {
            var result = token.claims.find(function (row) { return row.claimType === claim; });
            if (result) {
                return { value: result.claimValue === 'Allow' };
            }
            if (token.roles_claims.some(function (row) { return row.claimType === claim && row.claimValue === 'Allow'; })) {
                return { value: true };
            }
        };
        for (var _i = 0, claims_1 = claims; _i < claims_1.length; _i++) {
            var claim = claims_1[_i];
            var state_1 = _loop_1(claim);
            if (typeof state_1 === "object")
                return state_1.value;
        }
        return false;
    };
    AuthGuard = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_3__angular_router__["b" /* Router */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_3__angular_router__["b" /* Router */]) === "function" && _a || Object, typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_2__auth_service__["a" /* AuthService */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2__auth_service__["a" /* AuthService */]) === "function" && _b || Object])
    ], AuthGuard);
    return AuthGuard;
    var _a, _b;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/auth.guard.js.map

/***/ }),

/***/ "../../../../../src/app/auth/auth.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export authHttpServiceFactory */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AuthModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("../../../http/@angular/http.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_angular2_jwt__ = __webpack_require__("../../../../angular2-jwt/angular2-jwt.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_angular2_jwt___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2_angular2_jwt__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__auth_service__ = __webpack_require__("../../../../../src/app/auth/auth.service.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




function authHttpServiceFactory(http, options) {
    return new __WEBPACK_IMPORTED_MODULE_2_angular2_jwt__["AuthHttp"](new __WEBPACK_IMPORTED_MODULE_2_angular2_jwt__["AuthConfig"]({
        noJwtError: true,
        tokenName: 'token',
        tokenGetter: (function () { var token = JSON.parse(localStorage.getItem('token')); return token ? token.access_token : ''; }),
    }), http, options);
}
var AuthModule = /** @class */ (function () {
    function AuthModule() {
    }
    AuthModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            providers: [
                __WEBPACK_IMPORTED_MODULE_3__auth_service__["a" /* AuthService */],
                {
                    provide: __WEBPACK_IMPORTED_MODULE_2_angular2_jwt__["AuthHttp"],
                    useFactory: authHttpServiceFactory,
                    deps: [__WEBPACK_IMPORTED_MODULE_1__angular_http__["Http"], __WEBPACK_IMPORTED_MODULE_1__angular_http__["RequestOptions"]]
                }
            ]
        })
    ], AuthModule);
    return AuthModule;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/auth.module.js.map

/***/ }),

/***/ "../../../../../src/app/auth/auth.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AuthService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_http__ = __webpack_require__("../../../http/@angular/http.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_angular2_jwt__ = __webpack_require__("../../../../angular2-jwt/angular2-jwt.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_angular2_jwt___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2_angular2_jwt__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_Rx__ = __webpack_require__("../../../../rxjs/Rx.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_Rx___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_3_rxjs_Rx__);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var AuthService = /** @class */ (function () {
    function AuthService(authHttp) {
        this.authHttp = authHttp;
        this.jwtUrl = '/token';
    }
    AuthService.prototype.http = function () {
        return this.authHttp;
    };
    AuthService.prototype.auth = function (param) {
        if (param === void 0) { param = null; }
        var options = new __WEBPACK_IMPORTED_MODULE_1__angular_http__["RequestOptions"]({ headers: new __WEBPACK_IMPORTED_MODULE_1__angular_http__["Headers"]({ 'Content-Type': 'application/x-www-form-urlencoded' }) });
        return this.authHttp.post(this.jwtUrl, param, options);
    };
    AuthService.prototype.getToken = function () {
        return JSON.parse(localStorage.getItem('token'));
    };
    AuthService.prototype.saveToken = function (token) {
        localStorage.setItem('token', JSON.stringify(token));
    };
    AuthService.prototype.removeToken = function () {
        localStorage.removeItem('token');
    };
    AuthService.prototype.isAuthenticate = function () {
        var jwtHelper = new __WEBPACK_IMPORTED_MODULE_2_angular2_jwt__["JwtHelper"]();
        var objToken = this.getToken();
        if (!objToken) {
            return false;
        }
        var token = objToken.access_token;
        try {
            if (token == null || jwtHelper.isTokenExpired(token)) {
                this.removeToken();
                return false;
            }
            jwtHelper.decodeToken(token);
        }
        catch (e) {
            this.removeToken();
            return false;
        }
        return true;
    };
    AuthService.prototype.insertRealtimeToken = function (options) {
        var token = localStorage.getItem('realtimeToken');
        if (token) {
            options.headers.append('Realtime-Token', token);
        }
        return options;
    };
    AuthService.prototype.saveRealtimeToken = function (token) {
        localStorage.setItem('realtimeToken', token);
    };
    AuthService.prototype.removeRealtimeTOken = function () {
        localStorage.removeItem('realtimeToken');
    };
    AuthService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_2_angular2_jwt__["AuthHttp"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2_angular2_jwt__["AuthHttp"]) === "function" && _a || Object])
    ], AuthService);
    return AuthService;
    var _a;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/auth.service.js.map

/***/ }),

/***/ "../../../../../src/app/modules/shared/layout/base.component.html":
/***/ (function(module, exports) {

module.exports = "<app-header-component [sidenav]=\"sidenav\" class=\"navbar-fixed-top\"></app-header-component>\r\n<md-sidenav-container class=\"app-container\">\r\n    <md-sidenav #sidenav mode=\"side\" class=\"app-sidenav main-nav\" opened=\"true\">\r\n        <app-sidenav-component [sidenav]=\"sidenav\"></app-sidenav-component>\r\n    </md-sidenav>\r\n    <div class=\"app-content\">\r\n        <router-outlet></router-outlet>\r\n    </div>\r\n    <link href=\"https://fonts.googleapis.com/icon?family=Material+Icons\" rel=\"stylesheet\" async>\r\n</md-sidenav-container>"

/***/ }),

/***/ "../../../../../src/app/modules/shared/layout/base.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".main-nav {\n  min-width: 200px; }\n\n.app-content {\n  margin: 10px;\n  width: calc(100% - 25px); }\n\n.app-container {\n  height: calc(100vh - 64px);\n  top: 64px;\n  overflow: hidden;\n  background: #e0e0e0; }\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/modules/shared/layout/base.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return BaseComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};

var BaseComponent = /** @class */ (function () {
    function BaseComponent() {
    }
    BaseComponent.prototype.ngOnInit = function () {
    };
    BaseComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-base-layout-component',
            styles: [__webpack_require__("../../../../../src/app/modules/shared/layout/base.component.scss")],
            template: __webpack_require__("../../../../../src/app/modules/shared/layout/base.component.html")
        })
    ], BaseComponent);
    return BaseComponent;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/base.component.js.map

/***/ }),

/***/ "../../../../../src/app/modules/shared/layout/configs.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export LayoutAppConfig */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return APPCONFIG; });
function makeAppConfig() {
    var AppConfig = {
        navbarOpened: true,
        isScreenFull: false
    };
    return AppConfig;
}
var LayoutAppConfig = /** @class */ (function () {
    function LayoutAppConfig() {
    }
    return LayoutAppConfig;
}());

var APPCONFIG = makeAppConfig();
//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/configs.js.map

/***/ }),

/***/ "../../../../../src/app/modules/shared/layout/header/header.component.html":
/***/ (function(module, exports) {

module.exports = "<md-toolbar color=\"primary\">\r\n  <button md-button (click)=\"sidenav.toggle()\">\r\n      <i class=\"material-icons app-toolbar-menu\">menu</i>\r\n  </button> Nicollas presentation\r\n</md-toolbar>"

/***/ }),

/***/ "../../../../../src/app/modules/shared/layout/header/header.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".mat-toolbar.mat-primary {\n  background: #132f88;\n  color: rgba(255, 255, 255, 0.87); }\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/modules/shared/layout/header/header.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppHeaderComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_material__ = __webpack_require__("../../../material/@angular/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_app_modules_shared_layout_configs__ = __webpack_require__("../../../../../src/app/modules/shared/layout/configs.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__ngrx_store__ = __webpack_require__("../../../../@ngrx/store/@ngrx/store.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var AppHeaderComponent = /** @class */ (function () {
    function AppHeaderComponent(store) {
        this.store = store;
        this.authInformation = store.select(function (s) { return s.sign.tokenResponse; });
    }
    AppHeaderComponent.prototype.ngOnInit = function () {
        this.layoutConfig = __WEBPACK_IMPORTED_MODULE_2_app_modules_shared_layout_configs__["a" /* APPCONFIG */];
    };
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])('sidenav'),
        __metadata("design:type", typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__angular_material__["e" /* MdSidenav */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_material__["e" /* MdSidenav */]) === "function" && _a || Object)
    ], AppHeaderComponent.prototype, "sidenav", void 0);
    AppHeaderComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-header-component',
            styles: [__webpack_require__("../../../../../src/app/modules/shared/layout/header/header.component.scss")],
            template: __webpack_require__("../../../../../src/app/modules/shared/layout/header/header.component.html")
        }),
        __metadata("design:paramtypes", [typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_3__ngrx_store__["b" /* Store */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_3__ngrx_store__["b" /* Store */]) === "function" && _b || Object])
    ], AppHeaderComponent);
    return AppHeaderComponent;
    var _a, _b;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/header.component.js.map

/***/ }),

/***/ "../../../../../src/app/modules/shared/layout/sidenav/sidenav.component.html":
/***/ (function(module, exports) {

module.exports = "<span>\r\n    <div class=\"user-panel\">\r\n        <div class=\"pull-left image\"><img src=\"assets/IMG-20171127-WA0005-2.jpg\" alt=\"User Image\" class=\"img-circle\"></div>\r\n        <div class=\"pull-left info\">\r\n            <p>Nicollas Braga</p>\r\n            <p class=\"designation\">Challenge</p>\r\n        </div>\r\n    </div>\r\n    <ul class=\"sidebar-menu\">\r\n        <li routerLinkActive=\"active\" [routerLinkActiveOptions]=\"{ exact: true }\">\r\n            <a href=\"#\" routerLink=\"/\"><i class=\"fa fa-television\"></i><span>Welcome</span></a>\r\n        </li>\r\n        <li routerLinkActive=\"active\" *ngIf=\"guard.HasClaim(['Order','Bill'])\">\r\n            <a href=\"#\" routerLink=\"/Admin/Charts\"><i class=\"fa fa-eye\"></i><span>Report</span></a>\r\n        </li>                 \r\n    </ul>\r\n\r\n    <div class=\"panel-botton\">\r\n        <button md-icon-button mdTooltip=\"Logout\" [mdTooltipPosition]=\"'above'\" (click)=\"logout()\">\r\n            <md-icon class=\"md-24\">lock</md-icon>\r\n          </button>\r\n          <button md-icon-button mdTooltip=\"Help/about\" [mdTooltipPosition]=\"'above'\">\r\n            <md-icon class=\"md-24\">help</md-icon>\r\n          </button>\r\n          <button md-icon-button mdTooltip=\"Full screen\" [mdTooltipPosition]=\"'above'\" (click)=\"setFullScreen();\">\r\n            <md-icon class=\"md-24\"*ngIf=\"!layoutConfig.isScreenFull\">zoom_out_map</md-icon>\r\n            <md-icon class=\"md-24\"*ngIf=\"layoutConfig.isScreenFull\">fullscreen_exit</md-icon>\r\n          </button>\r\n          <!-- <button md-icon-button color=\"warn\" [hidden]=\"true\">\r\n            <md-icon class=\"md-24\">fullscreen_exit</md-icon>\r\n          </button> -->\r\n          <button md-icon-button mdTooltip=\"Opinion and suggestions\" [mdTooltipPosition]=\"'above'\">\r\n            <md-icon class=\"md-24\">insert_emoticon</md-icon>\r\n          </button>\r\n    </div>\r\n</span>\r\n\r\n<!--<md-sidenav #sidenav mode=\"side\" class=\"app-sidenav\" opened=\"true\">-->\r\n<!--<div class=\"user-panel\">\r\n        <div class=\"pull-left image\"><img src=\"https://s3.amazonaws.com/uifaces/faces/twitter/jsa/48.jpg\" alt=\"User Image\" class=\"img-circle\"></div>\r\n        <div class=\"pull-left info\">\r\n            <p>Nicollas Braga {{layoutConfig.navbarOpened}}</p>\r\n            <p class=\"designation\">Administrador</p>\r\n        </div>\r\n    </div>-->\r\n\r\n\r\n<!-- Sidebar Menu-->\r\n<!--<ul class=\"sidebar-menu\">\r\n        <li routerLinkActive=\"active\" [routerLinkActiveOptions]=\"{ exact: true }\"><a href=\"#\" routerLink=\"/\"><i class=\"fa fa-television\"></i><span>Inicio</span></a></li>\r\n        <li routerLinkActive=\"active\"><a href=\"#\" routerLink=\"/mesa/criar\"><i class=\"fa fa-table\"></i><span>Criar Mesa</span></a></li>\r\n        <li routerLinkActive=\"active\"><a href=\"#\" routerLink=\"/produtos/novo\"><i class=\"fa fa-dashboard\"></i><span>Novo Produto</span></a></li>\r\n        <li routerLinkActive=\"active\" [routerLinkActiveOptions]=\"{ exact: true }\"><a href=\"#\" routerLink=\"/produtos\"><i class=\"fa fa-dashboard\"></i><span>Produtos</span></a></li>\r\n        <li routerLinkActive=\"active\"><a href=\"#\" routerLink=\"/colaboradores\"><i class=\"fa fa-dashboard\"></i><span>Colaboradores</span></a></li>\r\n        <li routerLinkActive=\"active\"><a href=\"#\" routerLink=\"/permissoes\"><i class=\"fa fa-dashboard\"></i><span>Grupos de Permissoes</span></a></li>-->\r\n\r\n<!--<li class=\"treeview\">\r\n                    <a href=\"#\"><i class=\"fa fa-laptop\"></i><span>UI Elements</span><i class=\"fa fa-angle-right\"></i></a>\r\n                    <ul class=\"treeview-menu\" style=\"display: none;\">\r\n                        <li routerLinkActive=\"active\"><a href=\"#\" routerLink=\"/produto/novo\"><i class=\"fa fa-dashboard\"></i><span>Novo Produto</span></a></li>\r\n                        <li routerLinkActive=\"active\"><a href=\"#\" routerLink=\"/produtos\"><i class=\"fa fa-dashboard\"></i><span>Produtos</span></a></li>\r\n                        <li routerLinkActive=\"active\"><a href=\"#\" routerLink=\"/produto/editar/2\"><i class=\"fa fa-dashboard\"></i><span>Categorias</span></a></li>\r\n                    </ul>\r\n                </li>-->\r\n<!--</ul>-->\r\n<!--</md-sidenav>-->"

/***/ }),

/***/ "../../../../../src/app/modules/shared/layout/sidenav/sidenav.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, ".sidebar-menu {\n  list-style: none;\n  margin: 0;\n  padding: 0;\n  white-space: nowrap;\n  overflow: hidden; }\n  .sidebar-menu:hover {\n    overflow: visible; }\n  .sidebar-menu .active {\n    background: #eee; }\n  .sidebar-menu > li {\n    position: relative;\n    margin: 0;\n    padding: 0;\n    border-bottom-color: #e8e6e6;\n    border-bottom-width: 1px;\n    border-bottom-style: solid; }\n    .sidebar-menu > li:hover {\n      background: #eee; }\n    .sidebar-menu > li:first-child {\n      border-top-width: 1px;\n      border-top-style: solid;\n      border-top-color: #e8e6e6; }\n    .sidebar-menu > li > a {\n      color: #797878;\n      font: message-box;\n      text-decoration: none;\n      padding: 12px 5px 12px 15px;\n      display: block;\n      position: relative;\n      border-left: 3px solid transparent; }\n      .sidebar-menu > li > a > .fa {\n        width: 25px; }\n      .sidebar-menu > li > a .label, .sidebar-menu > li > a .badge {\n        margin-top: 3px;\n        margin-right: 5px; }\n\n.user-panel {\n  background: #061440;\n  position: relative;\n  width: 100%;\n  padding: 20px 10px 20px 10px;\n  overflow: hidden;\n  white-space: nowrap;\n  color: whitesmoke; }\n  .user-panel:before {\n    content: \" \";\n    display: table; }\n  .user-panel:after {\n    content: \" \";\n    display: table;\n    clear: both; }\n  .user-panel > .image > img {\n    width: 100%;\n    max-width: 45px;\n    height: auto; }\n  .user-panel .info {\n    padding: 5px 5px 5px 15px;\n    line-height: 1;\n    position: absolute;\n    left: 65px; }\n    .user-panel .info > p {\n      margin-top: 2px;\n      margin-bottom: 5px;\n      font-size: 17px; }\n      .user-panel .info > p .designation {\n        font-size: 13px; }\n\n@media (min-height: 500px) {\n  .panel-botton {\n    position: absolute; } }\n\n.panel-botton {\n  top: calc(100% - 46px);\n  background: rgba(17, 37, 95, 0.4);\n  padding: 3px;\n  width: 100%;\n  text-align: center; }\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/modules/shared/layout/sidenav/sidenav.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppSidenavComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_app_modules_shared_layout_configs__ = __webpack_require__("../../../../../src/app/modules/shared/layout/configs.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_material__ = __webpack_require__("../../../material/@angular/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__ngrx_store__ = __webpack_require__("../../../../@ngrx/store/@ngrx/store.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_app_store_actions_signs_sign_action__ = __webpack_require__("../../../../../src/app/store/actions/signs/sign.action.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5_screenfull__ = __webpack_require__("../../../../screenfull/dist/screenfull.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5_screenfull___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_5_screenfull__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6_app_auth_auth_guard__ = __webpack_require__("../../../../../src/app/auth/auth.guard.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};







var AppSidenavComponent = /** @class */ (function () {
    function AppSidenavComponent(store, guard, rd) {
        this.store = store;
        this.guard = guard;
        this.rd = rd;
        this.authInformation = store.select(function (s) { return s.sign.tokenResponse; });
        this.layoutConfig = __WEBPACK_IMPORTED_MODULE_1_app_modules_shared_layout_configs__["a" /* APPCONFIG */];
    }
    AppSidenavComponent.prototype.ngOnInit = function () {
        if (__WEBPACK_IMPORTED_MODULE_5_screenfull__["enabled"]) {
            if (this.layoutConfig.isScreenFull) {
                __WEBPACK_IMPORTED_MODULE_5_screenfull__["request"]();
            }
            else {
                __WEBPACK_IMPORTED_MODULE_5_screenfull__["exit"]();
            }
        }
    };
    AppSidenavComponent.prototype.logout = function () {
        this.store.dispatch(new __WEBPACK_IMPORTED_MODULE_4_app_store_actions_signs_sign_action__["x" /* LogoutRequestAction */]());
    };
    AppSidenavComponent.prototype.setFullScreen = function () {
        if (__WEBPACK_IMPORTED_MODULE_5_screenfull__["enabled"]) {
            __WEBPACK_IMPORTED_MODULE_5_screenfull__["toggle"]();
            this.layoutConfig.isScreenFull = !this.layoutConfig.isScreenFull;
        }
    };
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Input"])('sidenav'),
        __metadata("design:type", typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_2__angular_material__["e" /* MdSidenav */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2__angular_material__["e" /* MdSidenav */]) === "function" && _a || Object)
    ], AppSidenavComponent.prototype, "sidenav", void 0);
    AppSidenavComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-sidenav-component',
            styles: [__webpack_require__("../../../../../src/app/modules/shared/layout/sidenav/sidenav.component.scss")],
            template: __webpack_require__("../../../../../src/app/modules/shared/layout/sidenav/sidenav.component.html")
        }),
        __metadata("design:paramtypes", [typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_3__ngrx_store__["b" /* Store */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_3__ngrx_store__["b" /* Store */]) === "function" && _b || Object, typeof (_c = typeof __WEBPACK_IMPORTED_MODULE_6_app_auth_auth_guard__["a" /* AuthGuard */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_6_app_auth_auth_guard__["a" /* AuthGuard */]) === "function" && _c || Object, typeof (_d = typeof __WEBPACK_IMPORTED_MODULE_0__angular_core__["Renderer2"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_0__angular_core__["Renderer2"]) === "function" && _d || Object])
    ], AppSidenavComponent);
    return AppSidenavComponent;
    var _a, _b, _c, _d;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/sidenav.component.js.map

/***/ }),

/***/ "../../../../../src/app/modules/shared/shared.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SharedModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/@angular/common.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_forms__ = __webpack_require__("../../../forms/@angular/forms.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_router__ = __webpack_require__("../../../router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_material__ = __webpack_require__("../../../material/@angular/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__layout_sidenav_sidenav_component__ = __webpack_require__("../../../../../src/app/modules/shared/layout/sidenav/sidenav.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__layout_header_header_component__ = __webpack_require__("../../../../../src/app/modules/shared/layout/header/header.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__layout_base_component__ = __webpack_require__("../../../../../src/app/modules/shared/layout/base.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8_app_utils_dialog_dialog_component__ = __webpack_require__("../../../../../src/app/utils/dialog/dialog.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};





// Sidenav

// Header

// Footer
// BASE COMPONENT


var SharedModule = /** @class */ (function () {
    function SharedModule() {
    }
    SharedModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"],
                __WEBPACK_IMPORTED_MODULE_3__angular_router__["c" /* RouterModule */],
                __WEBPACK_IMPORTED_MODULE_4__angular_material__["b" /* MaterialModule */],
                __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormsModule"],
            ],
            declarations: [
                __WEBPACK_IMPORTED_MODULE_5__layout_sidenav_sidenav_component__["a" /* AppSidenavComponent */],
                __WEBPACK_IMPORTED_MODULE_6__layout_header_header_component__["a" /* AppHeaderComponent */],
                __WEBPACK_IMPORTED_MODULE_7__layout_base_component__["a" /* BaseComponent */],
                __WEBPACK_IMPORTED_MODULE_8_app_utils_dialog_dialog_component__["a" /* DialogComponent */],
            ],
            entryComponents: [__WEBPACK_IMPORTED_MODULE_8_app_utils_dialog_dialog_component__["a" /* DialogComponent */]],
            exports: [
                __WEBPACK_IMPORTED_MODULE_5__layout_sidenav_sidenav_component__["a" /* AppSidenavComponent */],
                __WEBPACK_IMPORTED_MODULE_6__layout_header_header_component__["a" /* AppHeaderComponent */],
                __WEBPACK_IMPORTED_MODULE_7__layout_base_component__["a" /* BaseComponent */],
                __WEBPACK_IMPORTED_MODULE_8_app_utils_dialog_dialog_component__["a" /* DialogComponent */],
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"], __WEBPACK_IMPORTED_MODULE_2__angular_forms__["FormsModule"], __WEBPACK_IMPORTED_MODULE_4__angular_material__["b" /* MaterialModule */]
            ]
        })
    ], SharedModule);
    return SharedModule;
}());

/*
Copyright 2017 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/
//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/shared.module.js.map

/***/ }),

/***/ "../../../../../src/app/modules/sign/account-recovery/account-recovery.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"login-page\">\r\n  <div class=\"form\">\r\n    <form *ngIf=\"!result && !resetPassword\" class=\"login-form\" name=\"f\" (ngSubmit)=\"f.form.valid && recovery()\" #f=\"ngForm\" novalidate>\r\n      <div class=\"row\">\r\n        <div class=\"form-group col-md-12\">\r\n          <h1>Recovery account</h1>\r\n        </div>\r\n\r\n        <!--USERNAME-->\r\n        <div class=\"form-group col-md-12\" [ngClass]=\"{ 'has-error': f.submitted && !UserName.valid }\">\r\n          <md-input-container class=\"full\">\r\n            <input mdInput placeholder=\"UserName\" name=\"UserName\" [(ngModel)]=\"model.userName\" #UserName=\"ngModel\">\r\n          </md-input-container>\r\n          <div *ngIf=\"f.submitted && !UserName.valid && !Email.valid && selectedOption == 2\" class=\"help-block\">\r\n            UserName or Email is required\r\n          </div>\r\n          <p class=\"text-center\">Or</p>\r\n        </div>\r\n        <!--EMAIL-->\r\n        <div class=\"form-group col-md-12\" [ngClass]=\"{ 'has-error': f.submitted && !Email.valid }\">\r\n          <md-input-container class=\"full\">\r\n            <input type=\"email\" mdInput placeholder=\"Email\" name=\"Email\" [(ngModel)]=\"model.email\" #Email=\"ngModel\">\r\n          </md-input-container>\r\n          <div *ngIf=\"f.submitted && !UserName.valid && !Email.valid && selectedOption == 2\" class=\"help-block\">\r\n            UserName or Email is required\r\n          </div>\r\n        </div>\r\n      </div>\r\n\r\n      <div class=\"form-group\">\r\n        <div *ngIf=\"(IsBusy | async); else elsetemplate\">\r\n          <md-spinner class=\"text-center\" style=\"width: inherit; height: 42px;\"></md-spinner>\r\n        </div>\r\n        <ng-template #elsetemplate>\r\n          <button [disabled]=\"(IsBusy | async)\" class=\"btn btn-primary\">Recovery</button>\r\n        </ng-template>\r\n        <a [routerLink]=\"['/login']\" class=\"btn btn-link\">Go back</a>\r\n      </div>\r\n    </form>\r\n\r\n    <div *ngIf=\"!result && resetPassword\" class=\"login-form\">\r\n      <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n          <h4>Reset your password<br><br></h4>\r\n        </div>\r\n        <hr>\r\n\r\n        <!--password-->\r\n        <div class=\"form-group col-md-6\" [ngClass]=\"{ 'has-error': password_confirmation != password }\">\r\n          <md-input-container class=\"full\">\r\n            <input mdInput type=\"password\" placeholder=\"Password\" name=\"Password2\" [(ngModel)]=\"password\">\r\n          </md-input-container>\r\n          <div *ngIf=\"password_confirmation != password\" class=\"help-block\">Password doesn't match</div>\r\n        </div>\r\n        <div class=\"form-group col-md-6\" [ngClass]=\"{ 'has-error':  password_confirmation != password }\">\r\n          <md-input-container class=\"full\">\r\n            <input mdInput placeholder=\"Confirm Password\" type=\"password\" [(ngModel)]=\"password_confirmation\">\r\n          </md-input-container>\r\n          <div *ngIf=\"password_confirmation != password\" class=\"help-block\">Password doesn't match</div>\r\n        </div>\r\n        <div class=\"col-md-12\">\r\n          <p class=\"text-left\">{{erro | async}}<br></p>\r\n        </div>\r\n\r\n        <!--password-->\r\n\r\n        <div class=\"form-group text-center col-md-12\">\r\n          <div *ngIf=\"(IsBusy | async); else elsetemplate\">\r\n            <md-spinner class=\"text-center\" style=\"width: inherit; height: 42px;\"></md-spinner>\r\n          </div>\r\n          <ng-template #elsetemplate>\r\n            <button [disabled]=\"(IsBusy | async)\" class=\"btn btn-primary\" (click)=\"sendToken()\">Change password</button>\r\n          </ng-template>\r\n          <a [routerLink]=\"['/login']\" class=\"btn btn-link\">Go back</a>\r\n        </div>\r\n      </div>\r\n    </div>\r\n\r\n    <div class=\"row\" *ngIf=\"result\">\r\n      <div class=\"col-md-12\">\r\n        <h2 class=\"text-center\">Check your email to change the account</h2><br>\r\n        <a [routerLink]=\"[ '/login']\" class=\"pull-left\">Go back</a>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/modules/sign/account-recovery/account-recovery.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports
exports.push([module.i, "@import url(https://fonts.googleapis.com/css?family=Roboto:300);", ""]);

// module
exports.push([module.i, ".login-page {\n  width: 100%;\n  padding: 8% 0 0;\n  margin: auto; }\n\n.full {\n  width: 100%;\n  margin: 0 0 15px; }\n\n.height-36px {\n  height: 36px; }\n\n.form {\n  position: relative;\n  z-index: 1;\n  background: #FFFFFF;\n  width: 70%;\n  margin: 0 auto 100px;\n  padding: 45px;\n  text-align: center;\n  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24); }\n\n.form input {\n  font-family: \"Roboto\", sans-serif;\n  outline: 0;\n  width: 100%;\n  border: 0;\n  box-sizing: border-box;\n  font-size: 14px; }\n\n.form button {\n  font-family: \"Roboto\", sans-serif;\n  text-transform: uppercase;\n  outline: 0;\n  width: 100%;\n  border: 0;\n  padding: 15px;\n  color: #FFFFFF;\n  font-size: 14px;\n  transition: all 0.3 ease;\n  cursor: pointer; }\n\n.form .message {\n  margin: 15px 0 0;\n  color: #b3b3b3;\n  font-size: 12px; }\n\n.form .message a {\n  text-decoration: none; }\n\n.container {\n  position: relative;\n  z-index: 1;\n  max-width: 300px;\n  margin: 0 auto; }\n\n.container:before, .container:after {\n  content: \"\";\n  display: block;\n  clear: both; }\n\n.container .info {\n  margin: 50px auto;\n  text-align: center; }\n\n.container .info h1 {\n  margin: 0 0 15px;\n  padding: 0;\n  font-size: 36px;\n  font-weight: 300;\n  color: #1a1a1a; }\n\n.container .info span {\n  color: #4d4d4d;\n  font-size: 12px; }\n\n.container .info span a {\n  color: #000000;\n  text-decoration: none; }\n\n.container .info span .fa {\n  color: #EF3B3A; }\n\nbody {\n  background: #76b852;\n  /* fallback for old browsers */\n  background: linear-gradient(to left, #76b852, #8DC26F);\n  font-family: \"Roboto\", sans-serif;\n  -webkit-font-smoothing: antialiased;\n  -moz-osx-font-smoothing: grayscale; }\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/modules/sign/account-recovery/account-recovery.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AccountRecoveryComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__ngrx_store__ = __webpack_require__("../../../../@ngrx/store/@ngrx/store.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__ = __webpack_require__("../../../../../src/app/store/actions/signs/sign.action.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var AccountRecoveryComponent = /** @class */ (function () {
    function AccountRecoveryComponent(store, router, route) {
        this.store = store;
        this.router = router;
        this.route = route;
        this.model = {};
        this.resetPassword = false;
        this.result = false;
    }
    AccountRecoveryComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.IsBusy = this.store.select(function (r) { return r.sign.busy; });
        this.erro = this.store.select(function (r) { return r.sign.error; });
        this.route.params.subscribe(function (params) {
            _this.userId = params['userId'];
            _this.token = params['token'];
            if (_this.token && _this.userId) {
                _this.resetPassword = true;
            }
        });
    };
    AccountRecoveryComponent.prototype.sendToken = function () {
        var _this = this;
        if (this.password !== this.password_confirmation) {
            return;
        }
        this.store.select(function (r) { return r.sign.tokenActived; }).distinctUntilChanged().take(1).subscribe(function (result) {
            if (result) {
                _this.router.navigate(['/login']);
            }
        });
        this.store.dispatch(new __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__["G" /* TokenAction */]({ id: this.userId, token: this.token, password: this.password }));
    };
    AccountRecoveryComponent.prototype.recovery = function () {
        var _this = this;
        this.IsBusy.distinctUntilChanged().skip(2).take(1).subscribe(function (_) { return _this.result = true; });
        this.store.dispatch(new __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__["c" /* AccountRecoveryAction */](Object.assign({}, this.model)));
    };
    AccountRecoveryComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-account-recovery',
            template: __webpack_require__("../../../../../src/app/modules/sign/account-recovery/account-recovery.component.html"),
            styles: [__webpack_require__("../../../../../src/app/modules/sign/account-recovery/account-recovery.component.scss")]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_2__ngrx_store__["b" /* Store */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2__ngrx_store__["b" /* Store */]) === "function" && _a || Object, typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* Router */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* Router */]) === "function" && _b || Object, typeof (_c = typeof __WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* ActivatedRoute */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* ActivatedRoute */]) === "function" && _c || Object])
    ], AccountRecoveryComponent);
    return AccountRecoveryComponent;
    var _a, _b, _c;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/account-recovery.component.js.map

/***/ }),

/***/ "../../../../../src/app/modules/sign/confirmation/confirmation.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"login-page\">\r\n    <div class=\"form\">\r\n        <h1>Your account is now confirmed.</h1><br>\r\n        <h4><a [routerLink]=\"[ '/login']\">Click here to sing in</a></h4>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/modules/sign/confirmation/confirmation.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports
exports.push([module.i, "@import url(https://fonts.googleapis.com/css?family=Roboto:300);", ""]);

// module
exports.push([module.i, ".login-page {\n  width: 100%;\n  padding: 15% 0 0;\n  margin: auto; }\n\n.full {\n  width: 100%;\n  margin: 0 0 15px; }\n\n.form {\n  position: relative;\n  z-index: 1;\n  background: #FFFFFF;\n  width: 70%;\n  margin: 0 auto 100px;\n  padding: 45px;\n  text-align: center;\n  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24); }\n\n.form input {\n  font-family: \"Roboto\", sans-serif;\n  outline: 0;\n  width: 100%;\n  border: 0;\n  box-sizing: border-box;\n  font-size: 14px; }\n\n.form button {\n  font-family: \"Roboto\", sans-serif;\n  text-transform: uppercase;\n  outline: 0;\n  width: 100%;\n  border: 0;\n  padding: 15px;\n  color: #FFFFFF;\n  font-size: 14px;\n  transition: all 0.3 ease;\n  cursor: pointer; }\n\n.form .message {\n  margin: 15px 0 0;\n  color: #b3b3b3;\n  font-size: 12px; }\n\n.form .message a {\n  text-decoration: none; }\n\n.container {\n  position: relative;\n  z-index: 1;\n  max-width: 300px;\n  margin: 0 auto; }\n\n.container:before, .container:after {\n  content: \"\";\n  display: block;\n  clear: both; }\n\n.container .info {\n  margin: 50px auto;\n  text-align: center; }\n\n.container .info h1 {\n  margin: 0 0 15px;\n  padding: 0;\n  font-size: 36px;\n  font-weight: 300;\n  color: #1a1a1a; }\n\n.container .info span {\n  color: #4d4d4d;\n  font-size: 12px; }\n\n.container .info span a {\n  color: #000000;\n  text-decoration: none; }\n\n.container .info span .fa {\n  color: #EF3B3A; }\n\nbody {\n  background: #76b852;\n  /* fallback for old browsers */\n  background: linear-gradient(to left, #76b852, #8DC26F);\n  font-family: \"Roboto\", sans-serif;\n  -webkit-font-smoothing: antialiased;\n  -moz-osx-font-smoothing: grayscale; }\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/modules/sign/confirmation/confirmation.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ConfirmationComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var ConfirmationComponent = /** @class */ (function () {
    function ConfirmationComponent() {
    }
    ConfirmationComponent.prototype.ngOnInit = function () {
    };
    ConfirmationComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-confirmation',
            template: __webpack_require__("../../../../../src/app/modules/sign/confirmation/confirmation.component.html"),
            styles: [__webpack_require__("../../../../../src/app/modules/sign/confirmation/confirmation.component.scss")]
        }),
        __metadata("design:paramtypes", [])
    ], ConfirmationComponent);
    return ConfirmationComponent;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/confirmation.component.js.map

/***/ }),

/***/ "../../../../../src/app/modules/sign/new-password/new-password.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"login-page\">\r\n  <div class=\"form\">\r\n    <form class=\"login-form\" name=\"form\" (ngSubmit)=\"f.form.valid && submit()\" #f=\"ngForm\" novalidate>\r\n      <div class=\"form-group\" [ngClass]=\"{ 'has-error': f.submitted && !password.valid }\">\r\n        <md-input-container class=\"full\">\r\n          <input mdInput type=\"Password\" placeholder=\"Password\" name=\"password\" [(ngModel)]=\"model.password\" #password=\"ngModel\" required>\r\n        </md-input-container>\r\n        <div *ngIf=\"f.submitted && !password.valid\" class=\"help-block\">Password is required</div>\r\n      </div>\r\n      <div class=\"form-group\" [ngClass]=\"{ 'has-error': f.submitted && !confirm.valid }\">\r\n        <md-input-container class=\"full\">\r\n          <input mdInput type=\"Password\" placeholder=\"Confirm Password\" name=\"confirm\" [(ngModel)]=\"model.confirm\" #confirm=\"ngModel\" required>\r\n        </md-input-container>\r\n        <div *ngIf=\"f.submitted && !password.valid\" class=\"help-block\">Confirmation is required</div>\r\n      </div>\r\n      <p class=\"text-alert\" *ngIf=\"model.password !== model.confirm && model.confirm.length > 0\" >Password doesnt match</p>\r\n      <p class=\"text-alert\">{{erro | async}}</p>\r\n      <div class=\"form-group\">\r\n        <button [disabled]=\"(IsBusy | async) || model.password !== model.confirm\" class=\"btn btn-primary\">\r\n          <ng-container *ngIf=\"!(IsBusy | async)\">\r\n            Change and sign in \r\n          </ng-container>\r\n          <ng-container *ngIf=\"(IsBusy | async)\">\r\n            <md-spinner class=\"text-center spinner-white\" style=\"width: inherit; height: 30px;\"></md-spinner>\r\n          </ng-container>\r\n        </button>\r\n      </div>\r\n    </form>\r\n  </div>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/modules/sign/new-password/new-password.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports
exports.push([module.i, "@import url(https://fonts.googleapis.com/css?family=Roboto:300);", ""]);

// module
exports.push([module.i, ".login-page {\n  width: 100%;\n  padding: 8% 0 0;\n  margin: auto; }\n\n.full {\n  width: 100%;\n  margin: 0 0 15px; }\n\n.form {\n  position: relative;\n  z-index: 1;\n  background: #FFFFFF;\n  width: 35%;\n  margin: 0 auto 100px;\n  padding: 45px;\n  text-align: center;\n  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24); }\n\n.form input {\n  font-family: \"Roboto\", sans-serif;\n  outline: 0;\n  width: 100%;\n  border: 0;\n  box-sizing: border-box;\n  font-size: 14px; }\n\n.form button {\n  font-family: \"Roboto\", sans-serif;\n  text-transform: uppercase;\n  outline: 0;\n  width: 100%;\n  border: 0;\n  padding: 15px;\n  color: #FFFFFF;\n  font-size: 14px;\n  transition: all 0.3 ease;\n  cursor: pointer; }\n\n.form .message {\n  margin: 15px 0 0;\n  color: #b3b3b3;\n  font-size: 12px; }\n\n.form .message a {\n  text-decoration: none; }\n\n.container {\n  position: relative;\n  z-index: 1;\n  max-width: 300px;\n  margin: 0 auto; }\n\n.container:before, .container:after {\n  content: \"\";\n  display: block;\n  clear: both; }\n\n.container .info {\n  margin: 50px auto;\n  text-align: center; }\n\n.container .info h1 {\n  margin: 0 0 15px;\n  padding: 0;\n  font-size: 36px;\n  font-weight: 300;\n  color: #1a1a1a; }\n\n.container .info span {\n  color: #4d4d4d;\n  font-size: 12px; }\n\n.container .info span a {\n  color: #000000;\n  text-decoration: none; }\n\n.container .info span .fa {\n  color: #EF3B3A; }\n\nbody {\n  background: #76b852;\n  /* fallback for old browsers */\n  background: linear-gradient(to left, #76b852, #8DC26F);\n  font-family: \"Roboto\", sans-serif;\n  -webkit-font-smoothing: antialiased;\n  -moz-osx-font-smoothing: grayscale; }\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/modules/sign/new-password/new-password.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return NewPasswordComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__ngrx_store__ = __webpack_require__("../../../../@ngrx/store/@ngrx/store.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__ = __webpack_require__("../../../../../src/app/store/actions/signs/sign.action.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var NewPasswordComponent = /** @class */ (function () {
    function NewPasswordComponent(store, router, route) {
        this.store = store;
        this.router = router;
        this.route = route;
        this.model = { password: '', confirm: '' };
        this.subscriptions = [];
    }
    NewPasswordComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.IsBusy = this.store.select(function (r) { return r.sign.busy; });
        this.erro = this.store.select(function (r) { return r.sign.error; });
        this.route.params.subscribe(function (params) {
            _this.userName = params['username'];
            _this.userId = params['userId'];
        });
        this.subscriptions.push(this.store.select(function (_) { return _.sign.lastActionOnReducer; }).distinctUntilChanged().subscribe(function (data) {
            switch (data) {
                case __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__["f" /* DEFAULT_PASSWORD_COMPLETE */]:
                    _this.store.dispatch(new __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__["v" /* LogInRequestAction */]({ userName: _this.userName, password: _this.model.password }));
                    break;
                case __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__["s" /* LOG_IN_COMPLETE */]: {
                    _this.router.navigate(['']);
                }
            }
        }));
    };
    NewPasswordComponent.prototype.ngOnDestroy = function () {
        this.subscriptions.forEach(function (sub) { return sub.unsubscribe(); });
    };
    NewPasswordComponent.prototype.submit = function () {
        this.store.dispatch(new __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__["i" /* DefaultPasswordAction */]({ id: this.userId, password: this.model.password }));
    };
    NewPasswordComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-new-password',
            template: __webpack_require__("../../../../../src/app/modules/sign/new-password/new-password.component.html"),
            styles: [__webpack_require__("../../../../../src/app/modules/sign/new-password/new-password.component.scss")]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_2__ngrx_store__["b" /* Store */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2__ngrx_store__["b" /* Store */]) === "function" && _a || Object, typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* Router */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* Router */]) === "function" && _b || Object, typeof (_c = typeof __WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* ActivatedRoute */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* ActivatedRoute */]) === "function" && _c || Object])
    ], NewPasswordComponent);
    return NewPasswordComponent;
    var _a, _b, _c;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/new-password.component.js.map

/***/ }),

/***/ "../../../../../src/app/modules/sign/resend-email/resend-email.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"login-page\">\r\n  <div class=\"form\">\r\n    <div *ngIf=\"!(IsBusy | async); else elseTemplate\">\r\n      <div *ngIf=\"!(sent| async); else elseTemplate2\">\r\n        <h1>Please confirm your email first.</h1><br>\r\n        <h4>Didn't received an confirmation email? <a href=\"javascript:void\" (click)=\"resendEmail();\">Click here to send again</a></h4>\r\n      </div>\r\n      <ng-template #elseTemplate2>\r\n         <h1>We sent an new email for you!</h1><br>\r\n        <h4><a [routerLink]=\"[ '/login']\">Click here to go back</a></h4>\r\n      </ng-template>\r\n    </div>\r\n  </div>\r\n  <ng-template #elseTemplate>\r\n    <md-spinner class=\"text-center\" style=\"width: 100%; height: 100px;\"></md-spinner>\r\n  </ng-template>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/modules/sign/resend-email/resend-email.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports
exports.push([module.i, "@import url(https://fonts.googleapis.com/css?family=Roboto:300);", ""]);

// module
exports.push([module.i, ".login-page {\n  width: 100%;\n  padding: 15% 0 0;\n  margin: auto; }\n\n.full {\n  width: 100%;\n  margin: 0 0 15px; }\n\n.form {\n  position: relative;\n  z-index: 1;\n  background: #FFFFFF;\n  width: 70%;\n  margin: 0 auto 100px;\n  padding: 45px;\n  text-align: center;\n  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24); }\n\n.form input {\n  font-family: \"Roboto\", sans-serif;\n  outline: 0;\n  width: 100%;\n  border: 0;\n  box-sizing: border-box;\n  font-size: 14px; }\n\n.form button {\n  font-family: \"Roboto\", sans-serif;\n  text-transform: uppercase;\n  outline: 0;\n  width: 100%;\n  border: 0;\n  padding: 15px;\n  color: #FFFFFF;\n  font-size: 14px;\n  transition: all 0.3 ease;\n  cursor: pointer; }\n\n.form .message {\n  margin: 15px 0 0;\n  color: #b3b3b3;\n  font-size: 12px; }\n\n.form .message a {\n  text-decoration: none; }\n\n.container {\n  position: relative;\n  z-index: 1;\n  max-width: 300px;\n  margin: 0 auto; }\n\n.container:before, .container:after {\n  content: \"\";\n  display: block;\n  clear: both; }\n\n.container .info {\n  margin: 50px auto;\n  text-align: center; }\n\n.container .info h1 {\n  margin: 0 0 15px;\n  padding: 0;\n  font-size: 36px;\n  font-weight: 300;\n  color: #1a1a1a; }\n\n.container .info span {\n  color: #4d4d4d;\n  font-size: 12px; }\n\n.container .info span a {\n  color: #000000;\n  text-decoration: none; }\n\n.container .info span .fa {\n  color: #EF3B3A; }\n\nbody {\n  background: #76b852;\n  /* fallback for old browsers */\n  background: linear-gradient(to left, #76b852, #8DC26F);\n  font-family: \"Roboto\", sans-serif;\n  -webkit-font-smoothing: antialiased;\n  -moz-osx-font-smoothing: grayscale; }\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/modules/sign/resend-email/resend-email.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ResendEmailComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__ngrx_store__ = __webpack_require__("../../../../@ngrx/store/@ngrx/store.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__ = __webpack_require__("../../../../../src/app/store/actions/signs/sign.action.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var ResendEmailComponent = /** @class */ (function () {
    function ResendEmailComponent(store, route) {
        this.store = store;
        this.route = route;
        this.IsBusy = store.select(function (r) { return r.sign.busy; });
        this.sent = store.select(function (r) { return r.sign.emailResent; });
    }
    ResendEmailComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.subscribe(function (params) {
            _this.username = params['username'];
        });
    };
    ResendEmailComponent.prototype.resendEmail = function () {
        this.store.dispatch(new __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__["y" /* ResendEmailAction */](this.username));
    };
    ResendEmailComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-resend-email',
            template: __webpack_require__("../../../../../src/app/modules/sign/resend-email/resend-email.component.html"),
            styles: [__webpack_require__("../../../../../src/app/modules/sign/resend-email/resend-email.component.scss")]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_2__ngrx_store__["b" /* Store */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2__ngrx_store__["b" /* Store */]) === "function" && _a || Object, typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* ActivatedRoute */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* ActivatedRoute */]) === "function" && _b || Object])
    ], ResendEmailComponent);
    return ResendEmailComponent;
    var _a, _b;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/resend-email.component.js.map

/***/ }),

/***/ "../../../../../src/app/modules/sign/sign.module.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SignModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_common__ = __webpack_require__("../../../common/@angular/common.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_angular2_text_mask__ = __webpack_require__("../../../../angular2-text-mask/dist/angular2TextMask.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_angular2_text_mask___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2_angular2_text_mask__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__angular_material__ = __webpack_require__("../../../material/@angular/material.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__angular_platform_browser_animations__ = __webpack_require__("../../../platform-browser/@angular/platform-browser/animations.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__shared_shared_module__ = __webpack_require__("../../../../../src/app/modules/shared/shared.module.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__sign_routing__ = __webpack_require__("../../../../../src/app/modules/sign/sign.routing.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__signin_signin_component__ = __webpack_require__("../../../../../src/app/modules/sign/signin/signin.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8__signup_signup_component__ = __webpack_require__("../../../../../src/app/modules/sign/signup/signup.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9__confirmation_confirmation_component__ = __webpack_require__("../../../../../src/app/modules/sign/confirmation/confirmation.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10__resend_email_resend_email_component__ = __webpack_require__("../../../../../src/app/modules/sign/resend-email/resend-email.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__account_recovery_account_recovery_component__ = __webpack_require__("../../../../../src/app/modules/sign/account-recovery/account-recovery.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12__ngrx_effects__ = __webpack_require__("../../../../@ngrx/effects/@ngrx/effects.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_13_app_store_effects_signs_sign_effect__ = __webpack_require__("../../../../../src/app/store/effects/signs/sign.effect.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_14_app_services_signs_sign_service__ = __webpack_require__("../../../../../src/app/services/signs/sign.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_15__new_password_new_password_component__ = __webpack_require__("../../../../../src/app/modules/sign/new-password/new-password.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
















var SignModule = /** @class */ (function () {
    function SignModule() {
    }
    SignModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [
                __WEBPACK_IMPORTED_MODULE_1__angular_common__["CommonModule"],
                __WEBPACK_IMPORTED_MODULE_5__shared_shared_module__["a" /* SharedModule */],
                __WEBPACK_IMPORTED_MODULE_4__angular_platform_browser_animations__["a" /* BrowserAnimationsModule */],
                __WEBPACK_IMPORTED_MODULE_6__sign_routing__["a" /* SignRoutingModule */],
                __WEBPACK_IMPORTED_MODULE_2_angular2_text_mask__["TextMaskModule"],
                __WEBPACK_IMPORTED_MODULE_3__angular_material__["b" /* MaterialModule */],
                __WEBPACK_IMPORTED_MODULE_12__ngrx_effects__["c" /* EffectsModule */].forFeature([__WEBPACK_IMPORTED_MODULE_13_app_store_effects_signs_sign_effect__["a" /* SignEffects */]]),
            ],
            providers: [
                __WEBPACK_IMPORTED_MODULE_14_app_services_signs_sign_service__["a" /* SignService */]
            ],
            declarations: [
                __WEBPACK_IMPORTED_MODULE_7__signin_signin_component__["a" /* SigninComponent */],
                __WEBPACK_IMPORTED_MODULE_8__signup_signup_component__["a" /* SignupComponent */],
                __WEBPACK_IMPORTED_MODULE_9__confirmation_confirmation_component__["a" /* ConfirmationComponent */],
                __WEBPACK_IMPORTED_MODULE_10__resend_email_resend_email_component__["a" /* ResendEmailComponent */],
                __WEBPACK_IMPORTED_MODULE_11__account_recovery_account_recovery_component__["a" /* AccountRecoveryComponent */],
                __WEBPACK_IMPORTED_MODULE_15__new_password_new_password_component__["a" /* NewPasswordComponent */]
            ]
        })
    ], SignModule);
    return SignModule;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/sign.module.js.map

/***/ }),

/***/ "../../../../../src/app/modules/sign/sign.routing.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SignRoutingModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__signin_signin_component__ = __webpack_require__("../../../../../src/app/modules/sign/signin/signin.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__signup_signup_component__ = __webpack_require__("../../../../../src/app/modules/sign/signup/signup.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__confirmation_confirmation_component__ = __webpack_require__("../../../../../src/app/modules/sign/confirmation/confirmation.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5__resend_email_resend_email_component__ = __webpack_require__("../../../../../src/app/modules/sign/resend-email/resend-email.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__account_recovery_account_recovery_component__ = __webpack_require__("../../../../../src/app/modules/sign/account-recovery/account-recovery.component.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7_app_modules_sign_new_password_new_password_component__ = __webpack_require__("../../../../../src/app/modules/sign/new-password/new-password.component.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};








var routes = [
    // { path: '', redirectTo: 'Login', pathMatch: 'full'},
    { path: 'login', component: __WEBPACK_IMPORTED_MODULE_2__signin_signin_component__["a" /* SigninComponent */] },
    { path: 'signup', component: __WEBPACK_IMPORTED_MODULE_3__signup_signup_component__["a" /* SignupComponent */], data: { 'claims': ['NOT_ALLOW'] } },
    { path: 'AccountConfirmed', component: __WEBPACK_IMPORTED_MODULE_4__confirmation_confirmation_component__["a" /* ConfirmationComponent */], data: { 'claims': ['NOT_ALLOW'] } },
    { path: 'AccountRecovery', component: __WEBPACK_IMPORTED_MODULE_6__account_recovery_account_recovery_component__["a" /* AccountRecoveryComponent */], data: { 'claims': ['NOT_ALLOW'] } },
    { path: 'AccountRecovery/:token/:userId', component: __WEBPACK_IMPORTED_MODULE_6__account_recovery_account_recovery_component__["a" /* AccountRecoveryComponent */], data: { 'claims': ['NOT_ALLOW'] } },
    { path: 'NewPassword/:username/:userId', component: __WEBPACK_IMPORTED_MODULE_7_app_modules_sign_new_password_new_password_component__["a" /* NewPasswordComponent */], data: { 'claims': ['NOT_ALLOW'] } },
    { path: 'ResendConfirmation/:username', component: __WEBPACK_IMPORTED_MODULE_5__resend_email_resend_email_component__["a" /* ResendEmailComponent */], data: { 'claims': ['NOT_ALLOW'] } },
];
var SignRoutingModule = /** @class */ (function () {
    function SignRoutingModule() {
    }
    SignRoutingModule = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["NgModule"])({
            imports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["c" /* RouterModule */].forChild(routes)],
            exports: [__WEBPACK_IMPORTED_MODULE_1__angular_router__["c" /* RouterModule */]]
        })
    ], SignRoutingModule);
    return SignRoutingModule;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/sign.routing.js.map

/***/ }),

/***/ "../../../../../src/app/modules/sign/signin/signin.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"login-page\">\r\n    <div class=\"form\">\r\n        <form class=\"login-form\" name=\"form\" (ngSubmit)=\"f.form.valid && signIn()\" #f=\"ngForm\" novalidate>\r\n            <!-- <a [routerLink]=\"['/AccountRecovery']\" class=\"btn btn-link pull-right\">Lost account?</a> -->\r\n            <div class=\"form-group\" [ngClass]=\"{ 'has-error': f.submitted && !userName.valid }\">\r\n                <md-input-container class=\"full\">\r\n                    <input mdInput placeholder=\"Usuário\" name=\"userName\" [(ngModel)]=\"model.userName\" #userName=\"ngModel\" required>\r\n                </md-input-container>\r\n                <div *ngIf=\"f.submitted && !userName.valid\" class=\"help-block\">Usuário é obrigatório</div>\r\n            </div>\r\n            <div class=\"form-group\" [ngClass]=\"{ 'has-error': f.submitted && !password.valid }\">\r\n                <md-input-container class=\"full\">\r\n                    <input mdInput type=\"password\" placeholder=\"Senha\" name=\"password\" [(ngModel)]=\"model.password\" #password=\"ngModel\" required>\r\n                </md-input-container>\r\n                <div *ngIf=\"f.submitted && !password.valid\" class=\"help-block\">Senha é obrigatório</div>\r\n            </div>\r\n            <p class=\"text-alert\">{{statusError | async}}</p>\r\n            <div class=\"form-group\">\r\n                <!--<button (click)=\"throwBackendException()\" class=\" btn btn-danger\"> Throw backend exception </button>-->\r\n                <button [disabled]=\"(loading| async)\" class=\"btn btn-primary\">\r\n                    <ng-container *ngIf=\"!(loading | async)\">\r\n                        Entrar\r\n                    </ng-container>\r\n                    <ng-container *ngIf=\"(loading | async)\">\r\n                        <md-spinner class=\"text-center spinner-white\" style=\"width: inherit; height: 30px;\"></md-spinner>\r\n                    </ng-container>\r\n                </button>\r\n                <!-- <a [routerLink]=\"['/signup']\" class=\"btn btn-link\">Sign up</a> -->\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/modules/sign/signin/signin.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports
exports.push([module.i, "@import url(https://fonts.googleapis.com/css?family=Roboto:300);", ""]);

// module
exports.push([module.i, ".login-page {\n  width: 100%;\n  padding: 8% 0 0;\n  margin: auto; }\n\n.full {\n  width: 100%;\n  margin: 0 0 15px; }\n\n.form {\n  position: relative;\n  z-index: 1;\n  background: #FFFFFF;\n  width: 35%;\n  margin: 0 auto 100px;\n  padding: 45px;\n  text-align: center;\n  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24); }\n\n.form input {\n  font-family: \"Roboto\", sans-serif;\n  outline: 0;\n  width: 100%;\n  border: 0;\n  box-sizing: border-box;\n  font-size: 14px; }\n\n.form button {\n  font-family: \"Roboto\", sans-serif;\n  text-transform: uppercase;\n  outline: 0;\n  width: 100%;\n  border: 0;\n  padding: 15px;\n  color: #FFFFFF;\n  font-size: 14px;\n  transition: all 0.3 ease;\n  cursor: pointer; }\n\n.form .message {\n  margin: 15px 0 0;\n  color: #b3b3b3;\n  font-size: 12px; }\n\n.form .message a {\n  text-decoration: none; }\n\n.container {\n  position: relative;\n  z-index: 1;\n  max-width: 300px;\n  margin: 0 auto; }\n\n.container:before, .container:after {\n  content: \"\";\n  display: block;\n  clear: both; }\n\n.container .info {\n  margin: 50px auto;\n  text-align: center; }\n\n.container .info h1 {\n  margin: 0 0 15px;\n  padding: 0;\n  font-size: 36px;\n  font-weight: 300;\n  color: #1a1a1a; }\n\n.container .info span {\n  color: #4d4d4d;\n  font-size: 12px; }\n\n.container .info span a {\n  color: #000000;\n  text-decoration: none; }\n\n.container .info span .fa {\n  color: #EF3B3A; }\n\nbody {\n  background: #76b852;\n  /* fallback for old browsers */\n  background: linear-gradient(to left, #76b852, #8DC26F);\n  font-family: \"Roboto\", sans-serif;\n  -webkit-font-smoothing: antialiased;\n  -moz-osx-font-smoothing: grayscale; }\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/modules/sign/signin/signin.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SigninComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__ngrx_store__ = __webpack_require__("../../../../@ngrx/store/@ngrx/store.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__ = __webpack_require__("../../../../../src/app/store/actions/signs/sign.action.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var SigninComponent = /** @class */ (function () {
    function SigninComponent(route, router, store) {
        this.route = route;
        this.router = router;
        this.store = store;
        this.model = { userName: '', password: '' }; // = {username: 'batman', password: 'KillSuperman!'};
    }
    SigninComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.loading = this.store.select(function (s) { return s.sign.busy; });
        this.statusError = this.store.select(function (s) { return s.sign.error; }).map(function (error) { return error ? error.text() : null; });
        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.params['returnUrl'] || '';
        var sub1 = this.store.select(function (s) { return s.sign.error; })
            .distinctUntilChanged()
            .subscribe(function (error) {
            if (error && error.status === 401) {
                _this.router.navigate(['ResendConfirmation', _this.model.userName]);
                if (sub1) {
                    sub1.unsubscribe();
                }
            }
            if (error && error.status === 406) {
                _this.router.navigate(['NewPassword', _this.model.userName, error.text()]);
                if (sub1) {
                    sub1.unsubscribe();
                }
            }
        });
        var sub2 = this.store.select(function (s) { return s.sign.authenticated; })
            .distinctUntilChanged()
            .subscribe(function (data) {
            if (data) {
                _this.router.navigate([_this.returnUrl]);
                if (sub2) {
                    sub2.unsubscribe();
                }
            }
        });
    };
    SigninComponent.prototype.signIn = function () {
        this.store.dispatch(new __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__["v" /* LogInRequestAction */](Object.assign({}, this.model)));
    };
    SigninComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            template: __webpack_require__("../../../../../src/app/modules/sign/signin/signin.component.html"),
            styles: [__webpack_require__("../../../../../src/app/modules/sign/signin/signin.component.scss")]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* ActivatedRoute */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_router__["a" /* ActivatedRoute */]) === "function" && _a || Object, typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* Router */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* Router */]) === "function" && _b || Object, typeof (_c = typeof __WEBPACK_IMPORTED_MODULE_2__ngrx_store__["b" /* Store */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2__ngrx_store__["b" /* Store */]) === "function" && _c || Object])
    ], SigninComponent);
    return SigninComponent;
    var _a, _b, _c;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/signin.component.js.map

/***/ }),

/***/ "../../../../../src/app/modules/sign/signup/signup.component.html":
/***/ (function(module, exports) {

module.exports = "<div class=\"login-page\">\r\n    <div class=\"form\">\r\n        <form class=\"login-form\" name=\"form\" (ngSubmit)=\"f.form.valid && signup()\" #f=\"ngForm\">\r\n            <div class=\"row\">\r\n                <div class=\"form-group col-md-12\" [ngClass]=\"{ 'has-error': f.submitted && !UserName.valid }\">\r\n                    <md-input-container class=\"full\">\r\n                        <input mdInput placeholder=\"UserName\" name=\"UserName\" [(ngModel)]=\"model.userName\" #UserName=\"ngModel\" required>\r\n                    </md-input-container>\r\n                    <div *ngIf=\"f.submitted && !UserName.valid\" class=\"help-block\">UserName is required</div>\r\n                </div>\r\n                <div class=\"form-group col-md-6\" [ngClass]=\"{ 'has-error': f.submitted && !FirstName.valid }\">\r\n                    <md-input-container class=\"full\">\r\n                        <input mdInput placeholder=\"First Name\" name=\"FirstName\" [(ngModel)]=\"model.firstName\" #FirstName=\"ngModel\" required>\r\n                    </md-input-container>\r\n                    <div *ngIf=\"f.submitted && !FirstName.valid\" class=\"help-block\">First name is required</div>\r\n                </div>\r\n                <div class=\"form-group col-md-6\" [ngClass]=\"{ 'has-error': f.submitted && !LastName.valid }\">\r\n                    <md-input-container class=\"full\">\r\n                        <input mdInput placeholder=\"Last Name\" name=\"LastName\" [(ngModel)]=\"model.lastName\" #LastName=\"ngModel\" required>\r\n                    </md-input-container>\r\n                    <div *ngIf=\"f.submitted && !LastName.valid\" class=\"help-block\">Last name is required</div>\r\n                </div>\r\n\r\n                <div class=\"form-group col-md-12\" [ngClass]=\"{ 'has-error': f.submitted && !Email.valid }\">\r\n                    <div class=\"row\">\r\n                        <md-input-container class=\"full col-md-8\">\r\n                            <input type=\"email\" mdInput placeholder=\"Email\" name=\"Email\" [(ngModel)]=\"model.email\" #Email=\"ngModel\" required>\r\n                        </md-input-container>\r\n                        <div *ngIf=\"f.submitted && !Email.valid\" class=\"help-block\">Email is required</div>\r\n\r\n                        <div *ngIf=\"IsBusy | async; else elseTemplate\">\r\n                            <md-spinner class=\"text-center\" style=\"width: inherit; height: 42px;\"></md-spinner>\r\n                        </div>\r\n                        <ng-template #elseTemplate>\r\n                            <md-select class=\"full col-md-4\" *ngIf=\"(domains| async)?.length > 0\" placeholder=\"Domain\" [(ngModel)]=\"emailDomain\" name=\"food\">\r\n                                <md-option *ngFor=\"let row of (domains| async)\" [value]=\"row\">\r\n                                    {{row}}\r\n                                </md-option>\r\n                            </md-select>\r\n                            <md-input-container class=\"full col-md-4\" *ngIf=\"!((domains| async)?.length > 0)\">\r\n                                <input tabindex=\"-1\" type=\"email\" mdInput placeholder=\"Domain\" value=\"No domain restriction\" readonly>\r\n                            </md-input-container>\r\n                        </ng-template>\r\n                    </div>\r\n\r\n                </div>\r\n\r\n                <div class=\"form-group col-md-4\">\r\n                    <md-input-container class=\"full\">\r\n                        <input type=\"text\" mdInput placeholder=\"Phone\" [textMask]=\"{mask: phoneMask, guide: false}\" name=\"Phone\" [(ngModel)]=\"model.phone\"\r\n                            #Phone=\"ngModel\">\r\n                    </md-input-container>\r\n                </div>\r\n\r\n                <!--password-->\r\n                <div class=\"form-group col-md-4\" [ngClass]=\"{ 'has-error': f.submitted && !Password.valid || ( password_confirmation != model.password) }\">\r\n                    <md-input-container class=\"full\">\r\n                        <input mdInput type=\"password\" placeholder=\"Password\" name=\"Password\" [(ngModel)]=\"model.password\" #Password=\"ngModel\" required>\r\n                    </md-input-container>\r\n\r\n                    <div *ngIf=\"f.submitted && !Password.valid\" class=\"help-block\">Password is required</div>\r\n                    <div *ngIf=\"f.submitted && password_confirmation != model.password\" class=\"help-block\">Password doesn't match</div>\r\n                </div>\r\n                <div class=\"form-group col-md-4\" [ngClass]=\"{ 'has-error': f.submitted && !confirm.valid || ( password_confirmation != model.password) }\">\r\n                    <md-input-container class=\"full\">\r\n                        <input mdInput placeholder=\"Confirm Password\" name=\"confirm\" type=\"password\" [(ngModel)]=\"password_confirmation\" #confirm=\"ngModel\"\r\n                            required validateEqual=\"Password\">\r\n                    </md-input-container>\r\n                    <div *ngIf=\"f.submitted && !confirm.valid\" class=\"help-block\">Please confirm the password</div>\r\n                    <div *ngIf=\"f.submitted && password_confirmation != model.password\" class=\"help-block\">Password doesn't match</div>\r\n                </div>\r\n                <!--password-->\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                <p *ngIf=\"error| async\">{{(error| async).errors}}</p>\r\n                <div *ngIf=\"(IsBusy | async); else elsetemplate\">\r\n                    <md-spinner class=\"text-center\" style=\"width: inherit; height: 42px;\"></md-spinner>\r\n                </div>\r\n                <ng-template #elsetemplate>\r\n                    <button [disabled]=\"(IsBusy | async)\" class=\"btn btn-primary\">Register</button>\r\n                </ng-template>\r\n                <a [routerLink]=\"['/login']\" class=\"btn btn-link\">Sign in</a>\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>"

/***/ }),

/***/ "../../../../../src/app/modules/sign/signup/signup.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports
exports.push([module.i, "@import url(https://fonts.googleapis.com/css?family=Roboto:300);", ""]);

// module
exports.push([module.i, ".login-page {\n  width: 100%;\n  padding: 8% 0 0;\n  margin: auto; }\n\n.full {\n  width: 100%;\n  margin: 0 0 15px; }\n\n.height-36px {\n  height: 36px; }\n\n.form {\n  position: relative;\n  z-index: 1;\n  background: #FFFFFF;\n  width: 70%;\n  margin: 0 auto 100px;\n  padding: 45px;\n  text-align: center;\n  box-shadow: 0 0 20px 0 rgba(0, 0, 0, 0.2), 0 5px 5px 0 rgba(0, 0, 0, 0.24); }\n\n.form input {\n  font-family: \"Roboto\", sans-serif;\n  outline: 0;\n  width: 100%;\n  border: 0;\n  box-sizing: border-box;\n  font-size: 14px; }\n\n.form button {\n  font-family: \"Roboto\", sans-serif;\n  text-transform: uppercase;\n  outline: 0;\n  width: 100%;\n  border: 0;\n  padding: 15px;\n  color: #FFFFFF;\n  font-size: 14px;\n  transition: all 0.3 ease;\n  cursor: pointer; }\n\n.form .message {\n  margin: 15px 0 0;\n  color: #b3b3b3;\n  font-size: 12px; }\n\n.form .message a {\n  text-decoration: none; }\n\n.container {\n  position: relative;\n  z-index: 1;\n  max-width: 300px;\n  margin: 0 auto; }\n\n.container:before, .container:after {\n  content: \"\";\n  display: block;\n  clear: both; }\n\n.container .info {\n  margin: 50px auto;\n  text-align: center; }\n\n.container .info h1 {\n  margin: 0 0 15px;\n  padding: 0;\n  font-size: 36px;\n  font-weight: 300;\n  color: #1a1a1a; }\n\n.container .info span {\n  color: #4d4d4d;\n  font-size: 12px; }\n\n.container .info span a {\n  color: #000000;\n  text-decoration: none; }\n\n.container .info span .fa {\n  color: #EF3B3A; }\n\nbody {\n  background: #76b852;\n  /* fallback for old browsers */\n  background: linear-gradient(to left, #76b852, #8DC26F);\n  font-family: \"Roboto\", sans-serif;\n  -webkit-font-smoothing: antialiased;\n  -moz-osx-font-smoothing: grayscale; }\n", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/modules/sign/signup/signup.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SignupComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_router__ = __webpack_require__("../../../router/@angular/router.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__ngrx_store__ = __webpack_require__("../../../../@ngrx/store/@ngrx/store.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__ = __webpack_require__("../../../../../src/app/store/actions/signs/sign.action.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var SignupComponent = /** @class */ (function () {
    function SignupComponent(router, store) {
        var _this = this;
        this.router = router;
        this.store = store;
        this.model = {}; // as Nicollas.Dto.Identity.userDto;
        this.phoneMask = ['(', /[1-9]/, /\d/, /\d/, ')', ' ', /\d/, /\d/, /\d/, '-', /\d/, /\d/, /\d/, /\d/];
        this.IsBusy = store.select(function (r) { return r.sign; }).map(function (state) { return state.busy; });
        this.domains = store.select(function (r) { return r.sign; }).map(function (state) { return state.domains; });
        // this.domains.distinctUntilChanged().subscribe(data => console.log(data));
        this.error = store.select(function (r) { return r.sign; }).map(function (state) { return JSON.parse(state.error); });
        var sub = store.select(function (r) { return r.sign; }).map(function (state) { return state.signupRequested; }).distinctUntilChanged().subscribe(function (result) {
            if (result) {
                _this.router.navigate(['ResendConfirmation', _this.model.userName]);
                sub.unsubscribe();
            }
        });
    }
    SignupComponent.prototype.ngOnInit = function () {
        this.store.dispatch(new __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__["k" /* DomainAction */]());
    };
    SignupComponent.prototype.signup = function () {
        if (this.model.password !== this.password_confirmation) {
            return;
        }
        var clone = Object.assign({}, this.model, { email: this.model.email + this.emailDomain });
        this.store.dispatch(new __WEBPACK_IMPORTED_MODULE_3_app_store_actions_signs_sign_action__["C" /* SignupAction */](clone));
    };
    SignupComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-signup',
            template: __webpack_require__("../../../../../src/app/modules/sign/signup/signup.component.html"),
            styles: [__webpack_require__("../../../../../src/app/modules/sign/signup/signup.component.scss")]
        }),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* Router */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_router__["b" /* Router */]) === "function" && _a || Object, typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_2__ngrx_store__["b" /* Store */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2__ngrx_store__["b" /* Store */]) === "function" && _b || Object])
    ], SignupComponent);
    return SignupComponent;
    var _a, _b;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/signup.component.js.map

/***/ }),

/***/ "../../../../../src/app/services/Socket/Realtime.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return RealtimeService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_app_api_service__ = __webpack_require__("../../../../../src/app/api.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__ngrx_store__ = __webpack_require__("../../../../@ngrx/store/@ngrx/store.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_app_store_reducers_BaseReducer__ = __webpack_require__("../../../../../src/app/store/reducers/BaseReducer.ts");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var RealtimeService = /** @class */ (function () {
    function RealtimeService(_api, _store) {
        this._api = _api;
        this._store = _store;
        if (!RealtimeService_1.store) {
            localStorage.removeItem('realtimeToken');
            RealtimeService_1.store = _store;
            RealtimeService_1.api = _api;
        }
    }
    RealtimeService_1 = RealtimeService;
    RealtimeService.OnMessageHandler = function (ev) {
        var data = JSON.parse(ev.data);
        switch (data.actionNeeded) {
            case 3:// ActionNeeded.RefreshByResponse:
                RealtimeService_1.store.dispatch({ type: "[" + data.reducer + "] " + (data.type || 'UPDATE_REDUCER'), payload: data.result });
                break;
            case 2:// ActionNeeded.RefreshReducer:
                RealtimeService_1.store.dispatch({ type: "[" + data.reducer + "] " + (data.type || 'NEED_REFRESH'), payload: data.result });
                break;
            case 1:// ActionNeeded.DoCallback:
                RealtimeService_1.DoCallback(data);
                break;
            case 4:// ActionNeeded.Init:
                localStorage.setItem('realtimeToken', data.result);
                break;
            default:
                break;
        }
        // data.Value is the response
        console.log('Realtime function found an message: ' + JSON.stringify(data));
        // RealtimeService.store.dispatch({type: ''});
    };
    RealtimeService.OnErrorHandler = function (ev) {
        console.error('Realtime function found an error: ' + ev);
    };
    RealtimeService.OnCloseHandler = function (ev) {
        console.log('Realtime function closed ' + ev.reason);
        RealtimeService_1.socket = null;
    };
    RealtimeService.OnOpenHandler = function (ev) {
        console.log('Realtime function started ');
    };
    RealtimeService.DoCallback = function (response) {
        this.api.get(response.reducer + "\\" + (response.callback || 'Read'))
            .publishLast().refCount().subscribe(function (data) {
            var filter = new __WEBPACK_IMPORTED_MODULE_3_app_store_reducers_BaseReducer__["a" /* Filter */](data);
            RealtimeService_1.store.
                dispatch({ type: "[" + response.reducer + "] " + (response.type || 'ReadComplete'), payload: filter });
        });
    };
    RealtimeService.Open = function () {
        if (!RealtimeService_1.socket) {
            RealtimeService_1.socket = new WebSocket(RealtimeService_1.path);
            RealtimeService_1.socket.onmessage = RealtimeService_1.OnMessageHandler;
            RealtimeService_1.socket.onerror = RealtimeService_1.OnErrorHandler;
            RealtimeService_1.socket.onclose = RealtimeService_1.OnCloseHandler;
            RealtimeService_1.socket.onopen = RealtimeService_1.OnOpenHandler;
        }
    };
    RealtimeService.Close = function () {
        if (RealtimeService_1.socket) {
            RealtimeService_1.socket.close();
            localStorage.removeItem('realtimeToken');
        }
    };
    RealtimeService.prototype.ngOnDestroy = function () {
        RealtimeService_1.Close();
    };
    RealtimeService.path = "ws://" + window.location.host + "/ws";
    RealtimeService = RealtimeService_1 = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1_app_api_service__["a" /* Api */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1_app_api_service__["a" /* Api */]) === "function" && _a || Object, typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_2__ngrx_store__["b" /* Store */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2__ngrx_store__["b" /* Store */]) === "function" && _b || Object])
    ], RealtimeService);
    return RealtimeService;
    var RealtimeService_1, _a, _b;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/Realtime.service.js.map

/***/ }),

/***/ "../../../../../src/app/services/signs/sign.service.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SignService; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_app_api_service__ = __webpack_require__("../../../../../src/app/api.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_app_auth_auth_service__ = __webpack_require__("../../../../../src/app/auth/auth.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_Observable__ = __webpack_require__("../../../../rxjs/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_Observable___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_3_rxjs_Observable__);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var SignService = /** @class */ (function () {
    function SignService(api, auth) {
        this.api = api;
        this.auth = auth;
    }
    SignService.prototype.SignIn = function (username, password) {
        var _this = this;
        var result = this.api
            .auth("username=" + username + "&password=" + password)
            .do(function (res) {
            _this.auth.saveToken(res);
            return res;
        });
        return result;
    };
    SignService.prototype.Logout = function () {
        return this.api.post('Sign/Logout');
    };
    SignService.prototype.ResetPassword = function (userId, token, password) {
        return this.api.get('Sign/ResetPassword', { userId: userId, token: token, newPassword: password });
    };
    SignService.prototype.RequestResetPassword = function (user) {
        return this.api.post('Sign/RequestResetPassword', user);
    };
    SignService.prototype.SignUp = function (user) {
        var password = user.password;
        var result = this.api.post('Sign/Singup' + ("/?password=" + password), user).map(function (r) {
            return true;
        }).catch(function (err) { return __WEBPACK_IMPORTED_MODULE_3_rxjs_Observable__["Observable"].throw(err || 'Server error'); });
        return result;
    };
    SignService.prototype.ResendEmail = function (username) {
        return this.api.get('Sign/resendConfirmationEmail', { username: username });
    };
    SignService.prototype.GetEmailRestriction = function () {
        return this.api.get('Sign/GetEmailDomainRestriction');
    };
    SignService.prototype.DefaultPassword = function (userId, password) {
        return this.api.get('Sign/DefaultPassword', { id: userId, password: password }).publishLast().refCount();
    };
    SignService = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1_app_api_service__["a" /* Api */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1_app_api_service__["a" /* Api */]) === "function" && _a || Object, typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_2_app_auth_auth_service__["a" /* AuthService */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_2_app_auth_auth_service__["a" /* AuthService */]) === "function" && _b || Object])
    ], SignService);
    return SignService;
    var _a, _b;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/sign.service.js.map

/***/ }),

/***/ "../../../../../src/app/store/actions/identity/role.action.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "b", function() { return CREATE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "c", function() { return CREATE_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "i", function() { return READ; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "j", function() { return READ_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "l", function() { return UPDATE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "m", function() { return UPDATE_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "e", function() { return DELETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "f", function() { return DELETE_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "g", function() { return DISABLE; });
/* unused harmony export DISABLE_COMPLETE */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ACTION_FAILED; });
/* unused harmony export CreateAction */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "d", function() { return CreateCompleteAction; });
/* unused harmony export ReadAction */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "k", function() { return ReadCompleteAction; });
/* unused harmony export UpdateAction */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "n", function() { return UpdateCompleteAction; });
/* unused harmony export DeleteAction */
/* unused harmony export DeleteCompleteAction */
/* unused harmony export DisableAction */
/* unused harmony export DisableCompleteAction */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "h", function() { return FaliedAction; });
var CREATE = '[Role] Create';
var CREATE_COMPLETE = '[Role] CreateComplete';
var READ = '[Role] Read';
var READ_COMPLETE = '[Role] ReadComplete';
var UPDATE = '[Role] Update';
var UPDATE_COMPLETE = '[Role] UpdateComplete';
var DELETE = '[Role] Delete';
var DELETE_COMPLETE = '[Role] DeleteComplete';
var DISABLE = '[Role] Disable';
var DISABLE_COMPLETE = '[Role] DisableComplete';
var ACTION_FAILED = '[Role] ActionFailed';
var CreateAction = /** @class */ (function () {
    function CreateAction(payload) {
        this.payload = payload;
        this.type = CREATE;
    }
    return CreateAction;
}());

var CreateCompleteAction = /** @class */ (function () {
    function CreateCompleteAction(payload) {
        this.payload = payload;
        this.type = CREATE_COMPLETE;
    }
    return CreateCompleteAction;
}());

var ReadAction = /** @class */ (function () {
    function ReadAction() {
        this.type = READ;
    }
    return ReadAction;
}());

var ReadCompleteAction = /** @class */ (function () {
    function ReadCompleteAction(payload) {
        this.payload = payload;
        this.type = READ_COMPLETE;
    }
    return ReadCompleteAction;
}());

var UpdateAction = /** @class */ (function () {
    function UpdateAction(payload) {
        this.payload = payload;
        this.type = UPDATE;
    }
    return UpdateAction;
}());

var UpdateCompleteAction = /** @class */ (function () {
    function UpdateCompleteAction(payload) {
        this.payload = payload;
        this.type = UPDATE_COMPLETE;
    }
    return UpdateCompleteAction;
}());

var DeleteAction = /** @class */ (function () {
    function DeleteAction(payload) {
        this.payload = payload;
        this.type = DELETE;
    }
    return DeleteAction;
}());

var DeleteCompleteAction = /** @class */ (function () {
    function DeleteCompleteAction(payload) {
        this.payload = payload;
        this.type = DELETE_COMPLETE;
    }
    return DeleteCompleteAction;
}());

var DisableAction = /** @class */ (function () {
    function DisableAction(payload) {
        this.payload = payload;
        this.type = DISABLE;
    }
    return DisableAction;
}());

var DisableCompleteAction = /** @class */ (function () {
    function DisableCompleteAction(payload) {
        this.payload = payload;
        this.type = DISABLE_COMPLETE;
    }
    return DisableCompleteAction;
}());

var FaliedAction = /** @class */ (function () {
    function FaliedAction(payload) {
        this.payload = payload;
        this.type = ACTION_FAILED;
    }
    return FaliedAction;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/role.action.js.map

/***/ }),

/***/ "../../../../../src/app/store/actions/identity/user.action.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "c", function() { return CREATE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "d", function() { return CREATE_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "l", function() { return READ; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "m", function() { return READ_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "p", function() { return UPDATE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "q", function() { return UPDATE_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "f", function() { return DELETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "g", function() { return DELETE_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "h", function() { return DISABLE; });
/* unused harmony export DISABLE_COMPLETE */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "n", function() { return RESET_PASSWORD; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "b", function() { return CHANGE_PASSWORD; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "j", function() { return PASSWORD_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ACTION_FAILED; });
/* unused harmony export CreateAction */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "e", function() { return CreateCompleteAction; });
/* unused harmony export ResetPasswordAction */
/* unused harmony export ChangePasswordAction */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "k", function() { return PasswordCompleteAction; });
/* unused harmony export ReadAction */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "o", function() { return ReadCompleteAction; });
/* unused harmony export UpdateAction */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "r", function() { return UpdateCompleteAction; });
/* unused harmony export DeleteAction */
/* unused harmony export DeleteCompleteAction */
/* unused harmony export DisableAction */
/* unused harmony export DisableCompleteAction */
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "i", function() { return FaliedAction; });
var CREATE = '[User] Create';
var CREATE_COMPLETE = '[User] CreateComplete';
var READ = '[User] Read';
var READ_COMPLETE = '[User] ReadComplete';
var UPDATE = '[User] Update';
var UPDATE_COMPLETE = '[User] UpdateComplete';
var DELETE = '[User] Delete';
var DELETE_COMPLETE = '[User] DeleteComplete';
var DISABLE = '[User] Disable';
var DISABLE_COMPLETE = '[User] DisableComplete';
var RESET_PASSWORD = '[User] ResetPassword';
var CHANGE_PASSWORD = '[User] ChangePassword';
var PASSWORD_COMPLETE = '[User] PasswordCompleted';
var ACTION_FAILED = '[User] ActionFailed';
var CreateAction = /** @class */ (function () {
    function CreateAction(payload) {
        this.payload = payload;
        this.type = CREATE;
    }
    return CreateAction;
}());

var CreateCompleteAction = /** @class */ (function () {
    function CreateCompleteAction(payload) {
        this.payload = payload;
        this.type = CREATE_COMPLETE;
    }
    return CreateCompleteAction;
}());

var ResetPasswordAction = /** @class */ (function () {
    function ResetPasswordAction(payload) {
        this.payload = payload;
        this.type = RESET_PASSWORD;
    }
    return ResetPasswordAction;
}());

var ChangePasswordAction = /** @class */ (function () {
    function ChangePasswordAction(payload) {
        this.payload = payload;
        this.type = CHANGE_PASSWORD;
    }
    return ChangePasswordAction;
}());

var PasswordCompleteAction = /** @class */ (function () {
    function PasswordCompleteAction() {
        this.type = PASSWORD_COMPLETE;
    }
    return PasswordCompleteAction;
}());

var ReadAction = /** @class */ (function () {
    function ReadAction() {
        this.type = READ;
    }
    return ReadAction;
}());

var ReadCompleteAction = /** @class */ (function () {
    function ReadCompleteAction(payload) {
        this.payload = payload;
        this.type = READ_COMPLETE;
    }
    return ReadCompleteAction;
}());

var UpdateAction = /** @class */ (function () {
    function UpdateAction(payload) {
        this.payload = payload;
        this.type = UPDATE;
    }
    return UpdateAction;
}());

var UpdateCompleteAction = /** @class */ (function () {
    function UpdateCompleteAction(payload) {
        this.payload = payload;
        this.type = UPDATE_COMPLETE;
    }
    return UpdateCompleteAction;
}());

var DeleteAction = /** @class */ (function () {
    function DeleteAction(payload) {
        this.payload = payload;
        this.type = DELETE;
    }
    return DeleteAction;
}());

var DeleteCompleteAction = /** @class */ (function () {
    function DeleteCompleteAction(payload) {
        this.payload = payload;
        this.type = DELETE_COMPLETE;
    }
    return DeleteCompleteAction;
}());

var DisableAction = /** @class */ (function () {
    function DisableAction(payload) {
        this.payload = payload;
        this.type = DISABLE;
    }
    return DisableAction;
}());

var DisableCompleteAction = /** @class */ (function () {
    function DisableCompleteAction(payload) {
        this.payload = payload;
        this.type = DISABLE_COMPLETE;
    }
    return DisableCompleteAction;
}());

var FaliedAction = /** @class */ (function () {
    function FaliedAction(payload) {
        this.payload = payload;
        this.type = ACTION_FAILED;
    }
    return FaliedAction;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/user.action.js.map

/***/ }),

/***/ "../../../../../src/app/store/actions/reports/report.action.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "c", function() { return LOAD_APLY_MONTH; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "d", function() { return LOAD_APLY_MONTH_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "e", function() { return LOAD_APLY_WEEK; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "f", function() { return LOAD_APLY_WEEK_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "g", function() { return LOAD_DIFICULTY_WEEK; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "h", function() { return LOAD_DIFICULTY_WEEK_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "i", function() { return LOAD_PROGRESS_WEEK; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "j", function() { return LOAD_PROGRESS_WEEK_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "s", function() { return SEND_JSON; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "t", function() { return SEND_JSON_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ACTION_FAILED; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "u", function() { return SendJsonAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "v", function() { return SendJsonActionComplete; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "k", function() { return LoadAplyMonthAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "l", function() { return LoadAplyMonthCompleteAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "m", function() { return LoadAplyWeekAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "n", function() { return LoadAplyWeekCompleteAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "o", function() { return LoadDificultyWeekAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "p", function() { return LoadDificultyWeekCompleteAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "q", function() { return LoadProgressWeekAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "r", function() { return LoadProgressWeekCompleteAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "b", function() { return FaliedAction; });
var LOAD_APLY_MONTH = '[Reports] LOAD_APLY_MONTH';
var LOAD_APLY_MONTH_COMPLETE = '[Reports] LOAD_APLY_MONTH_COMPLETE';
var LOAD_APLY_WEEK = '[Reports] LOAD_APLY_WEEK';
var LOAD_APLY_WEEK_COMPLETE = '[Reports] LOAD_APLY_WEEK_COMPLETE';
var LOAD_DIFICULTY_WEEK = '[Reports] LOAD_DIFICULTY_WEEK';
var LOAD_DIFICULTY_WEEK_COMPLETE = '[Reports] LOAD_DIFICULTY_WEEK_COMPLETE';
var LOAD_PROGRESS_WEEK = '[Reports] LOAD_PROGRESS_WEEK';
var LOAD_PROGRESS_WEEK_COMPLETE = '[Reports] LOAD_PROGRESS_WEEK_COMPLETE';
var SEND_JSON = '[Reports] SEND_JSON';
var SEND_JSON_COMPLETE = '[Reports] SEND_JSON_COMPLETE';
var ACTION_FAILED = '[Reports] ACTION_FAILED';
var SendJsonAction = /** @class */ (function () {
    function SendJsonAction(payload) {
        this.payload = payload;
        this.type = SEND_JSON;
    }
    return SendJsonAction;
}());

var SendJsonActionComplete = /** @class */ (function () {
    function SendJsonActionComplete() {
        this.type = SEND_JSON_COMPLETE;
    }
    return SendJsonActionComplete;
}());

var LoadAplyMonthAction = /** @class */ (function () {
    function LoadAplyMonthAction() {
        this.type = LOAD_APLY_MONTH;
    }
    return LoadAplyMonthAction;
}());

var LoadAplyMonthCompleteAction = /** @class */ (function () {
    function LoadAplyMonthCompleteAction(payload) {
        this.payload = payload;
        this.type = LOAD_APLY_MONTH_COMPLETE;
    }
    return LoadAplyMonthCompleteAction;
}());

var LoadAplyWeekAction = /** @class */ (function () {
    function LoadAplyWeekAction() {
        this.type = LOAD_APLY_WEEK;
    }
    return LoadAplyWeekAction;
}());

var LoadAplyWeekCompleteAction = /** @class */ (function () {
    function LoadAplyWeekCompleteAction(payload) {
        this.payload = payload;
        this.type = LOAD_APLY_WEEK_COMPLETE;
    }
    return LoadAplyWeekCompleteAction;
}());

var LoadDificultyWeekAction = /** @class */ (function () {
    function LoadDificultyWeekAction() {
        this.type = LOAD_DIFICULTY_WEEK;
    }
    return LoadDificultyWeekAction;
}());

var LoadDificultyWeekCompleteAction = /** @class */ (function () {
    function LoadDificultyWeekCompleteAction(payload) {
        this.payload = payload;
        this.type = LOAD_DIFICULTY_WEEK_COMPLETE;
    }
    return LoadDificultyWeekCompleteAction;
}());

var LoadProgressWeekAction = /** @class */ (function () {
    function LoadProgressWeekAction() {
        this.type = LOAD_PROGRESS_WEEK;
    }
    return LoadProgressWeekAction;
}());

var LoadProgressWeekCompleteAction = /** @class */ (function () {
    function LoadProgressWeekCompleteAction(payload) {
        this.payload = payload;
        this.type = LOAD_PROGRESS_WEEK_COMPLETE;
    }
    return LoadProgressWeekCompleteAction;
}());

var FaliedAction = /** @class */ (function () {
    function FaliedAction(payload) {
        this.payload = payload;
        this.type = ACTION_FAILED;
    }
    return FaliedAction;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/report.action.js.map

/***/ }),

/***/ "../../../../../src/app/store/actions/signs/sign.action.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "o", function() { return FAILED; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "t", function() { return LOG_IN_REQUEST; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "s", function() { return LOG_IN_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "r", function() { return LOGOUT_REQUEST; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "q", function() { return LOGOUT_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "A", function() { return SIGNUP; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "B", function() { return SIGNUP_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "g", function() { return DOMAIN; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "h", function() { return DOMAIN_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "m", function() { return EMAIL; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "n", function() { return EMAIL_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return ACCOUNT; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "b", function() { return ACCOUNT_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "e", function() { return DEFAULT_PASSWORD; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "f", function() { return DEFAULT_PASSWORD_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "E", function() { return TOKEN; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "F", function() { return TOKEN_COMPLETE; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "i", function() { return DefaultPasswordAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "j", function() { return DefaultPasswordCompleteAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "v", function() { return LogInRequestAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "u", function() { return LogInCompleteAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "x", function() { return LogoutRequestAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "w", function() { return LogoutCompleteAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "p", function() { return FailAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "C", function() { return SignupAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "D", function() { return SignupCompleteAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "k", function() { return DomainAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "l", function() { return DomainCompleteAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "y", function() { return ResendEmailAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "z", function() { return ResendEmailCompleteAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "c", function() { return AccountRecoveryAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "d", function() { return AccountRecoveryCompleteAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "G", function() { return TokenAction; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "H", function() { return TokenCompleteAction; });
var FAILED = '[Sign] Failed';
var LOG_IN_REQUEST = '[Sign] LogInRequest';
var LOG_IN_COMPLETE = '[Sign] LogInComplete';
var LOGOUT_REQUEST = '[Sign] LogoutRequest';
var LOGOUT_COMPLETE = '[Sign] LogoutComplete';
var SIGNUP = '[Sign] SignupRequest';
var SIGNUP_COMPLETE = '[Sign] SignupComplete';
var DOMAIN = '[Sign] Domain';
var DOMAIN_COMPLETE = '[Sign] DomainComplete';
var EMAIL = '[Sign] Email';
var EMAIL_COMPLETE = '[Sign] EmailComplete';
var ACCOUNT = '[Sign] RecoveryAccount';
var ACCOUNT_COMPLETE = '[Sign] RecoveryAccountComplete';
var DEFAULT_PASSWORD = '[Sign] DefaultPassword';
var DEFAULT_PASSWORD_COMPLETE = '[Sign] DefaultPasswordComplete';
var TOKEN = '[Sign] Token';
var TOKEN_COMPLETE = '[Sign] TokenComplete';
/**
 * Every action is comprised of at least a type and an optional
 * payload. Expressing actions as classes enables powerful
 * type checking in reducer functions.
 *
 * See Discriminated Unions: https://www.typescriptlang.org/docs/handbook/advanced-types.html#discriminated-unions
 */
var DefaultPasswordAction = /** @class */ (function () {
    function DefaultPasswordAction(payload) {
        this.payload = payload;
        this.type = DEFAULT_PASSWORD;
    }
    return DefaultPasswordAction;
}());

var DefaultPasswordCompleteAction = /** @class */ (function () {
    function DefaultPasswordCompleteAction() {
        this.type = DEFAULT_PASSWORD_COMPLETE;
    }
    return DefaultPasswordCompleteAction;
}());

var LogInRequestAction = /** @class */ (function () {
    function LogInRequestAction(payload) {
        this.payload = payload;
        this.type = LOG_IN_REQUEST;
    }
    return LogInRequestAction;
}());

var LogInCompleteAction = /** @class */ (function () {
    function LogInCompleteAction(payload) {
        this.payload = payload;
        this.type = LOG_IN_COMPLETE;
    }
    return LogInCompleteAction;
}());

var LogoutRequestAction = /** @class */ (function () {
    function LogoutRequestAction() {
        this.type = LOGOUT_REQUEST;
    }
    return LogoutRequestAction;
}());

var LogoutCompleteAction = /** @class */ (function () {
    function LogoutCompleteAction() {
        this.type = LOGOUT_COMPLETE;
    }
    return LogoutCompleteAction;
}());

var FailAction = /** @class */ (function () {
    function FailAction(payload) {
        this.payload = payload;
        this.type = FAILED;
    }
    return FailAction;
}());

var SignupAction = /** @class */ (function () {
    function SignupAction(payload) {
        this.payload = payload;
        this.type = SIGNUP;
    }
    return SignupAction;
}());

var SignupCompleteAction = /** @class */ (function () {
    function SignupCompleteAction(payload) {
        this.payload = payload;
        this.type = SIGNUP_COMPLETE;
    }
    return SignupCompleteAction;
}());

var DomainAction = /** @class */ (function () {
    function DomainAction() {
        this.type = DOMAIN;
    }
    return DomainAction;
}());

var DomainCompleteAction = /** @class */ (function () {
    function DomainCompleteAction(payload) {
        this.payload = payload;
        this.type = DOMAIN_COMPLETE;
    }
    return DomainCompleteAction;
}());

var ResendEmailAction = /** @class */ (function () {
    function ResendEmailAction(payload) {
        this.payload = payload;
        this.type = EMAIL;
    }
    return ResendEmailAction;
}());

var ResendEmailCompleteAction = /** @class */ (function () {
    function ResendEmailCompleteAction(payload) {
        this.payload = payload;
        this.type = EMAIL_COMPLETE;
    }
    return ResendEmailCompleteAction;
}());

var AccountRecoveryAction = /** @class */ (function () {
    function AccountRecoveryAction(payload) {
        this.payload = payload;
        this.type = ACCOUNT;
    }
    return AccountRecoveryAction;
}());

var AccountRecoveryCompleteAction = /** @class */ (function () {
    function AccountRecoveryCompleteAction() {
        this.type = ACCOUNT_COMPLETE;
    }
    return AccountRecoveryCompleteAction;
}());

var TokenAction = /** @class */ (function () {
    function TokenAction(payload) {
        this.payload = payload;
        this.type = TOKEN;
    }
    return TokenAction;
}());

var TokenCompleteAction = /** @class */ (function () {
    function TokenCompleteAction(payload) {
        this.payload = payload;
        this.type = TOKEN_COMPLETE;
    }
    return TokenCompleteAction;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/sign.action.js.map

/***/ }),

/***/ "../../../../../src/app/store/effects/signs/sign.effect.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return SignEffects; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_rxjs_add_operator_catch__ = __webpack_require__("../../../../rxjs/add/operator/catch.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_rxjs_add_operator_catch___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_rxjs_add_operator_catch__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_add_operator_map__ = __webpack_require__("../../../../rxjs/add/operator/map.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_rxjs_add_operator_map___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_rxjs_add_operator_map__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_add_operator_switchMap__ = __webpack_require__("../../../../rxjs/add/operator/switchMap.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_rxjs_add_operator_switchMap___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2_rxjs_add_operator_switchMap__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_debounceTime__ = __webpack_require__("../../../../rxjs/add/operator/debounceTime.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_debounceTime___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_3_rxjs_add_operator_debounceTime__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_rxjs_add_operator_skip__ = __webpack_require__("../../../../rxjs/add/operator/skip.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4_rxjs_add_operator_skip___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_4_rxjs_add_operator_skip__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5_rxjs_add_operator_takeUntil__ = __webpack_require__("../../../../rxjs/add/operator/takeUntil.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_5_rxjs_add_operator_takeUntil___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_5_rxjs_add_operator_takeUntil__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_6__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_7__ngrx_effects__ = __webpack_require__("../../../../@ngrx/effects/@ngrx/effects.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__ = __webpack_require__("../../../../rxjs/Observable.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9_rxjs_observable_of__ = __webpack_require__("../../../../rxjs/observable/of.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_9_rxjs_observable_of___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_9_rxjs_observable_of__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_10_app_services_signs_sign_service__ = __webpack_require__("../../../../../src/app/services/signs/sign.service.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__ = __webpack_require__("../../../../../src/app/store/actions/signs/sign.action.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12_rxjs_observable_defer__ = __webpack_require__("../../../../rxjs/observable/defer.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_12_rxjs_observable_defer___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_12_rxjs_observable_defer__);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};













/**
 * Effects offer a way to isolate and easily test side-effects within your
 * application.
 * The `toPayload` helper function returns just
 * the payload of the currently dispatched action, useful in
 * instances where the current state is not necessary.
 *
 * Documentation on `toPayload` can be found here:
 * https://github.com/ngrx/effects/blob/master/docs/api.md#topayload
 *
 * If you are unfamiliar with the operators being used in these examples, please
 * check out the sources below:
 *
 * Official Docs: http://reactivex.io/rxjs/manual/overview.html#categories-of-operators
 * RxJS 5 Operators By Example: https://gist.github.com/btroncone/d6cf141d6f2c00dc6b35
 */
var SignEffects = /** @class */ (function () {
    function SignEffects(actions$, service) {
        var _this = this;
        this.actions$ = actions$;
        this.service = service;
        /**
       * This effect makes use of the `startWith` operator to trigger
       * the effect immediately on startup.
       */
        this.LoadTokenData$ = Object(__WEBPACK_IMPORTED_MODULE_12_rxjs_observable_defer__["defer"])(function () {
            if (_this.service.auth.isAuthenticate()) {
                return Object(__WEBPACK_IMPORTED_MODULE_9_rxjs_observable_of__["of"])(new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["u" /* LogInCompleteAction */](_this.service.auth.getToken()));
            }
            return Object(__WEBPACK_IMPORTED_MODULE_9_rxjs_observable_of__["of"])(new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["p" /* FailAction */](null));
        });
        this.Login$ = this.actions$
            .ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["t" /* LOG_IN_REQUEST */]) // the action type that will hit this
            .map(function (action) { return action.payload; })
            .switchMap(function (entity) {
            var next$ = _this.actions$.ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["t" /* LOG_IN_REQUEST */]).skip(1);
            return _this.service.SignIn(entity.userName, entity.password)
                .takeUntil(next$)
                .map(function (result) { return new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["u" /* LogInCompleteAction */](result); })
                .catch(function (err) { return Object(__WEBPACK_IMPORTED_MODULE_9_rxjs_observable_of__["of"])(new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["p" /* FailAction */](err)); });
        });
        this.Logout$ = this.actions$
            .ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["r" /* LOGOUT_REQUEST */]) // the action type that will hit this
            .map(function (_) { return null; })
            .switchMap(function (_) {
            var next$ = _this.actions$.ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["r" /* LOGOUT_REQUEST */]).skip(1);
            return _this.service.Logout()
                .takeUntil(next$)
                .map(function (_) {
                _this.service.auth.removeToken();
                location.reload();
                return new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["w" /* LogoutCompleteAction */]();
            })
                .catch(function (err) { return Object(__WEBPACK_IMPORTED_MODULE_9_rxjs_observable_of__["of"])(new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["p" /* FailAction */](err)); });
        });
        this.Signup$ = this.actions$
            .ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["A" /* SIGNUP */]) // the action type that will hit this
            .map(function (action) { return action.payload; })
            .switchMap(function (entity) {
            var next$ = _this.actions$.ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["A" /* SIGNUP */]).skip(1);
            return _this.service.SignUp(entity)
                .takeUntil(next$)
                .map(function (result) { return new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["D" /* SignupCompleteAction */](result); })
                .catch(function (err) { return Object(__WEBPACK_IMPORTED_MODULE_9_rxjs_observable_of__["of"])(new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["p" /* FailAction */](err.text())); });
        });
        this.ResendEmail$ = this.actions$
            .ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["m" /* EMAIL */]) // the action type that will hit this
            .map(function (action) { return action.payload; })
            .switchMap(function (username) {
            var next$ = _this.actions$.ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["m" /* EMAIL */]).skip(1);
            return _this.service.ResendEmail(username)
                .takeUntil(next$)
                .map(function (result) { return new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["z" /* ResendEmailCompleteAction */](result); })
                .catch(function (err) { return Object(__WEBPACK_IMPORTED_MODULE_9_rxjs_observable_of__["of"])(new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["p" /* FailAction */](err.text())); });
        });
        this.SendToken$ = this.actions$
            .ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["E" /* TOKEN */]) // the action type that will hit this
            .map(function (action) { return action.payload; })
            .switchMap(function (entity) {
            var next$ = _this.actions$.ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["E" /* TOKEN */]).skip(1);
            return _this.service.ResetPassword(entity.id, entity.token, entity.password)
                .takeUntil(next$)
                .map(function (result) { return new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["H" /* TokenCompleteAction */](result); })
                .catch(function (err) { return Object(__WEBPACK_IMPORTED_MODULE_9_rxjs_observable_of__["of"])(new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["p" /* FailAction */](err.text())); });
        });
        this.DefaultPassword$ = this.actions$
            .ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["e" /* DEFAULT_PASSWORD */]) // the action type that will hit this
            .map(function (action) { return action.payload; })
            .switchMap(function (data) {
            var next$ = _this.actions$.ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["e" /* DEFAULT_PASSWORD */]).skip(1);
            return _this.service.DefaultPassword(data.id, data.password)
                .takeUntil(next$)
                .map(function (result) { return new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["j" /* DefaultPasswordCompleteAction */](); })
                .catch(function (err) { return Object(__WEBPACK_IMPORTED_MODULE_9_rxjs_observable_of__["of"])(new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["p" /* FailAction */](err.text())); });
        });
        this.RecoveryAccount$ = this.actions$
            .ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["a" /* ACCOUNT */]) // the action type that will hit this
            .map(function (action) { return action.payload; })
            .switchMap(function (username) {
            var next$ = _this.actions$.ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["m" /* EMAIL */]).skip(1);
            return _this.service.RequestResetPassword(username).takeUntil(next$)
                .map(function (result) { return new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["d" /* AccountRecoveryCompleteAction */](); })
                .catch(function (err) { return Object(__WEBPACK_IMPORTED_MODULE_9_rxjs_observable_of__["of"])(new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["p" /* FailAction */](err.text())); });
        });
        this.Domains$ = this.actions$
            .ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["g" /* DOMAIN */]) // the action type that will hit this
            .map(function (action) { return null; })
            .switchMap(function (_) {
            var next$ = _this.actions$.ofType(__WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["g" /* DOMAIN */]).skip(1);
            return _this.service.GetEmailRestriction()
                .takeUntil(next$)
                .map(function (result) { return new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["l" /* DomainCompleteAction */](result); })
                .catch(function (err) { return Object(__WEBPACK_IMPORTED_MODULE_9_rxjs_observable_of__["of"])(new __WEBPACK_IMPORTED_MODULE_11__actions_signs_sign_action__["p" /* FailAction */](err.text())); });
        });
    }
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_7__ngrx_effects__["b" /* Effect */])(),
        __metadata("design:type", typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"]) === "function" && _a || Object)
    ], SignEffects.prototype, "LoadTokenData$", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_7__ngrx_effects__["b" /* Effect */])(),
        __metadata("design:type", typeof (_b = typeof __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"]) === "function" && _b || Object)
    ], SignEffects.prototype, "Login$", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_7__ngrx_effects__["b" /* Effect */])(),
        __metadata("design:type", typeof (_c = typeof __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"]) === "function" && _c || Object)
    ], SignEffects.prototype, "Logout$", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_7__ngrx_effects__["b" /* Effect */])(),
        __metadata("design:type", typeof (_d = typeof __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"]) === "function" && _d || Object)
    ], SignEffects.prototype, "Signup$", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_7__ngrx_effects__["b" /* Effect */])(),
        __metadata("design:type", typeof (_e = typeof __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"]) === "function" && _e || Object)
    ], SignEffects.prototype, "ResendEmail$", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_7__ngrx_effects__["b" /* Effect */])(),
        __metadata("design:type", typeof (_f = typeof __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"]) === "function" && _f || Object)
    ], SignEffects.prototype, "SendToken$", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_7__ngrx_effects__["b" /* Effect */])(),
        __metadata("design:type", typeof (_g = typeof __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"]) === "function" && _g || Object)
    ], SignEffects.prototype, "DefaultPassword$", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_7__ngrx_effects__["b" /* Effect */])(),
        __metadata("design:type", typeof (_h = typeof __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"]) === "function" && _h || Object)
    ], SignEffects.prototype, "RecoveryAccount$", void 0);
    __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_7__ngrx_effects__["b" /* Effect */])(),
        __metadata("design:type", typeof (_j = typeof __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"] !== "undefined" && __WEBPACK_IMPORTED_MODULE_8_rxjs_Observable__["Observable"]) === "function" && _j || Object)
    ], SignEffects.prototype, "Domains$", void 0);
    SignEffects = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_6__angular_core__["Injectable"])(),
        __metadata("design:paramtypes", [typeof (_k = typeof __WEBPACK_IMPORTED_MODULE_7__ngrx_effects__["a" /* Actions */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_7__ngrx_effects__["a" /* Actions */]) === "function" && _k || Object, typeof (_l = typeof __WEBPACK_IMPORTED_MODULE_10_app_services_signs_sign_service__["a" /* SignService */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_10_app_services_signs_sign_service__["a" /* SignService */]) === "function" && _l || Object])
    ], SignEffects);
    return SignEffects;
    var _a, _b, _c, _d, _e, _f, _g, _h, _j, _k, _l;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/sign.effect.js.map

/***/ }),

/***/ "../../../../../src/app/store/reducers/BaseReducer.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return Filter; });
/* harmony export (immutable) */ __webpack_exports__["c"] = PureReplaceEntity;
/* harmony export (immutable) */ __webpack_exports__["b"] = PureInsertOrUpdate;
/* unused harmony export PureReplace */
/* unused harmony export PureRemove */
/* unused harmony export PureInsert */
/* Explaning
    As the concept of reducer is always be an pure function, We need to
    return an new object every time we make a change on that object
*/
/**
 * @class This class handle the pure functions to an array of our Entity
 * @type {TEntity} Extends the @see Nicollas.Dto.baseEntityDto with the Key
 * @type {TKey} The key used on TEntity
 */
var Filter = /** @class */ (function () {
    function Filter(values, key) {
        if (key === void 0) { key = 'unique'; }
        this.key = key;
        this.values = values;
    }
    /**
     * Check if exist some Entity with the key
     * @param id The id to look
     */
    Filter.prototype.exists = function (id) { return this.values.some(function (row) { return row.id === id; }); };
    /**
     * Get an entity by value
     * @param id The id to find
     */
    Filter.prototype.find = function (id) { return Object.assign({}, this.values.find(function (row) { return row.id === id; })); };
    /**
     * Get an entity by an action
     * @param filter The action
     */
    Filter.prototype.where = function (filter) { return Object.assign({}, this.values.find(filter)); };
    /**
     * return a new filter with the new entity inserted
     * @param entity The entity to be inserted
     */
    Filter.prototype.insert = function (entity) {
        return new Filter(this.values.concat([entity]), this.key);
    };
    /**
     * return a new filter with the entity updated
     * @param entity The entity to be updated
     */
    Filter.prototype.update = function (entity) {
        var index = this.values.findIndex(function (r) { return r.id === entity.id; });
        if (index < 0) {
            throw new Error('Entity not found');
        }
        return new Filter(this.values.slice(0, index).concat([entity], this.values.slice(index + 1)), this.key);
    };
    /**
     * return a new filter without the entity
     * @param entity The entity to be removed
     */
    Filter.prototype.remove = function (entity) {
        return new Filter(this.values.filter(function (row) { return row.id !== entity.id; }).slice(), this.key);
    };
    return Filter;
}());

/**
 * Update the entity on every filter that is found and return an new array
 * @param array the array of filters to be updated
 * @param entity the entity to be updated
 */
function PureReplaceEntity(array, entity) {
    var result = array;
    array.forEach(function (element, index) {
        if (element.exists(entity.id)) {
            result = PureReplace(result, element.update(entity));
        }
    });
    return result;
}
/**
 * insert or update the filter and return an new array
 * @param array the array of filters to insert or update
 * @param filter the filter to insert or update
 */
function PureInsertOrUpdate(array, filter) {
    return array.some(function (row) { return row.key === filter.key; }) ? PureReplace(array, filter) : PureInsert(array, filter);
}
/**
 * update the filter and return an new array
 * @param array the array of filters to update
 * @param filter the filter to update
 * @throws Error when the filter is not on the array
 */
function PureReplace(array, filter) {
    var index = array.findIndex(function (r) { return r.key === filter.key; });
    if (index < 0) {
        throw new Error('Key not found');
    }
    return array.slice(0, index).concat([filter], array.slice(index + 1));
}
/**
 * Remove the filter from array and return an new array
 * @param array the array of filters to remove
 * @param filter to remove
 */
function PureRemove(array, filter) {
    return array.filter(function (row) { return row.key === filter.key; }).slice();
}
/**
 * insert the filter and return an new array
 * @param array the array of filters to insert a new one
 * @param filter the filter to insert
 */
function PureInsert(array, filter) {
    return array.concat([filter]);
}
//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/BaseReducer.js.map

/***/ }),

/***/ "../../../../../src/app/store/reducers/identity/role.reducer.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export initialState */
/* harmony export (immutable) */ __webpack_exports__["a"] = reducer;
/* unused harmony export get */
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_role_action__ = __webpack_require__("../../../../../src/app/store/actions/identity/role.action.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_app_store_reducers_BaseReducer__ = __webpack_require__("../../../../../src/app/store/reducers/BaseReducer.ts");


;
/**
 * The initial state, if no state is passed to reducer, this state will be used
 */
var initialState = {
    loading: false,
    container: [],
    error: null,
    lastActionOnReducer: null
};
/**
 * @example The concept of reducer is:
 * Recive an object (state) and an action(with type of the action and the parameter.
 * with the action, the reducer function create an new state based on the state received, modify
 * this new state and return it.
 * this way, the reducer is an Pure function and never can modify the received state.
 * @param state the object to be based a new one
 * @param action the action to create the new state Object
 */
function reducer(state, action) {
    if (state === void 0) { state = initialState; }
    switch (action.type) {
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_role_action__["c" /* CREATE_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type,
                loading: false,
                container: __WEBPACK_IMPORTED_MODULE_1_app_store_reducers_BaseReducer__["b" /* PureInsertOrUpdate */](state.container, state.container[0].insert(action.payload))
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_role_action__["f" /* DELETE_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type,
                loading: false,
                container: __WEBPACK_IMPORTED_MODULE_1_app_store_reducers_BaseReducer__["b" /* PureInsertOrUpdate */](state.container, state.container[0].remove(action.payload))
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_role_action__["m" /* UPDATE_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type,
                loading: false,
                container: __WEBPACK_IMPORTED_MODULE_1_app_store_reducers_BaseReducer__["c" /* PureReplaceEntity */](state.container, action.payload)
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_role_action__["j" /* READ_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type,
                loading: false,
                container: __WEBPACK_IMPORTED_MODULE_1_app_store_reducers_BaseReducer__["b" /* PureInsertOrUpdate */](state.container, action.payload)
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_role_action__["b" /* CREATE */]:
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_role_action__["i" /* READ */]:
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_role_action__["l" /* UPDATE */]:
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_role_action__["e" /* DELETE */]: {
            return Object.assign({}, state, { lastActionOnReducer: action.type, loading: true, error: null });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_role_action__["a" /* ACTION_FAILED */]: {
            return Object.assign({}, state, { lastActionOnReducer: action.type, loading: false, error: action.payload });
        }
        default: {
            return state;
        }
    }
}
var get = function (state) { return state.container.length !== 0 ? state.container[0].values : []; };
//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/role.reducer.js.map

/***/ }),

/***/ "../../../../../src/app/store/reducers/identity/user.reducer.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export initialState */
/* harmony export (immutable) */ __webpack_exports__["a"] = reducer;
/* unused harmony export get */
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_user_action__ = __webpack_require__("../../../../../src/app/store/actions/identity/user.action.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_app_store_reducers_BaseReducer__ = __webpack_require__("../../../../../src/app/store/reducers/BaseReducer.ts");


;
/**
 * The initial state, if no state is passed to reducer, this state will be used
 */
var initialState = {
    loading: false,
    container: [],
    error: null,
    lastActionOnReducer: null
};
/**
 * @example The concept of reducer is:
 * Recive an object (state) and an action(with type of the action and the parameter.
 * with the action, the reducer function create an new state based on the state received, modify
 * this new state and return it.
 * this way, the reducer is an Pure function and never can modify the received state.
 * @param state the object to be based a new one
 * @param action the action to create the new state Object
 */
function reducer(state, action) {
    if (state === void 0) { state = initialState; }
    switch (action.type) {
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_user_action__["d" /* CREATE_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type,
                loading: false,
                container: __WEBPACK_IMPORTED_MODULE_1_app_store_reducers_BaseReducer__["b" /* PureInsertOrUpdate */](state.container, state.container[0].insert(action.payload))
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_user_action__["g" /* DELETE_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type,
                loading: false,
                container: __WEBPACK_IMPORTED_MODULE_1_app_store_reducers_BaseReducer__["b" /* PureInsertOrUpdate */](state.container, state.container[0].remove(action.payload))
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_user_action__["q" /* UPDATE_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type,
                loading: false,
                container: __WEBPACK_IMPORTED_MODULE_1_app_store_reducers_BaseReducer__["c" /* PureReplaceEntity */](state.container, action.payload)
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_user_action__["m" /* READ_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type,
                loading: false,
                container: __WEBPACK_IMPORTED_MODULE_1_app_store_reducers_BaseReducer__["b" /* PureInsertOrUpdate */](state.container, action.payload)
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_user_action__["j" /* PASSWORD_COMPLETE */]: {
            return Object.assign({}, state, { lastActionOnReducer: action.type, loading: false });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_user_action__["n" /* RESET_PASSWORD */]:
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_user_action__["c" /* CREATE */]:
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_user_action__["l" /* READ */]:
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_user_action__["p" /* UPDATE */]:
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_user_action__["f" /* DELETE */]: {
            return Object.assign({}, state, { lastActionOnReducer: action.type, loading: true, error: null });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_identity_user_action__["a" /* ACTION_FAILED */]: {
            return Object.assign({}, state, { lastActionOnReducer: action.type, loading: false, error: action.payload });
        }
        default: {
            return state;
        }
    }
}
var get = function (state) { return state.container.length !== 0 ? state.container[0].values : []; };
//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/user.reducer.js.map

/***/ }),

/***/ "../../../../../src/app/store/reducers/index.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return reducers; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__signs_sign_reducer__ = __webpack_require__("../../../../../src/app/store/reducers/signs/sign.reducer.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__identity_role_reducer__ = __webpack_require__("../../../../../src/app/store/reducers/identity/role.reducer.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__identity_user_reducer__ = __webpack_require__("../../../../../src/app/store/reducers/identity/user.reducer.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__reports_report_reducer__ = __webpack_require__("../../../../../src/app/store/reducers/reports/report.reducer.ts");
/**
 * Every reducer module's default export is the reducer function itself. In
 * addition, each module should export a type or interface that describes
 * the state of the reducer plus any selector functions. The `* as`
 * notation packages up all of the exports into a single object.
 */




/**
 * Because metareducers take a reducer function and return a new reducer,
 * we can use our compose helper to chain them together. Here we are
 * using combineReducers to make our top level reducer, and then
 * wrapping that in storeLogger. Remember that compose applies
 * the result from right to left.
 */
var reducers = {
    sign: __WEBPACK_IMPORTED_MODULE_0__signs_sign_reducer__["a" /* reducer */],
    role: __WEBPACK_IMPORTED_MODULE_1__identity_role_reducer__["a" /* reducer */],
    user: __WEBPACK_IMPORTED_MODULE_2__identity_user_reducer__["a" /* reducer */],
    report: __WEBPACK_IMPORTED_MODULE_3__reports_report_reducer__["e" /* reducer */]
};
//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/index.js.map

/***/ }),

/***/ "../../../../../src/app/store/reducers/reports/report.reducer.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export initialState */
/* harmony export (immutable) */ __webpack_exports__["e"] = reducer;
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return getAplyMonth; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "b", function() { return getAplyWeek; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "c", function() { return getDificultyWeek; });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "d", function() { return getProgressWeek; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_app_store_actions_reports_report_action__ = __webpack_require__("../../../../../src/app/store/actions/reports/report.action.ts");

;
/**
 * The initial state, if no state is passed to reducer, this state will be used
 */
var initialState = {
    loading: 0,
    aplyMonth: [],
    aplyWeek: [],
    dificultyWeek: [],
    progressWeek: [],
    error: null,
    lastActionOnReducer: null
};
/**
 * @example The concept of reducer is:
 * Recive an object (state) and an action(with type of the action and the parameter.
 * with the action, the reducer function create an new state based on the state received, modify
 * this new state and return it.
 * this way, the reducer is an Pure function and never can modify the received state.
 * @param state the object to be based a new one
 * @param action the action to create the new state Object
 */
function reducer(state, action) {
    if (state === void 0) { state = initialState; }
    switch (action.type) {
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_reports_report_action__["t" /* SEND_JSON_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type,
                loading: state.loading - 1
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_reports_report_action__["d" /* LOAD_APLY_MONTH_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type,
                loading: state.loading - 1,
                aplyMonth: action.payload
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_reports_report_action__["f" /* LOAD_APLY_WEEK_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type,
                loading: state.loading - 1,
                aplyWeek: action.payload
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_reports_report_action__["h" /* LOAD_DIFICULTY_WEEK_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type,
                loading: state.loading - 1,
                dificultyWeek: action.payload
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_reports_report_action__["j" /* LOAD_PROGRESS_WEEK_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type,
                loading: state.loading - 1,
                progressWeek: action.payload
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_reports_report_action__["s" /* SEND_JSON */]:
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_reports_report_action__["g" /* LOAD_DIFICULTY_WEEK */]:
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_reports_report_action__["i" /* LOAD_PROGRESS_WEEK */]:
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_reports_report_action__["e" /* LOAD_APLY_WEEK */]:
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_reports_report_action__["c" /* LOAD_APLY_MONTH */]: {
            return Object.assign({}, state, { lastActionOnReducer: action.type, loading: state.loading + 1, error: null });
        }
        case __WEBPACK_IMPORTED_MODULE_0_app_store_actions_reports_report_action__["a" /* ACTION_FAILED */]: {
            return Object.assign({}, state, { lastActionOnReducer: action.type, loading: state.loading - 1, error: action.payload });
        }
        default: {
            return state;
        }
    }
}
var getAplyMonth = function (state) { return state.aplyMonth; };
var getAplyWeek = function (state) { return state.aplyWeek; };
var getDificultyWeek = function (state) { return state.dificultyWeek; };
var getProgressWeek = function (state) { return state.progressWeek; };
//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/report.reducer.js.map

/***/ }),

/***/ "../../../../../src/app/store/reducers/signs/sign.reducer.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* unused harmony export initialState */
/* harmony export (immutable) */ __webpack_exports__["a"] = reducer;
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__ = __webpack_require__("../../../../../src/app/store/actions/signs/sign.action.ts");

;
/**
 * The initial state, if no state is passed to reducer, this state will be used
 */
var initialState = {
    busy: false,
    authenticated: false,
    signupRequested: false,
    emailResent: false,
    tokenActived: false,
    tokenResponse: null,
    error: null,
    domains: [],
    lastActionOnReducer: null
};
/**
 * @example The concept of reducer is:
 * Recive an object (state) and an action(with type of the action and the parameter.
 * with the action, the reducer function create an new state based on the state received, modify
 * this new state and return it.
 * this way, the reducer is an Pure function and never can modify the received state.
 * @param state the object to be based a new one
 * @param action the action to create the new state Object
 */
function reducer(state, action) {
    if (state === void 0) { state = initialState; }
    switch (action.type) {
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["q" /* LOGOUT_COMPLETE */]: {
            return Object.assign({}, initialState, { lastActionOnReducer: action.type });
        }
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["s" /* LOG_IN_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type, busy: false, authenticated: true, tokenResponse: action.payload
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["B" /* SIGNUP_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type, busy: false, error: null, signupRequested: true
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["n" /* EMAIL_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type, busy: false, error: null, emailResent: true
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["h" /* DOMAIN_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type, busy: false, error: null, domains: action.payload
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["b" /* ACCOUNT_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type, busy: false
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["o" /* FAILED */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type, busy: false, error: action.payload
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["f" /* DEFAULT_PASSWORD_COMPLETE */]:
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["F" /* TOKEN_COMPLETE */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type, busy: false
            });
        }
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["e" /* DEFAULT_PASSWORD */]:
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["a" /* ACCOUNT */]:
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["E" /* TOKEN */]:
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["m" /* EMAIL */]:
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["g" /* DOMAIN */]:
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["A" /* SIGNUP */]:
        case __WEBPACK_IMPORTED_MODULE_0__actions_signs_sign_action__["t" /* LOG_IN_REQUEST */]: {
            return Object.assign({}, state, {
                lastActionOnReducer: action.type,
                busy: true,
                authenticated: false,
                signupRequested: false,
                emailResent: false,
                tokenActived: false
            });
        }
        default: {
            return state;
        }
    }
}
//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/sign.reducer.js.map

/***/ }),

/***/ "../../../../../src/app/utils/dialog/dialog.component.html":
/***/ (function(module, exports) {

module.exports = "<h1 md-dialog-title>{{data.title}}</h1>\r\n<div md-dialog-content>\r\n  <p>{{data.question}}</p>\r\n  <md-input-container class=\"full\" *ngIf=\"data.customResponse\">\r\n    <input mdInput tabindex=\"1\" placeholder=\"Resposta\" [(ngModel)]=\"data.response\">\r\n  </md-input-container>\r\n</div>\r\n<div md-dialog-actions>\r\n  <button md-button [md-dialog-close]=\"data.response\" tabindex=\"2\">{{data.okText}}</button>\r\n  <button md-button (click)=\"onNoClick()\" tabindex=\"-1\">{{data.noText}}  <span *ngIf=\"data.timeout > 0\" class=\"pull-right\"> ({{data.timeout}})</span></button>\r\n</div>\r\n"

/***/ }),

/***/ "../../../../../src/app/utils/dialog/dialog.component.scss":
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__("../../../../css-loader/lib/css-base.js")(false);
// imports


// module
exports.push([module.i, "", ""]);

// exports


/*** EXPORTS FROM exports-loader ***/
module.exports = module.exports.toString();

/***/ }),

/***/ "../../../../../src/app/utils/dialog/dialog.component.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return DialogComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_material__ = __webpack_require__("../../../material/@angular/material.es5.js");
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};


var DialogComponent = /** @class */ (function () {
    function DialogComponent(dialogRef, data) {
        this.dialogRef = dialogRef;
        this.data = data;
        this.default = {
            response: true,
            customResponse: false,
            title: 'Waring',
            okText: 'Yes',
            noText: 'Cancel',
            question: 'Confirm the action?',
            timeout: 0,
        };
        this.data = Object.assign({}, this.default, data);
    }
    DialogComponent.prototype.onNoClick = function () {
        this.data.response = false;
        this.dialogRef.close();
    };
    DialogComponent.prototype.ngOnInit = function () {
        if (this.data.timeout > 0) {
            this.CountDown();
        }
    };
    DialogComponent.prototype.CountDown = function () {
        var _this = this;
        setTimeout(function () {
            if (--_this.data.timeout > 0) {
                _this.CountDown();
            }
            else {
                _this.onNoClick();
            }
        }, 1000);
    };
    DialogComponent = __decorate([
        Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Component"])({
            selector: 'app-dialog',
            template: __webpack_require__("../../../../../src/app/utils/dialog/dialog.component.html"),
            styles: [__webpack_require__("../../../../../src/app/utils/dialog/dialog.component.scss")]
        }),
        __param(1, Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["Inject"])(__WEBPACK_IMPORTED_MODULE_1__angular_material__["a" /* MD_DIALOG_DATA */])),
        __metadata("design:paramtypes", [typeof (_a = typeof __WEBPACK_IMPORTED_MODULE_1__angular_material__["d" /* MdDialogRef */] !== "undefined" && __WEBPACK_IMPORTED_MODULE_1__angular_material__["d" /* MdDialogRef */]) === "function" && _a || Object, Object])
    ], DialogComponent);
    return DialogComponent;
    var _a;
}());

//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/dialog.component.js.map

/***/ }),

/***/ "../../../../../src/environments/environment.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return environment; });
// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `angular-cli.json`.
var environment = {
    production: false
};
//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/environment.js.map

/***/ }),

/***/ "../../../../../src/main.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__polyfills_ts__ = __webpack_require__("../../../../../src/polyfills.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_dynamic__ = __webpack_require__("../../../platform-browser-dynamic/@angular/platform-browser-dynamic.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__angular_core__ = __webpack_require__("../../../core/@angular/core.es5.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__environments_environment__ = __webpack_require__("../../../../../src/environments/environment.ts");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_4__app_app_module__ = __webpack_require__("../../../../../src/app/app.module.ts");





if (__WEBPACK_IMPORTED_MODULE_3__environments_environment__["a" /* environment */].production) {
    Object(__WEBPACK_IMPORTED_MODULE_2__angular_core__["enableProdMode"])();
}
Object(__WEBPACK_IMPORTED_MODULE_1__angular_platform_browser_dynamic__["a" /* platformBrowserDynamic */])().bootstrapModule(__WEBPACK_IMPORTED_MODULE_4__app_app_module__["a" /* AppModule */]);
//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/main.js.map

/***/ }),

/***/ "../../../../../src/polyfills.ts":
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_core_js_es6_reflect__ = __webpack_require__("../../../../core-js/es6/reflect.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_core_js_es6_reflect___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_0_core_js_es6_reflect__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_core_js_es7_reflect__ = __webpack_require__("../../../../core-js/es7/reflect.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_core_js_es7_reflect___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_1_core_js_es7_reflect__);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_zone_js_dist_zone__ = __webpack_require__("../../../../zone.js/dist/zone.js");
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2_zone_js_dist_zone___default = __webpack_require__.n(__WEBPACK_IMPORTED_MODULE_2_zone_js_dist_zone__);
/**
 * This file includes polyfills needed by Angular and is loaded before the app.
 * You can add your own extra polyfills to this file.
 *
 * This file is divided into 2 sections:
 *   1. Browser polyfills. These are applied before loading ZoneJS and are sorted by browsers.
 *   2. Application imports. Files imported after ZoneJS that should be loaded before your main
 *      file.
 *
 * The current setup is for so-called "evergreen" browsers; the last versions of browsers that
 * automatically update themselves. This includes Safari >= 10, Chrome >= 55 (including Opera),
 * Edge >= 13 on the desktop, and iOS 10 and Chrome on mobile.
 *
 * Learn more in https://angular.io/docs/ts/latest/guide/browser-support.html
 */
/***************************************************************************************************
 * BROWSER POLYFILLS
 */
/** IE9, IE10 and IE11 requires all of the following polyfills. **/
// import 'core-js/es6/symbol';
// import 'core-js/es6/object';
// import 'core-js/es6/function';
// import 'core-js/es6/parse-int';
// import 'core-js/es6/parse-float';
// import 'core-js/es6/number';
// import 'core-js/es6/math';
// import 'core-js/es6/string';
// import 'core-js/es6/date';
// import 'core-js/es6/array';
// import 'core-js/es6/regexp';
// import 'core-js/es6/map';
// import 'core-js/es6/set';
/** IE10 and IE11 requires the following for NgClass support on SVG elements */
// import 'classlist.js';  // Run `npm install --save classlist.js`.
/** IE10 and IE11 requires the following to support `@angular/animation`. */
// import 'web-animations-js';  // Run `npm install --save web-animations-js`.
/** Evergreen browsers require these. **/


/** ALL Firefox browsers require the following to support `@angular/animation`. **/
// import 'web-animations-js';  // Run `npm install --save web-animations-js`.
/***************************************************************************************************
 * Zone JS is required by Angular itself.
 */
 // Included with Angular-CLI.
/***************************************************************************************************
 * APPLICATION IMPORTS
 */
/**
 * Date, currency, decimal and percent pipes.
 * Needed for: All but Chrome, Firefox, Edge, IE11 and Safari 10
 */
// import 'intl';  // Run `npm install --save intl`.
//# sourceMappingURL=C:/Users/nicol/source/repos/SnappetChallenge/Nicollas.Web/Angular/src/polyfills.js.map

/***/ }),

/***/ 0:
/***/ (function(module, exports, __webpack_require__) {

module.exports = __webpack_require__("../../../../../src/main.ts");


/***/ })

},[0]);
//# sourceMappingURL=main.bundle.js.map