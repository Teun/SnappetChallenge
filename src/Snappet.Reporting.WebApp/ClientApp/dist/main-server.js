(function(e, a) { for(var i in a) e[i] = a[i]; }(exports, /******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId])
/******/ 			return installedModules[moduleId].exports;
/******/
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// identity function for calling harmony imports with the correct context
/******/ 	__webpack_require__.i = function(value) { return value; };
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "/dist/";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 30);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(1))(0);

/***/ }),
/* 1 */
/***/ (function(module, exports) {

module.exports = require("./vendor");

/***/ }),
/* 2 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(1))(70);

/***/ }),
/* 3 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(1))(17);

/***/ }),
/* 4 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(1))(8);

/***/ }),
/* 5 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(1))(98);

/***/ }),
/* 6 */
/***/ (function(module, exports, __webpack_require__) {

/*
 * THIS IS TEMPORARY TO PATCH 2.1.1+ Core bugs
 */
var semver = __webpack_require__(25);
var __core__ = __webpack_require__(0);
var coreVersion = __core__ && __core__.VERSION && __core__.VERSION.full;

// Only patch if you're on Angular >= 2.1.1 and < the next major version (including prerelease)
if (coreVersion && semver.satisfies(coreVersion, '^2.1.1')) {
    var __compiler__ = __webpack_require__(4);
    var __core_private__ = __core__.__core_private__;

    var patch = false;
    if (!__core_private__['ViewUtils']) {
        patch = true;
        __core_private__['ViewUtils'] = __core_private__['view_utils'];
    }

    if (!__compiler__.__compiler_private__) {
        patch = true;
        __compiler__.__compiler_private__ = {
            SelectorMatcher: __compiler__.SelectorMatcher,
            CssSelector: __compiler__.CssSelector
        }
    }

    var __universal__ = __webpack_require__(11);
    if (patch) {
        __universal__.ViewUtils = __core_private__['view_utils'];
        __universal__.CssSelector = __compiler__.CssSelector
        __universal__.SelectorMatcher = __compiler__.SelectorMatcher
    }
}

/***/ }),
/* 7 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(0);
var router_1 = __webpack_require__(29);
var angular2_universal_1 = __webpack_require__(2);
var app_component_1 = __webpack_require__(12);
var navmenu_component_1 = __webpack_require__(15);
var home_component_1 = __webpack_require__(14);
var chartpersubject_component_1 = __webpack_require__(13);
var reportperlearningobjective_component_1 = __webpack_require__(16);
var ng2_charts_1 = __webpack_require__(24);
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        bootstrap: [app_component_1.AppComponent],
        declarations: [
            app_component_1.AppComponent,
            navmenu_component_1.NavMenuComponent,
            chartpersubject_component_1.ChartPerSubjectComponent,
            reportperlearningobjective_component_1.ReportPerLearningObjectiveComponent,
            home_component_1.HomeComponent
        ],
        imports: [
            angular2_universal_1.UniversalModule,
            ng2_charts_1.ChartsModule,
            router_1.RouterModule.forRoot([
                { path: '', redirectTo: 'home', pathMatch: 'full' },
                { path: 'home', component: home_component_1.HomeComponent },
                { path: 'chart-per-subject', component: chartpersubject_component_1.ChartPerSubjectComponent },
                { path: 'report-per-learning-objective', component: reportperlearningobjective_component_1.ReportPerLearningObjectiveComponent },
                { path: '**', redirectTo: 'home' }
            ])
        ]
    })
], AppModule);
exports.AppModule = AppModule;


/***/ }),
/* 8 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(1))(37);

/***/ }),
/* 9 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(1))(69);

/***/ }),
/* 10 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(1))(71);

/***/ }),
/* 11 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var platform_browser_1 = __webpack_require__(28);
var core_1 = __webpack_require__(0);
var compiler_1 = __webpack_require__(4);
var BROWSER_SANITIZATION_PROVIDERS = platform_browser_1.__platform_browser_private__.BROWSER_SANITIZATION_PROVIDERS, SharedStylesHost = platform_browser_1.__platform_browser_private__.SharedStylesHost, DomSharedStylesHost = platform_browser_1.__platform_browser_private__.DomSharedStylesHost, DomRootRenderer = platform_browser_1.__platform_browser_private__.DomRootRenderer, DomEventsPlugin = platform_browser_1.__platform_browser_private__.DomEventsPlugin, KeyEventsPlugin = platform_browser_1.__platform_browser_private__.KeyEventsPlugin, DomAdapter = platform_browser_1.__platform_browser_private__.DomAdapter, setRootDomAdapter = platform_browser_1.__platform_browser_private__.setRootDomAdapter, getDOM = platform_browser_1.__platform_browser_private__.getDOM, HammerGesturesPlugin = platform_browser_1.__platform_browser_private__.HammerGesturesPlugin;
exports.BROWSER_SANITIZATION_PROVIDERS = BROWSER_SANITIZATION_PROVIDERS;
exports.SharedStylesHost = SharedStylesHost;
exports.DomSharedStylesHost = DomSharedStylesHost;
exports.DomRootRenderer = DomRootRenderer;
exports.DomEventsPlugin = DomEventsPlugin;
exports.KeyEventsPlugin = KeyEventsPlugin;
exports.DomAdapter = DomAdapter;
exports.setRootDomAdapter = setRootDomAdapter;
exports.HammerGesturesPlugin = HammerGesturesPlugin;
var ViewUtils = core_1.__core_private__.ViewUtils, AnimationKeyframe = core_1.__core_private__.AnimationKeyframe, AnimationPlayer = core_1.__core_private__.AnimationPlayer, AnimationStyles = core_1.__core_private__.AnimationStyles, RenderDebugInfo = core_1.__core_private__.RenderDebugInfo;
exports.ViewUtils = ViewUtils;
exports.AnimationKeyframe = AnimationKeyframe;
exports.AnimationPlayer = AnimationPlayer;
exports.AnimationStyles = AnimationStyles;
exports.RenderDebugInfo = RenderDebugInfo;
var SelectorMatcher = compiler_1.__compiler_private__.SelectorMatcher, CssSelector = compiler_1.__compiler_private__.CssSelector;
exports.SelectorMatcher = SelectorMatcher;
exports.CssSelector = CssSelector;
var __empty = null;
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = __empty;


/***/ }),
/* 12 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(0);
var AppComponent = (function () {
    function AppComponent() {
    }
    return AppComponent;
}());
AppComponent = __decorate([
    core_1.Component({
        selector: 'app',
        template: __webpack_require__(19),
        styles: [__webpack_require__(26)]
    })
], AppComponent);
exports.AppComponent = AppComponent;


/***/ }),
/* 13 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(0);
var http_1 = __webpack_require__(3);
var ChartPerSubjectComponent = (function () {
    function ChartPerSubjectComponent(http) {
        var _this = this;
        this.barChartOptions = {
            scaleShowVerticalLines: false,
            responsive: true
        };
        this.barChartLabels = [];
        this.barChartType = 'bar';
        this.barChartLegend = true;
        this.barChartData = [
            { data: [], label: 'Gisteren' },
            { data: [], label: 'Vandaag' }
        ];
        this.baseUrl = 'http://localhost:5000';
        var yesterday = new Date(Date.UTC(2015, 2, 23));
        var today = new Date(Date.UTC(2015, 2, 24));
        this.getCorrectAnswersPerSubject(http, yesterday, true).then(function (data) {
            //buggie in Angular, update barChartData.data doesn't update the bar. We need to set a new barChartData object
            //so we clone the current one
            var clone = JSON.parse(JSON.stringify(_this.barChartData));
            //update the first bar
            clone[0].data = data;
            //get data for the next bar
            _this.getCorrectAnswersPerSubject(http, today, false).then(function (data) {
                clone[1].data = data;
                //and finally set a new barChartData
                _this.barChartData = clone;
            });
        });
    }
    ChartPerSubjectComponent.prototype.getCorrectAnswersPerSubject = function (http, date, setLabels) {
        var _this = this;
        return new Promise(function (resolve) {
            http.get(_this.baseUrl + '/reports/CorrectAnswersPerSubject?date=' + date.toJSON()).subscribe(function (result) {
                var subjects = result.json();
                //we only need percentages, extract them to a new array
                var percentages = [];
                for (var i = 0; i < subjects.length; i++) {
                    percentages.push((subjects[i].percentage * 100).toFixed(2));
                    if (setLabels) {
                        _this.barChartLabels.push(subjects[i].subject);
                    }
                }
                resolve(percentages);
            });
        });
    };
    return ChartPerSubjectComponent;
}());
ChartPerSubjectComponent = __decorate([
    core_1.Component({
        selector: 'chartpersubject',
        template: __webpack_require__(20)
    }),
    __metadata("design:paramtypes", [http_1.Http])
], ChartPerSubjectComponent);
exports.ChartPerSubjectComponent = ChartPerSubjectComponent;


/***/ }),
/* 14 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(0);
var HomeComponent = (function () {
    function HomeComponent() {
    }
    return HomeComponent;
}());
HomeComponent = __decorate([
    core_1.Component({
        selector: 'home',
        template: __webpack_require__(21)
    })
], HomeComponent);
exports.HomeComponent = HomeComponent;


/***/ }),
/* 15 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(0);
var NavMenuComponent = (function () {
    function NavMenuComponent() {
    }
    return NavMenuComponent;
}());
NavMenuComponent = __decorate([
    core_1.Component({
        selector: 'nav-menu',
        template: __webpack_require__(22),
        styles: [__webpack_require__(27)]
    })
], NavMenuComponent);
exports.NavMenuComponent = NavMenuComponent;


/***/ }),
/* 16 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(0);
var http_1 = __webpack_require__(3);
var ReportPerLearningObjectiveComponent = (function () {
    function ReportPerLearningObjectiveComponent(http) {
        var _this = this;
        this.baseUrl = 'http://localhost:5000';
        http.get(this.baseUrl + '/reports/CorrectAnswersPerLearningObjective?date=2015-03-24T00:00:00Z').subscribe(function (result) {
            _this.correctAnswersPerLearningObjective = result.json();
        });
    }
    return ReportPerLearningObjectiveComponent;
}());
ReportPerLearningObjectiveComponent = __decorate([
    core_1.Component({
        selector: 'reportperlearningobjective',
        template: __webpack_require__(23)
    }),
    __metadata("design:paramtypes", [http_1.Http])
], ReportPerLearningObjectiveComponent);
exports.ReportPerLearningObjectiveComponent = ReportPerLearningObjectiveComponent;


/***/ }),
/* 17 */
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(5)();
// imports


// module
exports.push([module.i, "@media (max-width: 767px) {\r\n    /* On small screens, the nav menu spans the full width of the screen. Leave a space for it. */\r\n    .body-content {\r\n        padding-top: 50px;\r\n    }\r\n}\r\n", ""]);

// exports


/***/ }),
/* 18 */
/***/ (function(module, exports, __webpack_require__) {

exports = module.exports = __webpack_require__(5)();
// imports


// module
exports.push([module.i, "li .glyphicon {\r\n    margin-right: 10px;\r\n}\r\n\r\n/* Highlighting rules for nav menu items */\r\nli.link-active a,\r\nli.link-active a:hover,\r\nli.link-active a:focus {\r\n    background-color: #4189C7;\r\n    color: white;\r\n}\r\n\r\n/* Keep the nav menu independent of scrolling and on top of other items */\r\n.main-nav {\r\n    position: fixed;\r\n    top: 0;\r\n    left: 0;\r\n    right: 0;\r\n    z-index: 1;\r\n}\r\n\r\n@media (min-width: 768px) {\r\n    /* On small screens, convert the nav menu to a vertical sidebar */\r\n    .main-nav {\r\n        height: 100%;\r\n        width: calc(25% - 20px);\r\n    }\r\n    .navbar {\r\n        border-radius: 0px;\r\n        border-width: 0px;\r\n        height: 100%;\r\n    }\r\n    .navbar-header {\r\n        float: none;\r\n    }\r\n    .navbar-collapse {\r\n        border-top: 1px solid #444;\r\n        padding: 0px;\r\n    }\r\n    .navbar ul {\r\n        float: none;\r\n    }\r\n    .navbar li {\r\n        float: none;\r\n        font-size: 15px;\r\n        margin: 6px;\r\n    }\r\n    .navbar li a {\r\n        padding: 10px 16px;\r\n        border-radius: 4px;\r\n    }\r\n    .navbar a {\r\n        /* If a menu item's text is too long, truncate it */\r\n        width: 100%;\r\n        white-space: nowrap;\r\n        overflow: hidden;\r\n        text-overflow: ellipsis;\r\n    }\r\n}\r\n", ""]);

// exports


/***/ }),
/* 19 */
/***/ (function(module, exports) {

module.exports = "<div class='container-fluid'>\r\n    <div class='row'>\r\n        <div class='col-sm-3'>\r\n            <nav-menu></nav-menu>\r\n        </div>\r\n        <div class='col-sm-9 body-content'>\r\n            <router-outlet></router-outlet>\r\n        </div>\r\n    </div>\r\n</div>\r\n";

/***/ }),
/* 20 */
/***/ (function(module, exports) {

module.exports = "<h1>Antwoorden per onderwerp</h1>\r\n<p>Dit is het percentage correcte antwoorden per onderwerp van vandaag en gisteren.</p>\r\n\r\n<div style=\"display: block\">\r\n    <canvas baseChart\r\n            [datasets]=\"barChartData\"\r\n            [labels]=\"barChartLabels\"\r\n            [options]=\"barChartOptions\"\r\n            [legend]=\"barChartLegend\"\r\n            [chartType]=\"barChartType\"></canvas>\r\n</div>\r\n";

/***/ }),
/* 21 */
/***/ (function(module, exports) {

module.exports = "<h1>Hallo leraar!</h1>\r\n<p>Deze app toont de voortgang van je groep vandaag. Het werkt zelfs op je mobiel, veel plezier!</p>\r\n";

/***/ }),
/* 22 */
/***/ (function(module, exports) {

module.exports = "<div class='main-nav'>\r\n    <div class='navbar navbar-inverse'>\r\n        <div class='navbar-header'>\r\n            <button type='button' class='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>\r\n                <span class='sr-only'>Toggle navigation</span>\r\n                <span class='icon-bar'></span>\r\n                <span class='icon-bar'></span>\r\n                <span class='icon-bar'></span>\r\n            </button>\r\n            <a class='navbar-brand' [routerLink]=\"['/home']\">Snappet Reporting</a>\r\n        </div>\r\n        <div class='clearfix'></div>\r\n        <div class='navbar-collapse collapse'>\r\n            <ul class='nav navbar-nav'>\r\n                <li [routerLinkActive]=\"['link-active']\">\r\n                    <a [routerLink]=\"['/home']\">\r\n                        <span class='glyphicon glyphicon-home'></span>Home\r\n                    </a>\r\n                </li>\r\n                <li [routerLinkActive]=\"['link-active']\">\r\n                    <a [routerLink]=\"['/chart-per-subject']\">\r\n                        <span class='glyphicon glyphicon-stats'></span>Antwoorden per onderwerp\r\n                    </a>\r\n                </li>\r\n                <li [routerLinkActive]=\"['link-active']\">\r\n                    <a [routerLink]=\"['/report-per-learning-objective']\">\r\n                        <span class='glyphicon glyphicon-th-list'></span>Antwoorden per leerdoel\r\n                    </a>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n</div>\r\n";

/***/ }),
/* 23 */
/***/ (function(module, exports) {

module.exports = "<h1>Antwoorden per leerdoel</h1>\r\n<p>Dit is het aantal correcte antwoorden van vandaag per leerdoel.</p>\r\n\r\n<p *ngIf=\"!correctAnswersPerLearningObjective\"><em>Laden...</em></p>\r\n\r\n<table class=\"table\" *ngIf=\"correctAnswersPerLearningObjective\">\r\n    <thead>\r\n        <tr>\r\n            <th class=\"hidden-xs\">Onderwerp</th>\r\n            <th>Leerdoel</th>\r\n            <th class=\"hidden-xs hidden-sm\">Aantal antwoorden</th>\r\n            <th class=\"hidden-xs hidden-sm\">Aantal correct</th>\r\n            <th>Percentage</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n        <tr *ngFor=\"let learningObjective of correctAnswersPerLearningObjective\">\r\n            <td class=\"hidden-xs\">{{ learningObjective.subject }}</td>\r\n            <td>{{ learningObjective.learningObjective }}</td>\r\n            <td class=\"text-right hidden-xs hidden-sm\">{{ learningObjective.total }}</td>\r\n            <td class=\"text-right hidden-xs hidden-sm\">{{ learningObjective.count }}</td>\r\n            <td class=\"text-right\">{{ learningObjective.percentage | percent : '2.2-2' }}</td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n";

/***/ }),
/* 24 */
/***/ (function(module, exports, __webpack_require__) {

(function webpackUniversalModuleDefinition(root, factory) {
	if(true)
		module.exports = factory(__webpack_require__(0));
	else if(typeof define === 'function' && define.amd)
		define(["@angular/core"], factory);
	else if(typeof exports === 'object')
		exports["ng2-charts.umd"] = factory(require("@angular/core"));
	else
		root["ng2-charts.umd"] = factory(root["@angular/core"]);
})(this, function(__WEBPACK_EXTERNAL_MODULE_1__) {
return /******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId])
/******/ 			return installedModules[moduleId].exports;
/******/
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// identity function for calling harmony imports with the correct context
/******/ 	__webpack_require__.i = function(value) { return value; };
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "/";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 2);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ function(module, exports, __webpack_require__) {

"use strict";

var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = __webpack_require__(1);
/* tslint:disable-next-line */
var BaseChartDirective = (function () {
    function BaseChartDirective(element) {
        this.labels = [];
        this.options = {};
        this.chartClick = new core_1.EventEmitter();
        this.chartHover = new core_1.EventEmitter();
        this.initFlag = false;
        this.element = element;
    }
    BaseChartDirective.prototype.ngOnInit = function () {
        this.ctx = this.element.nativeElement.getContext('2d');
        this.cvs = this.element.nativeElement;
        this.initFlag = true;
        if (this.data || this.datasets) {
            this.refresh();
        }
    };
    BaseChartDirective.prototype.ngOnChanges = function (changes) {
        if (this.initFlag) {
            // Check if the changes are in the data or datasets
            if (changes.hasOwnProperty('data') || changes.hasOwnProperty('datasets')) {
                if (changes['data']) {
                    this.updateChartData(changes['data'].currentValue);
                }
                else {
                    this.updateChartData(changes['datasets'].currentValue);
                }
                this.chart.update();
            }
            else {
                // otherwise rebuild the chart
                this.refresh();
            }
        }
    };
    BaseChartDirective.prototype.ngOnDestroy = function () {
        if (this.chart) {
            this.chart.destroy();
            this.chart = void 0;
        }
    };
    BaseChartDirective.prototype.getChartBuilder = function (ctx /*, data:Array<any>, options:any*/) {
        var _this = this;
        var datasets = this.getDatasets();
        var options = Object.assign({}, this.options);
        if (this.legend === false) {
            options.legend = { display: false };
        }
        // hock for onHover and onClick events
        options.hover = options.hover || {};
        if (!options.hover.onHover) {
            options.hover.onHover = function (active) {
                if (active && !active.length) {
                    return;
                }
                _this.chartHover.emit({ active: active });
            };
        }
        if (!options.onClick) {
            options.onClick = function (event, active) {
                _this.chartClick.emit({ event: event, active: active });
            };
        }
        var opts = {
            type: this.chartType,
            data: {
                labels: this.labels,
                datasets: datasets
            },
            options: options
        };
        if (typeof Chart === 'undefined') {
            throw new Error('ng2-charts configuration issue: Embedding Chart.js lib is mandatory');
        }
        return new Chart(ctx, opts);
    };
    BaseChartDirective.prototype.updateChartData = function (newDataValues) {
        if (Array.isArray(newDataValues[0].data)) {
            this.chart.data.datasets.forEach(function (dataset, i) {
                dataset.data = newDataValues[i].data;
                if (newDataValues[i].label) {
                    dataset.label = newDataValues[i].label;
                }
            });
        }
        else {
            this.chart.data.datasets[0].data = newDataValues;
        }
    };
    BaseChartDirective.prototype.getDatasets = function () {
        var _this = this;
        var datasets = void 0;
        // in case if datasets is not provided, but data is present
        if (!this.datasets || !this.datasets.length && (this.data && this.data.length)) {
            if (Array.isArray(this.data[0])) {
                datasets = this.data.map(function (data, index) {
                    return { data: data, label: _this.labels[index] || "Label " + index };
                });
            }
            else {
                datasets = [{ data: this.data, label: "Label 0" }];
            }
        }
        if (this.datasets && this.datasets.length ||
            (datasets && datasets.length)) {
            datasets = (this.datasets || datasets)
                .map(function (elm, index) {
                var newElm = Object.assign({}, elm);
                if (_this.colors && _this.colors.length) {
                    Object.assign(newElm, _this.colors[index]);
                }
                else {
                    Object.assign(newElm, getColors(_this.chartType, index, newElm.data.length));
                }
                return newElm;
            });
        }
        if (!datasets) {
            throw new Error("ng-charts configuration error,\n      data or datasets field are required to render char " + this.chartType);
        }
        return datasets;
    };
    BaseChartDirective.prototype.refresh = function () {
        // if (this.options && this.options.responsive) {
        //   setTimeout(() => this.refresh(), 50);
        // }
        // todo: remove this line, it is producing flickering
        this.ngOnDestroy();
        this.chart = this.getChartBuilder(this.ctx /*, data, this.options*/);
    };
    return BaseChartDirective;
}());
BaseChartDirective.defaultColors = [
    [255, 99, 132],
    [54, 162, 235],
    [255, 206, 86],
    [231, 233, 237],
    [75, 192, 192],
    [151, 187, 205],
    [220, 220, 220],
    [247, 70, 74],
    [70, 191, 189],
    [253, 180, 92],
    [148, 159, 177],
    [77, 83, 96]
];
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], BaseChartDirective.prototype, "data", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], BaseChartDirective.prototype, "datasets", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], BaseChartDirective.prototype, "labels", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Object)
], BaseChartDirective.prototype, "options", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", String)
], BaseChartDirective.prototype, "chartType", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Array)
], BaseChartDirective.prototype, "colors", void 0);
__decorate([
    core_1.Input(),
    __metadata("design:type", Boolean)
], BaseChartDirective.prototype, "legend", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", core_1.EventEmitter)
], BaseChartDirective.prototype, "chartClick", void 0);
__decorate([
    core_1.Output(),
    __metadata("design:type", core_1.EventEmitter)
], BaseChartDirective.prototype, "chartHover", void 0);
BaseChartDirective = __decorate([
    core_1.Directive({ selector: 'canvas[baseChart]', exportAs: 'base-chart' }),
    __metadata("design:paramtypes", [core_1.ElementRef])
], BaseChartDirective);
exports.BaseChartDirective = BaseChartDirective;
function rgba(colour, alpha) {
    return 'rgba(' + colour.concat(alpha).join(',') + ')';
}
function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
function formatLineColor(colors) {
    return {
        backgroundColor: rgba(colors, 0.4),
        borderColor: rgba(colors, 1),
        pointBackgroundColor: rgba(colors, 1),
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: rgba(colors, 0.8)
    };
}
function formatBarColor(colors) {
    return {
        backgroundColor: rgba(colors, 0.6),
        borderColor: rgba(colors, 1),
        hoverBackgroundColor: rgba(colors, 0.8),
        hoverBorderColor: rgba(colors, 1)
    };
}
function formatPieColors(colors) {
    return {
        backgroundColor: colors.map(function (color) { return rgba(color, 0.6); }),
        borderColor: colors.map(function () { return '#fff'; }),
        pointBackgroundColor: colors.map(function (color) { return rgba(color, 1); }),
        pointBorderColor: colors.map(function () { return '#fff'; }),
        pointHoverBackgroundColor: colors.map(function (color) { return rgba(color, 1); }),
        pointHoverBorderColor: colors.map(function (color) { return rgba(color, 1); })
    };
}
function formatPolarAreaColors(colors) {
    return {
        backgroundColor: colors.map(function (color) { return rgba(color, 0.6); }),
        borderColor: colors.map(function (color) { return rgba(color, 1); }),
        hoverBackgroundColor: colors.map(function (color) { return rgba(color, 0.8); }),
        hoverBorderColor: colors.map(function (color) { return rgba(color, 1); })
    };
}
function getRandomColor() {
    return [getRandomInt(0, 255), getRandomInt(0, 255), getRandomInt(0, 255)];
}
/**
 * Generate colors for line|bar charts
 * @param index
 * @returns {number[]|Color}
 */
function generateColor(index) {
    return BaseChartDirective.defaultColors[index] || getRandomColor();
}
/**
 * Generate colors for pie|doughnut charts
 * @param count
 * @returns {Colors}
 */
function generateColors(count) {
    var colorsArr = new Array(count);
    for (var i = 0; i < count; i++) {
        colorsArr[i] = BaseChartDirective.defaultColors[i] || getRandomColor();
    }
    return colorsArr;
}
/**
 * Generate colors by chart type
 * @param chartType
 * @param index
 * @param count
 * @returns {Color}
 */
function getColors(chartType, index, count) {
    if (chartType === 'pie' || chartType === 'doughnut') {
        return formatPieColors(generateColors(count));
    }
    if (chartType === 'polarArea') {
        return formatPolarAreaColors(generateColors(count));
    }
    if (chartType === 'line' || chartType === 'radar') {
        return formatLineColor(generateColor(index));
    }
    if (chartType === 'bar' || chartType === 'horizontalBar') {
        return formatBarColor(generateColor(index));
    }
    return generateColor(index);
}
var ChartsModule = (function () {
    function ChartsModule() {
    }
    return ChartsModule;
}());
ChartsModule = __decorate([
    core_1.NgModule({
        declarations: [
            BaseChartDirective
        ],
        exports: [
            BaseChartDirective
        ],
        imports: []
    })
], ChartsModule);
exports.ChartsModule = ChartsModule;


/***/ },
/* 1 */
/***/ function(module, exports) {

module.exports = __WEBPACK_EXTERNAL_MODULE_1__;

/***/ },
/* 2 */
/***/ function(module, exports, __webpack_require__) {

"use strict";

function __export(m) {
    for (var p in m) if (!exports.hasOwnProperty(p)) exports[p] = m[p];
}
__export(__webpack_require__(0));


/***/ }
/******/ ]);
});
//# sourceMappingURL=ng2-charts.umd.js.map

/***/ }),
/* 25 */
/***/ (function(module, exports) {

exports = module.exports = SemVer;

// The debug function is excluded entirely from the minified version.
/* nomin */ var debug;
/* nomin */ if (typeof process === 'object' &&
    /* nomin */ process.env &&
    /* nomin */ process.env.NODE_DEBUG &&
    /* nomin */ /\bsemver\b/i.test(process.env.NODE_DEBUG))
  /* nomin */ debug = function() {
    /* nomin */ var args = Array.prototype.slice.call(arguments, 0);
    /* nomin */ args.unshift('SEMVER');
    /* nomin */ console.log.apply(console, args);
    /* nomin */ };
/* nomin */ else
  /* nomin */ debug = function() {};

// Note: this is the semver.org version of the spec that it implements
// Not necessarily the package version of this code.
exports.SEMVER_SPEC_VERSION = '2.0.0';

var MAX_LENGTH = 256;
var MAX_SAFE_INTEGER = Number.MAX_SAFE_INTEGER || 9007199254740991;

// The actual regexps go on exports.re
var re = exports.re = [];
var src = exports.src = [];
var R = 0;

// The following Regular Expressions can be used for tokenizing,
// validating, and parsing SemVer version strings.

// ## Numeric Identifier
// A single `0`, or a non-zero digit followed by zero or more digits.

var NUMERICIDENTIFIER = R++;
src[NUMERICIDENTIFIER] = '0|[1-9]\\d*';
var NUMERICIDENTIFIERLOOSE = R++;
src[NUMERICIDENTIFIERLOOSE] = '[0-9]+';


// ## Non-numeric Identifier
// Zero or more digits, followed by a letter or hyphen, and then zero or
// more letters, digits, or hyphens.

var NONNUMERICIDENTIFIER = R++;
src[NONNUMERICIDENTIFIER] = '\\d*[a-zA-Z-][a-zA-Z0-9-]*';


// ## Main Version
// Three dot-separated numeric identifiers.

var MAINVERSION = R++;
src[MAINVERSION] = '(' + src[NUMERICIDENTIFIER] + ')\\.' +
                   '(' + src[NUMERICIDENTIFIER] + ')\\.' +
                   '(' + src[NUMERICIDENTIFIER] + ')';

var MAINVERSIONLOOSE = R++;
src[MAINVERSIONLOOSE] = '(' + src[NUMERICIDENTIFIERLOOSE] + ')\\.' +
                        '(' + src[NUMERICIDENTIFIERLOOSE] + ')\\.' +
                        '(' + src[NUMERICIDENTIFIERLOOSE] + ')';

// ## Pre-release Version Identifier
// A numeric identifier, or a non-numeric identifier.

var PRERELEASEIDENTIFIER = R++;
src[PRERELEASEIDENTIFIER] = '(?:' + src[NUMERICIDENTIFIER] +
                            '|' + src[NONNUMERICIDENTIFIER] + ')';

var PRERELEASEIDENTIFIERLOOSE = R++;
src[PRERELEASEIDENTIFIERLOOSE] = '(?:' + src[NUMERICIDENTIFIERLOOSE] +
                                 '|' + src[NONNUMERICIDENTIFIER] + ')';


// ## Pre-release Version
// Hyphen, followed by one or more dot-separated pre-release version
// identifiers.

var PRERELEASE = R++;
src[PRERELEASE] = '(?:-(' + src[PRERELEASEIDENTIFIER] +
                  '(?:\\.' + src[PRERELEASEIDENTIFIER] + ')*))';

var PRERELEASELOOSE = R++;
src[PRERELEASELOOSE] = '(?:-?(' + src[PRERELEASEIDENTIFIERLOOSE] +
                       '(?:\\.' + src[PRERELEASEIDENTIFIERLOOSE] + ')*))';

// ## Build Metadata Identifier
// Any combination of digits, letters, or hyphens.

var BUILDIDENTIFIER = R++;
src[BUILDIDENTIFIER] = '[0-9A-Za-z-]+';

// ## Build Metadata
// Plus sign, followed by one or more period-separated build metadata
// identifiers.

var BUILD = R++;
src[BUILD] = '(?:\\+(' + src[BUILDIDENTIFIER] +
             '(?:\\.' + src[BUILDIDENTIFIER] + ')*))';


// ## Full Version String
// A main version, followed optionally by a pre-release version and
// build metadata.

// Note that the only major, minor, patch, and pre-release sections of
// the version string are capturing groups.  The build metadata is not a
// capturing group, because it should not ever be used in version
// comparison.

var FULL = R++;
var FULLPLAIN = 'v?' + src[MAINVERSION] +
                src[PRERELEASE] + '?' +
                src[BUILD] + '?';

src[FULL] = '^' + FULLPLAIN + '$';

// like full, but allows v1.2.3 and =1.2.3, which people do sometimes.
// also, 1.0.0alpha1 (prerelease without the hyphen) which is pretty
// common in the npm registry.
var LOOSEPLAIN = '[v=\\s]*' + src[MAINVERSIONLOOSE] +
                 src[PRERELEASELOOSE] + '?' +
                 src[BUILD] + '?';

var LOOSE = R++;
src[LOOSE] = '^' + LOOSEPLAIN + '$';

var GTLT = R++;
src[GTLT] = '((?:<|>)?=?)';

// Something like "2.*" or "1.2.x".
// Note that "x.x" is a valid xRange identifer, meaning "any version"
// Only the first item is strictly required.
var XRANGEIDENTIFIERLOOSE = R++;
src[XRANGEIDENTIFIERLOOSE] = src[NUMERICIDENTIFIERLOOSE] + '|x|X|\\*';
var XRANGEIDENTIFIER = R++;
src[XRANGEIDENTIFIER] = src[NUMERICIDENTIFIER] + '|x|X|\\*';

var XRANGEPLAIN = R++;
src[XRANGEPLAIN] = '[v=\\s]*(' + src[XRANGEIDENTIFIER] + ')' +
                   '(?:\\.(' + src[XRANGEIDENTIFIER] + ')' +
                   '(?:\\.(' + src[XRANGEIDENTIFIER] + ')' +
                   '(?:' + src[PRERELEASE] + ')?' +
                   src[BUILD] + '?' +
                   ')?)?';

var XRANGEPLAINLOOSE = R++;
src[XRANGEPLAINLOOSE] = '[v=\\s]*(' + src[XRANGEIDENTIFIERLOOSE] + ')' +
                        '(?:\\.(' + src[XRANGEIDENTIFIERLOOSE] + ')' +
                        '(?:\\.(' + src[XRANGEIDENTIFIERLOOSE] + ')' +
                        '(?:' + src[PRERELEASELOOSE] + ')?' +
                        src[BUILD] + '?' +
                        ')?)?';

var XRANGE = R++;
src[XRANGE] = '^' + src[GTLT] + '\\s*' + src[XRANGEPLAIN] + '$';
var XRANGELOOSE = R++;
src[XRANGELOOSE] = '^' + src[GTLT] + '\\s*' + src[XRANGEPLAINLOOSE] + '$';

// Tilde ranges.
// Meaning is "reasonably at or greater than"
var LONETILDE = R++;
src[LONETILDE] = '(?:~>?)';

var TILDETRIM = R++;
src[TILDETRIM] = '(\\s*)' + src[LONETILDE] + '\\s+';
re[TILDETRIM] = new RegExp(src[TILDETRIM], 'g');
var tildeTrimReplace = '$1~';

var TILDE = R++;
src[TILDE] = '^' + src[LONETILDE] + src[XRANGEPLAIN] + '$';
var TILDELOOSE = R++;
src[TILDELOOSE] = '^' + src[LONETILDE] + src[XRANGEPLAINLOOSE] + '$';

// Caret ranges.
// Meaning is "at least and backwards compatible with"
var LONECARET = R++;
src[LONECARET] = '(?:\\^)';

var CARETTRIM = R++;
src[CARETTRIM] = '(\\s*)' + src[LONECARET] + '\\s+';
re[CARETTRIM] = new RegExp(src[CARETTRIM], 'g');
var caretTrimReplace = '$1^';

var CARET = R++;
src[CARET] = '^' + src[LONECARET] + src[XRANGEPLAIN] + '$';
var CARETLOOSE = R++;
src[CARETLOOSE] = '^' + src[LONECARET] + src[XRANGEPLAINLOOSE] + '$';

// A simple gt/lt/eq thing, or just "" to indicate "any version"
var COMPARATORLOOSE = R++;
src[COMPARATORLOOSE] = '^' + src[GTLT] + '\\s*(' + LOOSEPLAIN + ')$|^$';
var COMPARATOR = R++;
src[COMPARATOR] = '^' + src[GTLT] + '\\s*(' + FULLPLAIN + ')$|^$';


// An expression to strip any whitespace between the gtlt and the thing
// it modifies, so that `> 1.2.3` ==> `>1.2.3`
var COMPARATORTRIM = R++;
src[COMPARATORTRIM] = '(\\s*)' + src[GTLT] +
                      '\\s*(' + LOOSEPLAIN + '|' + src[XRANGEPLAIN] + ')';

// this one has to use the /g flag
re[COMPARATORTRIM] = new RegExp(src[COMPARATORTRIM], 'g');
var comparatorTrimReplace = '$1$2$3';


// Something like `1.2.3 - 1.2.4`
// Note that these all use the loose form, because they'll be
// checked against either the strict or loose comparator form
// later.
var HYPHENRANGE = R++;
src[HYPHENRANGE] = '^\\s*(' + src[XRANGEPLAIN] + ')' +
                   '\\s+-\\s+' +
                   '(' + src[XRANGEPLAIN] + ')' +
                   '\\s*$';

var HYPHENRANGELOOSE = R++;
src[HYPHENRANGELOOSE] = '^\\s*(' + src[XRANGEPLAINLOOSE] + ')' +
                        '\\s+-\\s+' +
                        '(' + src[XRANGEPLAINLOOSE] + ')' +
                        '\\s*$';

// Star ranges basically just allow anything at all.
var STAR = R++;
src[STAR] = '(<|>)?=?\\s*\\*';

// Compile to actual regexp objects.
// All are flag-free, unless they were created above with a flag.
for (var i = 0; i < R; i++) {
  debug(i, src[i]);
  if (!re[i])
    re[i] = new RegExp(src[i]);
}

exports.parse = parse;
function parse(version, loose) {
  if (version instanceof SemVer)
    return version;

  if (typeof version !== 'string')
    return null;

  if (version.length > MAX_LENGTH)
    return null;

  var r = loose ? re[LOOSE] : re[FULL];
  if (!r.test(version))
    return null;

  try {
    return new SemVer(version, loose);
  } catch (er) {
    return null;
  }
}

exports.valid = valid;
function valid(version, loose) {
  var v = parse(version, loose);
  return v ? v.version : null;
}


exports.clean = clean;
function clean(version, loose) {
  var s = parse(version.trim().replace(/^[=v]+/, ''), loose);
  return s ? s.version : null;
}

exports.SemVer = SemVer;

function SemVer(version, loose) {
  if (version instanceof SemVer) {
    if (version.loose === loose)
      return version;
    else
      version = version.version;
  } else if (typeof version !== 'string') {
    throw new TypeError('Invalid Version: ' + version);
  }

  if (version.length > MAX_LENGTH)
    throw new TypeError('version is longer than ' + MAX_LENGTH + ' characters')

  if (!(this instanceof SemVer))
    return new SemVer(version, loose);

  debug('SemVer', version, loose);
  this.loose = loose;
  var m = version.trim().match(loose ? re[LOOSE] : re[FULL]);

  if (!m)
    throw new TypeError('Invalid Version: ' + version);

  this.raw = version;

  // these are actually numbers
  this.major = +m[1];
  this.minor = +m[2];
  this.patch = +m[3];

  if (this.major > MAX_SAFE_INTEGER || this.major < 0)
    throw new TypeError('Invalid major version')

  if (this.minor > MAX_SAFE_INTEGER || this.minor < 0)
    throw new TypeError('Invalid minor version')

  if (this.patch > MAX_SAFE_INTEGER || this.patch < 0)
    throw new TypeError('Invalid patch version')

  // numberify any prerelease numeric ids
  if (!m[4])
    this.prerelease = [];
  else
    this.prerelease = m[4].split('.').map(function(id) {
      if (/^[0-9]+$/.test(id)) {
        var num = +id;
        if (num >= 0 && num < MAX_SAFE_INTEGER)
          return num;
      }
      return id;
    });

  this.build = m[5] ? m[5].split('.') : [];
  this.format();
}

SemVer.prototype.format = function() {
  this.version = this.major + '.' + this.minor + '.' + this.patch;
  if (this.prerelease.length)
    this.version += '-' + this.prerelease.join('.');
  return this.version;
};

SemVer.prototype.toString = function() {
  return this.version;
};

SemVer.prototype.compare = function(other) {
  debug('SemVer.compare', this.version, this.loose, other);
  if (!(other instanceof SemVer))
    other = new SemVer(other, this.loose);

  return this.compareMain(other) || this.comparePre(other);
};

SemVer.prototype.compareMain = function(other) {
  if (!(other instanceof SemVer))
    other = new SemVer(other, this.loose);

  return compareIdentifiers(this.major, other.major) ||
         compareIdentifiers(this.minor, other.minor) ||
         compareIdentifiers(this.patch, other.patch);
};

SemVer.prototype.comparePre = function(other) {
  if (!(other instanceof SemVer))
    other = new SemVer(other, this.loose);

  // NOT having a prerelease is > having one
  if (this.prerelease.length && !other.prerelease.length)
    return -1;
  else if (!this.prerelease.length && other.prerelease.length)
    return 1;
  else if (!this.prerelease.length && !other.prerelease.length)
    return 0;

  var i = 0;
  do {
    var a = this.prerelease[i];
    var b = other.prerelease[i];
    debug('prerelease compare', i, a, b);
    if (a === undefined && b === undefined)
      return 0;
    else if (b === undefined)
      return 1;
    else if (a === undefined)
      return -1;
    else if (a === b)
      continue;
    else
      return compareIdentifiers(a, b);
  } while (++i);
};

// preminor will bump the version up to the next minor release, and immediately
// down to pre-release. premajor and prepatch work the same way.
SemVer.prototype.inc = function(release, identifier) {
  switch (release) {
    case 'premajor':
      this.prerelease.length = 0;
      this.patch = 0;
      this.minor = 0;
      this.major++;
      this.inc('pre', identifier);
      break;
    case 'preminor':
      this.prerelease.length = 0;
      this.patch = 0;
      this.minor++;
      this.inc('pre', identifier);
      break;
    case 'prepatch':
      // If this is already a prerelease, it will bump to the next version
      // drop any prereleases that might already exist, since they are not
      // relevant at this point.
      this.prerelease.length = 0;
      this.inc('patch', identifier);
      this.inc('pre', identifier);
      break;
    // If the input is a non-prerelease version, this acts the same as
    // prepatch.
    case 'prerelease':
      if (this.prerelease.length === 0)
        this.inc('patch', identifier);
      this.inc('pre', identifier);
      break;

    case 'major':
      // If this is a pre-major version, bump up to the same major version.
      // Otherwise increment major.
      // 1.0.0-5 bumps to 1.0.0
      // 1.1.0 bumps to 2.0.0
      if (this.minor !== 0 || this.patch !== 0 || this.prerelease.length === 0)
        this.major++;
      this.minor = 0;
      this.patch = 0;
      this.prerelease = [];
      break;
    case 'minor':
      // If this is a pre-minor version, bump up to the same minor version.
      // Otherwise increment minor.
      // 1.2.0-5 bumps to 1.2.0
      // 1.2.1 bumps to 1.3.0
      if (this.patch !== 0 || this.prerelease.length === 0)
        this.minor++;
      this.patch = 0;
      this.prerelease = [];
      break;
    case 'patch':
      // If this is not a pre-release version, it will increment the patch.
      // If it is a pre-release it will bump up to the same patch version.
      // 1.2.0-5 patches to 1.2.0
      // 1.2.0 patches to 1.2.1
      if (this.prerelease.length === 0)
        this.patch++;
      this.prerelease = [];
      break;
    // This probably shouldn't be used publicly.
    // 1.0.0 "pre" would become 1.0.0-0 which is the wrong direction.
    case 'pre':
      if (this.prerelease.length === 0)
        this.prerelease = [0];
      else {
        var i = this.prerelease.length;
        while (--i >= 0) {
          if (typeof this.prerelease[i] === 'number') {
            this.prerelease[i]++;
            i = -2;
          }
        }
        if (i === -1) // didn't increment anything
          this.prerelease.push(0);
      }
      if (identifier) {
        // 1.2.0-beta.1 bumps to 1.2.0-beta.2,
        // 1.2.0-beta.fooblz or 1.2.0-beta bumps to 1.2.0-beta.0
        if (this.prerelease[0] === identifier) {
          if (isNaN(this.prerelease[1]))
            this.prerelease = [identifier, 0];
        } else
          this.prerelease = [identifier, 0];
      }
      break;

    default:
      throw new Error('invalid increment argument: ' + release);
  }
  this.format();
  this.raw = this.version;
  return this;
};

exports.inc = inc;
function inc(version, release, loose, identifier) {
  if (typeof(loose) === 'string') {
    identifier = loose;
    loose = undefined;
  }

  try {
    return new SemVer(version, loose).inc(release, identifier).version;
  } catch (er) {
    return null;
  }
}

exports.diff = diff;
function diff(version1, version2) {
  if (eq(version1, version2)) {
    return null;
  } else {
    var v1 = parse(version1);
    var v2 = parse(version2);
    if (v1.prerelease.length || v2.prerelease.length) {
      for (var key in v1) {
        if (key === 'major' || key === 'minor' || key === 'patch') {
          if (v1[key] !== v2[key]) {
            return 'pre'+key;
          }
        }
      }
      return 'prerelease';
    }
    for (var key in v1) {
      if (key === 'major' || key === 'minor' || key === 'patch') {
        if (v1[key] !== v2[key]) {
          return key;
        }
      }
    }
  }
}

exports.compareIdentifiers = compareIdentifiers;

var numeric = /^[0-9]+$/;
function compareIdentifiers(a, b) {
  var anum = numeric.test(a);
  var bnum = numeric.test(b);

  if (anum && bnum) {
    a = +a;
    b = +b;
  }

  return (anum && !bnum) ? -1 :
         (bnum && !anum) ? 1 :
         a < b ? -1 :
         a > b ? 1 :
         0;
}

exports.rcompareIdentifiers = rcompareIdentifiers;
function rcompareIdentifiers(a, b) {
  return compareIdentifiers(b, a);
}

exports.major = major;
function major(a, loose) {
  return new SemVer(a, loose).major;
}

exports.minor = minor;
function minor(a, loose) {
  return new SemVer(a, loose).minor;
}

exports.patch = patch;
function patch(a, loose) {
  return new SemVer(a, loose).patch;
}

exports.compare = compare;
function compare(a, b, loose) {
  return new SemVer(a, loose).compare(b);
}

exports.compareLoose = compareLoose;
function compareLoose(a, b) {
  return compare(a, b, true);
}

exports.rcompare = rcompare;
function rcompare(a, b, loose) {
  return compare(b, a, loose);
}

exports.sort = sort;
function sort(list, loose) {
  return list.sort(function(a, b) {
    return exports.compare(a, b, loose);
  });
}

exports.rsort = rsort;
function rsort(list, loose) {
  return list.sort(function(a, b) {
    return exports.rcompare(a, b, loose);
  });
}

exports.gt = gt;
function gt(a, b, loose) {
  return compare(a, b, loose) > 0;
}

exports.lt = lt;
function lt(a, b, loose) {
  return compare(a, b, loose) < 0;
}

exports.eq = eq;
function eq(a, b, loose) {
  return compare(a, b, loose) === 0;
}

exports.neq = neq;
function neq(a, b, loose) {
  return compare(a, b, loose) !== 0;
}

exports.gte = gte;
function gte(a, b, loose) {
  return compare(a, b, loose) >= 0;
}

exports.lte = lte;
function lte(a, b, loose) {
  return compare(a, b, loose) <= 0;
}

exports.cmp = cmp;
function cmp(a, op, b, loose) {
  var ret;
  switch (op) {
    case '===':
      if (typeof a === 'object') a = a.version;
      if (typeof b === 'object') b = b.version;
      ret = a === b;
      break;
    case '!==':
      if (typeof a === 'object') a = a.version;
      if (typeof b === 'object') b = b.version;
      ret = a !== b;
      break;
    case '': case '=': case '==': ret = eq(a, b, loose); break;
    case '!=': ret = neq(a, b, loose); break;
    case '>': ret = gt(a, b, loose); break;
    case '>=': ret = gte(a, b, loose); break;
    case '<': ret = lt(a, b, loose); break;
    case '<=': ret = lte(a, b, loose); break;
    default: throw new TypeError('Invalid operator: ' + op);
  }
  return ret;
}

exports.Comparator = Comparator;
function Comparator(comp, loose) {
  if (comp instanceof Comparator) {
    if (comp.loose === loose)
      return comp;
    else
      comp = comp.value;
  }

  if (!(this instanceof Comparator))
    return new Comparator(comp, loose);

  debug('comparator', comp, loose);
  this.loose = loose;
  this.parse(comp);

  if (this.semver === ANY)
    this.value = '';
  else
    this.value = this.operator + this.semver.version;

  debug('comp', this);
}

var ANY = {};
Comparator.prototype.parse = function(comp) {
  var r = this.loose ? re[COMPARATORLOOSE] : re[COMPARATOR];
  var m = comp.match(r);

  if (!m)
    throw new TypeError('Invalid comparator: ' + comp);

  this.operator = m[1];
  if (this.operator === '=')
    this.operator = '';

  // if it literally is just '>' or '' then allow anything.
  if (!m[2])
    this.semver = ANY;
  else
    this.semver = new SemVer(m[2], this.loose);
};

Comparator.prototype.toString = function() {
  return this.value;
};

Comparator.prototype.test = function(version) {
  debug('Comparator.test', version, this.loose);

  if (this.semver === ANY)
    return true;

  if (typeof version === 'string')
    version = new SemVer(version, this.loose);

  return cmp(version, this.operator, this.semver, this.loose);
};


exports.Range = Range;
function Range(range, loose) {
  if ((range instanceof Range) && range.loose === loose)
    return range;

  if (!(this instanceof Range))
    return new Range(range, loose);

  this.loose = loose;

  // First, split based on boolean or ||
  this.raw = range;
  this.set = range.split(/\s*\|\|\s*/).map(function(range) {
    return this.parseRange(range.trim());
  }, this).filter(function(c) {
    // throw out any that are not relevant for whatever reason
    return c.length;
  });

  if (!this.set.length) {
    throw new TypeError('Invalid SemVer Range: ' + range);
  }

  this.format();
}

Range.prototype.format = function() {
  this.range = this.set.map(function(comps) {
    return comps.join(' ').trim();
  }).join('||').trim();
  return this.range;
};

Range.prototype.toString = function() {
  return this.range;
};

Range.prototype.parseRange = function(range) {
  var loose = this.loose;
  range = range.trim();
  debug('range', range, loose);
  // `1.2.3 - 1.2.4` => `>=1.2.3 <=1.2.4`
  var hr = loose ? re[HYPHENRANGELOOSE] : re[HYPHENRANGE];
  range = range.replace(hr, hyphenReplace);
  debug('hyphen replace', range);
  // `> 1.2.3 < 1.2.5` => `>1.2.3 <1.2.5`
  range = range.replace(re[COMPARATORTRIM], comparatorTrimReplace);
  debug('comparator trim', range, re[COMPARATORTRIM]);

  // `~ 1.2.3` => `~1.2.3`
  range = range.replace(re[TILDETRIM], tildeTrimReplace);

  // `^ 1.2.3` => `^1.2.3`
  range = range.replace(re[CARETTRIM], caretTrimReplace);

  // normalize spaces
  range = range.split(/\s+/).join(' ');

  // At this point, the range is completely trimmed and
  // ready to be split into comparators.

  var compRe = loose ? re[COMPARATORLOOSE] : re[COMPARATOR];
  var set = range.split(' ').map(function(comp) {
    return parseComparator(comp, loose);
  }).join(' ').split(/\s+/);
  if (this.loose) {
    // in loose mode, throw out any that are not valid comparators
    set = set.filter(function(comp) {
      return !!comp.match(compRe);
    });
  }
  set = set.map(function(comp) {
    return new Comparator(comp, loose);
  });

  return set;
};

// Mostly just for testing and legacy API reasons
exports.toComparators = toComparators;
function toComparators(range, loose) {
  return new Range(range, loose).set.map(function(comp) {
    return comp.map(function(c) {
      return c.value;
    }).join(' ').trim().split(' ');
  });
}

// comprised of xranges, tildes, stars, and gtlt's at this point.
// already replaced the hyphen ranges
// turn into a set of JUST comparators.
function parseComparator(comp, loose) {
  debug('comp', comp);
  comp = replaceCarets(comp, loose);
  debug('caret', comp);
  comp = replaceTildes(comp, loose);
  debug('tildes', comp);
  comp = replaceXRanges(comp, loose);
  debug('xrange', comp);
  comp = replaceStars(comp, loose);
  debug('stars', comp);
  return comp;
}

function isX(id) {
  return !id || id.toLowerCase() === 'x' || id === '*';
}

// ~, ~> --> * (any, kinda silly)
// ~2, ~2.x, ~2.x.x, ~>2, ~>2.x ~>2.x.x --> >=2.0.0 <3.0.0
// ~2.0, ~2.0.x, ~>2.0, ~>2.0.x --> >=2.0.0 <2.1.0
// ~1.2, ~1.2.x, ~>1.2, ~>1.2.x --> >=1.2.0 <1.3.0
// ~1.2.3, ~>1.2.3 --> >=1.2.3 <1.3.0
// ~1.2.0, ~>1.2.0 --> >=1.2.0 <1.3.0
function replaceTildes(comp, loose) {
  return comp.trim().split(/\s+/).map(function(comp) {
    return replaceTilde(comp, loose);
  }).join(' ');
}

function replaceTilde(comp, loose) {
  var r = loose ? re[TILDELOOSE] : re[TILDE];
  return comp.replace(r, function(_, M, m, p, pr) {
    debug('tilde', comp, _, M, m, p, pr);
    var ret;

    if (isX(M))
      ret = '';
    else if (isX(m))
      ret = '>=' + M + '.0.0 <' + (+M + 1) + '.0.0';
    else if (isX(p))
      // ~1.2 == >=1.2.0 <1.3.0
      ret = '>=' + M + '.' + m + '.0 <' + M + '.' + (+m + 1) + '.0';
    else if (pr) {
      debug('replaceTilde pr', pr);
      if (pr.charAt(0) !== '-')
        pr = '-' + pr;
      ret = '>=' + M + '.' + m + '.' + p + pr +
            ' <' + M + '.' + (+m + 1) + '.0';
    } else
      // ~1.2.3 == >=1.2.3 <1.3.0
      ret = '>=' + M + '.' + m + '.' + p +
            ' <' + M + '.' + (+m + 1) + '.0';

    debug('tilde return', ret);
    return ret;
  });
}

// ^ --> * (any, kinda silly)
// ^2, ^2.x, ^2.x.x --> >=2.0.0 <3.0.0
// ^2.0, ^2.0.x --> >=2.0.0 <3.0.0
// ^1.2, ^1.2.x --> >=1.2.0 <2.0.0
// ^1.2.3 --> >=1.2.3 <2.0.0
// ^1.2.0 --> >=1.2.0 <2.0.0
function replaceCarets(comp, loose) {
  return comp.trim().split(/\s+/).map(function(comp) {
    return replaceCaret(comp, loose);
  }).join(' ');
}

function replaceCaret(comp, loose) {
  debug('caret', comp, loose);
  var r = loose ? re[CARETLOOSE] : re[CARET];
  return comp.replace(r, function(_, M, m, p, pr) {
    debug('caret', comp, _, M, m, p, pr);
    var ret;

    if (isX(M))
      ret = '';
    else if (isX(m))
      ret = '>=' + M + '.0.0 <' + (+M + 1) + '.0.0';
    else if (isX(p)) {
      if (M === '0')
        ret = '>=' + M + '.' + m + '.0 <' + M + '.' + (+m + 1) + '.0';
      else
        ret = '>=' + M + '.' + m + '.0 <' + (+M + 1) + '.0.0';
    } else if (pr) {
      debug('replaceCaret pr', pr);
      if (pr.charAt(0) !== '-')
        pr = '-' + pr;
      if (M === '0') {
        if (m === '0')
          ret = '>=' + M + '.' + m + '.' + p + pr +
                ' <' + M + '.' + m + '.' + (+p + 1);
        else
          ret = '>=' + M + '.' + m + '.' + p + pr +
                ' <' + M + '.' + (+m + 1) + '.0';
      } else
        ret = '>=' + M + '.' + m + '.' + p + pr +
              ' <' + (+M + 1) + '.0.0';
    } else {
      debug('no pr');
      if (M === '0') {
        if (m === '0')
          ret = '>=' + M + '.' + m + '.' + p +
                ' <' + M + '.' + m + '.' + (+p + 1);
        else
          ret = '>=' + M + '.' + m + '.' + p +
                ' <' + M + '.' + (+m + 1) + '.0';
      } else
        ret = '>=' + M + '.' + m + '.' + p +
              ' <' + (+M + 1) + '.0.0';
    }

    debug('caret return', ret);
    return ret;
  });
}

function replaceXRanges(comp, loose) {
  debug('replaceXRanges', comp, loose);
  return comp.split(/\s+/).map(function(comp) {
    return replaceXRange(comp, loose);
  }).join(' ');
}

function replaceXRange(comp, loose) {
  comp = comp.trim();
  var r = loose ? re[XRANGELOOSE] : re[XRANGE];
  return comp.replace(r, function(ret, gtlt, M, m, p, pr) {
    debug('xRange', comp, ret, gtlt, M, m, p, pr);
    var xM = isX(M);
    var xm = xM || isX(m);
    var xp = xm || isX(p);
    var anyX = xp;

    if (gtlt === '=' && anyX)
      gtlt = '';

    if (xM) {
      if (gtlt === '>' || gtlt === '<') {
        // nothing is allowed
        ret = '<0.0.0';
      } else {
        // nothing is forbidden
        ret = '*';
      }
    } else if (gtlt && anyX) {
      // replace X with 0
      if (xm)
        m = 0;
      if (xp)
        p = 0;

      if (gtlt === '>') {
        // >1 => >=2.0.0
        // >1.2 => >=1.3.0
        // >1.2.3 => >= 1.2.4
        gtlt = '>=';
        if (xm) {
          M = +M + 1;
          m = 0;
          p = 0;
        } else if (xp) {
          m = +m + 1;
          p = 0;
        }
      } else if (gtlt === '<=') {
        // <=0.7.x is actually <0.8.0, since any 0.7.x should
        // pass.  Similarly, <=7.x is actually <8.0.0, etc.
        gtlt = '<';
        if (xm)
          M = +M + 1;
        else
          m = +m + 1;
      }

      ret = gtlt + M + '.' + m + '.' + p;
    } else if (xm) {
      ret = '>=' + M + '.0.0 <' + (+M + 1) + '.0.0';
    } else if (xp) {
      ret = '>=' + M + '.' + m + '.0 <' + M + '.' + (+m + 1) + '.0';
    }

    debug('xRange return', ret);

    return ret;
  });
}

// Because * is AND-ed with everything else in the comparator,
// and '' means "any version", just remove the *s entirely.
function replaceStars(comp, loose) {
  debug('replaceStars', comp, loose);
  // Looseness is ignored here.  star is always as loose as it gets!
  return comp.trim().replace(re[STAR], '');
}

// This function is passed to string.replace(re[HYPHENRANGE])
// M, m, patch, prerelease, build
// 1.2 - 3.4.5 => >=1.2.0 <=3.4.5
// 1.2.3 - 3.4 => >=1.2.0 <3.5.0 Any 3.4.x will do
// 1.2 - 3.4 => >=1.2.0 <3.5.0
function hyphenReplace($0,
                       from, fM, fm, fp, fpr, fb,
                       to, tM, tm, tp, tpr, tb) {

  if (isX(fM))
    from = '';
  else if (isX(fm))
    from = '>=' + fM + '.0.0';
  else if (isX(fp))
    from = '>=' + fM + '.' + fm + '.0';
  else
    from = '>=' + from;

  if (isX(tM))
    to = '';
  else if (isX(tm))
    to = '<' + (+tM + 1) + '.0.0';
  else if (isX(tp))
    to = '<' + tM + '.' + (+tm + 1) + '.0';
  else if (tpr)
    to = '<=' + tM + '.' + tm + '.' + tp + '-' + tpr;
  else
    to = '<=' + to;

  return (from + ' ' + to).trim();
}


// if ANY of the sets match ALL of its comparators, then pass
Range.prototype.test = function(version) {
  if (!version)
    return false;

  if (typeof version === 'string')
    version = new SemVer(version, this.loose);

  for (var i = 0; i < this.set.length; i++) {
    if (testSet(this.set[i], version))
      return true;
  }
  return false;
};

function testSet(set, version) {
  for (var i = 0; i < set.length; i++) {
    if (!set[i].test(version))
      return false;
  }

  if (version.prerelease.length) {
    // Find the set of versions that are allowed to have prereleases
    // For example, ^1.2.3-pr.1 desugars to >=1.2.3-pr.1 <2.0.0
    // That should allow `1.2.3-pr.2` to pass.
    // However, `1.2.4-alpha.notready` should NOT be allowed,
    // even though it's within the range set by the comparators.
    for (var i = 0; i < set.length; i++) {
      debug(set[i].semver);
      if (set[i].semver === ANY)
        continue;

      if (set[i].semver.prerelease.length > 0) {
        var allowed = set[i].semver;
        if (allowed.major === version.major &&
            allowed.minor === version.minor &&
            allowed.patch === version.patch)
          return true;
      }
    }

    // Version has a -pre, but it's not one of the ones we like.
    return false;
  }

  return true;
}

exports.satisfies = satisfies;
function satisfies(version, range, loose) {
  try {
    range = new Range(range, loose);
  } catch (er) {
    return false;
  }
  return range.test(version);
}

exports.maxSatisfying = maxSatisfying;
function maxSatisfying(versions, range, loose) {
  return versions.filter(function(version) {
    return satisfies(version, range, loose);
  }).sort(function(a, b) {
    return rcompare(a, b, loose);
  })[0] || null;
}

exports.minSatisfying = minSatisfying;
function minSatisfying(versions, range, loose) {
  return versions.filter(function(version) {
    return satisfies(version, range, loose);
  }).sort(function(a, b) {
    return compare(a, b, loose);
  })[0] || null;
}

exports.validRange = validRange;
function validRange(range, loose) {
  try {
    // Return '*' instead of '' so that truthiness works.
    // This will throw if it's invalid anyway
    return new Range(range, loose).range || '*';
  } catch (er) {
    return null;
  }
}

// Determine if version is less than all the versions possible in the range
exports.ltr = ltr;
function ltr(version, range, loose) {
  return outside(version, range, '<', loose);
}

// Determine if version is greater than all the versions possible in the range.
exports.gtr = gtr;
function gtr(version, range, loose) {
  return outside(version, range, '>', loose);
}

exports.outside = outside;
function outside(version, range, hilo, loose) {
  version = new SemVer(version, loose);
  range = new Range(range, loose);

  var gtfn, ltefn, ltfn, comp, ecomp;
  switch (hilo) {
    case '>':
      gtfn = gt;
      ltefn = lte;
      ltfn = lt;
      comp = '>';
      ecomp = '>=';
      break;
    case '<':
      gtfn = lt;
      ltefn = gte;
      ltfn = gt;
      comp = '<';
      ecomp = '<=';
      break;
    default:
      throw new TypeError('Must provide a hilo val of "<" or ">"');
  }

  // If it satisifes the range it is not outside
  if (satisfies(version, range, loose)) {
    return false;
  }

  // From now on, variable terms are as if we're in "gtr" mode.
  // but note that everything is flipped for the "ltr" function.

  for (var i = 0; i < range.set.length; ++i) {
    var comparators = range.set[i];

    var high = null;
    var low = null;

    comparators.forEach(function(comparator) {
      if (comparator.semver === ANY) {
        comparator = new Comparator('>=0.0.0')
      }
      high = high || comparator;
      low = low || comparator;
      if (gtfn(comparator.semver, high.semver, loose)) {
        high = comparator;
      } else if (ltfn(comparator.semver, low.semver, loose)) {
        low = comparator;
      }
    });

    // If the edge version comparator has a operator then our version
    // isn't outside it
    if (high.operator === comp || high.operator === ecomp) {
      return false;
    }

    // If the lowest version comparator has an operator and our version
    // is less than it then it isn't higher than the range
    if ((!low.operator || low.operator === comp) &&
        ltefn(version, low.semver)) {
      return false;
    } else if (low.operator === ecomp && ltfn(version, low.semver)) {
      return false;
    }
  }
  return true;
}

exports.prerelease = prerelease;
function prerelease(version, loose) {
  var parsed = parse(version, loose);
  return (parsed && parsed.prerelease.length) ? parsed.prerelease : null;
}


/***/ }),
/* 26 */
/***/ (function(module, exports, __webpack_require__) {


        var result = __webpack_require__(17);

        if (typeof result === "string") {
            module.exports = result;
        } else {
            module.exports = result.toString();
        }
    

/***/ }),
/* 27 */
/***/ (function(module, exports, __webpack_require__) {


        var result = __webpack_require__(18);

        if (typeof result === "string") {
            module.exports = result;
        } else {
            module.exports = result.toString();
        }
    

/***/ }),
/* 28 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(1))(4);

/***/ }),
/* 29 */
/***/ (function(module, exports, __webpack_require__) {

module.exports = (__webpack_require__(1))(68);

/***/ }),
/* 30 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
__webpack_require__(9);
__webpack_require__(6);
__webpack_require__(8);
var aspnet_prerendering_1 = __webpack_require__(10);
var core_1 = __webpack_require__(0);
var angular2_universal_1 = __webpack_require__(2);
var app_module_1 = __webpack_require__(7);
core_1.enableProdMode();
var platform = angular2_universal_1.platformNodeDynamic();
exports.default = aspnet_prerendering_1.createServerRenderer(function (params) {
    return new Promise(function (resolve, reject) {
        var requestZone = Zone.current.fork({
            name: 'angular-universal request',
            properties: {
                baseUrl: '/',
                requestUrl: params.url,
                originUrl: params.origin,
                preboot: false,
                document: '<app></app>'
            },
            onHandleError: function (parentZone, currentZone, targetZone, error) {
                // If any error occurs while rendering the module, reject the whole operation
                reject(error);
                return true;
            }
        });
        return requestZone.run(function () { return platform.serializeModule(app_module_1.AppModule); }).then(function (html) {
            resolve({ html: html });
        }, reject);
    });
});


/***/ })
/******/ ])));
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly8vd2VicGFjay9ib290c3RyYXAgN2IxMDMxOWI4MGE1NDJhODVkOWMiLCJ3ZWJwYWNrOi8vL2RlbGVnYXRlZCAuL25vZGVfbW9kdWxlcy9AYW5ndWxhci9jb3JlL2J1bmRsZXMvY29yZS51bWQuanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yIiwid2VicGFjazovLy9leHRlcm5hbCBcIi4vdmVuZG9yXCIiLCJ3ZWJwYWNrOi8vL2RlbGVnYXRlZCAuL25vZGVfbW9kdWxlcy9hbmd1bGFyMi11bml2ZXJzYWwvbm9kZS9pbmRleC5qcyBmcm9tIGRsbC1yZWZlcmVuY2UgLi92ZW5kb3IiLCJ3ZWJwYWNrOi8vL2RlbGVnYXRlZCAuL25vZGVfbW9kdWxlcy9AYW5ndWxhci9odHRwL2J1bmRsZXMvaHR0cC51bWQuanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yIiwid2VicGFjazovLy9kZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvQGFuZ3VsYXIvY29tcGlsZXIvYnVuZGxlcy9jb21waWxlci51bWQuanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yIiwid2VicGFjazovLy9kZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvY3NzLWxvYWRlci9saWIvY3NzLWJhc2UuanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yIiwid2VicGFjazovLy8uL34vYW5ndWxhcjItdW5pdmVyc2FsLXBhdGNoL2luZGV4LmpzIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvYXBwLm1vZHVsZS50cyIsIndlYnBhY2s6Ly8vZGVsZWdhdGVkIC4vbm9kZV9tb2R1bGVzL3pvbmUuanMvZGlzdC96b25lLW5vZGUuanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yIiwid2VicGFjazovLy9kZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvYW5ndWxhcjItdW5pdmVyc2FsLXBvbHlmaWxscy9ub2RlLmpzIGZyb20gZGxsLXJlZmVyZW5jZSAuL3ZlbmRvciIsIndlYnBhY2s6Ly8vZGVsZWdhdGVkIC4vbm9kZV9tb2R1bGVzL2FzcG5ldC1wcmVyZW5kZXJpbmcvaW5kZXguanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yIiwid2VicGFjazovLy8uL34vYW5ndWxhcjItcGxhdGZvcm0tbm9kZS9fX3ByaXZhdGVfaW1wb3J0c19fLmpzIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9hcHAvYXBwLmNvbXBvbmVudC50cyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvY2hhcnRwZXJzdWJqZWN0L2NoYXJ0cGVyc3ViamVjdC5jb21wb25lbnQudHMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2hvbWUvaG9tZS5jb21wb25lbnQudHMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL25hdm1lbnUvbmF2bWVudS5jb21wb25lbnQudHMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL3JlcG9ydHBlcmxlYXJuaW5nb2JqZWN0aXZlL3JlcG9ydHBlcmxlYXJuaW5nb2JqZWN0aXZlLmNvbXBvbmVudC50cyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvYXBwL2FwcC5jb21wb25lbnQuY3NzIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9uYXZtZW51L25hdm1lbnUuY29tcG9uZW50LmNzcyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvYXBwL2FwcC5jb21wb25lbnQuaHRtbCIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvY2hhcnRwZXJzdWJqZWN0L2NoYXJ0cGVyc3ViamVjdC5jb21wb25lbnQuaHRtbCIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvaG9tZS9ob21lLmNvbXBvbmVudC5odG1sIiwid2VicGFjazovLy8uL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9uYXZtZW51L25hdm1lbnUuY29tcG9uZW50Lmh0bWwiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL3JlcG9ydHBlcmxlYXJuaW5nb2JqZWN0aXZlL3JlcG9ydHBlcmxlYXJuaW5nb2JqZWN0aXZlLmNvbXBvbmVudC5odG1sIiwid2VicGFjazovLy8uL34vbmcyLWNoYXJ0cy9idW5kbGVzL25nMi1jaGFydHMudW1kLmpzIiwid2VicGFjazovLy8uL34vc2VtdmVyL3NlbXZlci5qcyIsIndlYnBhY2s6Ly8vLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvYXBwL2FwcC5jb21wb25lbnQuY3NzP2RkYzMiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL25hdm1lbnUvbmF2bWVudS5jb21wb25lbnQuY3NzPzlmNjQiLCJ3ZWJwYWNrOi8vL2RlbGVnYXRlZCAuL25vZGVfbW9kdWxlcy9AYW5ndWxhci9wbGF0Zm9ybS1icm93c2VyL2J1bmRsZXMvcGxhdGZvcm0tYnJvd3Nlci51bWQuanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yIiwid2VicGFjazovLy9kZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvQGFuZ3VsYXIvcm91dGVyL2J1bmRsZXMvcm91dGVyLnVtZC5qcyBmcm9tIGRsbC1yZWZlcmVuY2UgLi92ZW5kb3IiLCJ3ZWJwYWNrOi8vLy4vQ2xpZW50QXBwL2Jvb3Qtc2VydmVyLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7QUFBQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOzs7QUFHQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQSxtREFBMkMsY0FBYzs7QUFFekQ7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxhQUFLO0FBQ0w7QUFD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QSxhQUFhO0FBQ2I7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLENBQUM7QUFDRDtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxLQUFLO0FBQ0w7QUFDQTs7O0FBR0EsT0FBTztBQUNQO0FBQ0E7O0FBRUE7O0FBRUEsT0FBTztBQUNQO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7OztBQUdBO0FBQ0E7QUFDQSxDQUFDO0FBQ0QsMEM7Ozs7OztBQ3paQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7OztBQUdBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOzs7QUFHQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTs7O0FBR0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7OztBQUdBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7OztBQUdBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOzs7QUFHQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBLGVBQWUsT0FBTztBQUN0QjtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQSxHQUFHO0FBQ0g7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7OztBQUdBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsR0FBRztBQUNIO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxLQUFLOztBQUVMO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0g7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLFNBQVM7QUFDVDtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQSxHQUFHO0FBQ0g7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsR0FBRztBQUNIO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0g7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0g7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLHdEQUF3RDtBQUN4RCxzQ0FBc0M7QUFDdEMsb0NBQW9DO0FBQ3BDLHNDQUFzQztBQUN0QyxvQ0FBb0M7QUFDcEMsc0NBQXNDO0FBQ3RDO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7OztBQUdBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0g7QUFDQTtBQUNBLEdBQUc7O0FBRUg7QUFDQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0EsR0FBRztBQUNIO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0g7QUFDQTtBQUNBO0FBQ0E7QUFDQSxLQUFLO0FBQ0w7QUFDQTtBQUNBO0FBQ0EsR0FBRzs7QUFFSDtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEtBQUs7QUFDTCxHQUFHO0FBQ0g7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0g7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEtBQUs7QUFDTDtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBLEdBQUc7QUFDSDs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0g7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEtBQUs7QUFDTDtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLE9BQU87QUFDUDtBQUNBO0FBQ0EsS0FBSztBQUNMO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxPQUFPO0FBQ1A7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQSxHQUFHO0FBQ0g7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FB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WUFDbEMsSUFBSSxFQUFFLDJCQUEyQjtZQUNqQyxVQUFVLEVBQUU7Z0JBQ1IsT0FBTyxFQUFFLEdBQUc7Z0JBQ1osVUFBVSxFQUFFLE1BQU0sQ0FBQyxHQUFHO2dCQUN0QixTQUFTLEVBQUUsTUFBTSxDQUFDLE1BQU07Z0JBQ3hCLE9BQU8sRUFBRSxLQUFLO2dCQUNkLFFBQVEsRUFBRSxhQUFhO2FBQzFCO1lBQ0QsYUFBYSxFQUFFLFVBQUMsVUFBVSxFQUFFLFdBQVcsRUFBRSxVQUFVLEVBQUUsS0FBSztnQkFDdEQsNkVBQTZFO2dCQUM3RSxNQUFNLENBQUMsS0FBSyxDQUFDLENBQUM7Z0JBQ2QsTUFBTSxDQUFDLElBQUksQ0FBQztZQUNoQixDQUFDO1NBQ0osQ0FBQyxDQUFDO1FBRUgsTUFBTSxDQUFDLFdBQVcsQ0FBQyxHQUFHLENBQWtCLGNBQU0sZUFBUSxDQUFDLGVBQWUsQ0FBQyxzQkFBUyxDQUFDLEVBQW5DLENBQW1DLENBQUMsQ0FBQyxJQUFJLENBQUMsY0FBSTtZQUN4RixPQUFPLENBQUMsRUFBRSxJQUFJLEVBQUUsSUFBSSxFQUFFLENBQUMsQ0FBQztRQUM1QixDQUFDLEVBQUUsTUFBTSxDQUFDLENBQUM7SUFDZixDQUFDLENBQUMsQ0FBQztBQUNQLENBQUMsQ0FBQyxDQUFDIiwiZmlsZSI6Im1haW4tc2VydmVyLmpzIiwic291cmNlc0NvbnRlbnQiOlsiIFx0Ly8gVGhlIG1vZHVsZSBjYWNoZVxuIFx0dmFyIGluc3RhbGxlZE1vZHVsZXMgPSB7fTtcblxuIFx0Ly8gVGhlIHJlcXVpcmUgZnVuY3Rpb25cbiBcdGZ1bmN0aW9uIF9fd2VicGFja19yZXF1aXJlX18obW9kdWxlSWQpIHtcblxuIFx0XHQvLyBDaGVjayBpZiBtb2R1bGUgaXMgaW4gY2FjaGVcbiBcdFx0aWYoaW5zdGFsbGVkTW9kdWxlc1ttb2R1bGVJZF0pXG4gXHRcdFx0cmV0dXJuIGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdLmV4cG9ydHM7XG5cbiBcdFx0Ly8gQ3JlYXRlIGEgbmV3IG1vZHVsZSAoYW5kIHB1dCBpdCBpbnRvIHRoZSBjYWNoZSlcbiBcdFx0dmFyIG1vZHVsZSA9IGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdID0ge1xuIFx0XHRcdGk6IG1vZHVsZUlkLFxuIFx0XHRcdGw6IGZhbHNlLFxuIFx0XHRcdGV4cG9ydHM6IHt9XG4gXHRcdH07XG5cbiBcdFx0Ly8gRXhlY3V0ZSB0aGUgbW9kdWxlIGZ1bmN0aW9uXG4gXHRcdG1vZHVsZXNbbW9kdWxlSWRdLmNhbGwobW9kdWxlLmV4cG9ydHMsIG1vZHVsZSwgbW9kdWxlLmV4cG9ydHMsIF9fd2VicGFja19yZXF1aXJlX18pO1xuXG4gXHRcdC8vIEZsYWcgdGhlIG1vZHVsZSBhcyBsb2FkZWRcbiBcdFx0bW9kdWxlLmwgPSB0cnVlO1xuXG4gXHRcdC8vIFJldHVybiB0aGUgZXhwb3J0cyBvZiB0aGUgbW9kdWxlXG4gXHRcdHJldHVybiBtb2R1bGUuZXhwb3J0cztcbiBcdH1cblxuXG4gXHQvLyBleHBvc2UgdGhlIG1vZHVsZXMgb2JqZWN0IChfX3dlYnBhY2tfbW9kdWxlc19fKVxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5tID0gbW9kdWxlcztcblxuIFx0Ly8gZXhwb3NlIHRoZSBtb2R1bGUgY2FjaGVcbiBcdF9fd2VicGFja19yZXF1aXJlX18uYyA9IGluc3RhbGxlZE1vZHVsZXM7XG5cbiBcdC8vIGlkZW50aXR5IGZ1bmN0aW9uIGZvciBjYWxsaW5nIGhhcm1vbnkgaW1wb3J0cyB3aXRoIHRoZSBjb3JyZWN0IGNvbnRleHRcbiBcdF9fd2VicGFja19yZXF1aXJlX18uaSA9IGZ1bmN0aW9uKHZhbHVlKSB7IHJldHVybiB2YWx1ZTsgfTtcblxuIFx0Ly8gZGVmaW5lIGdldHRlciBmdW5jdGlvbiBmb3IgaGFybW9ueSBleHBvcnRzXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLmQgPSBmdW5jdGlvbihleHBvcnRzLCBuYW1lLCBnZXR0ZXIpIHtcbiBcdFx0aWYoIV9fd2VicGFja19yZXF1aXJlX18ubyhleHBvcnRzLCBuYW1lKSkge1xuIFx0XHRcdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBuYW1lLCB7XG4gXHRcdFx0XHRjb25maWd1cmFibGU6IGZhbHNlLFxuIFx0XHRcdFx0ZW51bWVyYWJsZTogdHJ1ZSxcbiBcdFx0XHRcdGdldDogZ2V0dGVyXG4gXHRcdFx0fSk7XG4gXHRcdH1cbiBcdH07XG5cbiBcdC8vIGdldERlZmF1bHRFeHBvcnQgZnVuY3Rpb24gZm9yIGNvbXBhdGliaWxpdHkgd2l0aCBub24taGFybW9ueSBtb2R1bGVzXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLm4gPSBmdW5jdGlvbihtb2R1bGUpIHtcbiBcdFx0dmFyIGdldHRlciA9IG1vZHVsZSAmJiBtb2R1bGUuX19lc01vZHVsZSA/XG4gXHRcdFx0ZnVuY3Rpb24gZ2V0RGVmYXVsdCgpIHsgcmV0dXJuIG1vZHVsZVsnZGVmYXVsdCddOyB9IDpcbiBcdFx0XHRmdW5jdGlvbiBnZXRNb2R1bGVFeHBvcnRzKCkgeyByZXR1cm4gbW9kdWxlOyB9O1xuIFx0XHRfX3dlYnBhY2tfcmVxdWlyZV9fLmQoZ2V0dGVyLCAnYScsIGdldHRlcik7XG4gXHRcdHJldHVybiBnZXR0ZXI7XG4gXHR9O1xuXG4gXHQvLyBPYmplY3QucHJvdG90eXBlLmhhc093blByb3BlcnR5LmNhbGxcbiBcdF9fd2VicGFja19yZXF1aXJlX18ubyA9IGZ1bmN0aW9uKG9iamVjdCwgcHJvcGVydHkpIHsgcmV0dXJuIE9iamVjdC5wcm90b3R5cGUuaGFzT3duUHJvcGVydHkuY2FsbChvYmplY3QsIHByb3BlcnR5KTsgfTtcblxuIFx0Ly8gX193ZWJwYWNrX3B1YmxpY19wYXRoX19cbiBcdF9fd2VicGFja19yZXF1aXJlX18ucCA9IFwiL2Rpc3QvXCI7XG5cbiBcdC8vIExvYWQgZW50cnkgbW9kdWxlIGFuZCByZXR1cm4gZXhwb3J0c1xuIFx0cmV0dXJuIF9fd2VicGFja19yZXF1aXJlX18oX193ZWJwYWNrX3JlcXVpcmVfXy5zID0gMzApO1xuXG5cblxuLy8gV0VCUEFDSyBGT09URVIgLy9cbi8vIHdlYnBhY2svYm9vdHN0cmFwIDdiMTAzMTliODBhNTQyYTg1ZDljIiwibW9kdWxlLmV4cG9ydHMgPSAoX193ZWJwYWNrX3JlcXVpcmVfXygxKSkoMCk7XG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gZGVsZWdhdGVkIC4vbm9kZV9tb2R1bGVzL0Bhbmd1bGFyL2NvcmUvYnVuZGxlcy9jb3JlLnVtZC5qcyBmcm9tIGRsbC1yZWZlcmVuY2UgLi92ZW5kb3Jcbi8vIG1vZHVsZSBpZCA9IDBcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwibW9kdWxlLmV4cG9ydHMgPSByZXF1aXJlKFwiLi92ZW5kb3JcIik7XG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gZXh0ZXJuYWwgXCIuL3ZlbmRvclwiXG4vLyBtb2R1bGUgaWQgPSAxXG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsIm1vZHVsZS5leHBvcnRzID0gKF9fd2VicGFja19yZXF1aXJlX18oMSkpKDcwKTtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyBkZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvYW5ndWxhcjItdW5pdmVyc2FsL25vZGUvaW5kZXguanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yXG4vLyBtb2R1bGUgaWQgPSAyXG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsIm1vZHVsZS5leHBvcnRzID0gKF9fd2VicGFja19yZXF1aXJlX18oMSkpKDE3KTtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyBkZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvQGFuZ3VsYXIvaHR0cC9idW5kbGVzL2h0dHAudW1kLmpzIGZyb20gZGxsLXJlZmVyZW5jZSAuL3ZlbmRvclxuLy8gbW9kdWxlIGlkID0gM1xuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJtb2R1bGUuZXhwb3J0cyA9IChfX3dlYnBhY2tfcmVxdWlyZV9fKDEpKSg4KTtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyBkZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvQGFuZ3VsYXIvY29tcGlsZXIvYnVuZGxlcy9jb21waWxlci51bWQuanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yXG4vLyBtb2R1bGUgaWQgPSA0XG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsIm1vZHVsZS5leHBvcnRzID0gKF9fd2VicGFja19yZXF1aXJlX18oMSkpKDk4KTtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyBkZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvY3NzLWxvYWRlci9saWIvY3NzLWJhc2UuanMgZnJvbSBkbGwtcmVmZXJlbmNlIC4vdmVuZG9yXG4vLyBtb2R1bGUgaWQgPSA1XG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsIi8qXG4gKiBUSElTIElTIFRFTVBPUkFSWSBUTyBQQVRDSCAyLjEuMSsgQ29yZSBidWdzXG4gKi9cbnZhciBzZW12ZXIgPSByZXF1aXJlKCdzZW12ZXInKTtcbnZhciBfX2NvcmVfXyA9IHJlcXVpcmUoJ0Bhbmd1bGFyL2NvcmUnKTtcbnZhciBjb3JlVmVyc2lvbiA9IF9fY29yZV9fICYmIF9fY29yZV9fLlZFUlNJT04gJiYgX19jb3JlX18uVkVSU0lPTi5mdWxsO1xuXG4vLyBPbmx5IHBhdGNoIGlmIHlvdSdyZSBvbiBBbmd1bGFyID49IDIuMS4xIGFuZCA8IHRoZSBuZXh0IG1ham9yIHZlcnNpb24gKGluY2x1ZGluZyBwcmVyZWxlYXNlKVxuaWYgKGNvcmVWZXJzaW9uICYmIHNlbXZlci5zYXRpc2ZpZXMoY29yZVZlcnNpb24sICdeMi4xLjEnKSkge1xuICAgIHZhciBfX2NvbXBpbGVyX18gPSByZXF1aXJlKCdAYW5ndWxhci9jb21waWxlcicpO1xuICAgIHZhciBfX2NvcmVfcHJpdmF0ZV9fID0gX19jb3JlX18uX19jb3JlX3ByaXZhdGVfXztcblxuICAgIHZhciBwYXRjaCA9IGZhbHNlO1xuICAgIGlmICghX19jb3JlX3ByaXZhdGVfX1snVmlld1V0aWxzJ10pIHtcbiAgICAgICAgcGF0Y2ggPSB0cnVlO1xuICAgICAgICBfX2NvcmVfcHJpdmF0ZV9fWydWaWV3VXRpbHMnXSA9IF9fY29yZV9wcml2YXRlX19bJ3ZpZXdfdXRpbHMnXTtcbiAgICB9XG5cbiAgICBpZiAoIV9fY29tcGlsZXJfXy5fX2NvbXBpbGVyX3ByaXZhdGVfXykge1xuICAgICAgICBwYXRjaCA9IHRydWU7XG4gICAgICAgIF9fY29tcGlsZXJfXy5fX2NvbXBpbGVyX3ByaXZhdGVfXyA9IHtcbiAgICAgICAgICAgIFNlbGVjdG9yTWF0Y2hlcjogX19jb21waWxlcl9fLlNlbGVjdG9yTWF0Y2hlcixcbiAgICAgICAgICAgIENzc1NlbGVjdG9yOiBfX2NvbXBpbGVyX18uQ3NzU2VsZWN0b3JcbiAgICAgICAgfVxuICAgIH1cblxuICAgIHZhciBfX3VuaXZlcnNhbF9fID0gcmVxdWlyZSgnYW5ndWxhcjItcGxhdGZvcm0tbm9kZS9fX3ByaXZhdGVfaW1wb3J0c19fJyk7XG4gICAgaWYgKHBhdGNoKSB7XG4gICAgICAgIF9fdW5pdmVyc2FsX18uVmlld1V0aWxzID0gX19jb3JlX3ByaXZhdGVfX1sndmlld191dGlscyddO1xuICAgICAgICBfX3VuaXZlcnNhbF9fLkNzc1NlbGVjdG9yID0gX19jb21waWxlcl9fLkNzc1NlbGVjdG9yXG4gICAgICAgIF9fdW5pdmVyc2FsX18uU2VsZWN0b3JNYXRjaGVyID0gX19jb21waWxlcl9fLlNlbGVjdG9yTWF0Y2hlclxuICAgIH1cbn1cblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyAuL34vYW5ndWxhcjItdW5pdmVyc2FsLXBhdGNoL2luZGV4LmpzXG4vLyBtb2R1bGUgaWQgPSA2XG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsImltcG9ydCB7IE5nTW9kdWxlIH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XHJcbmltcG9ydCB7IFJvdXRlck1vZHVsZSB9IGZyb20gJ0Bhbmd1bGFyL3JvdXRlcic7XHJcbmltcG9ydCB7IFVuaXZlcnNhbE1vZHVsZSB9IGZyb20gJ2FuZ3VsYXIyLXVuaXZlcnNhbCc7XHJcbmltcG9ydCB7IEFwcENvbXBvbmVudCB9IGZyb20gJy4vY29tcG9uZW50cy9hcHAvYXBwLmNvbXBvbmVudCdcclxuaW1wb3J0IHsgTmF2TWVudUNvbXBvbmVudCB9IGZyb20gJy4vY29tcG9uZW50cy9uYXZtZW51L25hdm1lbnUuY29tcG9uZW50JztcclxuaW1wb3J0IHsgSG9tZUNvbXBvbmVudCB9IGZyb20gJy4vY29tcG9uZW50cy9ob21lL2hvbWUuY29tcG9uZW50JztcclxuaW1wb3J0IHsgQ2hhcnRQZXJTdWJqZWN0Q29tcG9uZW50IH0gZnJvbSAnLi9jb21wb25lbnRzL2NoYXJ0cGVyc3ViamVjdC9jaGFydHBlcnN1YmplY3QuY29tcG9uZW50JztcclxuaW1wb3J0IHsgUmVwb3J0UGVyTGVhcm5pbmdPYmplY3RpdmVDb21wb25lbnQgfSBmcm9tICcuL2NvbXBvbmVudHMvcmVwb3J0cGVybGVhcm5pbmdvYmplY3RpdmUvcmVwb3J0cGVybGVhcm5pbmdvYmplY3RpdmUuY29tcG9uZW50JztcclxuaW1wb3J0IHsgQ2hhcnRzTW9kdWxlIH0gZnJvbSAnbmcyLWNoYXJ0cyc7XHJcblxyXG5ATmdNb2R1bGUoe1xyXG4gICAgYm9vdHN0cmFwOiBbIEFwcENvbXBvbmVudCBdLFxyXG4gICAgZGVjbGFyYXRpb25zOiBbXHJcbiAgICAgICAgQXBwQ29tcG9uZW50LFxyXG4gICAgICAgIE5hdk1lbnVDb21wb25lbnQsXHJcbiAgICAgICAgQ2hhcnRQZXJTdWJqZWN0Q29tcG9uZW50LFxyXG4gICAgICAgIFJlcG9ydFBlckxlYXJuaW5nT2JqZWN0aXZlQ29tcG9uZW50LFxyXG4gICAgICAgIEhvbWVDb21wb25lbnRcclxuICAgIF0sXHJcbiAgICBpbXBvcnRzOiBbXHJcbiAgICAgICAgVW5pdmVyc2FsTW9kdWxlLCAvLyBtdXN0IGJlIGZpcnN0IGltcG9ydC4gVGhpcyBhdXRvbWF0aWNhbGx5IGltcG9ydHMgQnJvd3Nlck1vZHVsZSwgSHR0cE1vZHVsZSwgYW5kIEpzb25wTW9kdWxlIHRvby5cclxuICAgICAgICBDaGFydHNNb2R1bGUsXHJcbiAgICAgICAgUm91dGVyTW9kdWxlLmZvclJvb3QoW1xyXG4gICAgICAgICAgICB7IHBhdGg6ICcnLCByZWRpcmVjdFRvOiAnaG9tZScsIHBhdGhNYXRjaDogJ2Z1bGwnIH0sXHJcbiAgICAgICAgICAgIHsgcGF0aDogJ2hvbWUnLCBjb21wb25lbnQ6IEhvbWVDb21wb25lbnQgfSxcclxuICAgICAgICAgICAgeyBwYXRoOiAnY2hhcnQtcGVyLXN1YmplY3QnLCBjb21wb25lbnQ6IENoYXJ0UGVyU3ViamVjdENvbXBvbmVudCB9LFxyXG4gICAgICAgICAgICB7IHBhdGg6ICdyZXBvcnQtcGVyLWxlYXJuaW5nLW9iamVjdGl2ZScsIGNvbXBvbmVudDogUmVwb3J0UGVyTGVhcm5pbmdPYmplY3RpdmVDb21wb25lbnQgfSxcclxuICAgICAgICAgICAgeyBwYXRoOiAnKionLCByZWRpcmVjdFRvOiAnaG9tZScgfVxyXG4gICAgICAgIF0pXHJcbiAgICBdXHJcbn0pXHJcbmV4cG9ydCBjbGFzcyBBcHBNb2R1bGUge1xyXG59XHJcblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL34vYW5ndWxhcjItdGVtcGxhdGUtbG9hZGVyIS4vQ2xpZW50QXBwL2FwcC9hcHAubW9kdWxlLnRzIiwibW9kdWxlLmV4cG9ydHMgPSAoX193ZWJwYWNrX3JlcXVpcmVfXygxKSkoMzcpO1xuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIGRlbGVnYXRlZCAuL25vZGVfbW9kdWxlcy96b25lLmpzL2Rpc3Qvem9uZS1ub2RlLmpzIGZyb20gZGxsLXJlZmVyZW5jZSAuL3ZlbmRvclxuLy8gbW9kdWxlIGlkID0gOFxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJtb2R1bGUuZXhwb3J0cyA9IChfX3dlYnBhY2tfcmVxdWlyZV9fKDEpKSg2OSk7XG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gZGVsZWdhdGVkIC4vbm9kZV9tb2R1bGVzL2FuZ3VsYXIyLXVuaXZlcnNhbC1wb2x5ZmlsbHMvbm9kZS5qcyBmcm9tIGRsbC1yZWZlcmVuY2UgLi92ZW5kb3Jcbi8vIG1vZHVsZSBpZCA9IDlcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwibW9kdWxlLmV4cG9ydHMgPSAoX193ZWJwYWNrX3JlcXVpcmVfXygxKSkoNzEpO1xuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIGRlbGVnYXRlZCAuL25vZGVfbW9kdWxlcy9hc3BuZXQtcHJlcmVuZGVyaW5nL2luZGV4LmpzIGZyb20gZGxsLXJlZmVyZW5jZSAuL3ZlbmRvclxuLy8gbW9kdWxlIGlkID0gMTBcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwiXCJ1c2Ugc3RyaWN0XCI7XG52YXIgcGxhdGZvcm1fYnJvd3Nlcl8xID0gcmVxdWlyZSgnQGFuZ3VsYXIvcGxhdGZvcm0tYnJvd3NlcicpO1xudmFyIGNvcmVfMSA9IHJlcXVpcmUoJ0Bhbmd1bGFyL2NvcmUnKTtcbnZhciBjb21waWxlcl8xID0gcmVxdWlyZSgnQGFuZ3VsYXIvY29tcGlsZXInKTtcbnZhciBCUk9XU0VSX1NBTklUSVpBVElPTl9QUk9WSURFUlMgPSBwbGF0Zm9ybV9icm93c2VyXzEuX19wbGF0Zm9ybV9icm93c2VyX3ByaXZhdGVfXy5CUk9XU0VSX1NBTklUSVpBVElPTl9QUk9WSURFUlMsIFNoYXJlZFN0eWxlc0hvc3QgPSBwbGF0Zm9ybV9icm93c2VyXzEuX19wbGF0Zm9ybV9icm93c2VyX3ByaXZhdGVfXy5TaGFyZWRTdHlsZXNIb3N0LCBEb21TaGFyZWRTdHlsZXNIb3N0ID0gcGxhdGZvcm1fYnJvd3Nlcl8xLl9fcGxhdGZvcm1fYnJvd3Nlcl9wcml2YXRlX18uRG9tU2hhcmVkU3R5bGVzSG9zdCwgRG9tUm9vdFJlbmRlcmVyID0gcGxhdGZvcm1fYnJvd3Nlcl8xLl9fcGxhdGZvcm1fYnJvd3Nlcl9wcml2YXRlX18uRG9tUm9vdFJlbmRlcmVyLCBEb21FdmVudHNQbHVnaW4gPSBwbGF0Zm9ybV9icm93c2VyXzEuX19wbGF0Zm9ybV9icm93c2VyX3ByaXZhdGVfXy5Eb21FdmVudHNQbHVnaW4sIEtleUV2ZW50c1BsdWdpbiA9IHBsYXRmb3JtX2Jyb3dzZXJfMS5fX3BsYXRmb3JtX2Jyb3dzZXJfcHJpdmF0ZV9fLktleUV2ZW50c1BsdWdpbiwgRG9tQWRhcHRlciA9IHBsYXRmb3JtX2Jyb3dzZXJfMS5fX3BsYXRmb3JtX2Jyb3dzZXJfcHJpdmF0ZV9fLkRvbUFkYXB0ZXIsIHNldFJvb3REb21BZGFwdGVyID0gcGxhdGZvcm1fYnJvd3Nlcl8xLl9fcGxhdGZvcm1fYnJvd3Nlcl9wcml2YXRlX18uc2V0Um9vdERvbUFkYXB0ZXIsIGdldERPTSA9IHBsYXRmb3JtX2Jyb3dzZXJfMS5fX3BsYXRmb3JtX2Jyb3dzZXJfcHJpdmF0ZV9fLmdldERPTSwgSGFtbWVyR2VzdHVyZXNQbHVnaW4gPSBwbGF0Zm9ybV9icm93c2VyXzEuX19wbGF0Zm9ybV9icm93c2VyX3ByaXZhdGVfXy5IYW1tZXJHZXN0dXJlc1BsdWdpbjtcbmV4cG9ydHMuQlJPV1NFUl9TQU5JVElaQVRJT05fUFJPVklERVJTID0gQlJPV1NFUl9TQU5JVElaQVRJT05fUFJPVklERVJTO1xuZXhwb3J0cy5TaGFyZWRTdHlsZXNIb3N0ID0gU2hhcmVkU3R5bGVzSG9zdDtcbmV4cG9ydHMuRG9tU2hhcmVkU3R5bGVzSG9zdCA9IERvbVNoYXJlZFN0eWxlc0hvc3Q7XG5leHBvcnRzLkRvbVJvb3RSZW5kZXJlciA9IERvbVJvb3RSZW5kZXJlcjtcbmV4cG9ydHMuRG9tRXZlbnRzUGx1Z2luID0gRG9tRXZlbnRzUGx1Z2luO1xuZXhwb3J0cy5LZXlFdmVudHNQbHVnaW4gPSBLZXlFdmVudHNQbHVnaW47XG5leHBvcnRzLkRvbUFkYXB0ZXIgPSBEb21BZGFwdGVyO1xuZXhwb3J0cy5zZXRSb290RG9tQWRhcHRlciA9IHNldFJvb3REb21BZGFwdGVyO1xuZXhwb3J0cy5IYW1tZXJHZXN0dXJlc1BsdWdpbiA9IEhhbW1lckdlc3R1cmVzUGx1Z2luO1xudmFyIFZpZXdVdGlscyA9IGNvcmVfMS5fX2NvcmVfcHJpdmF0ZV9fLlZpZXdVdGlscywgQW5pbWF0aW9uS2V5ZnJhbWUgPSBjb3JlXzEuX19jb3JlX3ByaXZhdGVfXy5BbmltYXRpb25LZXlmcmFtZSwgQW5pbWF0aW9uUGxheWVyID0gY29yZV8xLl9fY29yZV9wcml2YXRlX18uQW5pbWF0aW9uUGxheWVyLCBBbmltYXRpb25TdHlsZXMgPSBjb3JlXzEuX19jb3JlX3ByaXZhdGVfXy5BbmltYXRpb25TdHlsZXMsIFJlbmRlckRlYnVnSW5mbyA9IGNvcmVfMS5fX2NvcmVfcHJpdmF0ZV9fLlJlbmRlckRlYnVnSW5mbztcbmV4cG9ydHMuVmlld1V0aWxzID0gVmlld1V0aWxzO1xuZXhwb3J0cy5BbmltYXRpb25LZXlmcmFtZSA9IEFuaW1hdGlvbktleWZyYW1lO1xuZXhwb3J0cy5BbmltYXRpb25QbGF5ZXIgPSBBbmltYXRpb25QbGF5ZXI7XG5leHBvcnRzLkFuaW1hdGlvblN0eWxlcyA9IEFuaW1hdGlvblN0eWxlcztcbmV4cG9ydHMuUmVuZGVyRGVidWdJbmZvID0gUmVuZGVyRGVidWdJbmZvO1xudmFyIFNlbGVjdG9yTWF0Y2hlciA9IGNvbXBpbGVyXzEuX19jb21waWxlcl9wcml2YXRlX18uU2VsZWN0b3JNYXRjaGVyLCBDc3NTZWxlY3RvciA9IGNvbXBpbGVyXzEuX19jb21waWxlcl9wcml2YXRlX18uQ3NzU2VsZWN0b3I7XG5leHBvcnRzLlNlbGVjdG9yTWF0Y2hlciA9IFNlbGVjdG9yTWF0Y2hlcjtcbmV4cG9ydHMuQ3NzU2VsZWN0b3IgPSBDc3NTZWxlY3RvcjtcbnZhciBfX2VtcHR5ID0gbnVsbDtcbk9iamVjdC5kZWZpbmVQcm9wZXJ0eShleHBvcnRzLCBcIl9fZXNNb2R1bGVcIiwgeyB2YWx1ZTogdHJ1ZSB9KTtcbmV4cG9ydHMuZGVmYXVsdCA9IF9fZW1wdHk7XG5cblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyAuL34vYW5ndWxhcjItcGxhdGZvcm0tbm9kZS9fX3ByaXZhdGVfaW1wb3J0c19fLmpzXG4vLyBtb2R1bGUgaWQgPSAxMVxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJpbXBvcnQgeyBDb21wb25lbnQgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcclxuXHJcbkBDb21wb25lbnQoe1xyXG4gICAgc2VsZWN0b3I6ICdhcHAnLFxyXG4gICAgdGVtcGxhdGU6IHJlcXVpcmUoJy4vYXBwLmNvbXBvbmVudC5odG1sJyksXHJcbiAgICBzdHlsZXM6IFtyZXF1aXJlKCcuL2FwcC5jb21wb25lbnQuY3NzJyldXHJcbn0pXHJcbmV4cG9ydCBjbGFzcyBBcHBDb21wb25lbnQge1xyXG59XHJcblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL34vYW5ndWxhcjItdGVtcGxhdGUtbG9hZGVyIS4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2FwcC9hcHAuY29tcG9uZW50LnRzIiwiaW1wb3J0IHsgQ29tcG9uZW50IH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XHJcbmltcG9ydCB7IEh0dHAgfSBmcm9tICdAYW5ndWxhci9odHRwJztcclxuXHJcbkBDb21wb25lbnQoe1xyXG4gICAgc2VsZWN0b3I6ICdjaGFydHBlcnN1YmplY3QnLFxyXG4gICAgdGVtcGxhdGU6IHJlcXVpcmUoJy4vY2hhcnRwZXJzdWJqZWN0LmNvbXBvbmVudC5odG1sJylcclxufSlcclxuZXhwb3J0IGNsYXNzIENoYXJ0UGVyU3ViamVjdENvbXBvbmVudCB7XHJcbiAgICBwdWJsaWMgYmFyQ2hhcnRPcHRpb25zOiBhbnkgPSB7XHJcbiAgICAgICAgc2NhbGVTaG93VmVydGljYWxMaW5lczogZmFsc2UsXHJcbiAgICAgICAgcmVzcG9uc2l2ZTogdHJ1ZVxyXG4gICAgfTtcclxuICAgIHB1YmxpYyBiYXJDaGFydExhYmVsczogc3RyaW5nW10gPSBbXTtcclxuICAgIHB1YmxpYyBiYXJDaGFydFR5cGU6IHN0cmluZyA9ICdiYXInO1xyXG4gICAgcHVibGljIGJhckNoYXJ0TGVnZW5kOiBib29sZWFuID0gdHJ1ZTtcclxuXHJcbiAgICBwdWJsaWMgYmFyQ2hhcnREYXRhOiBhbnlbXSA9IFtcclxuICAgICAgICB7IGRhdGE6IFtdLCBsYWJlbDogJ0dpc3RlcmVuJyB9LFxyXG4gICAgICAgIHsgZGF0YTogW10sIGxhYmVsOiAnVmFuZGFhZycgfVxyXG4gICAgXTtcclxuXHJcbiAgICBwcml2YXRlIGJhc2VVcmw6IHN0cmluZyA9ICdodHRwOi8vbG9jYWxob3N0OjUwMDAnO1xyXG4gICAgIFxyXG4gICAgY29uc3RydWN0b3IoaHR0cDogSHR0cCkge1xyXG4gICAgICAgIHZhciB5ZXN0ZXJkYXkgPSBuZXcgRGF0ZShEYXRlLlVUQygyMDE1LCAyLCAyMykpO1xyXG4gICAgICAgIHZhciB0b2RheSA9IG5ldyBEYXRlKERhdGUuVVRDKDIwMTUsIDIsIDI0KSk7XHJcblxyXG4gICAgICAgIHRoaXMuZ2V0Q29ycmVjdEFuc3dlcnNQZXJTdWJqZWN0KGh0dHAsIHllc3RlcmRheSwgdHJ1ZSkudGhlbihkYXRhID0+IHtcclxuICAgICAgICAgICAgLy9idWdnaWUgaW4gQW5ndWxhciwgdXBkYXRlIGJhckNoYXJ0RGF0YS5kYXRhIGRvZXNuJ3QgdXBkYXRlIHRoZSBiYXIuIFdlIG5lZWQgdG8gc2V0IGEgbmV3IGJhckNoYXJ0RGF0YSBvYmplY3RcclxuICAgICAgICAgICAgLy9zbyB3ZSBjbG9uZSB0aGUgY3VycmVudCBvbmVcclxuICAgICAgICAgICAgbGV0IGNsb25lID0gSlNPTi5wYXJzZShKU09OLnN0cmluZ2lmeSh0aGlzLmJhckNoYXJ0RGF0YSkpO1xyXG4gICAgICAgICAgICAvL3VwZGF0ZSB0aGUgZmlyc3QgYmFyXHJcbiAgICAgICAgICAgIGNsb25lWzBdLmRhdGEgPSBkYXRhO1xyXG4gICAgICAgICAgICAvL2dldCBkYXRhIGZvciB0aGUgbmV4dCBiYXJcclxuICAgICAgICAgICAgdGhpcy5nZXRDb3JyZWN0QW5zd2Vyc1BlclN1YmplY3QoaHR0cCwgdG9kYXksIGZhbHNlKS50aGVuKGRhdGEgPT4ge1xyXG4gICAgICAgICAgICAgICAgY2xvbmVbMV0uZGF0YSA9IGRhdGE7XHJcbiAgICAgICAgICAgICAgICAvL2FuZCBmaW5hbGx5IHNldCBhIG5ldyBiYXJDaGFydERhdGFcclxuICAgICAgICAgICAgICAgIHRoaXMuYmFyQ2hhcnREYXRhID0gY2xvbmU7XHJcbiAgICAgICAgICAgIH0pO1xyXG4gICAgICAgIH0pO1xyXG5cclxuICAgIH1cclxuXHJcbiAgICBwcml2YXRlIGdldENvcnJlY3RBbnN3ZXJzUGVyU3ViamVjdChodHRwOiBIdHRwLCBkYXRlOiBEYXRlLCBzZXRMYWJlbHM6IGJvb2xlYW4pIHtcclxuICAgICAgICByZXR1cm4gbmV3IFByb21pc2UocmVzb2x2ZSA9PiB7XHJcbiAgICAgICAgICAgIGh0dHAuZ2V0KHRoaXMuYmFzZVVybCArICcvcmVwb3J0cy9Db3JyZWN0QW5zd2Vyc1BlclN1YmplY3Q/ZGF0ZT0nICsgZGF0ZS50b0pTT04oKSkuc3Vic2NyaWJlKHJlc3VsdCA9PiB7XHJcbiAgICAgICAgICAgICAgICB2YXIgc3ViamVjdHMgPSByZXN1bHQuanNvbigpIGFzIENvcnJlY3RBbnN3ZXJzUGVyU3ViamVjdFtdO1xyXG5cclxuICAgICAgICAgICAgICAgIC8vd2Ugb25seSBuZWVkIHBlcmNlbnRhZ2VzLCBleHRyYWN0IHRoZW0gdG8gYSBuZXcgYXJyYXlcclxuICAgICAgICAgICAgICAgIHZhciBwZXJjZW50YWdlcyA9IFtdO1xyXG4gICAgICAgICAgICAgICAgZm9yICh2YXIgaSA9IDA7IGkgPCBzdWJqZWN0cy5sZW5ndGg7IGkrKykge1xyXG4gICAgICAgICAgICAgICAgICAgIHBlcmNlbnRhZ2VzLnB1c2goKHN1YmplY3RzW2ldLnBlcmNlbnRhZ2UgKiAxMDApLnRvRml4ZWQoMikpO1xyXG4gICAgICAgICAgICAgICAgICAgIGlmIChzZXRMYWJlbHMpIHtcclxuICAgICAgICAgICAgICAgICAgICAgICAgdGhpcy5iYXJDaGFydExhYmVscy5wdXNoKHN1YmplY3RzW2ldLnN1YmplY3QpO1xyXG4gICAgICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgIHJlc29sdmUocGVyY2VudGFnZXMpO1xyXG4gICAgICAgICAgICB9KTtcclxuICAgICAgICB9KTtcclxuICAgIH1cclxufVxyXG5cclxuaW50ZXJmYWNlIENvcnJlY3RBbnN3ZXJzUGVyU3ViamVjdCB7XHJcbiAgICBzdWJqZWN0OiBzdHJpbmc7XHJcbiAgICBjb3VudDogbnVtYmVyO1xyXG4gICAgdG90YWw6IG51bWJlcjtcclxuICAgIHBlcmNlbnRhZ2U6IG51bWJlcjtcclxufVxyXG5cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9+L2FuZ3VsYXIyLXRlbXBsYXRlLWxvYWRlciEuL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9jaGFydHBlcnN1YmplY3QvY2hhcnRwZXJzdWJqZWN0LmNvbXBvbmVudC50cyIsImltcG9ydCB7IENvbXBvbmVudCB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xyXG5cclxuQENvbXBvbmVudCh7XHJcbiAgICBzZWxlY3RvcjogJ2hvbWUnLFxyXG4gICAgdGVtcGxhdGU6IHJlcXVpcmUoJy4vaG9tZS5jb21wb25lbnQuaHRtbCcpXHJcbn0pXHJcbmV4cG9ydCBjbGFzcyBIb21lQ29tcG9uZW50IHtcclxufVxyXG5cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9+L2FuZ3VsYXIyLXRlbXBsYXRlLWxvYWRlciEuL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9ob21lL2hvbWUuY29tcG9uZW50LnRzIiwiaW1wb3J0IHsgQ29tcG9uZW50IH0gZnJvbSAnQGFuZ3VsYXIvY29yZSc7XHJcblxyXG5AQ29tcG9uZW50KHtcclxuICAgIHNlbGVjdG9yOiAnbmF2LW1lbnUnLFxyXG4gICAgdGVtcGxhdGU6IHJlcXVpcmUoJy4vbmF2bWVudS5jb21wb25lbnQuaHRtbCcpLFxyXG4gICAgc3R5bGVzOiBbcmVxdWlyZSgnLi9uYXZtZW51LmNvbXBvbmVudC5jc3MnKV1cclxufSlcclxuZXhwb3J0IGNsYXNzIE5hdk1lbnVDb21wb25lbnQge1xyXG59XHJcblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL34vYW5ndWxhcjItdGVtcGxhdGUtbG9hZGVyIS4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL25hdm1lbnUvbmF2bWVudS5jb21wb25lbnQudHMiLCJpbXBvcnQgeyBDb21wb25lbnQgfSBmcm9tICdAYW5ndWxhci9jb3JlJztcclxuaW1wb3J0IHsgSHR0cCB9IGZyb20gJ0Bhbmd1bGFyL2h0dHAnO1xyXG5cclxuQENvbXBvbmVudCh7XHJcbiAgICBzZWxlY3RvcjogJ3JlcG9ydHBlcmxlYXJuaW5nb2JqZWN0aXZlJyxcclxuICAgIHRlbXBsYXRlOiByZXF1aXJlKCcuL3JlcG9ydHBlcmxlYXJuaW5nb2JqZWN0aXZlLmNvbXBvbmVudC5odG1sJylcclxufSlcclxuZXhwb3J0IGNsYXNzIFJlcG9ydFBlckxlYXJuaW5nT2JqZWN0aXZlQ29tcG9uZW50IHtcclxuICAgIHB1YmxpYyBjb3JyZWN0QW5zd2Vyc1BlckxlYXJuaW5nT2JqZWN0aXZlOiBDb3JyZWN0QW5zd2Vyc1BlckxlYXJuaW5nT2JqZWN0aXZlW107XHJcbiAgICBwcml2YXRlIGJhc2VVcmw6IHN0cmluZyA9ICdodHRwOi8vbG9jYWxob3N0OjUwMDAnO1xyXG4gICAgIFxyXG4gICAgY29uc3RydWN0b3IoaHR0cDogSHR0cCkge1xyXG4gICAgICAgIGh0dHAuZ2V0KHRoaXMuYmFzZVVybCArICcvcmVwb3J0cy9Db3JyZWN0QW5zd2Vyc1BlckxlYXJuaW5nT2JqZWN0aXZlP2RhdGU9MjAxNS0wMy0yNFQwMDowMDowMFonKS5zdWJzY3JpYmUocmVzdWx0ID0+IHtcclxuICAgICAgICAgICAgdGhpcy5jb3JyZWN0QW5zd2Vyc1BlckxlYXJuaW5nT2JqZWN0aXZlID0gcmVzdWx0Lmpzb24oKSBhcyBDb3JyZWN0QW5zd2Vyc1BlckxlYXJuaW5nT2JqZWN0aXZlW107XHJcbiAgICAgICAgfSk7XHJcbiAgICB9XHJcbn1cclxuXHJcbmludGVyZmFjZSBDb3JyZWN0QW5zd2Vyc1BlckxlYXJuaW5nT2JqZWN0aXZlIHtcclxuICAgIHN1YmplY3Q6IHN0cmluZztcclxuICAgIGxlYXJuaW5nT2JqZWN0aXZlOiBzdHJpbmc7XHJcbiAgICBjb3VudDogbnVtYmVyO1xyXG4gICAgdG90YWw6IG51bWJlcjtcclxuICAgIHBlcmNlbnRhZ2U6IG51bWJlcjtcclxufVxyXG5cblxuXG4vLyBXRUJQQUNLIEZPT1RFUiAvL1xuLy8gLi9+L2FuZ3VsYXIyLXRlbXBsYXRlLWxvYWRlciEuL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9yZXBvcnRwZXJsZWFybmluZ29iamVjdGl2ZS9yZXBvcnRwZXJsZWFybmluZ29iamVjdGl2ZS5jb21wb25lbnQudHMiLCJleHBvcnRzID0gbW9kdWxlLmV4cG9ydHMgPSByZXF1aXJlKFwiLi4vLi4vLi4vLi4vbm9kZV9tb2R1bGVzL2Nzcy1sb2FkZXIvbGliL2Nzcy1iYXNlLmpzXCIpKCk7XG4vLyBpbXBvcnRzXG5cblxuLy8gbW9kdWxlXG5leHBvcnRzLnB1c2goW21vZHVsZS5pZCwgXCJAbWVkaWEgKG1heC13aWR0aDogNzY3cHgpIHtcXHJcXG4gICAgLyogT24gc21hbGwgc2NyZWVucywgdGhlIG5hdiBtZW51IHNwYW5zIHRoZSBmdWxsIHdpZHRoIG9mIHRoZSBzY3JlZW4uIExlYXZlIGEgc3BhY2UgZm9yIGl0LiAqL1xcclxcbiAgICAuYm9keS1jb250ZW50IHtcXHJcXG4gICAgICAgIHBhZGRpbmctdG9wOiA1MHB4O1xcclxcbiAgICB9XFxyXFxufVxcclxcblwiLCBcIlwiXSk7XG5cbi8vIGV4cG9ydHNcblxuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIC4vfi9jc3MtbG9hZGVyIS4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2FwcC9hcHAuY29tcG9uZW50LmNzc1xuLy8gbW9kdWxlIGlkID0gMTdcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwiZXhwb3J0cyA9IG1vZHVsZS5leHBvcnRzID0gcmVxdWlyZShcIi4uLy4uLy4uLy4uL25vZGVfbW9kdWxlcy9jc3MtbG9hZGVyL2xpYi9jc3MtYmFzZS5qc1wiKSgpO1xuLy8gaW1wb3J0c1xuXG5cbi8vIG1vZHVsZVxuZXhwb3J0cy5wdXNoKFttb2R1bGUuaWQsIFwibGkgLmdseXBoaWNvbiB7XFxyXFxuICAgIG1hcmdpbi1yaWdodDogMTBweDtcXHJcXG59XFxyXFxuXFxyXFxuLyogSGlnaGxpZ2h0aW5nIHJ1bGVzIGZvciBuYXYgbWVudSBpdGVtcyAqL1xcclxcbmxpLmxpbmstYWN0aXZlIGEsXFxyXFxubGkubGluay1hY3RpdmUgYTpob3ZlcixcXHJcXG5saS5saW5rLWFjdGl2ZSBhOmZvY3VzIHtcXHJcXG4gICAgYmFja2dyb3VuZC1jb2xvcjogIzQxODlDNztcXHJcXG4gICAgY29sb3I6IHdoaXRlO1xcclxcbn1cXHJcXG5cXHJcXG4vKiBLZWVwIHRoZSBuYXYgbWVudSBpbmRlcGVuZGVudCBvZiBzY3JvbGxpbmcgYW5kIG9uIHRvcCBvZiBvdGhlciBpdGVtcyAqL1xcclxcbi5tYWluLW5hdiB7XFxyXFxuICAgIHBvc2l0aW9uOiBmaXhlZDtcXHJcXG4gICAgdG9wOiAwO1xcclxcbiAgICBsZWZ0OiAwO1xcclxcbiAgICByaWdodDogMDtcXHJcXG4gICAgei1pbmRleDogMTtcXHJcXG59XFxyXFxuXFxyXFxuQG1lZGlhIChtaW4td2lkdGg6IDc2OHB4KSB7XFxyXFxuICAgIC8qIE9uIHNtYWxsIHNjcmVlbnMsIGNvbnZlcnQgdGhlIG5hdiBtZW51IHRvIGEgdmVydGljYWwgc2lkZWJhciAqL1xcclxcbiAgICAubWFpbi1uYXYge1xcclxcbiAgICAgICAgaGVpZ2h0OiAxMDAlO1xcclxcbiAgICAgICAgd2lkdGg6IGNhbGMoMjUlIC0gMjBweCk7XFxyXFxuICAgIH1cXHJcXG4gICAgLm5hdmJhciB7XFxyXFxuICAgICAgICBib3JkZXItcmFkaXVzOiAwcHg7XFxyXFxuICAgICAgICBib3JkZXItd2lkdGg6IDBweDtcXHJcXG4gICAgICAgIGhlaWdodDogMTAwJTtcXHJcXG4gICAgfVxcclxcbiAgICAubmF2YmFyLWhlYWRlciB7XFxyXFxuICAgICAgICBmbG9hdDogbm9uZTtcXHJcXG4gICAgfVxcclxcbiAgICAubmF2YmFyLWNvbGxhcHNlIHtcXHJcXG4gICAgICAgIGJvcmRlci10b3A6IDFweCBzb2xpZCAjNDQ0O1xcclxcbiAgICAgICAgcGFkZGluZzogMHB4O1xcclxcbiAgICB9XFxyXFxuICAgIC5uYXZiYXIgdWwge1xcclxcbiAgICAgICAgZmxvYXQ6IG5vbmU7XFxyXFxuICAgIH1cXHJcXG4gICAgLm5hdmJhciBsaSB7XFxyXFxuICAgICAgICBmbG9hdDogbm9uZTtcXHJcXG4gICAgICAgIGZvbnQtc2l6ZTogMTVweDtcXHJcXG4gICAgICAgIG1hcmdpbjogNnB4O1xcclxcbiAgICB9XFxyXFxuICAgIC5uYXZiYXIgbGkgYSB7XFxyXFxuICAgICAgICBwYWRkaW5nOiAxMHB4IDE2cHg7XFxyXFxuICAgICAgICBib3JkZXItcmFkaXVzOiA0cHg7XFxyXFxuICAgIH1cXHJcXG4gICAgLm5hdmJhciBhIHtcXHJcXG4gICAgICAgIC8qIElmIGEgbWVudSBpdGVtJ3MgdGV4dCBpcyB0b28gbG9uZywgdHJ1bmNhdGUgaXQgKi9cXHJcXG4gICAgICAgIHdpZHRoOiAxMDAlO1xcclxcbiAgICAgICAgd2hpdGUtc3BhY2U6IG5vd3JhcDtcXHJcXG4gICAgICAgIG92ZXJmbG93OiBoaWRkZW47XFxyXFxuICAgICAgICB0ZXh0LW92ZXJmbG93OiBlbGxpcHNpcztcXHJcXG4gICAgfVxcclxcbn1cXHJcXG5cIiwgXCJcIl0pO1xuXG4vLyBleHBvcnRzXG5cblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyAuL34vY3NzLWxvYWRlciEuL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9uYXZtZW51L25hdm1lbnUuY29tcG9uZW50LmNzc1xuLy8gbW9kdWxlIGlkID0gMThcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwibW9kdWxlLmV4cG9ydHMgPSBcIjxkaXYgY2xhc3M9J2NvbnRhaW5lci1mbHVpZCc+XFxyXFxuICAgIDxkaXYgY2xhc3M9J3Jvdyc+XFxyXFxuICAgICAgICA8ZGl2IGNsYXNzPSdjb2wtc20tMyc+XFxyXFxuICAgICAgICAgICAgPG5hdi1tZW51PjwvbmF2LW1lbnU+XFxyXFxuICAgICAgICA8L2Rpdj5cXHJcXG4gICAgICAgIDxkaXYgY2xhc3M9J2NvbC1zbS05IGJvZHktY29udGVudCc+XFxyXFxuICAgICAgICAgICAgPHJvdXRlci1vdXRsZXQ+PC9yb3V0ZXItb3V0bGV0PlxcclxcbiAgICAgICAgPC9kaXY+XFxyXFxuICAgIDwvZGl2PlxcclxcbjwvZGl2PlxcclxcblwiO1xuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIC4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL2FwcC9hcHAuY29tcG9uZW50Lmh0bWxcbi8vIG1vZHVsZSBpZCA9IDE5XG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsIm1vZHVsZS5leHBvcnRzID0gXCI8aDE+QW50d29vcmRlbiBwZXIgb25kZXJ3ZXJwPC9oMT5cXHJcXG48cD5EaXQgaXMgaGV0IHBlcmNlbnRhZ2UgY29ycmVjdGUgYW50d29vcmRlbiBwZXIgb25kZXJ3ZXJwIHZhbiB2YW5kYWFnIGVuIGdpc3RlcmVuLjwvcD5cXHJcXG5cXHJcXG48ZGl2IHN0eWxlPVxcXCJkaXNwbGF5OiBibG9ja1xcXCI+XFxyXFxuICAgIDxjYW52YXMgYmFzZUNoYXJ0XFxyXFxuICAgICAgICAgICAgW2RhdGFzZXRzXT1cXFwiYmFyQ2hhcnREYXRhXFxcIlxcclxcbiAgICAgICAgICAgIFtsYWJlbHNdPVxcXCJiYXJDaGFydExhYmVsc1xcXCJcXHJcXG4gICAgICAgICAgICBbb3B0aW9uc109XFxcImJhckNoYXJ0T3B0aW9uc1xcXCJcXHJcXG4gICAgICAgICAgICBbbGVnZW5kXT1cXFwiYmFyQ2hhcnRMZWdlbmRcXFwiXFxyXFxuICAgICAgICAgICAgW2NoYXJ0VHlwZV09XFxcImJhckNoYXJ0VHlwZVxcXCI+PC9jYW52YXM+XFxyXFxuPC9kaXY+XFxyXFxuXCI7XG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvY2hhcnRwZXJzdWJqZWN0L2NoYXJ0cGVyc3ViamVjdC5jb21wb25lbnQuaHRtbFxuLy8gbW9kdWxlIGlkID0gMjBcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwibW9kdWxlLmV4cG9ydHMgPSBcIjxoMT5IYWxsbyBsZXJhYXIhPC9oMT5cXHJcXG48cD5EZXplIGFwcCB0b29udCBkZSB2b29ydGdhbmcgdmFuIGplIGdyb2VwIHZhbmRhYWcuIEhldCB3ZXJrdCB6ZWxmcyBvcCBqZSBtb2JpZWwsIHZlZWwgcGxlemllciE8L3A+XFxyXFxuXCI7XG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvaG9tZS9ob21lLmNvbXBvbmVudC5odG1sXG4vLyBtb2R1bGUgaWQgPSAyMVxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJtb2R1bGUuZXhwb3J0cyA9IFwiPGRpdiBjbGFzcz0nbWFpbi1uYXYnPlxcclxcbiAgICA8ZGl2IGNsYXNzPSduYXZiYXIgbmF2YmFyLWludmVyc2UnPlxcclxcbiAgICAgICAgPGRpdiBjbGFzcz0nbmF2YmFyLWhlYWRlcic+XFxyXFxuICAgICAgICAgICAgPGJ1dHRvbiB0eXBlPSdidXR0b24nIGNsYXNzPSduYXZiYXItdG9nZ2xlJyBkYXRhLXRvZ2dsZT0nY29sbGFwc2UnIGRhdGEtdGFyZ2V0PScubmF2YmFyLWNvbGxhcHNlJz5cXHJcXG4gICAgICAgICAgICAgICAgPHNwYW4gY2xhc3M9J3NyLW9ubHknPlRvZ2dsZSBuYXZpZ2F0aW9uPC9zcGFuPlxcclxcbiAgICAgICAgICAgICAgICA8c3BhbiBjbGFzcz0naWNvbi1iYXInPjwvc3Bhbj5cXHJcXG4gICAgICAgICAgICAgICAgPHNwYW4gY2xhc3M9J2ljb24tYmFyJz48L3NwYW4+XFxyXFxuICAgICAgICAgICAgICAgIDxzcGFuIGNsYXNzPSdpY29uLWJhcic+PC9zcGFuPlxcclxcbiAgICAgICAgICAgIDwvYnV0dG9uPlxcclxcbiAgICAgICAgICAgIDxhIGNsYXNzPSduYXZiYXItYnJhbmQnIFtyb3V0ZXJMaW5rXT1cXFwiWycvaG9tZSddXFxcIj5TbmFwcGV0IFJlcG9ydGluZzwvYT5cXHJcXG4gICAgICAgIDwvZGl2PlxcclxcbiAgICAgICAgPGRpdiBjbGFzcz0nY2xlYXJmaXgnPjwvZGl2PlxcclxcbiAgICAgICAgPGRpdiBjbGFzcz0nbmF2YmFyLWNvbGxhcHNlIGNvbGxhcHNlJz5cXHJcXG4gICAgICAgICAgICA8dWwgY2xhc3M9J25hdiBuYXZiYXItbmF2Jz5cXHJcXG4gICAgICAgICAgICAgICAgPGxpIFtyb3V0ZXJMaW5rQWN0aXZlXT1cXFwiWydsaW5rLWFjdGl2ZSddXFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgICAgIDxhIFtyb3V0ZXJMaW5rXT1cXFwiWycvaG9tZSddXFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8c3BhbiBjbGFzcz0nZ2x5cGhpY29uIGdseXBoaWNvbi1ob21lJz48L3NwYW4+SG9tZVxcclxcbiAgICAgICAgICAgICAgICAgICAgPC9hPlxcclxcbiAgICAgICAgICAgICAgICA8L2xpPlxcclxcbiAgICAgICAgICAgICAgICA8bGkgW3JvdXRlckxpbmtBY3RpdmVdPVxcXCJbJ2xpbmstYWN0aXZlJ11cXFwiPlxcclxcbiAgICAgICAgICAgICAgICAgICAgPGEgW3JvdXRlckxpbmtdPVxcXCJbJy9jaGFydC1wZXItc3ViamVjdCddXFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8c3BhbiBjbGFzcz0nZ2x5cGhpY29uIGdseXBoaWNvbi1zdGF0cyc+PC9zcGFuPkFudHdvb3JkZW4gcGVyIG9uZGVyd2VycFxcclxcbiAgICAgICAgICAgICAgICAgICAgPC9hPlxcclxcbiAgICAgICAgICAgICAgICA8L2xpPlxcclxcbiAgICAgICAgICAgICAgICA8bGkgW3JvdXRlckxpbmtBY3RpdmVdPVxcXCJbJ2xpbmstYWN0aXZlJ11cXFwiPlxcclxcbiAgICAgICAgICAgICAgICAgICAgPGEgW3JvdXRlckxpbmtdPVxcXCJbJy9yZXBvcnQtcGVyLWxlYXJuaW5nLW9iamVjdGl2ZSddXFxcIj5cXHJcXG4gICAgICAgICAgICAgICAgICAgICAgICA8c3BhbiBjbGFzcz0nZ2x5cGhpY29uIGdseXBoaWNvbi10aC1saXN0Jz48L3NwYW4+QW50d29vcmRlbiBwZXIgbGVlcmRvZWxcXHJcXG4gICAgICAgICAgICAgICAgICAgIDwvYT5cXHJcXG4gICAgICAgICAgICAgICAgPC9saT5cXHJcXG4gICAgICAgICAgICA8L3VsPlxcclxcbiAgICAgICAgPC9kaXY+XFxyXFxuICAgIDwvZGl2PlxcclxcbjwvZGl2PlxcclxcblwiO1xuXG5cbi8vLy8vLy8vLy8vLy8vLy8vL1xuLy8gV0VCUEFDSyBGT09URVJcbi8vIC4vQ2xpZW50QXBwL2FwcC9jb21wb25lbnRzL25hdm1lbnUvbmF2bWVudS5jb21wb25lbnQuaHRtbFxuLy8gbW9kdWxlIGlkID0gMjJcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwibW9kdWxlLmV4cG9ydHMgPSBcIjxoMT5BbnR3b29yZGVuIHBlciBsZWVyZG9lbDwvaDE+XFxyXFxuPHA+RGl0IGlzIGhldCBhYW50YWwgY29ycmVjdGUgYW50d29vcmRlbiB2YW4gdmFuZGFhZyBwZXIgbGVlcmRvZWwuPC9wPlxcclxcblxcclxcbjxwICpuZ0lmPVxcXCIhY29ycmVjdEFuc3dlcnNQZXJMZWFybmluZ09iamVjdGl2ZVxcXCI+PGVtPkxhZGVuLi4uPC9lbT48L3A+XFxyXFxuXFxyXFxuPHRhYmxlIGNsYXNzPVxcXCJ0YWJsZVxcXCIgKm5nSWY9XFxcImNvcnJlY3RBbnN3ZXJzUGVyTGVhcm5pbmdPYmplY3RpdmVcXFwiPlxcclxcbiAgICA8dGhlYWQ+XFxyXFxuICAgICAgICA8dHI+XFxyXFxuICAgICAgICAgICAgPHRoIGNsYXNzPVxcXCJoaWRkZW4teHNcXFwiPk9uZGVyd2VycDwvdGg+XFxyXFxuICAgICAgICAgICAgPHRoPkxlZXJkb2VsPC90aD5cXHJcXG4gICAgICAgICAgICA8dGggY2xhc3M9XFxcImhpZGRlbi14cyBoaWRkZW4tc21cXFwiPkFhbnRhbCBhbnR3b29yZGVuPC90aD5cXHJcXG4gICAgICAgICAgICA8dGggY2xhc3M9XFxcImhpZGRlbi14cyBoaWRkZW4tc21cXFwiPkFhbnRhbCBjb3JyZWN0PC90aD5cXHJcXG4gICAgICAgICAgICA8dGg+UGVyY2VudGFnZTwvdGg+XFxyXFxuICAgICAgICA8L3RyPlxcclxcbiAgICA8L3RoZWFkPlxcclxcbiAgICA8dGJvZHk+XFxyXFxuICAgICAgICA8dHIgKm5nRm9yPVxcXCJsZXQgbGVhcm5pbmdPYmplY3RpdmUgb2YgY29ycmVjdEFuc3dlcnNQZXJMZWFybmluZ09iamVjdGl2ZVxcXCI+XFxyXFxuICAgICAgICAgICAgPHRkIGNsYXNzPVxcXCJoaWRkZW4teHNcXFwiPnt7IGxlYXJuaW5nT2JqZWN0aXZlLnN1YmplY3QgfX08L3RkPlxcclxcbiAgICAgICAgICAgIDx0ZD57eyBsZWFybmluZ09iamVjdGl2ZS5sZWFybmluZ09iamVjdGl2ZSB9fTwvdGQ+XFxyXFxuICAgICAgICAgICAgPHRkIGNsYXNzPVxcXCJ0ZXh0LXJpZ2h0IGhpZGRlbi14cyBoaWRkZW4tc21cXFwiPnt7IGxlYXJuaW5nT2JqZWN0aXZlLnRvdGFsIH19PC90ZD5cXHJcXG4gICAgICAgICAgICA8dGQgY2xhc3M9XFxcInRleHQtcmlnaHQgaGlkZGVuLXhzIGhpZGRlbi1zbVxcXCI+e3sgbGVhcm5pbmdPYmplY3RpdmUuY291bnQgfX08L3RkPlxcclxcbiAgICAgICAgICAgIDx0ZCBjbGFzcz1cXFwidGV4dC1yaWdodFxcXCI+e3sgbGVhcm5pbmdPYmplY3RpdmUucGVyY2VudGFnZSB8IHBlcmNlbnQgOiAnMi4yLTInIH19PC90ZD5cXHJcXG4gICAgICAgIDwvdHI+XFxyXFxuICAgIDwvdGJvZHk+XFxyXFxuPC90YWJsZT5cXHJcXG5cIjtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyAuL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9yZXBvcnRwZXJsZWFybmluZ29iamVjdGl2ZS9yZXBvcnRwZXJsZWFybmluZ29iamVjdGl2ZS5jb21wb25lbnQuaHRtbFxuLy8gbW9kdWxlIGlkID0gMjNcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwiKGZ1bmN0aW9uIHdlYnBhY2tVbml2ZXJzYWxNb2R1bGVEZWZpbml0aW9uKHJvb3QsIGZhY3RvcnkpIHtcblx0aWYodHlwZW9mIGV4cG9ydHMgPT09ICdvYmplY3QnICYmIHR5cGVvZiBtb2R1bGUgPT09ICdvYmplY3QnKVxuXHRcdG1vZHVsZS5leHBvcnRzID0gZmFjdG9yeShyZXF1aXJlKFwiQGFuZ3VsYXIvY29yZVwiKSk7XG5cdGVsc2UgaWYodHlwZW9mIGRlZmluZSA9PT0gJ2Z1bmN0aW9uJyAmJiBkZWZpbmUuYW1kKVxuXHRcdGRlZmluZShbXCJAYW5ndWxhci9jb3JlXCJdLCBmYWN0b3J5KTtcblx0ZWxzZSBpZih0eXBlb2YgZXhwb3J0cyA9PT0gJ29iamVjdCcpXG5cdFx0ZXhwb3J0c1tcIm5nMi1jaGFydHMudW1kXCJdID0gZmFjdG9yeShyZXF1aXJlKFwiQGFuZ3VsYXIvY29yZVwiKSk7XG5cdGVsc2Vcblx0XHRyb290W1wibmcyLWNoYXJ0cy51bWRcIl0gPSBmYWN0b3J5KHJvb3RbXCJAYW5ndWxhci9jb3JlXCJdKTtcbn0pKHRoaXMsIGZ1bmN0aW9uKF9fV0VCUEFDS19FWFRFUk5BTF9NT0RVTEVfMV9fKSB7XG5yZXR1cm4gLyoqKioqKi8gKGZ1bmN0aW9uKG1vZHVsZXMpIHsgLy8gd2VicGFja0Jvb3RzdHJhcFxuLyoqKioqKi8gXHQvLyBUaGUgbW9kdWxlIGNhY2hlXG4vKioqKioqLyBcdHZhciBpbnN0YWxsZWRNb2R1bGVzID0ge307XG4vKioqKioqL1xuLyoqKioqKi8gXHQvLyBUaGUgcmVxdWlyZSBmdW5jdGlvblxuLyoqKioqKi8gXHRmdW5jdGlvbiBfX3dlYnBhY2tfcmVxdWlyZV9fKG1vZHVsZUlkKSB7XG4vKioqKioqL1xuLyoqKioqKi8gXHRcdC8vIENoZWNrIGlmIG1vZHVsZSBpcyBpbiBjYWNoZVxuLyoqKioqKi8gXHRcdGlmKGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdKVxuLyoqKioqKi8gXHRcdFx0cmV0dXJuIGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdLmV4cG9ydHM7XG4vKioqKioqL1xuLyoqKioqKi8gXHRcdC8vIENyZWF0ZSBhIG5ldyBtb2R1bGUgKGFuZCBwdXQgaXQgaW50byB0aGUgY2FjaGUpXG4vKioqKioqLyBcdFx0dmFyIG1vZHVsZSA9IGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdID0ge1xuLyoqKioqKi8gXHRcdFx0aTogbW9kdWxlSWQsXG4vKioqKioqLyBcdFx0XHRsOiBmYWxzZSxcbi8qKioqKiovIFx0XHRcdGV4cG9ydHM6IHt9XG4vKioqKioqLyBcdFx0fTtcbi8qKioqKiovXG4vKioqKioqLyBcdFx0Ly8gRXhlY3V0ZSB0aGUgbW9kdWxlIGZ1bmN0aW9uXG4vKioqKioqLyBcdFx0bW9kdWxlc1ttb2R1bGVJZF0uY2FsbChtb2R1bGUuZXhwb3J0cywgbW9kdWxlLCBtb2R1bGUuZXhwb3J0cywgX193ZWJwYWNrX3JlcXVpcmVfXyk7XG4vKioqKioqL1xuLyoqKioqKi8gXHRcdC8vIEZsYWcgdGhlIG1vZHVsZSBhcyBsb2FkZWRcbi8qKioqKiovIFx0XHRtb2R1bGUubCA9IHRydWU7XG4vKioqKioqL1xuLyoqKioqKi8gXHRcdC8vIFJldHVybiB0aGUgZXhwb3J0cyBvZiB0aGUgbW9kdWxlXG4vKioqKioqLyBcdFx0cmV0dXJuIG1vZHVsZS5leHBvcnRzO1xuLyoqKioqKi8gXHR9XG4vKioqKioqL1xuLyoqKioqKi9cbi8qKioqKiovIFx0Ly8gZXhwb3NlIHRoZSBtb2R1bGVzIG9iamVjdCAoX193ZWJwYWNrX21vZHVsZXNfXylcbi8qKioqKiovIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5tID0gbW9kdWxlcztcbi8qKioqKiovXG4vKioqKioqLyBcdC8vIGV4cG9zZSB0aGUgbW9kdWxlIGNhY2hlXG4vKioqKioqLyBcdF9fd2VicGFja19yZXF1aXJlX18uYyA9IGluc3RhbGxlZE1vZHVsZXM7XG4vKioqKioqL1xuLyoqKioqKi8gXHQvLyBpZGVudGl0eSBmdW5jdGlvbiBmb3IgY2FsbGluZyBoYXJtb255IGltcG9ydHMgd2l0aCB0aGUgY29ycmVjdCBjb250ZXh0XG4vKioqKioqLyBcdF9fd2VicGFja19yZXF1aXJlX18uaSA9IGZ1bmN0aW9uKHZhbHVlKSB7IHJldHVybiB2YWx1ZTsgfTtcbi8qKioqKiovXG4vKioqKioqLyBcdC8vIGRlZmluZSBnZXR0ZXIgZnVuY3Rpb24gZm9yIGhhcm1vbnkgZXhwb3J0c1xuLyoqKioqKi8gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLmQgPSBmdW5jdGlvbihleHBvcnRzLCBuYW1lLCBnZXR0ZXIpIHtcbi8qKioqKiovIFx0XHRpZighX193ZWJwYWNrX3JlcXVpcmVfXy5vKGV4cG9ydHMsIG5hbWUpKSB7XG4vKioqKioqLyBcdFx0XHRPYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgbmFtZSwge1xuLyoqKioqKi8gXHRcdFx0XHRjb25maWd1cmFibGU6IGZhbHNlLFxuLyoqKioqKi8gXHRcdFx0XHRlbnVtZXJhYmxlOiB0cnVlLFxuLyoqKioqKi8gXHRcdFx0XHRnZXQ6IGdldHRlclxuLyoqKioqKi8gXHRcdFx0fSk7XG4vKioqKioqLyBcdFx0fVxuLyoqKioqKi8gXHR9O1xuLyoqKioqKi9cbi8qKioqKiovIFx0Ly8gZ2V0RGVmYXVsdEV4cG9ydCBmdW5jdGlvbiBmb3IgY29tcGF0aWJpbGl0eSB3aXRoIG5vbi1oYXJtb255IG1vZHVsZXNcbi8qKioqKiovIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5uID0gZnVuY3Rpb24obW9kdWxlKSB7XG4vKioqKioqLyBcdFx0dmFyIGdldHRlciA9IG1vZHVsZSAmJiBtb2R1bGUuX19lc01vZHVsZSA/XG4vKioqKioqLyBcdFx0XHRmdW5jdGlvbiBnZXREZWZhdWx0KCkgeyByZXR1cm4gbW9kdWxlWydkZWZhdWx0J107IH0gOlxuLyoqKioqKi8gXHRcdFx0ZnVuY3Rpb24gZ2V0TW9kdWxlRXhwb3J0cygpIHsgcmV0dXJuIG1vZHVsZTsgfTtcbi8qKioqKiovIFx0XHRfX3dlYnBhY2tfcmVxdWlyZV9fLmQoZ2V0dGVyLCAnYScsIGdldHRlcik7XG4vKioqKioqLyBcdFx0cmV0dXJuIGdldHRlcjtcbi8qKioqKiovIFx0fTtcbi8qKioqKiovXG4vKioqKioqLyBcdC8vIE9iamVjdC5wcm90b3R5cGUuaGFzT3duUHJvcGVydHkuY2FsbFxuLyoqKioqKi8gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLm8gPSBmdW5jdGlvbihvYmplY3QsIHByb3BlcnR5KSB7IHJldHVybiBPYmplY3QucHJvdG90eXBlLmhhc093blByb3BlcnR5LmNhbGwob2JqZWN0LCBwcm9wZXJ0eSk7IH07XG4vKioqKioqL1xuLyoqKioqKi8gXHQvLyBfX3dlYnBhY2tfcHVibGljX3BhdGhfX1xuLyoqKioqKi8gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLnAgPSBcIi9cIjtcbi8qKioqKiovXG4vKioqKioqLyBcdC8vIExvYWQgZW50cnkgbW9kdWxlIGFuZCByZXR1cm4gZXhwb3J0c1xuLyoqKioqKi8gXHRyZXR1cm4gX193ZWJwYWNrX3JlcXVpcmVfXyhfX3dlYnBhY2tfcmVxdWlyZV9fLnMgPSAyKTtcbi8qKioqKiovIH0pXG4vKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqKioqL1xuLyoqKioqKi8gKFtcbi8qIDAgKi9cbi8qKiovIGZ1bmN0aW9uKG1vZHVsZSwgZXhwb3J0cywgX193ZWJwYWNrX3JlcXVpcmVfXykge1xuXG5cInVzZSBzdHJpY3RcIjtcblxyXG52YXIgX19kZWNvcmF0ZSA9ICh0aGlzICYmIHRoaXMuX19kZWNvcmF0ZSkgfHwgZnVuY3Rpb24gKGRlY29yYXRvcnMsIHRhcmdldCwga2V5LCBkZXNjKSB7XHJcbiAgICB2YXIgYyA9IGFyZ3VtZW50cy5sZW5ndGgsIHIgPSBjIDwgMyA/IHRhcmdldCA6IGRlc2MgPT09IG51bGwgPyBkZXNjID0gT2JqZWN0LmdldE93blByb3BlcnR5RGVzY3JpcHRvcih0YXJnZXQsIGtleSkgOiBkZXNjLCBkO1xyXG4gICAgaWYgKHR5cGVvZiBSZWZsZWN0ID09PSBcIm9iamVjdFwiICYmIHR5cGVvZiBSZWZsZWN0LmRlY29yYXRlID09PSBcImZ1bmN0aW9uXCIpIHIgPSBSZWZsZWN0LmRlY29yYXRlKGRlY29yYXRvcnMsIHRhcmdldCwga2V5LCBkZXNjKTtcclxuICAgIGVsc2UgZm9yICh2YXIgaSA9IGRlY29yYXRvcnMubGVuZ3RoIC0gMTsgaSA+PSAwOyBpLS0pIGlmIChkID0gZGVjb3JhdG9yc1tpXSkgciA9IChjIDwgMyA/IGQocikgOiBjID4gMyA/IGQodGFyZ2V0LCBrZXksIHIpIDogZCh0YXJnZXQsIGtleSkpIHx8IHI7XHJcbiAgICByZXR1cm4gYyA+IDMgJiYgciAmJiBPYmplY3QuZGVmaW5lUHJvcGVydHkodGFyZ2V0LCBrZXksIHIpLCByO1xyXG59O1xyXG52YXIgX19tZXRhZGF0YSA9ICh0aGlzICYmIHRoaXMuX19tZXRhZGF0YSkgfHwgZnVuY3Rpb24gKGssIHYpIHtcclxuICAgIGlmICh0eXBlb2YgUmVmbGVjdCA9PT0gXCJvYmplY3RcIiAmJiB0eXBlb2YgUmVmbGVjdC5tZXRhZGF0YSA9PT0gXCJmdW5jdGlvblwiKSByZXR1cm4gUmVmbGVjdC5tZXRhZGF0YShrLCB2KTtcclxufTtcclxudmFyIGNvcmVfMSA9IF9fd2VicGFja19yZXF1aXJlX18oMSk7XHJcbi8qIHRzbGludDpkaXNhYmxlLW5leHQtbGluZSAqL1xyXG52YXIgQmFzZUNoYXJ0RGlyZWN0aXZlID0gKGZ1bmN0aW9uICgpIHtcclxuICAgIGZ1bmN0aW9uIEJhc2VDaGFydERpcmVjdGl2ZShlbGVtZW50KSB7XHJcbiAgICAgICAgdGhpcy5sYWJlbHMgPSBbXTtcclxuICAgICAgICB0aGlzLm9wdGlvbnMgPSB7fTtcclxuICAgICAgICB0aGlzLmNoYXJ0Q2xpY2sgPSBuZXcgY29yZV8xLkV2ZW50RW1pdHRlcigpO1xyXG4gICAgICAgIHRoaXMuY2hhcnRIb3ZlciA9IG5ldyBjb3JlXzEuRXZlbnRFbWl0dGVyKCk7XHJcbiAgICAgICAgdGhpcy5pbml0RmxhZyA9IGZhbHNlO1xyXG4gICAgICAgIHRoaXMuZWxlbWVudCA9IGVsZW1lbnQ7XHJcbiAgICB9XHJcbiAgICBCYXNlQ2hhcnREaXJlY3RpdmUucHJvdG90eXBlLm5nT25Jbml0ID0gZnVuY3Rpb24gKCkge1xyXG4gICAgICAgIHRoaXMuY3R4ID0gdGhpcy5lbGVtZW50Lm5hdGl2ZUVsZW1lbnQuZ2V0Q29udGV4dCgnMmQnKTtcclxuICAgICAgICB0aGlzLmN2cyA9IHRoaXMuZWxlbWVudC5uYXRpdmVFbGVtZW50O1xyXG4gICAgICAgIHRoaXMuaW5pdEZsYWcgPSB0cnVlO1xyXG4gICAgICAgIGlmICh0aGlzLmRhdGEgfHwgdGhpcy5kYXRhc2V0cykge1xyXG4gICAgICAgICAgICB0aGlzLnJlZnJlc2goKTtcclxuICAgICAgICB9XHJcbiAgICB9O1xyXG4gICAgQmFzZUNoYXJ0RGlyZWN0aXZlLnByb3RvdHlwZS5uZ09uQ2hhbmdlcyA9IGZ1bmN0aW9uIChjaGFuZ2VzKSB7XHJcbiAgICAgICAgaWYgKHRoaXMuaW5pdEZsYWcpIHtcclxuICAgICAgICAgICAgLy8gQ2hlY2sgaWYgdGhlIGNoYW5nZXMgYXJlIGluIHRoZSBkYXRhIG9yIGRhdGFzZXRzXHJcbiAgICAgICAgICAgIGlmIChjaGFuZ2VzLmhhc093blByb3BlcnR5KCdkYXRhJykgfHwgY2hhbmdlcy5oYXNPd25Qcm9wZXJ0eSgnZGF0YXNldHMnKSkge1xyXG4gICAgICAgICAgICAgICAgaWYgKGNoYW5nZXNbJ2RhdGEnXSkge1xyXG4gICAgICAgICAgICAgICAgICAgIHRoaXMudXBkYXRlQ2hhcnREYXRhKGNoYW5nZXNbJ2RhdGEnXS5jdXJyZW50VmFsdWUpO1xyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAgICAgZWxzZSB7XHJcbiAgICAgICAgICAgICAgICAgICAgdGhpcy51cGRhdGVDaGFydERhdGEoY2hhbmdlc1snZGF0YXNldHMnXS5jdXJyZW50VmFsdWUpO1xyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAgICAgdGhpcy5jaGFydC51cGRhdGUoKTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICBlbHNlIHtcclxuICAgICAgICAgICAgICAgIC8vIG90aGVyd2lzZSByZWJ1aWxkIHRoZSBjaGFydFxyXG4gICAgICAgICAgICAgICAgdGhpcy5yZWZyZXNoKCk7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICB9XHJcbiAgICB9O1xyXG4gICAgQmFzZUNoYXJ0RGlyZWN0aXZlLnByb3RvdHlwZS5uZ09uRGVzdHJveSA9IGZ1bmN0aW9uICgpIHtcclxuICAgICAgICBpZiAodGhpcy5jaGFydCkge1xyXG4gICAgICAgICAgICB0aGlzLmNoYXJ0LmRlc3Ryb3koKTtcclxuICAgICAgICAgICAgdGhpcy5jaGFydCA9IHZvaWQgMDtcclxuICAgICAgICB9XHJcbiAgICB9O1xyXG4gICAgQmFzZUNoYXJ0RGlyZWN0aXZlLnByb3RvdHlwZS5nZXRDaGFydEJ1aWxkZXIgPSBmdW5jdGlvbiAoY3R4IC8qLCBkYXRhOkFycmF5PGFueT4sIG9wdGlvbnM6YW55Ki8pIHtcclxuICAgICAgICB2YXIgX3RoaXMgPSB0aGlzO1xyXG4gICAgICAgIHZhciBkYXRhc2V0cyA9IHRoaXMuZ2V0RGF0YXNldHMoKTtcclxuICAgICAgICB2YXIgb3B0aW9ucyA9IE9iamVjdC5hc3NpZ24oe30sIHRoaXMub3B0aW9ucyk7XHJcbiAgICAgICAgaWYgKHRoaXMubGVnZW5kID09PSBmYWxzZSkge1xyXG4gICAgICAgICAgICBvcHRpb25zLmxlZ2VuZCA9IHsgZGlzcGxheTogZmFsc2UgfTtcclxuICAgICAgICB9XHJcbiAgICAgICAgLy8gaG9jayBmb3Igb25Ib3ZlciBhbmQgb25DbGljayBldmVudHNcclxuICAgICAgICBvcHRpb25zLmhvdmVyID0gb3B0aW9ucy5ob3ZlciB8fCB7fTtcclxuICAgICAgICBpZiAoIW9wdGlvbnMuaG92ZXIub25Ib3Zlcikge1xyXG4gICAgICAgICAgICBvcHRpb25zLmhvdmVyLm9uSG92ZXIgPSBmdW5jdGlvbiAoYWN0aXZlKSB7XHJcbiAgICAgICAgICAgICAgICBpZiAoYWN0aXZlICYmICFhY3RpdmUubGVuZ3RoKSB7XHJcbiAgICAgICAgICAgICAgICAgICAgcmV0dXJuO1xyXG4gICAgICAgICAgICAgICAgfVxyXG4gICAgICAgICAgICAgICAgX3RoaXMuY2hhcnRIb3Zlci5lbWl0KHsgYWN0aXZlOiBhY3RpdmUgfSk7XHJcbiAgICAgICAgICAgIH07XHJcbiAgICAgICAgfVxyXG4gICAgICAgIGlmICghb3B0aW9ucy5vbkNsaWNrKSB7XHJcbiAgICAgICAgICAgIG9wdGlvbnMub25DbGljayA9IGZ1bmN0aW9uIChldmVudCwgYWN0aXZlKSB7XHJcbiAgICAgICAgICAgICAgICBfdGhpcy5jaGFydENsaWNrLmVtaXQoeyBldmVudDogZXZlbnQsIGFjdGl2ZTogYWN0aXZlIH0pO1xyXG4gICAgICAgICAgICB9O1xyXG4gICAgICAgIH1cclxuICAgICAgICB2YXIgb3B0cyA9IHtcclxuICAgICAgICAgICAgdHlwZTogdGhpcy5jaGFydFR5cGUsXHJcbiAgICAgICAgICAgIGRhdGE6IHtcclxuICAgICAgICAgICAgICAgIGxhYmVsczogdGhpcy5sYWJlbHMsXHJcbiAgICAgICAgICAgICAgICBkYXRhc2V0czogZGF0YXNldHNcclxuICAgICAgICAgICAgfSxcclxuICAgICAgICAgICAgb3B0aW9uczogb3B0aW9uc1xyXG4gICAgICAgIH07XHJcbiAgICAgICAgaWYgKHR5cGVvZiBDaGFydCA9PT0gJ3VuZGVmaW5lZCcpIHtcclxuICAgICAgICAgICAgdGhyb3cgbmV3IEVycm9yKCduZzItY2hhcnRzIGNvbmZpZ3VyYXRpb24gaXNzdWU6IEVtYmVkZGluZyBDaGFydC5qcyBsaWIgaXMgbWFuZGF0b3J5Jyk7XHJcbiAgICAgICAgfVxyXG4gICAgICAgIHJldHVybiBuZXcgQ2hhcnQoY3R4LCBvcHRzKTtcclxuICAgIH07XHJcbiAgICBCYXNlQ2hhcnREaXJlY3RpdmUucHJvdG90eXBlLnVwZGF0ZUNoYXJ0RGF0YSA9IGZ1bmN0aW9uIChuZXdEYXRhVmFsdWVzKSB7XHJcbiAgICAgICAgaWYgKEFycmF5LmlzQXJyYXkobmV3RGF0YVZhbHVlc1swXS5kYXRhKSkge1xyXG4gICAgICAgICAgICB0aGlzLmNoYXJ0LmRhdGEuZGF0YXNldHMuZm9yRWFjaChmdW5jdGlvbiAoZGF0YXNldCwgaSkge1xyXG4gICAgICAgICAgICAgICAgZGF0YXNldC5kYXRhID0gbmV3RGF0YVZhbHVlc1tpXS5kYXRhO1xyXG4gICAgICAgICAgICAgICAgaWYgKG5ld0RhdGFWYWx1ZXNbaV0ubGFiZWwpIHtcclxuICAgICAgICAgICAgICAgICAgICBkYXRhc2V0LmxhYmVsID0gbmV3RGF0YVZhbHVlc1tpXS5sYWJlbDtcclxuICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgfSk7XHJcbiAgICAgICAgfVxyXG4gICAgICAgIGVsc2Uge1xyXG4gICAgICAgICAgICB0aGlzLmNoYXJ0LmRhdGEuZGF0YXNldHNbMF0uZGF0YSA9IG5ld0RhdGFWYWx1ZXM7XHJcbiAgICAgICAgfVxyXG4gICAgfTtcclxuICAgIEJhc2VDaGFydERpcmVjdGl2ZS5wcm90b3R5cGUuZ2V0RGF0YXNldHMgPSBmdW5jdGlvbiAoKSB7XHJcbiAgICAgICAgdmFyIF90aGlzID0gdGhpcztcclxuICAgICAgICB2YXIgZGF0YXNldHMgPSB2b2lkIDA7XHJcbiAgICAgICAgLy8gaW4gY2FzZSBpZiBkYXRhc2V0cyBpcyBub3QgcHJvdmlkZWQsIGJ1dCBkYXRhIGlzIHByZXNlbnRcclxuICAgICAgICBpZiAoIXRoaXMuZGF0YXNldHMgfHwgIXRoaXMuZGF0YXNldHMubGVuZ3RoICYmICh0aGlzLmRhdGEgJiYgdGhpcy5kYXRhLmxlbmd0aCkpIHtcclxuICAgICAgICAgICAgaWYgKEFycmF5LmlzQXJyYXkodGhpcy5kYXRhWzBdKSkge1xyXG4gICAgICAgICAgICAgICAgZGF0YXNldHMgPSB0aGlzLmRhdGEubWFwKGZ1bmN0aW9uIChkYXRhLCBpbmRleCkge1xyXG4gICAgICAgICAgICAgICAgICAgIHJldHVybiB7IGRhdGE6IGRhdGEsIGxhYmVsOiBfdGhpcy5sYWJlbHNbaW5kZXhdIHx8IFwiTGFiZWwgXCIgKyBpbmRleCB9O1xyXG4gICAgICAgICAgICAgICAgfSk7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgZWxzZSB7XHJcbiAgICAgICAgICAgICAgICBkYXRhc2V0cyA9IFt7IGRhdGE6IHRoaXMuZGF0YSwgbGFiZWw6IFwiTGFiZWwgMFwiIH1dO1xyXG4gICAgICAgICAgICB9XHJcbiAgICAgICAgfVxyXG4gICAgICAgIGlmICh0aGlzLmRhdGFzZXRzICYmIHRoaXMuZGF0YXNldHMubGVuZ3RoIHx8XHJcbiAgICAgICAgICAgIChkYXRhc2V0cyAmJiBkYXRhc2V0cy5sZW5ndGgpKSB7XHJcbiAgICAgICAgICAgIGRhdGFzZXRzID0gKHRoaXMuZGF0YXNldHMgfHwgZGF0YXNldHMpXHJcbiAgICAgICAgICAgICAgICAubWFwKGZ1bmN0aW9uIChlbG0sIGluZGV4KSB7XHJcbiAgICAgICAgICAgICAgICB2YXIgbmV3RWxtID0gT2JqZWN0LmFzc2lnbih7fSwgZWxtKTtcclxuICAgICAgICAgICAgICAgIGlmIChfdGhpcy5jb2xvcnMgJiYgX3RoaXMuY29sb3JzLmxlbmd0aCkge1xyXG4gICAgICAgICAgICAgICAgICAgIE9iamVjdC5hc3NpZ24obmV3RWxtLCBfdGhpcy5jb2xvcnNbaW5kZXhdKTtcclxuICAgICAgICAgICAgICAgIH1cclxuICAgICAgICAgICAgICAgIGVsc2Uge1xyXG4gICAgICAgICAgICAgICAgICAgIE9iamVjdC5hc3NpZ24obmV3RWxtLCBnZXRDb2xvcnMoX3RoaXMuY2hhcnRUeXBlLCBpbmRleCwgbmV3RWxtLmRhdGEubGVuZ3RoKSk7XHJcbiAgICAgICAgICAgICAgICB9XHJcbiAgICAgICAgICAgICAgICByZXR1cm4gbmV3RWxtO1xyXG4gICAgICAgICAgICB9KTtcclxuICAgICAgICB9XHJcbiAgICAgICAgaWYgKCFkYXRhc2V0cykge1xyXG4gICAgICAgICAgICB0aHJvdyBuZXcgRXJyb3IoXCJuZy1jaGFydHMgY29uZmlndXJhdGlvbiBlcnJvcixcXG4gICAgICBkYXRhIG9yIGRhdGFzZXRzIGZpZWxkIGFyZSByZXF1aXJlZCB0byByZW5kZXIgY2hhciBcIiArIHRoaXMuY2hhcnRUeXBlKTtcclxuICAgICAgICB9XHJcbiAgICAgICAgcmV0dXJuIGRhdGFzZXRzO1xyXG4gICAgfTtcclxuICAgIEJhc2VDaGFydERpcmVjdGl2ZS5wcm90b3R5cGUucmVmcmVzaCA9IGZ1bmN0aW9uICgpIHtcclxuICAgICAgICAvLyBpZiAodGhpcy5vcHRpb25zICYmIHRoaXMub3B0aW9ucy5yZXNwb25zaXZlKSB7XHJcbiAgICAgICAgLy8gICBzZXRUaW1lb3V0KCgpID0+IHRoaXMucmVmcmVzaCgpLCA1MCk7XHJcbiAgICAgICAgLy8gfVxyXG4gICAgICAgIC8vIHRvZG86IHJlbW92ZSB0aGlzIGxpbmUsIGl0IGlzIHByb2R1Y2luZyBmbGlja2VyaW5nXHJcbiAgICAgICAgdGhpcy5uZ09uRGVzdHJveSgpO1xyXG4gICAgICAgIHRoaXMuY2hhcnQgPSB0aGlzLmdldENoYXJ0QnVpbGRlcih0aGlzLmN0eCAvKiwgZGF0YSwgdGhpcy5vcHRpb25zKi8pO1xyXG4gICAgfTtcclxuICAgIHJldHVybiBCYXNlQ2hhcnREaXJlY3RpdmU7XHJcbn0oKSk7XHJcbkJhc2VDaGFydERpcmVjdGl2ZS5kZWZhdWx0Q29sb3JzID0gW1xyXG4gICAgWzI1NSwgOTksIDEzMl0sXHJcbiAgICBbNTQsIDE2MiwgMjM1XSxcclxuICAgIFsyNTUsIDIwNiwgODZdLFxyXG4gICAgWzIzMSwgMjMzLCAyMzddLFxyXG4gICAgWzc1LCAxOTIsIDE5Ml0sXHJcbiAgICBbMTUxLCAxODcsIDIwNV0sXHJcbiAgICBbMjIwLCAyMjAsIDIyMF0sXHJcbiAgICBbMjQ3LCA3MCwgNzRdLFxyXG4gICAgWzcwLCAxOTEsIDE4OV0sXHJcbiAgICBbMjUzLCAxODAsIDkyXSxcclxuICAgIFsxNDgsIDE1OSwgMTc3XSxcclxuICAgIFs3NywgODMsIDk2XVxyXG5dO1xyXG5fX2RlY29yYXRlKFtcclxuICAgIGNvcmVfMS5JbnB1dCgpLFxyXG4gICAgX19tZXRhZGF0YShcImRlc2lnbjp0eXBlXCIsIEFycmF5KVxyXG5dLCBCYXNlQ2hhcnREaXJlY3RpdmUucHJvdG90eXBlLCBcImRhdGFcIiwgdm9pZCAwKTtcclxuX19kZWNvcmF0ZShbXHJcbiAgICBjb3JlXzEuSW5wdXQoKSxcclxuICAgIF9fbWV0YWRhdGEoXCJkZXNpZ246dHlwZVwiLCBBcnJheSlcclxuXSwgQmFzZUNoYXJ0RGlyZWN0aXZlLnByb3RvdHlwZSwgXCJkYXRhc2V0c1wiLCB2b2lkIDApO1xyXG5fX2RlY29yYXRlKFtcclxuICAgIGNvcmVfMS5JbnB1dCgpLFxyXG4gICAgX19tZXRhZGF0YShcImRlc2lnbjp0eXBlXCIsIEFycmF5KVxyXG5dLCBCYXNlQ2hhcnREaXJlY3RpdmUucHJvdG90eXBlLCBcImxhYmVsc1wiLCB2b2lkIDApO1xyXG5fX2RlY29yYXRlKFtcclxuICAgIGNvcmVfMS5JbnB1dCgpLFxyXG4gICAgX19tZXRhZGF0YShcImRlc2lnbjp0eXBlXCIsIE9iamVjdClcclxuXSwgQmFzZUNoYXJ0RGlyZWN0aXZlLnByb3RvdHlwZSwgXCJvcHRpb25zXCIsIHZvaWQgMCk7XHJcbl9fZGVjb3JhdGUoW1xyXG4gICAgY29yZV8xLklucHV0KCksXHJcbiAgICBfX21ldGFkYXRhKFwiZGVzaWduOnR5cGVcIiwgU3RyaW5nKVxyXG5dLCBCYXNlQ2hhcnREaXJlY3RpdmUucHJvdG90eXBlLCBcImNoYXJ0VHlwZVwiLCB2b2lkIDApO1xyXG5fX2RlY29yYXRlKFtcclxuICAgIGNvcmVfMS5JbnB1dCgpLFxyXG4gICAgX19tZXRhZGF0YShcImRlc2lnbjp0eXBlXCIsIEFycmF5KVxyXG5dLCBCYXNlQ2hhcnREaXJlY3RpdmUucHJvdG90eXBlLCBcImNvbG9yc1wiLCB2b2lkIDApO1xyXG5fX2RlY29yYXRlKFtcclxuICAgIGNvcmVfMS5JbnB1dCgpLFxyXG4gICAgX19tZXRhZGF0YShcImRlc2lnbjp0eXBlXCIsIEJvb2xlYW4pXHJcbl0sIEJhc2VDaGFydERpcmVjdGl2ZS5wcm90b3R5cGUsIFwibGVnZW5kXCIsIHZvaWQgMCk7XHJcbl9fZGVjb3JhdGUoW1xyXG4gICAgY29yZV8xLk91dHB1dCgpLFxyXG4gICAgX19tZXRhZGF0YShcImRlc2lnbjp0eXBlXCIsIGNvcmVfMS5FdmVudEVtaXR0ZXIpXHJcbl0sIEJhc2VDaGFydERpcmVjdGl2ZS5wcm90b3R5cGUsIFwiY2hhcnRDbGlja1wiLCB2b2lkIDApO1xyXG5fX2RlY29yYXRlKFtcclxuICAgIGNvcmVfMS5PdXRwdXQoKSxcclxuICAgIF9fbWV0YWRhdGEoXCJkZXNpZ246dHlwZVwiLCBjb3JlXzEuRXZlbnRFbWl0dGVyKVxyXG5dLCBCYXNlQ2hhcnREaXJlY3RpdmUucHJvdG90eXBlLCBcImNoYXJ0SG92ZXJcIiwgdm9pZCAwKTtcclxuQmFzZUNoYXJ0RGlyZWN0aXZlID0gX19kZWNvcmF0ZShbXHJcbiAgICBjb3JlXzEuRGlyZWN0aXZlKHsgc2VsZWN0b3I6ICdjYW52YXNbYmFzZUNoYXJ0XScsIGV4cG9ydEFzOiAnYmFzZS1jaGFydCcgfSksXHJcbiAgICBfX21ldGFkYXRhKFwiZGVzaWduOnBhcmFtdHlwZXNcIiwgW2NvcmVfMS5FbGVtZW50UmVmXSlcclxuXSwgQmFzZUNoYXJ0RGlyZWN0aXZlKTtcclxuZXhwb3J0cy5CYXNlQ2hhcnREaXJlY3RpdmUgPSBCYXNlQ2hhcnREaXJlY3RpdmU7XHJcbmZ1bmN0aW9uIHJnYmEoY29sb3VyLCBhbHBoYSkge1xyXG4gICAgcmV0dXJuICdyZ2JhKCcgKyBjb2xvdXIuY29uY2F0KGFscGhhKS5qb2luKCcsJykgKyAnKSc7XHJcbn1cclxuZnVuY3Rpb24gZ2V0UmFuZG9tSW50KG1pbiwgbWF4KSB7XHJcbiAgICByZXR1cm4gTWF0aC5mbG9vcihNYXRoLnJhbmRvbSgpICogKG1heCAtIG1pbiArIDEpKSArIG1pbjtcclxufVxyXG5mdW5jdGlvbiBmb3JtYXRMaW5lQ29sb3IoY29sb3JzKSB7XHJcbiAgICByZXR1cm4ge1xyXG4gICAgICAgIGJhY2tncm91bmRDb2xvcjogcmdiYShjb2xvcnMsIDAuNCksXHJcbiAgICAgICAgYm9yZGVyQ29sb3I6IHJnYmEoY29sb3JzLCAxKSxcclxuICAgICAgICBwb2ludEJhY2tncm91bmRDb2xvcjogcmdiYShjb2xvcnMsIDEpLFxyXG4gICAgICAgIHBvaW50Qm9yZGVyQ29sb3I6ICcjZmZmJyxcclxuICAgICAgICBwb2ludEhvdmVyQmFja2dyb3VuZENvbG9yOiAnI2ZmZicsXHJcbiAgICAgICAgcG9pbnRIb3ZlckJvcmRlckNvbG9yOiByZ2JhKGNvbG9ycywgMC44KVxyXG4gICAgfTtcclxufVxyXG5mdW5jdGlvbiBmb3JtYXRCYXJDb2xvcihjb2xvcnMpIHtcclxuICAgIHJldHVybiB7XHJcbiAgICAgICAgYmFja2dyb3VuZENvbG9yOiByZ2JhKGNvbG9ycywgMC42KSxcclxuICAgICAgICBib3JkZXJDb2xvcjogcmdiYShjb2xvcnMsIDEpLFxyXG4gICAgICAgIGhvdmVyQmFja2dyb3VuZENvbG9yOiByZ2JhKGNvbG9ycywgMC44KSxcclxuICAgICAgICBob3ZlckJvcmRlckNvbG9yOiByZ2JhKGNvbG9ycywgMSlcclxuICAgIH07XHJcbn1cclxuZnVuY3Rpb24gZm9ybWF0UGllQ29sb3JzKGNvbG9ycykge1xyXG4gICAgcmV0dXJuIHtcclxuICAgICAgICBiYWNrZ3JvdW5kQ29sb3I6IGNvbG9ycy5tYXAoZnVuY3Rpb24gKGNvbG9yKSB7IHJldHVybiByZ2JhKGNvbG9yLCAwLjYpOyB9KSxcclxuICAgICAgICBib3JkZXJDb2xvcjogY29sb3JzLm1hcChmdW5jdGlvbiAoKSB7IHJldHVybiAnI2ZmZic7IH0pLFxyXG4gICAgICAgIHBvaW50QmFja2dyb3VuZENvbG9yOiBjb2xvcnMubWFwKGZ1bmN0aW9uIChjb2xvcikgeyByZXR1cm4gcmdiYShjb2xvciwgMSk7IH0pLFxyXG4gICAgICAgIHBvaW50Qm9yZGVyQ29sb3I6IGNvbG9ycy5tYXAoZnVuY3Rpb24gKCkgeyByZXR1cm4gJyNmZmYnOyB9KSxcclxuICAgICAgICBwb2ludEhvdmVyQmFja2dyb3VuZENvbG9yOiBjb2xvcnMubWFwKGZ1bmN0aW9uIChjb2xvcikgeyByZXR1cm4gcmdiYShjb2xvciwgMSk7IH0pLFxyXG4gICAgICAgIHBvaW50SG92ZXJCb3JkZXJDb2xvcjogY29sb3JzLm1hcChmdW5jdGlvbiAoY29sb3IpIHsgcmV0dXJuIHJnYmEoY29sb3IsIDEpOyB9KVxyXG4gICAgfTtcclxufVxyXG5mdW5jdGlvbiBmb3JtYXRQb2xhckFyZWFDb2xvcnMoY29sb3JzKSB7XHJcbiAgICByZXR1cm4ge1xyXG4gICAgICAgIGJhY2tncm91bmRDb2xvcjogY29sb3JzLm1hcChmdW5jdGlvbiAoY29sb3IpIHsgcmV0dXJuIHJnYmEoY29sb3IsIDAuNik7IH0pLFxyXG4gICAgICAgIGJvcmRlckNvbG9yOiBjb2xvcnMubWFwKGZ1bmN0aW9uIChjb2xvcikgeyByZXR1cm4gcmdiYShjb2xvciwgMSk7IH0pLFxyXG4gICAgICAgIGhvdmVyQmFja2dyb3VuZENvbG9yOiBjb2xvcnMubWFwKGZ1bmN0aW9uIChjb2xvcikgeyByZXR1cm4gcmdiYShjb2xvciwgMC44KTsgfSksXHJcbiAgICAgICAgaG92ZXJCb3JkZXJDb2xvcjogY29sb3JzLm1hcChmdW5jdGlvbiAoY29sb3IpIHsgcmV0dXJuIHJnYmEoY29sb3IsIDEpOyB9KVxyXG4gICAgfTtcclxufVxyXG5mdW5jdGlvbiBnZXRSYW5kb21Db2xvcigpIHtcclxuICAgIHJldHVybiBbZ2V0UmFuZG9tSW50KDAsIDI1NSksIGdldFJhbmRvbUludCgwLCAyNTUpLCBnZXRSYW5kb21JbnQoMCwgMjU1KV07XHJcbn1cclxuLyoqXHJcbiAqIEdlbmVyYXRlIGNvbG9ycyBmb3IgbGluZXxiYXIgY2hhcnRzXHJcbiAqIEBwYXJhbSBpbmRleFxyXG4gKiBAcmV0dXJucyB7bnVtYmVyW118Q29sb3J9XHJcbiAqL1xyXG5mdW5jdGlvbiBnZW5lcmF0ZUNvbG9yKGluZGV4KSB7XHJcbiAgICByZXR1cm4gQmFzZUNoYXJ0RGlyZWN0aXZlLmRlZmF1bHRDb2xvcnNbaW5kZXhdIHx8IGdldFJhbmRvbUNvbG9yKCk7XHJcbn1cclxuLyoqXHJcbiAqIEdlbmVyYXRlIGNvbG9ycyBmb3IgcGllfGRvdWdobnV0IGNoYXJ0c1xyXG4gKiBAcGFyYW0gY291bnRcclxuICogQHJldHVybnMge0NvbG9yc31cclxuICovXHJcbmZ1bmN0aW9uIGdlbmVyYXRlQ29sb3JzKGNvdW50KSB7XHJcbiAgICB2YXIgY29sb3JzQXJyID0gbmV3IEFycmF5KGNvdW50KTtcclxuICAgIGZvciAodmFyIGkgPSAwOyBpIDwgY291bnQ7IGkrKykge1xyXG4gICAgICAgIGNvbG9yc0FycltpXSA9IEJhc2VDaGFydERpcmVjdGl2ZS5kZWZhdWx0Q29sb3JzW2ldIHx8IGdldFJhbmRvbUNvbG9yKCk7XHJcbiAgICB9XHJcbiAgICByZXR1cm4gY29sb3JzQXJyO1xyXG59XHJcbi8qKlxyXG4gKiBHZW5lcmF0ZSBjb2xvcnMgYnkgY2hhcnQgdHlwZVxyXG4gKiBAcGFyYW0gY2hhcnRUeXBlXHJcbiAqIEBwYXJhbSBpbmRleFxyXG4gKiBAcGFyYW0gY291bnRcclxuICogQHJldHVybnMge0NvbG9yfVxyXG4gKi9cclxuZnVuY3Rpb24gZ2V0Q29sb3JzKGNoYXJ0VHlwZSwgaW5kZXgsIGNvdW50KSB7XHJcbiAgICBpZiAoY2hhcnRUeXBlID09PSAncGllJyB8fCBjaGFydFR5cGUgPT09ICdkb3VnaG51dCcpIHtcclxuICAgICAgICByZXR1cm4gZm9ybWF0UGllQ29sb3JzKGdlbmVyYXRlQ29sb3JzKGNvdW50KSk7XHJcbiAgICB9XHJcbiAgICBpZiAoY2hhcnRUeXBlID09PSAncG9sYXJBcmVhJykge1xyXG4gICAgICAgIHJldHVybiBmb3JtYXRQb2xhckFyZWFDb2xvcnMoZ2VuZXJhdGVDb2xvcnMoY291bnQpKTtcclxuICAgIH1cclxuICAgIGlmIChjaGFydFR5cGUgPT09ICdsaW5lJyB8fCBjaGFydFR5cGUgPT09ICdyYWRhcicpIHtcclxuICAgICAgICByZXR1cm4gZm9ybWF0TGluZUNvbG9yKGdlbmVyYXRlQ29sb3IoaW5kZXgpKTtcclxuICAgIH1cclxuICAgIGlmIChjaGFydFR5cGUgPT09ICdiYXInIHx8IGNoYXJ0VHlwZSA9PT0gJ2hvcml6b250YWxCYXInKSB7XHJcbiAgICAgICAgcmV0dXJuIGZvcm1hdEJhckNvbG9yKGdlbmVyYXRlQ29sb3IoaW5kZXgpKTtcclxuICAgIH1cclxuICAgIHJldHVybiBnZW5lcmF0ZUNvbG9yKGluZGV4KTtcclxufVxyXG52YXIgQ2hhcnRzTW9kdWxlID0gKGZ1bmN0aW9uICgpIHtcclxuICAgIGZ1bmN0aW9uIENoYXJ0c01vZHVsZSgpIHtcclxuICAgIH1cclxuICAgIHJldHVybiBDaGFydHNNb2R1bGU7XHJcbn0oKSk7XHJcbkNoYXJ0c01vZHVsZSA9IF9fZGVjb3JhdGUoW1xyXG4gICAgY29yZV8xLk5nTW9kdWxlKHtcclxuICAgICAgICBkZWNsYXJhdGlvbnM6IFtcclxuICAgICAgICAgICAgQmFzZUNoYXJ0RGlyZWN0aXZlXHJcbiAgICAgICAgXSxcclxuICAgICAgICBleHBvcnRzOiBbXHJcbiAgICAgICAgICAgIEJhc2VDaGFydERpcmVjdGl2ZVxyXG4gICAgICAgIF0sXHJcbiAgICAgICAgaW1wb3J0czogW11cclxuICAgIH0pXHJcbl0sIENoYXJ0c01vZHVsZSk7XHJcbmV4cG9ydHMuQ2hhcnRzTW9kdWxlID0gQ2hhcnRzTW9kdWxlO1xyXG5cblxuLyoqKi8gfSxcbi8qIDEgKi9cbi8qKiovIGZ1bmN0aW9uKG1vZHVsZSwgZXhwb3J0cykge1xuXG5tb2R1bGUuZXhwb3J0cyA9IF9fV0VCUEFDS19FWFRFUk5BTF9NT0RVTEVfMV9fO1xuXG4vKioqLyB9LFxuLyogMiAqL1xuLyoqKi8gZnVuY3Rpb24obW9kdWxlLCBleHBvcnRzLCBfX3dlYnBhY2tfcmVxdWlyZV9fKSB7XG5cblwidXNlIHN0cmljdFwiO1xuXHJcbmZ1bmN0aW9uIF9fZXhwb3J0KG0pIHtcclxuICAgIGZvciAodmFyIHAgaW4gbSkgaWYgKCFleHBvcnRzLmhhc093blByb3BlcnR5KHApKSBleHBvcnRzW3BdID0gbVtwXTtcclxufVxyXG5fX2V4cG9ydChfX3dlYnBhY2tfcmVxdWlyZV9fKDApKTtcclxuXG5cbi8qKiovIH1cbi8qKioqKiovIF0pO1xufSk7XG4vLyMgc291cmNlTWFwcGluZ1VSTD1uZzItY2hhcnRzLnVtZC5qcy5tYXBcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyAuL34vbmcyLWNoYXJ0cy9idW5kbGVzL25nMi1jaGFydHMudW1kLmpzXG4vLyBtb2R1bGUgaWQgPSAyNFxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJleHBvcnRzID0gbW9kdWxlLmV4cG9ydHMgPSBTZW1WZXI7XG5cbi8vIFRoZSBkZWJ1ZyBmdW5jdGlvbiBpcyBleGNsdWRlZCBlbnRpcmVseSBmcm9tIHRoZSBtaW5pZmllZCB2ZXJzaW9uLlxuLyogbm9taW4gKi8gdmFyIGRlYnVnO1xuLyogbm9taW4gKi8gaWYgKHR5cGVvZiBwcm9jZXNzID09PSAnb2JqZWN0JyAmJlxuICAgIC8qIG5vbWluICovIHByb2Nlc3MuZW52ICYmXG4gICAgLyogbm9taW4gKi8gcHJvY2Vzcy5lbnYuTk9ERV9ERUJVRyAmJlxuICAgIC8qIG5vbWluICovIC9cXGJzZW12ZXJcXGIvaS50ZXN0KHByb2Nlc3MuZW52Lk5PREVfREVCVUcpKVxuICAvKiBub21pbiAqLyBkZWJ1ZyA9IGZ1bmN0aW9uKCkge1xuICAgIC8qIG5vbWluICovIHZhciBhcmdzID0gQXJyYXkucHJvdG90eXBlLnNsaWNlLmNhbGwoYXJndW1lbnRzLCAwKTtcbiAgICAvKiBub21pbiAqLyBhcmdzLnVuc2hpZnQoJ1NFTVZFUicpO1xuICAgIC8qIG5vbWluICovIGNvbnNvbGUubG9nLmFwcGx5KGNvbnNvbGUsIGFyZ3MpO1xuICAgIC8qIG5vbWluICovIH07XG4vKiBub21pbiAqLyBlbHNlXG4gIC8qIG5vbWluICovIGRlYnVnID0gZnVuY3Rpb24oKSB7fTtcblxuLy8gTm90ZTogdGhpcyBpcyB0aGUgc2VtdmVyLm9yZyB2ZXJzaW9uIG9mIHRoZSBzcGVjIHRoYXQgaXQgaW1wbGVtZW50c1xuLy8gTm90IG5lY2Vzc2FyaWx5IHRoZSBwYWNrYWdlIHZlcnNpb24gb2YgdGhpcyBjb2RlLlxuZXhwb3J0cy5TRU1WRVJfU1BFQ19WRVJTSU9OID0gJzIuMC4wJztcblxudmFyIE1BWF9MRU5HVEggPSAyNTY7XG52YXIgTUFYX1NBRkVfSU5URUdFUiA9IE51bWJlci5NQVhfU0FGRV9JTlRFR0VSIHx8IDkwMDcxOTkyNTQ3NDA5OTE7XG5cbi8vIFRoZSBhY3R1YWwgcmVnZXhwcyBnbyBvbiBleHBvcnRzLnJlXG52YXIgcmUgPSBleHBvcnRzLnJlID0gW107XG52YXIgc3JjID0gZXhwb3J0cy5zcmMgPSBbXTtcbnZhciBSID0gMDtcblxuLy8gVGhlIGZvbGxvd2luZyBSZWd1bGFyIEV4cHJlc3Npb25zIGNhbiBiZSB1c2VkIGZvciB0b2tlbml6aW5nLFxuLy8gdmFsaWRhdGluZywgYW5kIHBhcnNpbmcgU2VtVmVyIHZlcnNpb24gc3RyaW5ncy5cblxuLy8gIyMgTnVtZXJpYyBJZGVudGlmaWVyXG4vLyBBIHNpbmdsZSBgMGAsIG9yIGEgbm9uLXplcm8gZGlnaXQgZm9sbG93ZWQgYnkgemVybyBvciBtb3JlIGRpZ2l0cy5cblxudmFyIE5VTUVSSUNJREVOVElGSUVSID0gUisrO1xuc3JjW05VTUVSSUNJREVOVElGSUVSXSA9ICcwfFsxLTldXFxcXGQqJztcbnZhciBOVU1FUklDSURFTlRJRklFUkxPT1NFID0gUisrO1xuc3JjW05VTUVSSUNJREVOVElGSUVSTE9PU0VdID0gJ1swLTldKyc7XG5cblxuLy8gIyMgTm9uLW51bWVyaWMgSWRlbnRpZmllclxuLy8gWmVybyBvciBtb3JlIGRpZ2l0cywgZm9sbG93ZWQgYnkgYSBsZXR0ZXIgb3IgaHlwaGVuLCBhbmQgdGhlbiB6ZXJvIG9yXG4vLyBtb3JlIGxldHRlcnMsIGRpZ2l0cywgb3IgaHlwaGVucy5cblxudmFyIE5PTk5VTUVSSUNJREVOVElGSUVSID0gUisrO1xuc3JjW05PTk5VTUVSSUNJREVOVElGSUVSXSA9ICdcXFxcZCpbYS16QS1aLV1bYS16QS1aMC05LV0qJztcblxuXG4vLyAjIyBNYWluIFZlcnNpb25cbi8vIFRocmVlIGRvdC1zZXBhcmF0ZWQgbnVtZXJpYyBpZGVudGlmaWVycy5cblxudmFyIE1BSU5WRVJTSU9OID0gUisrO1xuc3JjW01BSU5WRVJTSU9OXSA9ICcoJyArIHNyY1tOVU1FUklDSURFTlRJRklFUl0gKyAnKVxcXFwuJyArXG4gICAgICAgICAgICAgICAgICAgJygnICsgc3JjW05VTUVSSUNJREVOVElGSUVSXSArICcpXFxcXC4nICtcbiAgICAgICAgICAgICAgICAgICAnKCcgKyBzcmNbTlVNRVJJQ0lERU5USUZJRVJdICsgJyknO1xuXG52YXIgTUFJTlZFUlNJT05MT09TRSA9IFIrKztcbnNyY1tNQUlOVkVSU0lPTkxPT1NFXSA9ICcoJyArIHNyY1tOVU1FUklDSURFTlRJRklFUkxPT1NFXSArICcpXFxcXC4nICtcbiAgICAgICAgICAgICAgICAgICAgICAgICcoJyArIHNyY1tOVU1FUklDSURFTlRJRklFUkxPT1NFXSArICcpXFxcXC4nICtcbiAgICAgICAgICAgICAgICAgICAgICAgICcoJyArIHNyY1tOVU1FUklDSURFTlRJRklFUkxPT1NFXSArICcpJztcblxuLy8gIyMgUHJlLXJlbGVhc2UgVmVyc2lvbiBJZGVudGlmaWVyXG4vLyBBIG51bWVyaWMgaWRlbnRpZmllciwgb3IgYSBub24tbnVtZXJpYyBpZGVudGlmaWVyLlxuXG52YXIgUFJFUkVMRUFTRUlERU5USUZJRVIgPSBSKys7XG5zcmNbUFJFUkVMRUFTRUlERU5USUZJRVJdID0gJyg/OicgKyBzcmNbTlVNRVJJQ0lERU5USUZJRVJdICtcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAnfCcgKyBzcmNbTk9OTlVNRVJJQ0lERU5USUZJRVJdICsgJyknO1xuXG52YXIgUFJFUkVMRUFTRUlERU5USUZJRVJMT09TRSA9IFIrKztcbnNyY1tQUkVSRUxFQVNFSURFTlRJRklFUkxPT1NFXSA9ICcoPzonICsgc3JjW05VTUVSSUNJREVOVElGSUVSTE9PU0VdICtcbiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICd8JyArIHNyY1tOT05OVU1FUklDSURFTlRJRklFUl0gKyAnKSc7XG5cblxuLy8gIyMgUHJlLXJlbGVhc2UgVmVyc2lvblxuLy8gSHlwaGVuLCBmb2xsb3dlZCBieSBvbmUgb3IgbW9yZSBkb3Qtc2VwYXJhdGVkIHByZS1yZWxlYXNlIHZlcnNpb25cbi8vIGlkZW50aWZpZXJzLlxuXG52YXIgUFJFUkVMRUFTRSA9IFIrKztcbnNyY1tQUkVSRUxFQVNFXSA9ICcoPzotKCcgKyBzcmNbUFJFUkVMRUFTRUlERU5USUZJRVJdICtcbiAgICAgICAgICAgICAgICAgICcoPzpcXFxcLicgKyBzcmNbUFJFUkVMRUFTRUlERU5USUZJRVJdICsgJykqKSknO1xuXG52YXIgUFJFUkVMRUFTRUxPT1NFID0gUisrO1xuc3JjW1BSRVJFTEVBU0VMT09TRV0gPSAnKD86LT8oJyArIHNyY1tQUkVSRUxFQVNFSURFTlRJRklFUkxPT1NFXSArXG4gICAgICAgICAgICAgICAgICAgICAgICcoPzpcXFxcLicgKyBzcmNbUFJFUkVMRUFTRUlERU5USUZJRVJMT09TRV0gKyAnKSopKSc7XG5cbi8vICMjIEJ1aWxkIE1ldGFkYXRhIElkZW50aWZpZXJcbi8vIEFueSBjb21iaW5hdGlvbiBvZiBkaWdpdHMsIGxldHRlcnMsIG9yIGh5cGhlbnMuXG5cbnZhciBCVUlMRElERU5USUZJRVIgPSBSKys7XG5zcmNbQlVJTERJREVOVElGSUVSXSA9ICdbMC05QS1aYS16LV0rJztcblxuLy8gIyMgQnVpbGQgTWV0YWRhdGFcbi8vIFBsdXMgc2lnbiwgZm9sbG93ZWQgYnkgb25lIG9yIG1vcmUgcGVyaW9kLXNlcGFyYXRlZCBidWlsZCBtZXRhZGF0YVxuLy8gaWRlbnRpZmllcnMuXG5cbnZhciBCVUlMRCA9IFIrKztcbnNyY1tCVUlMRF0gPSAnKD86XFxcXCsoJyArIHNyY1tCVUlMRElERU5USUZJRVJdICtcbiAgICAgICAgICAgICAnKD86XFxcXC4nICsgc3JjW0JVSUxESURFTlRJRklFUl0gKyAnKSopKSc7XG5cblxuLy8gIyMgRnVsbCBWZXJzaW9uIFN0cmluZ1xuLy8gQSBtYWluIHZlcnNpb24sIGZvbGxvd2VkIG9wdGlvbmFsbHkgYnkgYSBwcmUtcmVsZWFzZSB2ZXJzaW9uIGFuZFxuLy8gYnVpbGQgbWV0YWRhdGEuXG5cbi8vIE5vdGUgdGhhdCB0aGUgb25seSBtYWpvciwgbWlub3IsIHBhdGNoLCBhbmQgcHJlLXJlbGVhc2Ugc2VjdGlvbnMgb2Zcbi8vIHRoZSB2ZXJzaW9uIHN0cmluZyBhcmUgY2FwdHVyaW5nIGdyb3Vwcy4gIFRoZSBidWlsZCBtZXRhZGF0YSBpcyBub3QgYVxuLy8gY2FwdHVyaW5nIGdyb3VwLCBiZWNhdXNlIGl0IHNob3VsZCBub3QgZXZlciBiZSB1c2VkIGluIHZlcnNpb25cbi8vIGNvbXBhcmlzb24uXG5cbnZhciBGVUxMID0gUisrO1xudmFyIEZVTExQTEFJTiA9ICd2PycgKyBzcmNbTUFJTlZFUlNJT05dICtcbiAgICAgICAgICAgICAgICBzcmNbUFJFUkVMRUFTRV0gKyAnPycgK1xuICAgICAgICAgICAgICAgIHNyY1tCVUlMRF0gKyAnPyc7XG5cbnNyY1tGVUxMXSA9ICdeJyArIEZVTExQTEFJTiArICckJztcblxuLy8gbGlrZSBmdWxsLCBidXQgYWxsb3dzIHYxLjIuMyBhbmQgPTEuMi4zLCB3aGljaCBwZW9wbGUgZG8gc29tZXRpbWVzLlxuLy8gYWxzbywgMS4wLjBhbHBoYTEgKHByZXJlbGVhc2Ugd2l0aG91dCB0aGUgaHlwaGVuKSB3aGljaCBpcyBwcmV0dHlcbi8vIGNvbW1vbiBpbiB0aGUgbnBtIHJlZ2lzdHJ5LlxudmFyIExPT1NFUExBSU4gPSAnW3Y9XFxcXHNdKicgKyBzcmNbTUFJTlZFUlNJT05MT09TRV0gK1xuICAgICAgICAgICAgICAgICBzcmNbUFJFUkVMRUFTRUxPT1NFXSArICc/JyArXG4gICAgICAgICAgICAgICAgIHNyY1tCVUlMRF0gKyAnPyc7XG5cbnZhciBMT09TRSA9IFIrKztcbnNyY1tMT09TRV0gPSAnXicgKyBMT09TRVBMQUlOICsgJyQnO1xuXG52YXIgR1RMVCA9IFIrKztcbnNyY1tHVExUXSA9ICcoKD86PHw+KT89PyknO1xuXG4vLyBTb21ldGhpbmcgbGlrZSBcIjIuKlwiIG9yIFwiMS4yLnhcIi5cbi8vIE5vdGUgdGhhdCBcIngueFwiIGlzIGEgdmFsaWQgeFJhbmdlIGlkZW50aWZlciwgbWVhbmluZyBcImFueSB2ZXJzaW9uXCJcbi8vIE9ubHkgdGhlIGZpcnN0IGl0ZW0gaXMgc3RyaWN0bHkgcmVxdWlyZWQuXG52YXIgWFJBTkdFSURFTlRJRklFUkxPT1NFID0gUisrO1xuc3JjW1hSQU5HRUlERU5USUZJRVJMT09TRV0gPSBzcmNbTlVNRVJJQ0lERU5USUZJRVJMT09TRV0gKyAnfHh8WHxcXFxcKic7XG52YXIgWFJBTkdFSURFTlRJRklFUiA9IFIrKztcbnNyY1tYUkFOR0VJREVOVElGSUVSXSA9IHNyY1tOVU1FUklDSURFTlRJRklFUl0gKyAnfHh8WHxcXFxcKic7XG5cbnZhciBYUkFOR0VQTEFJTiA9IFIrKztcbnNyY1tYUkFOR0VQTEFJTl0gPSAnW3Y9XFxcXHNdKignICsgc3JjW1hSQU5HRUlERU5USUZJRVJdICsgJyknICtcbiAgICAgICAgICAgICAgICAgICAnKD86XFxcXC4oJyArIHNyY1tYUkFOR0VJREVOVElGSUVSXSArICcpJyArXG4gICAgICAgICAgICAgICAgICAgJyg/OlxcXFwuKCcgKyBzcmNbWFJBTkdFSURFTlRJRklFUl0gKyAnKScgK1xuICAgICAgICAgICAgICAgICAgICcoPzonICsgc3JjW1BSRVJFTEVBU0VdICsgJyk/JyArXG4gICAgICAgICAgICAgICAgICAgc3JjW0JVSUxEXSArICc/JyArXG4gICAgICAgICAgICAgICAgICAgJyk/KT8nO1xuXG52YXIgWFJBTkdFUExBSU5MT09TRSA9IFIrKztcbnNyY1tYUkFOR0VQTEFJTkxPT1NFXSA9ICdbdj1cXFxcc10qKCcgKyBzcmNbWFJBTkdFSURFTlRJRklFUkxPT1NFXSArICcpJyArXG4gICAgICAgICAgICAgICAgICAgICAgICAnKD86XFxcXC4oJyArIHNyY1tYUkFOR0VJREVOVElGSUVSTE9PU0VdICsgJyknICtcbiAgICAgICAgICAgICAgICAgICAgICAgICcoPzpcXFxcLignICsgc3JjW1hSQU5HRUlERU5USUZJRVJMT09TRV0gKyAnKScgK1xuICAgICAgICAgICAgICAgICAgICAgICAgJyg/OicgKyBzcmNbUFJFUkVMRUFTRUxPT1NFXSArICcpPycgK1xuICAgICAgICAgICAgICAgICAgICAgICAgc3JjW0JVSUxEXSArICc/JyArXG4gICAgICAgICAgICAgICAgICAgICAgICAnKT8pPyc7XG5cbnZhciBYUkFOR0UgPSBSKys7XG5zcmNbWFJBTkdFXSA9ICdeJyArIHNyY1tHVExUXSArICdcXFxccyonICsgc3JjW1hSQU5HRVBMQUlOXSArICckJztcbnZhciBYUkFOR0VMT09TRSA9IFIrKztcbnNyY1tYUkFOR0VMT09TRV0gPSAnXicgKyBzcmNbR1RMVF0gKyAnXFxcXHMqJyArIHNyY1tYUkFOR0VQTEFJTkxPT1NFXSArICckJztcblxuLy8gVGlsZGUgcmFuZ2VzLlxuLy8gTWVhbmluZyBpcyBcInJlYXNvbmFibHkgYXQgb3IgZ3JlYXRlciB0aGFuXCJcbnZhciBMT05FVElMREUgPSBSKys7XG5zcmNbTE9ORVRJTERFXSA9ICcoPzp+Pj8pJztcblxudmFyIFRJTERFVFJJTSA9IFIrKztcbnNyY1tUSUxERVRSSU1dID0gJyhcXFxccyopJyArIHNyY1tMT05FVElMREVdICsgJ1xcXFxzKyc7XG5yZVtUSUxERVRSSU1dID0gbmV3IFJlZ0V4cChzcmNbVElMREVUUklNXSwgJ2cnKTtcbnZhciB0aWxkZVRyaW1SZXBsYWNlID0gJyQxfic7XG5cbnZhciBUSUxERSA9IFIrKztcbnNyY1tUSUxERV0gPSAnXicgKyBzcmNbTE9ORVRJTERFXSArIHNyY1tYUkFOR0VQTEFJTl0gKyAnJCc7XG52YXIgVElMREVMT09TRSA9IFIrKztcbnNyY1tUSUxERUxPT1NFXSA9ICdeJyArIHNyY1tMT05FVElMREVdICsgc3JjW1hSQU5HRVBMQUlOTE9PU0VdICsgJyQnO1xuXG4vLyBDYXJldCByYW5nZXMuXG4vLyBNZWFuaW5nIGlzIFwiYXQgbGVhc3QgYW5kIGJhY2t3YXJkcyBjb21wYXRpYmxlIHdpdGhcIlxudmFyIExPTkVDQVJFVCA9IFIrKztcbnNyY1tMT05FQ0FSRVRdID0gJyg/OlxcXFxeKSc7XG5cbnZhciBDQVJFVFRSSU0gPSBSKys7XG5zcmNbQ0FSRVRUUklNXSA9ICcoXFxcXHMqKScgKyBzcmNbTE9ORUNBUkVUXSArICdcXFxccysnO1xucmVbQ0FSRVRUUklNXSA9IG5ldyBSZWdFeHAoc3JjW0NBUkVUVFJJTV0sICdnJyk7XG52YXIgY2FyZXRUcmltUmVwbGFjZSA9ICckMV4nO1xuXG52YXIgQ0FSRVQgPSBSKys7XG5zcmNbQ0FSRVRdID0gJ14nICsgc3JjW0xPTkVDQVJFVF0gKyBzcmNbWFJBTkdFUExBSU5dICsgJyQnO1xudmFyIENBUkVUTE9PU0UgPSBSKys7XG5zcmNbQ0FSRVRMT09TRV0gPSAnXicgKyBzcmNbTE9ORUNBUkVUXSArIHNyY1tYUkFOR0VQTEFJTkxPT1NFXSArICckJztcblxuLy8gQSBzaW1wbGUgZ3QvbHQvZXEgdGhpbmcsIG9yIGp1c3QgXCJcIiB0byBpbmRpY2F0ZSBcImFueSB2ZXJzaW9uXCJcbnZhciBDT01QQVJBVE9STE9PU0UgPSBSKys7XG5zcmNbQ09NUEFSQVRPUkxPT1NFXSA9ICdeJyArIHNyY1tHVExUXSArICdcXFxccyooJyArIExPT1NFUExBSU4gKyAnKSR8XiQnO1xudmFyIENPTVBBUkFUT1IgPSBSKys7XG5zcmNbQ09NUEFSQVRPUl0gPSAnXicgKyBzcmNbR1RMVF0gKyAnXFxcXHMqKCcgKyBGVUxMUExBSU4gKyAnKSR8XiQnO1xuXG5cbi8vIEFuIGV4cHJlc3Npb24gdG8gc3RyaXAgYW55IHdoaXRlc3BhY2UgYmV0d2VlbiB0aGUgZ3RsdCBhbmQgdGhlIHRoaW5nXG4vLyBpdCBtb2RpZmllcywgc28gdGhhdCBgPiAxLjIuM2AgPT0+IGA+MS4yLjNgXG52YXIgQ09NUEFSQVRPUlRSSU0gPSBSKys7XG5zcmNbQ09NUEFSQVRPUlRSSU1dID0gJyhcXFxccyopJyArIHNyY1tHVExUXSArXG4gICAgICAgICAgICAgICAgICAgICAgJ1xcXFxzKignICsgTE9PU0VQTEFJTiArICd8JyArIHNyY1tYUkFOR0VQTEFJTl0gKyAnKSc7XG5cbi8vIHRoaXMgb25lIGhhcyB0byB1c2UgdGhlIC9nIGZsYWdcbnJlW0NPTVBBUkFUT1JUUklNXSA9IG5ldyBSZWdFeHAoc3JjW0NPTVBBUkFUT1JUUklNXSwgJ2cnKTtcbnZhciBjb21wYXJhdG9yVHJpbVJlcGxhY2UgPSAnJDEkMiQzJztcblxuXG4vLyBTb21ldGhpbmcgbGlrZSBgMS4yLjMgLSAxLjIuNGBcbi8vIE5vdGUgdGhhdCB0aGVzZSBhbGwgdXNlIHRoZSBsb29zZSBmb3JtLCBiZWNhdXNlIHRoZXknbGwgYmVcbi8vIGNoZWNrZWQgYWdhaW5zdCBlaXRoZXIgdGhlIHN0cmljdCBvciBsb29zZSBjb21wYXJhdG9yIGZvcm1cbi8vIGxhdGVyLlxudmFyIEhZUEhFTlJBTkdFID0gUisrO1xuc3JjW0hZUEhFTlJBTkdFXSA9ICdeXFxcXHMqKCcgKyBzcmNbWFJBTkdFUExBSU5dICsgJyknICtcbiAgICAgICAgICAgICAgICAgICAnXFxcXHMrLVxcXFxzKycgK1xuICAgICAgICAgICAgICAgICAgICcoJyArIHNyY1tYUkFOR0VQTEFJTl0gKyAnKScgK1xuICAgICAgICAgICAgICAgICAgICdcXFxccyokJztcblxudmFyIEhZUEhFTlJBTkdFTE9PU0UgPSBSKys7XG5zcmNbSFlQSEVOUkFOR0VMT09TRV0gPSAnXlxcXFxzKignICsgc3JjW1hSQU5HRVBMQUlOTE9PU0VdICsgJyknICtcbiAgICAgICAgICAgICAgICAgICAgICAgICdcXFxccystXFxcXHMrJyArXG4gICAgICAgICAgICAgICAgICAgICAgICAnKCcgKyBzcmNbWFJBTkdFUExBSU5MT09TRV0gKyAnKScgK1xuICAgICAgICAgICAgICAgICAgICAgICAgJ1xcXFxzKiQnO1xuXG4vLyBTdGFyIHJhbmdlcyBiYXNpY2FsbHkganVzdCBhbGxvdyBhbnl0aGluZyBhdCBhbGwuXG52YXIgU1RBUiA9IFIrKztcbnNyY1tTVEFSXSA9ICcoPHw+KT89P1xcXFxzKlxcXFwqJztcblxuLy8gQ29tcGlsZSB0byBhY3R1YWwgcmVnZXhwIG9iamVjdHMuXG4vLyBBbGwgYXJlIGZsYWctZnJlZSwgdW5sZXNzIHRoZXkgd2VyZSBjcmVhdGVkIGFib3ZlIHdpdGggYSBmbGFnLlxuZm9yICh2YXIgaSA9IDA7IGkgPCBSOyBpKyspIHtcbiAgZGVidWcoaSwgc3JjW2ldKTtcbiAgaWYgKCFyZVtpXSlcbiAgICByZVtpXSA9IG5ldyBSZWdFeHAoc3JjW2ldKTtcbn1cblxuZXhwb3J0cy5wYXJzZSA9IHBhcnNlO1xuZnVuY3Rpb24gcGFyc2UodmVyc2lvbiwgbG9vc2UpIHtcbiAgaWYgKHZlcnNpb24gaW5zdGFuY2VvZiBTZW1WZXIpXG4gICAgcmV0dXJuIHZlcnNpb247XG5cbiAgaWYgKHR5cGVvZiB2ZXJzaW9uICE9PSAnc3RyaW5nJylcbiAgICByZXR1cm4gbnVsbDtcblxuICBpZiAodmVyc2lvbi5sZW5ndGggPiBNQVhfTEVOR1RIKVxuICAgIHJldHVybiBudWxsO1xuXG4gIHZhciByID0gbG9vc2UgPyByZVtMT09TRV0gOiByZVtGVUxMXTtcbiAgaWYgKCFyLnRlc3QodmVyc2lvbikpXG4gICAgcmV0dXJuIG51bGw7XG5cbiAgdHJ5IHtcbiAgICByZXR1cm4gbmV3IFNlbVZlcih2ZXJzaW9uLCBsb29zZSk7XG4gIH0gY2F0Y2ggKGVyKSB7XG4gICAgcmV0dXJuIG51bGw7XG4gIH1cbn1cblxuZXhwb3J0cy52YWxpZCA9IHZhbGlkO1xuZnVuY3Rpb24gdmFsaWQodmVyc2lvbiwgbG9vc2UpIHtcbiAgdmFyIHYgPSBwYXJzZSh2ZXJzaW9uLCBsb29zZSk7XG4gIHJldHVybiB2ID8gdi52ZXJzaW9uIDogbnVsbDtcbn1cblxuXG5leHBvcnRzLmNsZWFuID0gY2xlYW47XG5mdW5jdGlvbiBjbGVhbih2ZXJzaW9uLCBsb29zZSkge1xuICB2YXIgcyA9IHBhcnNlKHZlcnNpb24udHJpbSgpLnJlcGxhY2UoL15bPXZdKy8sICcnKSwgbG9vc2UpO1xuICByZXR1cm4gcyA/IHMudmVyc2lvbiA6IG51bGw7XG59XG5cbmV4cG9ydHMuU2VtVmVyID0gU2VtVmVyO1xuXG5mdW5jdGlvbiBTZW1WZXIodmVyc2lvbiwgbG9vc2UpIHtcbiAgaWYgKHZlcnNpb24gaW5zdGFuY2VvZiBTZW1WZXIpIHtcbiAgICBpZiAodmVyc2lvbi5sb29zZSA9PT0gbG9vc2UpXG4gICAgICByZXR1cm4gdmVyc2lvbjtcbiAgICBlbHNlXG4gICAgICB2ZXJzaW9uID0gdmVyc2lvbi52ZXJzaW9uO1xuICB9IGVsc2UgaWYgKHR5cGVvZiB2ZXJzaW9uICE9PSAnc3RyaW5nJykge1xuICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ0ludmFsaWQgVmVyc2lvbjogJyArIHZlcnNpb24pO1xuICB9XG5cbiAgaWYgKHZlcnNpb24ubGVuZ3RoID4gTUFYX0xFTkdUSClcbiAgICB0aHJvdyBuZXcgVHlwZUVycm9yKCd2ZXJzaW9uIGlzIGxvbmdlciB0aGFuICcgKyBNQVhfTEVOR1RIICsgJyBjaGFyYWN0ZXJzJylcblxuICBpZiAoISh0aGlzIGluc3RhbmNlb2YgU2VtVmVyKSlcbiAgICByZXR1cm4gbmV3IFNlbVZlcih2ZXJzaW9uLCBsb29zZSk7XG5cbiAgZGVidWcoJ1NlbVZlcicsIHZlcnNpb24sIGxvb3NlKTtcbiAgdGhpcy5sb29zZSA9IGxvb3NlO1xuICB2YXIgbSA9IHZlcnNpb24udHJpbSgpLm1hdGNoKGxvb3NlID8gcmVbTE9PU0VdIDogcmVbRlVMTF0pO1xuXG4gIGlmICghbSlcbiAgICB0aHJvdyBuZXcgVHlwZUVycm9yKCdJbnZhbGlkIFZlcnNpb246ICcgKyB2ZXJzaW9uKTtcblxuICB0aGlzLnJhdyA9IHZlcnNpb247XG5cbiAgLy8gdGhlc2UgYXJlIGFjdHVhbGx5IG51bWJlcnNcbiAgdGhpcy5tYWpvciA9ICttWzFdO1xuICB0aGlzLm1pbm9yID0gK21bMl07XG4gIHRoaXMucGF0Y2ggPSArbVszXTtcblxuICBpZiAodGhpcy5tYWpvciA+IE1BWF9TQUZFX0lOVEVHRVIgfHwgdGhpcy5tYWpvciA8IDApXG4gICAgdGhyb3cgbmV3IFR5cGVFcnJvcignSW52YWxpZCBtYWpvciB2ZXJzaW9uJylcblxuICBpZiAodGhpcy5taW5vciA+IE1BWF9TQUZFX0lOVEVHRVIgfHwgdGhpcy5taW5vciA8IDApXG4gICAgdGhyb3cgbmV3IFR5cGVFcnJvcignSW52YWxpZCBtaW5vciB2ZXJzaW9uJylcblxuICBpZiAodGhpcy5wYXRjaCA+IE1BWF9TQUZFX0lOVEVHRVIgfHwgdGhpcy5wYXRjaCA8IDApXG4gICAgdGhyb3cgbmV3IFR5cGVFcnJvcignSW52YWxpZCBwYXRjaCB2ZXJzaW9uJylcblxuICAvLyBudW1iZXJpZnkgYW55IHByZXJlbGVhc2UgbnVtZXJpYyBpZHNcbiAgaWYgKCFtWzRdKVxuICAgIHRoaXMucHJlcmVsZWFzZSA9IFtdO1xuICBlbHNlXG4gICAgdGhpcy5wcmVyZWxlYXNlID0gbVs0XS5zcGxpdCgnLicpLm1hcChmdW5jdGlvbihpZCkge1xuICAgICAgaWYgKC9eWzAtOV0rJC8udGVzdChpZCkpIHtcbiAgICAgICAgdmFyIG51bSA9ICtpZDtcbiAgICAgICAgaWYgKG51bSA+PSAwICYmIG51bSA8IE1BWF9TQUZFX0lOVEVHRVIpXG4gICAgICAgICAgcmV0dXJuIG51bTtcbiAgICAgIH1cbiAgICAgIHJldHVybiBpZDtcbiAgICB9KTtcblxuICB0aGlzLmJ1aWxkID0gbVs1XSA/IG1bNV0uc3BsaXQoJy4nKSA6IFtdO1xuICB0aGlzLmZvcm1hdCgpO1xufVxuXG5TZW1WZXIucHJvdG90eXBlLmZvcm1hdCA9IGZ1bmN0aW9uKCkge1xuICB0aGlzLnZlcnNpb24gPSB0aGlzLm1ham9yICsgJy4nICsgdGhpcy5taW5vciArICcuJyArIHRoaXMucGF0Y2g7XG4gIGlmICh0aGlzLnByZXJlbGVhc2UubGVuZ3RoKVxuICAgIHRoaXMudmVyc2lvbiArPSAnLScgKyB0aGlzLnByZXJlbGVhc2Uuam9pbignLicpO1xuICByZXR1cm4gdGhpcy52ZXJzaW9uO1xufTtcblxuU2VtVmVyLnByb3RvdHlwZS50b1N0cmluZyA9IGZ1bmN0aW9uKCkge1xuICByZXR1cm4gdGhpcy52ZXJzaW9uO1xufTtcblxuU2VtVmVyLnByb3RvdHlwZS5jb21wYXJlID0gZnVuY3Rpb24ob3RoZXIpIHtcbiAgZGVidWcoJ1NlbVZlci5jb21wYXJlJywgdGhpcy52ZXJzaW9uLCB0aGlzLmxvb3NlLCBvdGhlcik7XG4gIGlmICghKG90aGVyIGluc3RhbmNlb2YgU2VtVmVyKSlcbiAgICBvdGhlciA9IG5ldyBTZW1WZXIob3RoZXIsIHRoaXMubG9vc2UpO1xuXG4gIHJldHVybiB0aGlzLmNvbXBhcmVNYWluKG90aGVyKSB8fCB0aGlzLmNvbXBhcmVQcmUob3RoZXIpO1xufTtcblxuU2VtVmVyLnByb3RvdHlwZS5jb21wYXJlTWFpbiA9IGZ1bmN0aW9uKG90aGVyKSB7XG4gIGlmICghKG90aGVyIGluc3RhbmNlb2YgU2VtVmVyKSlcbiAgICBvdGhlciA9IG5ldyBTZW1WZXIob3RoZXIsIHRoaXMubG9vc2UpO1xuXG4gIHJldHVybiBjb21wYXJlSWRlbnRpZmllcnModGhpcy5tYWpvciwgb3RoZXIubWFqb3IpIHx8XG4gICAgICAgICBjb21wYXJlSWRlbnRpZmllcnModGhpcy5taW5vciwgb3RoZXIubWlub3IpIHx8XG4gICAgICAgICBjb21wYXJlSWRlbnRpZmllcnModGhpcy5wYXRjaCwgb3RoZXIucGF0Y2gpO1xufTtcblxuU2VtVmVyLnByb3RvdHlwZS5jb21wYXJlUHJlID0gZnVuY3Rpb24ob3RoZXIpIHtcbiAgaWYgKCEob3RoZXIgaW5zdGFuY2VvZiBTZW1WZXIpKVxuICAgIG90aGVyID0gbmV3IFNlbVZlcihvdGhlciwgdGhpcy5sb29zZSk7XG5cbiAgLy8gTk9UIGhhdmluZyBhIHByZXJlbGVhc2UgaXMgPiBoYXZpbmcgb25lXG4gIGlmICh0aGlzLnByZXJlbGVhc2UubGVuZ3RoICYmICFvdGhlci5wcmVyZWxlYXNlLmxlbmd0aClcbiAgICByZXR1cm4gLTE7XG4gIGVsc2UgaWYgKCF0aGlzLnByZXJlbGVhc2UubGVuZ3RoICYmIG90aGVyLnByZXJlbGVhc2UubGVuZ3RoKVxuICAgIHJldHVybiAxO1xuICBlbHNlIGlmICghdGhpcy5wcmVyZWxlYXNlLmxlbmd0aCAmJiAhb3RoZXIucHJlcmVsZWFzZS5sZW5ndGgpXG4gICAgcmV0dXJuIDA7XG5cbiAgdmFyIGkgPSAwO1xuICBkbyB7XG4gICAgdmFyIGEgPSB0aGlzLnByZXJlbGVhc2VbaV07XG4gICAgdmFyIGIgPSBvdGhlci5wcmVyZWxlYXNlW2ldO1xuICAgIGRlYnVnKCdwcmVyZWxlYXNlIGNvbXBhcmUnLCBpLCBhLCBiKTtcbiAgICBpZiAoYSA9PT0gdW5kZWZpbmVkICYmIGIgPT09IHVuZGVmaW5lZClcbiAgICAgIHJldHVybiAwO1xuICAgIGVsc2UgaWYgKGIgPT09IHVuZGVmaW5lZClcbiAgICAgIHJldHVybiAxO1xuICAgIGVsc2UgaWYgKGEgPT09IHVuZGVmaW5lZClcbiAgICAgIHJldHVybiAtMTtcbiAgICBlbHNlIGlmIChhID09PSBiKVxuICAgICAgY29udGludWU7XG4gICAgZWxzZVxuICAgICAgcmV0dXJuIGNvbXBhcmVJZGVudGlmaWVycyhhLCBiKTtcbiAgfSB3aGlsZSAoKytpKTtcbn07XG5cbi8vIHByZW1pbm9yIHdpbGwgYnVtcCB0aGUgdmVyc2lvbiB1cCB0byB0aGUgbmV4dCBtaW5vciByZWxlYXNlLCBhbmQgaW1tZWRpYXRlbHlcbi8vIGRvd24gdG8gcHJlLXJlbGVhc2UuIHByZW1ham9yIGFuZCBwcmVwYXRjaCB3b3JrIHRoZSBzYW1lIHdheS5cblNlbVZlci5wcm90b3R5cGUuaW5jID0gZnVuY3Rpb24ocmVsZWFzZSwgaWRlbnRpZmllcikge1xuICBzd2l0Y2ggKHJlbGVhc2UpIHtcbiAgICBjYXNlICdwcmVtYWpvcic6XG4gICAgICB0aGlzLnByZXJlbGVhc2UubGVuZ3RoID0gMDtcbiAgICAgIHRoaXMucGF0Y2ggPSAwO1xuICAgICAgdGhpcy5taW5vciA9IDA7XG4gICAgICB0aGlzLm1ham9yKys7XG4gICAgICB0aGlzLmluYygncHJlJywgaWRlbnRpZmllcik7XG4gICAgICBicmVhaztcbiAgICBjYXNlICdwcmVtaW5vcic6XG4gICAgICB0aGlzLnByZXJlbGVhc2UubGVuZ3RoID0gMDtcbiAgICAgIHRoaXMucGF0Y2ggPSAwO1xuICAgICAgdGhpcy5taW5vcisrO1xuICAgICAgdGhpcy5pbmMoJ3ByZScsIGlkZW50aWZpZXIpO1xuICAgICAgYnJlYWs7XG4gICAgY2FzZSAncHJlcGF0Y2gnOlxuICAgICAgLy8gSWYgdGhpcyBpcyBhbHJlYWR5IGEgcHJlcmVsZWFzZSwgaXQgd2lsbCBidW1wIHRvIHRoZSBuZXh0IHZlcnNpb25cbiAgICAgIC8vIGRyb3AgYW55IHByZXJlbGVhc2VzIHRoYXQgbWlnaHQgYWxyZWFkeSBleGlzdCwgc2luY2UgdGhleSBhcmUgbm90XG4gICAgICAvLyByZWxldmFudCBhdCB0aGlzIHBvaW50LlxuICAgICAgdGhpcy5wcmVyZWxlYXNlLmxlbmd0aCA9IDA7XG4gICAgICB0aGlzLmluYygncGF0Y2gnLCBpZGVudGlmaWVyKTtcbiAgICAgIHRoaXMuaW5jKCdwcmUnLCBpZGVudGlmaWVyKTtcbiAgICAgIGJyZWFrO1xuICAgIC8vIElmIHRoZSBpbnB1dCBpcyBhIG5vbi1wcmVyZWxlYXNlIHZlcnNpb24sIHRoaXMgYWN0cyB0aGUgc2FtZSBhc1xuICAgIC8vIHByZXBhdGNoLlxuICAgIGNhc2UgJ3ByZXJlbGVhc2UnOlxuICAgICAgaWYgKHRoaXMucHJlcmVsZWFzZS5sZW5ndGggPT09IDApXG4gICAgICAgIHRoaXMuaW5jKCdwYXRjaCcsIGlkZW50aWZpZXIpO1xuICAgICAgdGhpcy5pbmMoJ3ByZScsIGlkZW50aWZpZXIpO1xuICAgICAgYnJlYWs7XG5cbiAgICBjYXNlICdtYWpvcic6XG4gICAgICAvLyBJZiB0aGlzIGlzIGEgcHJlLW1ham9yIHZlcnNpb24sIGJ1bXAgdXAgdG8gdGhlIHNhbWUgbWFqb3IgdmVyc2lvbi5cbiAgICAgIC8vIE90aGVyd2lzZSBpbmNyZW1lbnQgbWFqb3IuXG4gICAgICAvLyAxLjAuMC01IGJ1bXBzIHRvIDEuMC4wXG4gICAgICAvLyAxLjEuMCBidW1wcyB0byAyLjAuMFxuICAgICAgaWYgKHRoaXMubWlub3IgIT09IDAgfHwgdGhpcy5wYXRjaCAhPT0gMCB8fCB0aGlzLnByZXJlbGVhc2UubGVuZ3RoID09PSAwKVxuICAgICAgICB0aGlzLm1ham9yKys7XG4gICAgICB0aGlzLm1pbm9yID0gMDtcbiAgICAgIHRoaXMucGF0Y2ggPSAwO1xuICAgICAgdGhpcy5wcmVyZWxlYXNlID0gW107XG4gICAgICBicmVhaztcbiAgICBjYXNlICdtaW5vcic6XG4gICAgICAvLyBJZiB0aGlzIGlzIGEgcHJlLW1pbm9yIHZlcnNpb24sIGJ1bXAgdXAgdG8gdGhlIHNhbWUgbWlub3IgdmVyc2lvbi5cbiAgICAgIC8vIE90aGVyd2lzZSBpbmNyZW1lbnQgbWlub3IuXG4gICAgICAvLyAxLjIuMC01IGJ1bXBzIHRvIDEuMi4wXG4gICAgICAvLyAxLjIuMSBidW1wcyB0byAxLjMuMFxuICAgICAgaWYgKHRoaXMucGF0Y2ggIT09IDAgfHwgdGhpcy5wcmVyZWxlYXNlLmxlbmd0aCA9PT0gMClcbiAgICAgICAgdGhpcy5taW5vcisrO1xuICAgICAgdGhpcy5wYXRjaCA9IDA7XG4gICAgICB0aGlzLnByZXJlbGVhc2UgPSBbXTtcbiAgICAgIGJyZWFrO1xuICAgIGNhc2UgJ3BhdGNoJzpcbiAgICAgIC8vIElmIHRoaXMgaXMgbm90IGEgcHJlLXJlbGVhc2UgdmVyc2lvbiwgaXQgd2lsbCBpbmNyZW1lbnQgdGhlIHBhdGNoLlxuICAgICAgLy8gSWYgaXQgaXMgYSBwcmUtcmVsZWFzZSBpdCB3aWxsIGJ1bXAgdXAgdG8gdGhlIHNhbWUgcGF0Y2ggdmVyc2lvbi5cbiAgICAgIC8vIDEuMi4wLTUgcGF0Y2hlcyB0byAxLjIuMFxuICAgICAgLy8gMS4yLjAgcGF0Y2hlcyB0byAxLjIuMVxuICAgICAgaWYgKHRoaXMucHJlcmVsZWFzZS5sZW5ndGggPT09IDApXG4gICAgICAgIHRoaXMucGF0Y2grKztcbiAgICAgIHRoaXMucHJlcmVsZWFzZSA9IFtdO1xuICAgICAgYnJlYWs7XG4gICAgLy8gVGhpcyBwcm9iYWJseSBzaG91bGRuJ3QgYmUgdXNlZCBwdWJsaWNseS5cbiAgICAvLyAxLjAuMCBcInByZVwiIHdvdWxkIGJlY29tZSAxLjAuMC0wIHdoaWNoIGlzIHRoZSB3cm9uZyBkaXJlY3Rpb24uXG4gICAgY2FzZSAncHJlJzpcbiAgICAgIGlmICh0aGlzLnByZXJlbGVhc2UubGVuZ3RoID09PSAwKVxuICAgICAgICB0aGlzLnByZXJlbGVhc2UgPSBbMF07XG4gICAgICBlbHNlIHtcbiAgICAgICAgdmFyIGkgPSB0aGlzLnByZXJlbGVhc2UubGVuZ3RoO1xuICAgICAgICB3aGlsZSAoLS1pID49IDApIHtcbiAgICAgICAgICBpZiAodHlwZW9mIHRoaXMucHJlcmVsZWFzZVtpXSA9PT0gJ251bWJlcicpIHtcbiAgICAgICAgICAgIHRoaXMucHJlcmVsZWFzZVtpXSsrO1xuICAgICAgICAgICAgaSA9IC0yO1xuICAgICAgICAgIH1cbiAgICAgICAgfVxuICAgICAgICBpZiAoaSA9PT0gLTEpIC8vIGRpZG4ndCBpbmNyZW1lbnQgYW55dGhpbmdcbiAgICAgICAgICB0aGlzLnByZXJlbGVhc2UucHVzaCgwKTtcbiAgICAgIH1cbiAgICAgIGlmIChpZGVudGlmaWVyKSB7XG4gICAgICAgIC8vIDEuMi4wLWJldGEuMSBidW1wcyB0byAxLjIuMC1iZXRhLjIsXG4gICAgICAgIC8vIDEuMi4wLWJldGEuZm9vYmx6IG9yIDEuMi4wLWJldGEgYnVtcHMgdG8gMS4yLjAtYmV0YS4wXG4gICAgICAgIGlmICh0aGlzLnByZXJlbGVhc2VbMF0gPT09IGlkZW50aWZpZXIpIHtcbiAgICAgICAgICBpZiAoaXNOYU4odGhpcy5wcmVyZWxlYXNlWzFdKSlcbiAgICAgICAgICAgIHRoaXMucHJlcmVsZWFzZSA9IFtpZGVudGlmaWVyLCAwXTtcbiAgICAgICAgfSBlbHNlXG4gICAgICAgICAgdGhpcy5wcmVyZWxlYXNlID0gW2lkZW50aWZpZXIsIDBdO1xuICAgICAgfVxuICAgICAgYnJlYWs7XG5cbiAgICBkZWZhdWx0OlxuICAgICAgdGhyb3cgbmV3IEVycm9yKCdpbnZhbGlkIGluY3JlbWVudCBhcmd1bWVudDogJyArIHJlbGVhc2UpO1xuICB9XG4gIHRoaXMuZm9ybWF0KCk7XG4gIHRoaXMucmF3ID0gdGhpcy52ZXJzaW9uO1xuICByZXR1cm4gdGhpcztcbn07XG5cbmV4cG9ydHMuaW5jID0gaW5jO1xuZnVuY3Rpb24gaW5jKHZlcnNpb24sIHJlbGVhc2UsIGxvb3NlLCBpZGVudGlmaWVyKSB7XG4gIGlmICh0eXBlb2YobG9vc2UpID09PSAnc3RyaW5nJykge1xuICAgIGlkZW50aWZpZXIgPSBsb29zZTtcbiAgICBsb29zZSA9IHVuZGVmaW5lZDtcbiAgfVxuXG4gIHRyeSB7XG4gICAgcmV0dXJuIG5ldyBTZW1WZXIodmVyc2lvbiwgbG9vc2UpLmluYyhyZWxlYXNlLCBpZGVudGlmaWVyKS52ZXJzaW9uO1xuICB9IGNhdGNoIChlcikge1xuICAgIHJldHVybiBudWxsO1xuICB9XG59XG5cbmV4cG9ydHMuZGlmZiA9IGRpZmY7XG5mdW5jdGlvbiBkaWZmKHZlcnNpb24xLCB2ZXJzaW9uMikge1xuICBpZiAoZXEodmVyc2lvbjEsIHZlcnNpb24yKSkge1xuICAgIHJldHVybiBudWxsO1xuICB9IGVsc2Uge1xuICAgIHZhciB2MSA9IHBhcnNlKHZlcnNpb24xKTtcbiAgICB2YXIgdjIgPSBwYXJzZSh2ZXJzaW9uMik7XG4gICAgaWYgKHYxLnByZXJlbGVhc2UubGVuZ3RoIHx8IHYyLnByZXJlbGVhc2UubGVuZ3RoKSB7XG4gICAgICBmb3IgKHZhciBrZXkgaW4gdjEpIHtcbiAgICAgICAgaWYgKGtleSA9PT0gJ21ham9yJyB8fCBrZXkgPT09ICdtaW5vcicgfHwga2V5ID09PSAncGF0Y2gnKSB7XG4gICAgICAgICAgaWYgKHYxW2tleV0gIT09IHYyW2tleV0pIHtcbiAgICAgICAgICAgIHJldHVybiAncHJlJytrZXk7XG4gICAgICAgICAgfVxuICAgICAgICB9XG4gICAgICB9XG4gICAgICByZXR1cm4gJ3ByZXJlbGVhc2UnO1xuICAgIH1cbiAgICBmb3IgKHZhciBrZXkgaW4gdjEpIHtcbiAgICAgIGlmIChrZXkgPT09ICdtYWpvcicgfHwga2V5ID09PSAnbWlub3InIHx8IGtleSA9PT0gJ3BhdGNoJykge1xuICAgICAgICBpZiAodjFba2V5XSAhPT0gdjJba2V5XSkge1xuICAgICAgICAgIHJldHVybiBrZXk7XG4gICAgICAgIH1cbiAgICAgIH1cbiAgICB9XG4gIH1cbn1cblxuZXhwb3J0cy5jb21wYXJlSWRlbnRpZmllcnMgPSBjb21wYXJlSWRlbnRpZmllcnM7XG5cbnZhciBudW1lcmljID0gL15bMC05XSskLztcbmZ1bmN0aW9uIGNvbXBhcmVJZGVudGlmaWVycyhhLCBiKSB7XG4gIHZhciBhbnVtID0gbnVtZXJpYy50ZXN0KGEpO1xuICB2YXIgYm51bSA9IG51bWVyaWMudGVzdChiKTtcblxuICBpZiAoYW51bSAmJiBibnVtKSB7XG4gICAgYSA9ICthO1xuICAgIGIgPSArYjtcbiAgfVxuXG4gIHJldHVybiAoYW51bSAmJiAhYm51bSkgPyAtMSA6XG4gICAgICAgICAoYm51bSAmJiAhYW51bSkgPyAxIDpcbiAgICAgICAgIGEgPCBiID8gLTEgOlxuICAgICAgICAgYSA+IGIgPyAxIDpcbiAgICAgICAgIDA7XG59XG5cbmV4cG9ydHMucmNvbXBhcmVJZGVudGlmaWVycyA9IHJjb21wYXJlSWRlbnRpZmllcnM7XG5mdW5jdGlvbiByY29tcGFyZUlkZW50aWZpZXJzKGEsIGIpIHtcbiAgcmV0dXJuIGNvbXBhcmVJZGVudGlmaWVycyhiLCBhKTtcbn1cblxuZXhwb3J0cy5tYWpvciA9IG1ham9yO1xuZnVuY3Rpb24gbWFqb3IoYSwgbG9vc2UpIHtcbiAgcmV0dXJuIG5ldyBTZW1WZXIoYSwgbG9vc2UpLm1ham9yO1xufVxuXG5leHBvcnRzLm1pbm9yID0gbWlub3I7XG5mdW5jdGlvbiBtaW5vcihhLCBsb29zZSkge1xuICByZXR1cm4gbmV3IFNlbVZlcihhLCBsb29zZSkubWlub3I7XG59XG5cbmV4cG9ydHMucGF0Y2ggPSBwYXRjaDtcbmZ1bmN0aW9uIHBhdGNoKGEsIGxvb3NlKSB7XG4gIHJldHVybiBuZXcgU2VtVmVyKGEsIGxvb3NlKS5wYXRjaDtcbn1cblxuZXhwb3J0cy5jb21wYXJlID0gY29tcGFyZTtcbmZ1bmN0aW9uIGNvbXBhcmUoYSwgYiwgbG9vc2UpIHtcbiAgcmV0dXJuIG5ldyBTZW1WZXIoYSwgbG9vc2UpLmNvbXBhcmUoYik7XG59XG5cbmV4cG9ydHMuY29tcGFyZUxvb3NlID0gY29tcGFyZUxvb3NlO1xuZnVuY3Rpb24gY29tcGFyZUxvb3NlKGEsIGIpIHtcbiAgcmV0dXJuIGNvbXBhcmUoYSwgYiwgdHJ1ZSk7XG59XG5cbmV4cG9ydHMucmNvbXBhcmUgPSByY29tcGFyZTtcbmZ1bmN0aW9uIHJjb21wYXJlKGEsIGIsIGxvb3NlKSB7XG4gIHJldHVybiBjb21wYXJlKGIsIGEsIGxvb3NlKTtcbn1cblxuZXhwb3J0cy5zb3J0ID0gc29ydDtcbmZ1bmN0aW9uIHNvcnQobGlzdCwgbG9vc2UpIHtcbiAgcmV0dXJuIGxpc3Quc29ydChmdW5jdGlvbihhLCBiKSB7XG4gICAgcmV0dXJuIGV4cG9ydHMuY29tcGFyZShhLCBiLCBsb29zZSk7XG4gIH0pO1xufVxuXG5leHBvcnRzLnJzb3J0ID0gcnNvcnQ7XG5mdW5jdGlvbiByc29ydChsaXN0LCBsb29zZSkge1xuICByZXR1cm4gbGlzdC5zb3J0KGZ1bmN0aW9uKGEsIGIpIHtcbiAgICByZXR1cm4gZXhwb3J0cy5yY29tcGFyZShhLCBiLCBsb29zZSk7XG4gIH0pO1xufVxuXG5leHBvcnRzLmd0ID0gZ3Q7XG5mdW5jdGlvbiBndChhLCBiLCBsb29zZSkge1xuICByZXR1cm4gY29tcGFyZShhLCBiLCBsb29zZSkgPiAwO1xufVxuXG5leHBvcnRzLmx0ID0gbHQ7XG5mdW5jdGlvbiBsdChhLCBiLCBsb29zZSkge1xuICByZXR1cm4gY29tcGFyZShhLCBiLCBsb29zZSkgPCAwO1xufVxuXG5leHBvcnRzLmVxID0gZXE7XG5mdW5jdGlvbiBlcShhLCBiLCBsb29zZSkge1xuICByZXR1cm4gY29tcGFyZShhLCBiLCBsb29zZSkgPT09IDA7XG59XG5cbmV4cG9ydHMubmVxID0gbmVxO1xuZnVuY3Rpb24gbmVxKGEsIGIsIGxvb3NlKSB7XG4gIHJldHVybiBjb21wYXJlKGEsIGIsIGxvb3NlKSAhPT0gMDtcbn1cblxuZXhwb3J0cy5ndGUgPSBndGU7XG5mdW5jdGlvbiBndGUoYSwgYiwgbG9vc2UpIHtcbiAgcmV0dXJuIGNvbXBhcmUoYSwgYiwgbG9vc2UpID49IDA7XG59XG5cbmV4cG9ydHMubHRlID0gbHRlO1xuZnVuY3Rpb24gbHRlKGEsIGIsIGxvb3NlKSB7XG4gIHJldHVybiBjb21wYXJlKGEsIGIsIGxvb3NlKSA8PSAwO1xufVxuXG5leHBvcnRzLmNtcCA9IGNtcDtcbmZ1bmN0aW9uIGNtcChhLCBvcCwgYiwgbG9vc2UpIHtcbiAgdmFyIHJldDtcbiAgc3dpdGNoIChvcCkge1xuICAgIGNhc2UgJz09PSc6XG4gICAgICBpZiAodHlwZW9mIGEgPT09ICdvYmplY3QnKSBhID0gYS52ZXJzaW9uO1xuICAgICAgaWYgKHR5cGVvZiBiID09PSAnb2JqZWN0JykgYiA9IGIudmVyc2lvbjtcbiAgICAgIHJldCA9IGEgPT09IGI7XG4gICAgICBicmVhaztcbiAgICBjYXNlICchPT0nOlxuICAgICAgaWYgKHR5cGVvZiBhID09PSAnb2JqZWN0JykgYSA9IGEudmVyc2lvbjtcbiAgICAgIGlmICh0eXBlb2YgYiA9PT0gJ29iamVjdCcpIGIgPSBiLnZlcnNpb247XG4gICAgICByZXQgPSBhICE9PSBiO1xuICAgICAgYnJlYWs7XG4gICAgY2FzZSAnJzogY2FzZSAnPSc6IGNhc2UgJz09JzogcmV0ID0gZXEoYSwgYiwgbG9vc2UpOyBicmVhaztcbiAgICBjYXNlICchPSc6IHJldCA9IG5lcShhLCBiLCBsb29zZSk7IGJyZWFrO1xuICAgIGNhc2UgJz4nOiByZXQgPSBndChhLCBiLCBsb29zZSk7IGJyZWFrO1xuICAgIGNhc2UgJz49JzogcmV0ID0gZ3RlKGEsIGIsIGxvb3NlKTsgYnJlYWs7XG4gICAgY2FzZSAnPCc6IHJldCA9IGx0KGEsIGIsIGxvb3NlKTsgYnJlYWs7XG4gICAgY2FzZSAnPD0nOiByZXQgPSBsdGUoYSwgYiwgbG9vc2UpOyBicmVhaztcbiAgICBkZWZhdWx0OiB0aHJvdyBuZXcgVHlwZUVycm9yKCdJbnZhbGlkIG9wZXJhdG9yOiAnICsgb3ApO1xuICB9XG4gIHJldHVybiByZXQ7XG59XG5cbmV4cG9ydHMuQ29tcGFyYXRvciA9IENvbXBhcmF0b3I7XG5mdW5jdGlvbiBDb21wYXJhdG9yKGNvbXAsIGxvb3NlKSB7XG4gIGlmIChjb21wIGluc3RhbmNlb2YgQ29tcGFyYXRvcikge1xuICAgIGlmIChjb21wLmxvb3NlID09PSBsb29zZSlcbiAgICAgIHJldHVybiBjb21wO1xuICAgIGVsc2VcbiAgICAgIGNvbXAgPSBjb21wLnZhbHVlO1xuICB9XG5cbiAgaWYgKCEodGhpcyBpbnN0YW5jZW9mIENvbXBhcmF0b3IpKVxuICAgIHJldHVybiBuZXcgQ29tcGFyYXRvcihjb21wLCBsb29zZSk7XG5cbiAgZGVidWcoJ2NvbXBhcmF0b3InLCBjb21wLCBsb29zZSk7XG4gIHRoaXMubG9vc2UgPSBsb29zZTtcbiAgdGhpcy5wYXJzZShjb21wKTtcblxuICBpZiAodGhpcy5zZW12ZXIgPT09IEFOWSlcbiAgICB0aGlzLnZhbHVlID0gJyc7XG4gIGVsc2VcbiAgICB0aGlzLnZhbHVlID0gdGhpcy5vcGVyYXRvciArIHRoaXMuc2VtdmVyLnZlcnNpb247XG5cbiAgZGVidWcoJ2NvbXAnLCB0aGlzKTtcbn1cblxudmFyIEFOWSA9IHt9O1xuQ29tcGFyYXRvci5wcm90b3R5cGUucGFyc2UgPSBmdW5jdGlvbihjb21wKSB7XG4gIHZhciByID0gdGhpcy5sb29zZSA/IHJlW0NPTVBBUkFUT1JMT09TRV0gOiByZVtDT01QQVJBVE9SXTtcbiAgdmFyIG0gPSBjb21wLm1hdGNoKHIpO1xuXG4gIGlmICghbSlcbiAgICB0aHJvdyBuZXcgVHlwZUVycm9yKCdJbnZhbGlkIGNvbXBhcmF0b3I6ICcgKyBjb21wKTtcblxuICB0aGlzLm9wZXJhdG9yID0gbVsxXTtcbiAgaWYgKHRoaXMub3BlcmF0b3IgPT09ICc9JylcbiAgICB0aGlzLm9wZXJhdG9yID0gJyc7XG5cbiAgLy8gaWYgaXQgbGl0ZXJhbGx5IGlzIGp1c3QgJz4nIG9yICcnIHRoZW4gYWxsb3cgYW55dGhpbmcuXG4gIGlmICghbVsyXSlcbiAgICB0aGlzLnNlbXZlciA9IEFOWTtcbiAgZWxzZVxuICAgIHRoaXMuc2VtdmVyID0gbmV3IFNlbVZlcihtWzJdLCB0aGlzLmxvb3NlKTtcbn07XG5cbkNvbXBhcmF0b3IucHJvdG90eXBlLnRvU3RyaW5nID0gZnVuY3Rpb24oKSB7XG4gIHJldHVybiB0aGlzLnZhbHVlO1xufTtcblxuQ29tcGFyYXRvci5wcm90b3R5cGUudGVzdCA9IGZ1bmN0aW9uKHZlcnNpb24pIHtcbiAgZGVidWcoJ0NvbXBhcmF0b3IudGVzdCcsIHZlcnNpb24sIHRoaXMubG9vc2UpO1xuXG4gIGlmICh0aGlzLnNlbXZlciA9PT0gQU5ZKVxuICAgIHJldHVybiB0cnVlO1xuXG4gIGlmICh0eXBlb2YgdmVyc2lvbiA9PT0gJ3N0cmluZycpXG4gICAgdmVyc2lvbiA9IG5ldyBTZW1WZXIodmVyc2lvbiwgdGhpcy5sb29zZSk7XG5cbiAgcmV0dXJuIGNtcCh2ZXJzaW9uLCB0aGlzLm9wZXJhdG9yLCB0aGlzLnNlbXZlciwgdGhpcy5sb29zZSk7XG59O1xuXG5cbmV4cG9ydHMuUmFuZ2UgPSBSYW5nZTtcbmZ1bmN0aW9uIFJhbmdlKHJhbmdlLCBsb29zZSkge1xuICBpZiAoKHJhbmdlIGluc3RhbmNlb2YgUmFuZ2UpICYmIHJhbmdlLmxvb3NlID09PSBsb29zZSlcbiAgICByZXR1cm4gcmFuZ2U7XG5cbiAgaWYgKCEodGhpcyBpbnN0YW5jZW9mIFJhbmdlKSlcbiAgICByZXR1cm4gbmV3IFJhbmdlKHJhbmdlLCBsb29zZSk7XG5cbiAgdGhpcy5sb29zZSA9IGxvb3NlO1xuXG4gIC8vIEZpcnN0LCBzcGxpdCBiYXNlZCBvbiBib29sZWFuIG9yIHx8XG4gIHRoaXMucmF3ID0gcmFuZ2U7XG4gIHRoaXMuc2V0ID0gcmFuZ2Uuc3BsaXQoL1xccypcXHxcXHxcXHMqLykubWFwKGZ1bmN0aW9uKHJhbmdlKSB7XG4gICAgcmV0dXJuIHRoaXMucGFyc2VSYW5nZShyYW5nZS50cmltKCkpO1xuICB9LCB0aGlzKS5maWx0ZXIoZnVuY3Rpb24oYykge1xuICAgIC8vIHRocm93IG91dCBhbnkgdGhhdCBhcmUgbm90IHJlbGV2YW50IGZvciB3aGF0ZXZlciByZWFzb25cbiAgICByZXR1cm4gYy5sZW5ndGg7XG4gIH0pO1xuXG4gIGlmICghdGhpcy5zZXQubGVuZ3RoKSB7XG4gICAgdGhyb3cgbmV3IFR5cGVFcnJvcignSW52YWxpZCBTZW1WZXIgUmFuZ2U6ICcgKyByYW5nZSk7XG4gIH1cblxuICB0aGlzLmZvcm1hdCgpO1xufVxuXG5SYW5nZS5wcm90b3R5cGUuZm9ybWF0ID0gZnVuY3Rpb24oKSB7XG4gIHRoaXMucmFuZ2UgPSB0aGlzLnNldC5tYXAoZnVuY3Rpb24oY29tcHMpIHtcbiAgICByZXR1cm4gY29tcHMuam9pbignICcpLnRyaW0oKTtcbiAgfSkuam9pbignfHwnKS50cmltKCk7XG4gIHJldHVybiB0aGlzLnJhbmdlO1xufTtcblxuUmFuZ2UucHJvdG90eXBlLnRvU3RyaW5nID0gZnVuY3Rpb24oKSB7XG4gIHJldHVybiB0aGlzLnJhbmdlO1xufTtcblxuUmFuZ2UucHJvdG90eXBlLnBhcnNlUmFuZ2UgPSBmdW5jdGlvbihyYW5nZSkge1xuICB2YXIgbG9vc2UgPSB0aGlzLmxvb3NlO1xuICByYW5nZSA9IHJhbmdlLnRyaW0oKTtcbiAgZGVidWcoJ3JhbmdlJywgcmFuZ2UsIGxvb3NlKTtcbiAgLy8gYDEuMi4zIC0gMS4yLjRgID0+IGA+PTEuMi4zIDw9MS4yLjRgXG4gIHZhciBociA9IGxvb3NlID8gcmVbSFlQSEVOUkFOR0VMT09TRV0gOiByZVtIWVBIRU5SQU5HRV07XG4gIHJhbmdlID0gcmFuZ2UucmVwbGFjZShociwgaHlwaGVuUmVwbGFjZSk7XG4gIGRlYnVnKCdoeXBoZW4gcmVwbGFjZScsIHJhbmdlKTtcbiAgLy8gYD4gMS4yLjMgPCAxLjIuNWAgPT4gYD4xLjIuMyA8MS4yLjVgXG4gIHJhbmdlID0gcmFuZ2UucmVwbGFjZShyZVtDT01QQVJBVE9SVFJJTV0sIGNvbXBhcmF0b3JUcmltUmVwbGFjZSk7XG4gIGRlYnVnKCdjb21wYXJhdG9yIHRyaW0nLCByYW5nZSwgcmVbQ09NUEFSQVRPUlRSSU1dKTtcblxuICAvLyBgfiAxLjIuM2AgPT4gYH4xLjIuM2BcbiAgcmFuZ2UgPSByYW5nZS5yZXBsYWNlKHJlW1RJTERFVFJJTV0sIHRpbGRlVHJpbVJlcGxhY2UpO1xuXG4gIC8vIGBeIDEuMi4zYCA9PiBgXjEuMi4zYFxuICByYW5nZSA9IHJhbmdlLnJlcGxhY2UocmVbQ0FSRVRUUklNXSwgY2FyZXRUcmltUmVwbGFjZSk7XG5cbiAgLy8gbm9ybWFsaXplIHNwYWNlc1xuICByYW5nZSA9IHJhbmdlLnNwbGl0KC9cXHMrLykuam9pbignICcpO1xuXG4gIC8vIEF0IHRoaXMgcG9pbnQsIHRoZSByYW5nZSBpcyBjb21wbGV0ZWx5IHRyaW1tZWQgYW5kXG4gIC8vIHJlYWR5IHRvIGJlIHNwbGl0IGludG8gY29tcGFyYXRvcnMuXG5cbiAgdmFyIGNvbXBSZSA9IGxvb3NlID8gcmVbQ09NUEFSQVRPUkxPT1NFXSA6IHJlW0NPTVBBUkFUT1JdO1xuICB2YXIgc2V0ID0gcmFuZ2Uuc3BsaXQoJyAnKS5tYXAoZnVuY3Rpb24oY29tcCkge1xuICAgIHJldHVybiBwYXJzZUNvbXBhcmF0b3IoY29tcCwgbG9vc2UpO1xuICB9KS5qb2luKCcgJykuc3BsaXQoL1xccysvKTtcbiAgaWYgKHRoaXMubG9vc2UpIHtcbiAgICAvLyBpbiBsb29zZSBtb2RlLCB0aHJvdyBvdXQgYW55IHRoYXQgYXJlIG5vdCB2YWxpZCBjb21wYXJhdG9yc1xuICAgIHNldCA9IHNldC5maWx0ZXIoZnVuY3Rpb24oY29tcCkge1xuICAgICAgcmV0dXJuICEhY29tcC5tYXRjaChjb21wUmUpO1xuICAgIH0pO1xuICB9XG4gIHNldCA9IHNldC5tYXAoZnVuY3Rpb24oY29tcCkge1xuICAgIHJldHVybiBuZXcgQ29tcGFyYXRvcihjb21wLCBsb29zZSk7XG4gIH0pO1xuXG4gIHJldHVybiBzZXQ7XG59O1xuXG4vLyBNb3N0bHkganVzdCBmb3IgdGVzdGluZyBhbmQgbGVnYWN5IEFQSSByZWFzb25zXG5leHBvcnRzLnRvQ29tcGFyYXRvcnMgPSB0b0NvbXBhcmF0b3JzO1xuZnVuY3Rpb24gdG9Db21wYXJhdG9ycyhyYW5nZSwgbG9vc2UpIHtcbiAgcmV0dXJuIG5ldyBSYW5nZShyYW5nZSwgbG9vc2UpLnNldC5tYXAoZnVuY3Rpb24oY29tcCkge1xuICAgIHJldHVybiBjb21wLm1hcChmdW5jdGlvbihjKSB7XG4gICAgICByZXR1cm4gYy52YWx1ZTtcbiAgICB9KS5qb2luKCcgJykudHJpbSgpLnNwbGl0KCcgJyk7XG4gIH0pO1xufVxuXG4vLyBjb21wcmlzZWQgb2YgeHJhbmdlcywgdGlsZGVzLCBzdGFycywgYW5kIGd0bHQncyBhdCB0aGlzIHBvaW50LlxuLy8gYWxyZWFkeSByZXBsYWNlZCB0aGUgaHlwaGVuIHJhbmdlc1xuLy8gdHVybiBpbnRvIGEgc2V0IG9mIEpVU1QgY29tcGFyYXRvcnMuXG5mdW5jdGlvbiBwYXJzZUNvbXBhcmF0b3IoY29tcCwgbG9vc2UpIHtcbiAgZGVidWcoJ2NvbXAnLCBjb21wKTtcbiAgY29tcCA9IHJlcGxhY2VDYXJldHMoY29tcCwgbG9vc2UpO1xuICBkZWJ1ZygnY2FyZXQnLCBjb21wKTtcbiAgY29tcCA9IHJlcGxhY2VUaWxkZXMoY29tcCwgbG9vc2UpO1xuICBkZWJ1ZygndGlsZGVzJywgY29tcCk7XG4gIGNvbXAgPSByZXBsYWNlWFJhbmdlcyhjb21wLCBsb29zZSk7XG4gIGRlYnVnKCd4cmFuZ2UnLCBjb21wKTtcbiAgY29tcCA9IHJlcGxhY2VTdGFycyhjb21wLCBsb29zZSk7XG4gIGRlYnVnKCdzdGFycycsIGNvbXApO1xuICByZXR1cm4gY29tcDtcbn1cblxuZnVuY3Rpb24gaXNYKGlkKSB7XG4gIHJldHVybiAhaWQgfHwgaWQudG9Mb3dlckNhc2UoKSA9PT0gJ3gnIHx8IGlkID09PSAnKic7XG59XG5cbi8vIH4sIH4+IC0tPiAqIChhbnksIGtpbmRhIHNpbGx5KVxuLy8gfjIsIH4yLngsIH4yLngueCwgfj4yLCB+PjIueCB+PjIueC54IC0tPiA+PTIuMC4wIDwzLjAuMFxuLy8gfjIuMCwgfjIuMC54LCB+PjIuMCwgfj4yLjAueCAtLT4gPj0yLjAuMCA8Mi4xLjBcbi8vIH4xLjIsIH4xLjIueCwgfj4xLjIsIH4+MS4yLnggLS0+ID49MS4yLjAgPDEuMy4wXG4vLyB+MS4yLjMsIH4+MS4yLjMgLS0+ID49MS4yLjMgPDEuMy4wXG4vLyB+MS4yLjAsIH4+MS4yLjAgLS0+ID49MS4yLjAgPDEuMy4wXG5mdW5jdGlvbiByZXBsYWNlVGlsZGVzKGNvbXAsIGxvb3NlKSB7XG4gIHJldHVybiBjb21wLnRyaW0oKS5zcGxpdCgvXFxzKy8pLm1hcChmdW5jdGlvbihjb21wKSB7XG4gICAgcmV0dXJuIHJlcGxhY2VUaWxkZShjb21wLCBsb29zZSk7XG4gIH0pLmpvaW4oJyAnKTtcbn1cblxuZnVuY3Rpb24gcmVwbGFjZVRpbGRlKGNvbXAsIGxvb3NlKSB7XG4gIHZhciByID0gbG9vc2UgPyByZVtUSUxERUxPT1NFXSA6IHJlW1RJTERFXTtcbiAgcmV0dXJuIGNvbXAucmVwbGFjZShyLCBmdW5jdGlvbihfLCBNLCBtLCBwLCBwcikge1xuICAgIGRlYnVnKCd0aWxkZScsIGNvbXAsIF8sIE0sIG0sIHAsIHByKTtcbiAgICB2YXIgcmV0O1xuXG4gICAgaWYgKGlzWChNKSlcbiAgICAgIHJldCA9ICcnO1xuICAgIGVsc2UgaWYgKGlzWChtKSlcbiAgICAgIHJldCA9ICc+PScgKyBNICsgJy4wLjAgPCcgKyAoK00gKyAxKSArICcuMC4wJztcbiAgICBlbHNlIGlmIChpc1gocCkpXG4gICAgICAvLyB+MS4yID09ID49MS4yLjAgPDEuMy4wXG4gICAgICByZXQgPSAnPj0nICsgTSArICcuJyArIG0gKyAnLjAgPCcgKyBNICsgJy4nICsgKCttICsgMSkgKyAnLjAnO1xuICAgIGVsc2UgaWYgKHByKSB7XG4gICAgICBkZWJ1ZygncmVwbGFjZVRpbGRlIHByJywgcHIpO1xuICAgICAgaWYgKHByLmNoYXJBdCgwKSAhPT0gJy0nKVxuICAgICAgICBwciA9ICctJyArIHByO1xuICAgICAgcmV0ID0gJz49JyArIE0gKyAnLicgKyBtICsgJy4nICsgcCArIHByICtcbiAgICAgICAgICAgICcgPCcgKyBNICsgJy4nICsgKCttICsgMSkgKyAnLjAnO1xuICAgIH0gZWxzZVxuICAgICAgLy8gfjEuMi4zID09ID49MS4yLjMgPDEuMy4wXG4gICAgICByZXQgPSAnPj0nICsgTSArICcuJyArIG0gKyAnLicgKyBwICtcbiAgICAgICAgICAgICcgPCcgKyBNICsgJy4nICsgKCttICsgMSkgKyAnLjAnO1xuXG4gICAgZGVidWcoJ3RpbGRlIHJldHVybicsIHJldCk7XG4gICAgcmV0dXJuIHJldDtcbiAgfSk7XG59XG5cbi8vIF4gLS0+ICogKGFueSwga2luZGEgc2lsbHkpXG4vLyBeMiwgXjIueCwgXjIueC54IC0tPiA+PTIuMC4wIDwzLjAuMFxuLy8gXjIuMCwgXjIuMC54IC0tPiA+PTIuMC4wIDwzLjAuMFxuLy8gXjEuMiwgXjEuMi54IC0tPiA+PTEuMi4wIDwyLjAuMFxuLy8gXjEuMi4zIC0tPiA+PTEuMi4zIDwyLjAuMFxuLy8gXjEuMi4wIC0tPiA+PTEuMi4wIDwyLjAuMFxuZnVuY3Rpb24gcmVwbGFjZUNhcmV0cyhjb21wLCBsb29zZSkge1xuICByZXR1cm4gY29tcC50cmltKCkuc3BsaXQoL1xccysvKS5tYXAoZnVuY3Rpb24oY29tcCkge1xuICAgIHJldHVybiByZXBsYWNlQ2FyZXQoY29tcCwgbG9vc2UpO1xuICB9KS5qb2luKCcgJyk7XG59XG5cbmZ1bmN0aW9uIHJlcGxhY2VDYXJldChjb21wLCBsb29zZSkge1xuICBkZWJ1ZygnY2FyZXQnLCBjb21wLCBsb29zZSk7XG4gIHZhciByID0gbG9vc2UgPyByZVtDQVJFVExPT1NFXSA6IHJlW0NBUkVUXTtcbiAgcmV0dXJuIGNvbXAucmVwbGFjZShyLCBmdW5jdGlvbihfLCBNLCBtLCBwLCBwcikge1xuICAgIGRlYnVnKCdjYXJldCcsIGNvbXAsIF8sIE0sIG0sIHAsIHByKTtcbiAgICB2YXIgcmV0O1xuXG4gICAgaWYgKGlzWChNKSlcbiAgICAgIHJldCA9ICcnO1xuICAgIGVsc2UgaWYgKGlzWChtKSlcbiAgICAgIHJldCA9ICc+PScgKyBNICsgJy4wLjAgPCcgKyAoK00gKyAxKSArICcuMC4wJztcbiAgICBlbHNlIGlmIChpc1gocCkpIHtcbiAgICAgIGlmIChNID09PSAnMCcpXG4gICAgICAgIHJldCA9ICc+PScgKyBNICsgJy4nICsgbSArICcuMCA8JyArIE0gKyAnLicgKyAoK20gKyAxKSArICcuMCc7XG4gICAgICBlbHNlXG4gICAgICAgIHJldCA9ICc+PScgKyBNICsgJy4nICsgbSArICcuMCA8JyArICgrTSArIDEpICsgJy4wLjAnO1xuICAgIH0gZWxzZSBpZiAocHIpIHtcbiAgICAgIGRlYnVnKCdyZXBsYWNlQ2FyZXQgcHInLCBwcik7XG4gICAgICBpZiAocHIuY2hhckF0KDApICE9PSAnLScpXG4gICAgICAgIHByID0gJy0nICsgcHI7XG4gICAgICBpZiAoTSA9PT0gJzAnKSB7XG4gICAgICAgIGlmIChtID09PSAnMCcpXG4gICAgICAgICAgcmV0ID0gJz49JyArIE0gKyAnLicgKyBtICsgJy4nICsgcCArIHByICtcbiAgICAgICAgICAgICAgICAnIDwnICsgTSArICcuJyArIG0gKyAnLicgKyAoK3AgKyAxKTtcbiAgICAgICAgZWxzZVxuICAgICAgICAgIHJldCA9ICc+PScgKyBNICsgJy4nICsgbSArICcuJyArIHAgKyBwciArXG4gICAgICAgICAgICAgICAgJyA8JyArIE0gKyAnLicgKyAoK20gKyAxKSArICcuMCc7XG4gICAgICB9IGVsc2VcbiAgICAgICAgcmV0ID0gJz49JyArIE0gKyAnLicgKyBtICsgJy4nICsgcCArIHByICtcbiAgICAgICAgICAgICAgJyA8JyArICgrTSArIDEpICsgJy4wLjAnO1xuICAgIH0gZWxzZSB7XG4gICAgICBkZWJ1Zygnbm8gcHInKTtcbiAgICAgIGlmIChNID09PSAnMCcpIHtcbiAgICAgICAgaWYgKG0gPT09ICcwJylcbiAgICAgICAgICByZXQgPSAnPj0nICsgTSArICcuJyArIG0gKyAnLicgKyBwICtcbiAgICAgICAgICAgICAgICAnIDwnICsgTSArICcuJyArIG0gKyAnLicgKyAoK3AgKyAxKTtcbiAgICAgICAgZWxzZVxuICAgICAgICAgIHJldCA9ICc+PScgKyBNICsgJy4nICsgbSArICcuJyArIHAgK1xuICAgICAgICAgICAgICAgICcgPCcgKyBNICsgJy4nICsgKCttICsgMSkgKyAnLjAnO1xuICAgICAgfSBlbHNlXG4gICAgICAgIHJldCA9ICc+PScgKyBNICsgJy4nICsgbSArICcuJyArIHAgK1xuICAgICAgICAgICAgICAnIDwnICsgKCtNICsgMSkgKyAnLjAuMCc7XG4gICAgfVxuXG4gICAgZGVidWcoJ2NhcmV0IHJldHVybicsIHJldCk7XG4gICAgcmV0dXJuIHJldDtcbiAgfSk7XG59XG5cbmZ1bmN0aW9uIHJlcGxhY2VYUmFuZ2VzKGNvbXAsIGxvb3NlKSB7XG4gIGRlYnVnKCdyZXBsYWNlWFJhbmdlcycsIGNvbXAsIGxvb3NlKTtcbiAgcmV0dXJuIGNvbXAuc3BsaXQoL1xccysvKS5tYXAoZnVuY3Rpb24oY29tcCkge1xuICAgIHJldHVybiByZXBsYWNlWFJhbmdlKGNvbXAsIGxvb3NlKTtcbiAgfSkuam9pbignICcpO1xufVxuXG5mdW5jdGlvbiByZXBsYWNlWFJhbmdlKGNvbXAsIGxvb3NlKSB7XG4gIGNvbXAgPSBjb21wLnRyaW0oKTtcbiAgdmFyIHIgPSBsb29zZSA/IHJlW1hSQU5HRUxPT1NFXSA6IHJlW1hSQU5HRV07XG4gIHJldHVybiBjb21wLnJlcGxhY2UociwgZnVuY3Rpb24ocmV0LCBndGx0LCBNLCBtLCBwLCBwcikge1xuICAgIGRlYnVnKCd4UmFuZ2UnLCBjb21wLCByZXQsIGd0bHQsIE0sIG0sIHAsIHByKTtcbiAgICB2YXIgeE0gPSBpc1goTSk7XG4gICAgdmFyIHhtID0geE0gfHwgaXNYKG0pO1xuICAgIHZhciB4cCA9IHhtIHx8IGlzWChwKTtcbiAgICB2YXIgYW55WCA9IHhwO1xuXG4gICAgaWYgKGd0bHQgPT09ICc9JyAmJiBhbnlYKVxuICAgICAgZ3RsdCA9ICcnO1xuXG4gICAgaWYgKHhNKSB7XG4gICAgICBpZiAoZ3RsdCA9PT0gJz4nIHx8IGd0bHQgPT09ICc8Jykge1xuICAgICAgICAvLyBub3RoaW5nIGlzIGFsbG93ZWRcbiAgICAgICAgcmV0ID0gJzwwLjAuMCc7XG4gICAgICB9IGVsc2Uge1xuICAgICAgICAvLyBub3RoaW5nIGlzIGZvcmJpZGRlblxuICAgICAgICByZXQgPSAnKic7XG4gICAgICB9XG4gICAgfSBlbHNlIGlmIChndGx0ICYmIGFueVgpIHtcbiAgICAgIC8vIHJlcGxhY2UgWCB3aXRoIDBcbiAgICAgIGlmICh4bSlcbiAgICAgICAgbSA9IDA7XG4gICAgICBpZiAoeHApXG4gICAgICAgIHAgPSAwO1xuXG4gICAgICBpZiAoZ3RsdCA9PT0gJz4nKSB7XG4gICAgICAgIC8vID4xID0+ID49Mi4wLjBcbiAgICAgICAgLy8gPjEuMiA9PiA+PTEuMy4wXG4gICAgICAgIC8vID4xLjIuMyA9PiA+PSAxLjIuNFxuICAgICAgICBndGx0ID0gJz49JztcbiAgICAgICAgaWYgKHhtKSB7XG4gICAgICAgICAgTSA9ICtNICsgMTtcbiAgICAgICAgICBtID0gMDtcbiAgICAgICAgICBwID0gMDtcbiAgICAgICAgfSBlbHNlIGlmICh4cCkge1xuICAgICAgICAgIG0gPSArbSArIDE7XG4gICAgICAgICAgcCA9IDA7XG4gICAgICAgIH1cbiAgICAgIH0gZWxzZSBpZiAoZ3RsdCA9PT0gJzw9Jykge1xuICAgICAgICAvLyA8PTAuNy54IGlzIGFjdHVhbGx5IDwwLjguMCwgc2luY2UgYW55IDAuNy54IHNob3VsZFxuICAgICAgICAvLyBwYXNzLiAgU2ltaWxhcmx5LCA8PTcueCBpcyBhY3R1YWxseSA8OC4wLjAsIGV0Yy5cbiAgICAgICAgZ3RsdCA9ICc8JztcbiAgICAgICAgaWYgKHhtKVxuICAgICAgICAgIE0gPSArTSArIDE7XG4gICAgICAgIGVsc2VcbiAgICAgICAgICBtID0gK20gKyAxO1xuICAgICAgfVxuXG4gICAgICByZXQgPSBndGx0ICsgTSArICcuJyArIG0gKyAnLicgKyBwO1xuICAgIH0gZWxzZSBpZiAoeG0pIHtcbiAgICAgIHJldCA9ICc+PScgKyBNICsgJy4wLjAgPCcgKyAoK00gKyAxKSArICcuMC4wJztcbiAgICB9IGVsc2UgaWYgKHhwKSB7XG4gICAgICByZXQgPSAnPj0nICsgTSArICcuJyArIG0gKyAnLjAgPCcgKyBNICsgJy4nICsgKCttICsgMSkgKyAnLjAnO1xuICAgIH1cblxuICAgIGRlYnVnKCd4UmFuZ2UgcmV0dXJuJywgcmV0KTtcblxuICAgIHJldHVybiByZXQ7XG4gIH0pO1xufVxuXG4vLyBCZWNhdXNlICogaXMgQU5ELWVkIHdpdGggZXZlcnl0aGluZyBlbHNlIGluIHRoZSBjb21wYXJhdG9yLFxuLy8gYW5kICcnIG1lYW5zIFwiYW55IHZlcnNpb25cIiwganVzdCByZW1vdmUgdGhlICpzIGVudGlyZWx5LlxuZnVuY3Rpb24gcmVwbGFjZVN0YXJzKGNvbXAsIGxvb3NlKSB7XG4gIGRlYnVnKCdyZXBsYWNlU3RhcnMnLCBjb21wLCBsb29zZSk7XG4gIC8vIExvb3NlbmVzcyBpcyBpZ25vcmVkIGhlcmUuICBzdGFyIGlzIGFsd2F5cyBhcyBsb29zZSBhcyBpdCBnZXRzIVxuICByZXR1cm4gY29tcC50cmltKCkucmVwbGFjZShyZVtTVEFSXSwgJycpO1xufVxuXG4vLyBUaGlzIGZ1bmN0aW9uIGlzIHBhc3NlZCB0byBzdHJpbmcucmVwbGFjZShyZVtIWVBIRU5SQU5HRV0pXG4vLyBNLCBtLCBwYXRjaCwgcHJlcmVsZWFzZSwgYnVpbGRcbi8vIDEuMiAtIDMuNC41ID0+ID49MS4yLjAgPD0zLjQuNVxuLy8gMS4yLjMgLSAzLjQgPT4gPj0xLjIuMCA8My41LjAgQW55IDMuNC54IHdpbGwgZG9cbi8vIDEuMiAtIDMuNCA9PiA+PTEuMi4wIDwzLjUuMFxuZnVuY3Rpb24gaHlwaGVuUmVwbGFjZSgkMCxcbiAgICAgICAgICAgICAgICAgICAgICAgZnJvbSwgZk0sIGZtLCBmcCwgZnByLCBmYixcbiAgICAgICAgICAgICAgICAgICAgICAgdG8sIHRNLCB0bSwgdHAsIHRwciwgdGIpIHtcblxuICBpZiAoaXNYKGZNKSlcbiAgICBmcm9tID0gJyc7XG4gIGVsc2UgaWYgKGlzWChmbSkpXG4gICAgZnJvbSA9ICc+PScgKyBmTSArICcuMC4wJztcbiAgZWxzZSBpZiAoaXNYKGZwKSlcbiAgICBmcm9tID0gJz49JyArIGZNICsgJy4nICsgZm0gKyAnLjAnO1xuICBlbHNlXG4gICAgZnJvbSA9ICc+PScgKyBmcm9tO1xuXG4gIGlmIChpc1godE0pKVxuICAgIHRvID0gJyc7XG4gIGVsc2UgaWYgKGlzWCh0bSkpXG4gICAgdG8gPSAnPCcgKyAoK3RNICsgMSkgKyAnLjAuMCc7XG4gIGVsc2UgaWYgKGlzWCh0cCkpXG4gICAgdG8gPSAnPCcgKyB0TSArICcuJyArICgrdG0gKyAxKSArICcuMCc7XG4gIGVsc2UgaWYgKHRwcilcbiAgICB0byA9ICc8PScgKyB0TSArICcuJyArIHRtICsgJy4nICsgdHAgKyAnLScgKyB0cHI7XG4gIGVsc2VcbiAgICB0byA9ICc8PScgKyB0bztcblxuICByZXR1cm4gKGZyb20gKyAnICcgKyB0bykudHJpbSgpO1xufVxuXG5cbi8vIGlmIEFOWSBvZiB0aGUgc2V0cyBtYXRjaCBBTEwgb2YgaXRzIGNvbXBhcmF0b3JzLCB0aGVuIHBhc3NcblJhbmdlLnByb3RvdHlwZS50ZXN0ID0gZnVuY3Rpb24odmVyc2lvbikge1xuICBpZiAoIXZlcnNpb24pXG4gICAgcmV0dXJuIGZhbHNlO1xuXG4gIGlmICh0eXBlb2YgdmVyc2lvbiA9PT0gJ3N0cmluZycpXG4gICAgdmVyc2lvbiA9IG5ldyBTZW1WZXIodmVyc2lvbiwgdGhpcy5sb29zZSk7XG5cbiAgZm9yICh2YXIgaSA9IDA7IGkgPCB0aGlzLnNldC5sZW5ndGg7IGkrKykge1xuICAgIGlmICh0ZXN0U2V0KHRoaXMuc2V0W2ldLCB2ZXJzaW9uKSlcbiAgICAgIHJldHVybiB0cnVlO1xuICB9XG4gIHJldHVybiBmYWxzZTtcbn07XG5cbmZ1bmN0aW9uIHRlc3RTZXQoc2V0LCB2ZXJzaW9uKSB7XG4gIGZvciAodmFyIGkgPSAwOyBpIDwgc2V0Lmxlbmd0aDsgaSsrKSB7XG4gICAgaWYgKCFzZXRbaV0udGVzdCh2ZXJzaW9uKSlcbiAgICAgIHJldHVybiBmYWxzZTtcbiAgfVxuXG4gIGlmICh2ZXJzaW9uLnByZXJlbGVhc2UubGVuZ3RoKSB7XG4gICAgLy8gRmluZCB0aGUgc2V0IG9mIHZlcnNpb25zIHRoYXQgYXJlIGFsbG93ZWQgdG8gaGF2ZSBwcmVyZWxlYXNlc1xuICAgIC8vIEZvciBleGFtcGxlLCBeMS4yLjMtcHIuMSBkZXN1Z2FycyB0byA+PTEuMi4zLXByLjEgPDIuMC4wXG4gICAgLy8gVGhhdCBzaG91bGQgYWxsb3cgYDEuMi4zLXByLjJgIHRvIHBhc3MuXG4gICAgLy8gSG93ZXZlciwgYDEuMi40LWFscGhhLm5vdHJlYWR5YCBzaG91bGQgTk9UIGJlIGFsbG93ZWQsXG4gICAgLy8gZXZlbiB0aG91Z2ggaXQncyB3aXRoaW4gdGhlIHJhbmdlIHNldCBieSB0aGUgY29tcGFyYXRvcnMuXG4gICAgZm9yICh2YXIgaSA9IDA7IGkgPCBzZXQubGVuZ3RoOyBpKyspIHtcbiAgICAgIGRlYnVnKHNldFtpXS5zZW12ZXIpO1xuICAgICAgaWYgKHNldFtpXS5zZW12ZXIgPT09IEFOWSlcbiAgICAgICAgY29udGludWU7XG5cbiAgICAgIGlmIChzZXRbaV0uc2VtdmVyLnByZXJlbGVhc2UubGVuZ3RoID4gMCkge1xuICAgICAgICB2YXIgYWxsb3dlZCA9IHNldFtpXS5zZW12ZXI7XG4gICAgICAgIGlmIChhbGxvd2VkLm1ham9yID09PSB2ZXJzaW9uLm1ham9yICYmXG4gICAgICAgICAgICBhbGxvd2VkLm1pbm9yID09PSB2ZXJzaW9uLm1pbm9yICYmXG4gICAgICAgICAgICBhbGxvd2VkLnBhdGNoID09PSB2ZXJzaW9uLnBhdGNoKVxuICAgICAgICAgIHJldHVybiB0cnVlO1xuICAgICAgfVxuICAgIH1cblxuICAgIC8vIFZlcnNpb24gaGFzIGEgLXByZSwgYnV0IGl0J3Mgbm90IG9uZSBvZiB0aGUgb25lcyB3ZSBsaWtlLlxuICAgIHJldHVybiBmYWxzZTtcbiAgfVxuXG4gIHJldHVybiB0cnVlO1xufVxuXG5leHBvcnRzLnNhdGlzZmllcyA9IHNhdGlzZmllcztcbmZ1bmN0aW9uIHNhdGlzZmllcyh2ZXJzaW9uLCByYW5nZSwgbG9vc2UpIHtcbiAgdHJ5IHtcbiAgICByYW5nZSA9IG5ldyBSYW5nZShyYW5nZSwgbG9vc2UpO1xuICB9IGNhdGNoIChlcikge1xuICAgIHJldHVybiBmYWxzZTtcbiAgfVxuICByZXR1cm4gcmFuZ2UudGVzdCh2ZXJzaW9uKTtcbn1cblxuZXhwb3J0cy5tYXhTYXRpc2Z5aW5nID0gbWF4U2F0aXNmeWluZztcbmZ1bmN0aW9uIG1heFNhdGlzZnlpbmcodmVyc2lvbnMsIHJhbmdlLCBsb29zZSkge1xuICByZXR1cm4gdmVyc2lvbnMuZmlsdGVyKGZ1bmN0aW9uKHZlcnNpb24pIHtcbiAgICByZXR1cm4gc2F0aXNmaWVzKHZlcnNpb24sIHJhbmdlLCBsb29zZSk7XG4gIH0pLnNvcnQoZnVuY3Rpb24oYSwgYikge1xuICAgIHJldHVybiByY29tcGFyZShhLCBiLCBsb29zZSk7XG4gIH0pWzBdIHx8IG51bGw7XG59XG5cbmV4cG9ydHMubWluU2F0aXNmeWluZyA9IG1pblNhdGlzZnlpbmc7XG5mdW5jdGlvbiBtaW5TYXRpc2Z5aW5nKHZlcnNpb25zLCByYW5nZSwgbG9vc2UpIHtcbiAgcmV0dXJuIHZlcnNpb25zLmZpbHRlcihmdW5jdGlvbih2ZXJzaW9uKSB7XG4gICAgcmV0dXJuIHNhdGlzZmllcyh2ZXJzaW9uLCByYW5nZSwgbG9vc2UpO1xuICB9KS5zb3J0KGZ1bmN0aW9uKGEsIGIpIHtcbiAgICByZXR1cm4gY29tcGFyZShhLCBiLCBsb29zZSk7XG4gIH0pWzBdIHx8IG51bGw7XG59XG5cbmV4cG9ydHMudmFsaWRSYW5nZSA9IHZhbGlkUmFuZ2U7XG5mdW5jdGlvbiB2YWxpZFJhbmdlKHJhbmdlLCBsb29zZSkge1xuICB0cnkge1xuICAgIC8vIFJldHVybiAnKicgaW5zdGVhZCBvZiAnJyBzbyB0aGF0IHRydXRoaW5lc3Mgd29ya3MuXG4gICAgLy8gVGhpcyB3aWxsIHRocm93IGlmIGl0J3MgaW52YWxpZCBhbnl3YXlcbiAgICByZXR1cm4gbmV3IFJhbmdlKHJhbmdlLCBsb29zZSkucmFuZ2UgfHwgJyonO1xuICB9IGNhdGNoIChlcikge1xuICAgIHJldHVybiBudWxsO1xuICB9XG59XG5cbi8vIERldGVybWluZSBpZiB2ZXJzaW9uIGlzIGxlc3MgdGhhbiBhbGwgdGhlIHZlcnNpb25zIHBvc3NpYmxlIGluIHRoZSByYW5nZVxuZXhwb3J0cy5sdHIgPSBsdHI7XG5mdW5jdGlvbiBsdHIodmVyc2lvbiwgcmFuZ2UsIGxvb3NlKSB7XG4gIHJldHVybiBvdXRzaWRlKHZlcnNpb24sIHJhbmdlLCAnPCcsIGxvb3NlKTtcbn1cblxuLy8gRGV0ZXJtaW5lIGlmIHZlcnNpb24gaXMgZ3JlYXRlciB0aGFuIGFsbCB0aGUgdmVyc2lvbnMgcG9zc2libGUgaW4gdGhlIHJhbmdlLlxuZXhwb3J0cy5ndHIgPSBndHI7XG5mdW5jdGlvbiBndHIodmVyc2lvbiwgcmFuZ2UsIGxvb3NlKSB7XG4gIHJldHVybiBvdXRzaWRlKHZlcnNpb24sIHJhbmdlLCAnPicsIGxvb3NlKTtcbn1cblxuZXhwb3J0cy5vdXRzaWRlID0gb3V0c2lkZTtcbmZ1bmN0aW9uIG91dHNpZGUodmVyc2lvbiwgcmFuZ2UsIGhpbG8sIGxvb3NlKSB7XG4gIHZlcnNpb24gPSBuZXcgU2VtVmVyKHZlcnNpb24sIGxvb3NlKTtcbiAgcmFuZ2UgPSBuZXcgUmFuZ2UocmFuZ2UsIGxvb3NlKTtcblxuICB2YXIgZ3RmbiwgbHRlZm4sIGx0Zm4sIGNvbXAsIGVjb21wO1xuICBzd2l0Y2ggKGhpbG8pIHtcbiAgICBjYXNlICc+JzpcbiAgICAgIGd0Zm4gPSBndDtcbiAgICAgIGx0ZWZuID0gbHRlO1xuICAgICAgbHRmbiA9IGx0O1xuICAgICAgY29tcCA9ICc+JztcbiAgICAgIGVjb21wID0gJz49JztcbiAgICAgIGJyZWFrO1xuICAgIGNhc2UgJzwnOlxuICAgICAgZ3RmbiA9IGx0O1xuICAgICAgbHRlZm4gPSBndGU7XG4gICAgICBsdGZuID0gZ3Q7XG4gICAgICBjb21wID0gJzwnO1xuICAgICAgZWNvbXAgPSAnPD0nO1xuICAgICAgYnJlYWs7XG4gICAgZGVmYXVsdDpcbiAgICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ011c3QgcHJvdmlkZSBhIGhpbG8gdmFsIG9mIFwiPFwiIG9yIFwiPlwiJyk7XG4gIH1cblxuICAvLyBJZiBpdCBzYXRpc2lmZXMgdGhlIHJhbmdlIGl0IGlzIG5vdCBvdXRzaWRlXG4gIGlmIChzYXRpc2ZpZXModmVyc2lvbiwgcmFuZ2UsIGxvb3NlKSkge1xuICAgIHJldHVybiBmYWxzZTtcbiAgfVxuXG4gIC8vIEZyb20gbm93IG9uLCB2YXJpYWJsZSB0ZXJtcyBhcmUgYXMgaWYgd2UncmUgaW4gXCJndHJcIiBtb2RlLlxuICAvLyBidXQgbm90ZSB0aGF0IGV2ZXJ5dGhpbmcgaXMgZmxpcHBlZCBmb3IgdGhlIFwibHRyXCIgZnVuY3Rpb24uXG5cbiAgZm9yICh2YXIgaSA9IDA7IGkgPCByYW5nZS5zZXQubGVuZ3RoOyArK2kpIHtcbiAgICB2YXIgY29tcGFyYXRvcnMgPSByYW5nZS5zZXRbaV07XG5cbiAgICB2YXIgaGlnaCA9IG51bGw7XG4gICAgdmFyIGxvdyA9IG51bGw7XG5cbiAgICBjb21wYXJhdG9ycy5mb3JFYWNoKGZ1bmN0aW9uKGNvbXBhcmF0b3IpIHtcbiAgICAgIGlmIChjb21wYXJhdG9yLnNlbXZlciA9PT0gQU5ZKSB7XG4gICAgICAgIGNvbXBhcmF0b3IgPSBuZXcgQ29tcGFyYXRvcignPj0wLjAuMCcpXG4gICAgICB9XG4gICAgICBoaWdoID0gaGlnaCB8fCBjb21wYXJhdG9yO1xuICAgICAgbG93ID0gbG93IHx8IGNvbXBhcmF0b3I7XG4gICAgICBpZiAoZ3Rmbihjb21wYXJhdG9yLnNlbXZlciwgaGlnaC5zZW12ZXIsIGxvb3NlKSkge1xuICAgICAgICBoaWdoID0gY29tcGFyYXRvcjtcbiAgICAgIH0gZWxzZSBpZiAobHRmbihjb21wYXJhdG9yLnNlbXZlciwgbG93LnNlbXZlciwgbG9vc2UpKSB7XG4gICAgICAgIGxvdyA9IGNvbXBhcmF0b3I7XG4gICAgICB9XG4gICAgfSk7XG5cbiAgICAvLyBJZiB0aGUgZWRnZSB2ZXJzaW9uIGNvbXBhcmF0b3IgaGFzIGEgb3BlcmF0b3IgdGhlbiBvdXIgdmVyc2lvblxuICAgIC8vIGlzbid0IG91dHNpZGUgaXRcbiAgICBpZiAoaGlnaC5vcGVyYXRvciA9PT0gY29tcCB8fCBoaWdoLm9wZXJhdG9yID09PSBlY29tcCkge1xuICAgICAgcmV0dXJuIGZhbHNlO1xuICAgIH1cblxuICAgIC8vIElmIHRoZSBsb3dlc3QgdmVyc2lvbiBjb21wYXJhdG9yIGhhcyBhbiBvcGVyYXRvciBhbmQgb3VyIHZlcnNpb25cbiAgICAvLyBpcyBsZXNzIHRoYW4gaXQgdGhlbiBpdCBpc24ndCBoaWdoZXIgdGhhbiB0aGUgcmFuZ2VcbiAgICBpZiAoKCFsb3cub3BlcmF0b3IgfHwgbG93Lm9wZXJhdG9yID09PSBjb21wKSAmJlxuICAgICAgICBsdGVmbih2ZXJzaW9uLCBsb3cuc2VtdmVyKSkge1xuICAgICAgcmV0dXJuIGZhbHNlO1xuICAgIH0gZWxzZSBpZiAobG93Lm9wZXJhdG9yID09PSBlY29tcCAmJiBsdGZuKHZlcnNpb24sIGxvdy5zZW12ZXIpKSB7XG4gICAgICByZXR1cm4gZmFsc2U7XG4gICAgfVxuICB9XG4gIHJldHVybiB0cnVlO1xufVxuXG5leHBvcnRzLnByZXJlbGVhc2UgPSBwcmVyZWxlYXNlO1xuZnVuY3Rpb24gcHJlcmVsZWFzZSh2ZXJzaW9uLCBsb29zZSkge1xuICB2YXIgcGFyc2VkID0gcGFyc2UodmVyc2lvbiwgbG9vc2UpO1xuICByZXR1cm4gKHBhcnNlZCAmJiBwYXJzZWQucHJlcmVsZWFzZS5sZW5ndGgpID8gcGFyc2VkLnByZXJlbGVhc2UgOiBudWxsO1xufVxuXG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gLi9+L3NlbXZlci9zZW12ZXIuanNcbi8vIG1vZHVsZSBpZCA9IDI1XG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsIlxuICAgICAgICB2YXIgcmVzdWx0ID0gcmVxdWlyZShcIiEhLi4vLi4vLi4vLi4vbm9kZV9tb2R1bGVzL2Nzcy1sb2FkZXIvaW5kZXguanMhLi9hcHAuY29tcG9uZW50LmNzc1wiKTtcblxuICAgICAgICBpZiAodHlwZW9mIHJlc3VsdCA9PT0gXCJzdHJpbmdcIikge1xuICAgICAgICAgICAgbW9kdWxlLmV4cG9ydHMgPSByZXN1bHQ7XG4gICAgICAgIH0gZWxzZSB7XG4gICAgICAgICAgICBtb2R1bGUuZXhwb3J0cyA9IHJlc3VsdC50b1N0cmluZygpO1xuICAgICAgICB9XG4gICAgXG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gLi9DbGllbnRBcHAvYXBwL2NvbXBvbmVudHMvYXBwL2FwcC5jb21wb25lbnQuY3NzXG4vLyBtb2R1bGUgaWQgPSAyNlxuLy8gbW9kdWxlIGNodW5rcyA9IDAiLCJcbiAgICAgICAgdmFyIHJlc3VsdCA9IHJlcXVpcmUoXCIhIS4uLy4uLy4uLy4uL25vZGVfbW9kdWxlcy9jc3MtbG9hZGVyL2luZGV4LmpzIS4vbmF2bWVudS5jb21wb25lbnQuY3NzXCIpO1xuXG4gICAgICAgIGlmICh0eXBlb2YgcmVzdWx0ID09PSBcInN0cmluZ1wiKSB7XG4gICAgICAgICAgICBtb2R1bGUuZXhwb3J0cyA9IHJlc3VsdDtcbiAgICAgICAgfSBlbHNlIHtcbiAgICAgICAgICAgIG1vZHVsZS5leHBvcnRzID0gcmVzdWx0LnRvU3RyaW5nKCk7XG4gICAgICAgIH1cbiAgICBcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyAuL0NsaWVudEFwcC9hcHAvY29tcG9uZW50cy9uYXZtZW51L25hdm1lbnUuY29tcG9uZW50LmNzc1xuLy8gbW9kdWxlIGlkID0gMjdcbi8vIG1vZHVsZSBjaHVua3MgPSAwIiwibW9kdWxlLmV4cG9ydHMgPSAoX193ZWJwYWNrX3JlcXVpcmVfXygxKSkoNCk7XG5cblxuLy8vLy8vLy8vLy8vLy8vLy8vXG4vLyBXRUJQQUNLIEZPT1RFUlxuLy8gZGVsZWdhdGVkIC4vbm9kZV9tb2R1bGVzL0Bhbmd1bGFyL3BsYXRmb3JtLWJyb3dzZXIvYnVuZGxlcy9wbGF0Zm9ybS1icm93c2VyLnVtZC5qcyBmcm9tIGRsbC1yZWZlcmVuY2UgLi92ZW5kb3Jcbi8vIG1vZHVsZSBpZCA9IDI4XG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsIm1vZHVsZS5leHBvcnRzID0gKF9fd2VicGFja19yZXF1aXJlX18oMSkpKDY4KTtcblxuXG4vLy8vLy8vLy8vLy8vLy8vLy9cbi8vIFdFQlBBQ0sgRk9PVEVSXG4vLyBkZWxlZ2F0ZWQgLi9ub2RlX21vZHVsZXMvQGFuZ3VsYXIvcm91dGVyL2J1bmRsZXMvcm91dGVyLnVtZC5qcyBmcm9tIGRsbC1yZWZlcmVuY2UgLi92ZW5kb3Jcbi8vIG1vZHVsZSBpZCA9IDI5XG4vLyBtb2R1bGUgY2h1bmtzID0gMCIsImltcG9ydCAnYW5ndWxhcjItdW5pdmVyc2FsLXBvbHlmaWxscyc7XHJcbmltcG9ydCAnYW5ndWxhcjItdW5pdmVyc2FsLXBhdGNoJztcclxuaW1wb3J0ICd6b25lLmpzJztcclxuaW1wb3J0IHsgY3JlYXRlU2VydmVyUmVuZGVyZXIsIFJlbmRlclJlc3VsdCB9IGZyb20gJ2FzcG5ldC1wcmVyZW5kZXJpbmcnO1xyXG5pbXBvcnQgeyBlbmFibGVQcm9kTW9kZSB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xyXG5pbXBvcnQgeyBwbGF0Zm9ybU5vZGVEeW5hbWljIH0gZnJvbSAnYW5ndWxhcjItdW5pdmVyc2FsJztcclxuaW1wb3J0IHsgQXBwTW9kdWxlIH0gZnJvbSAnLi9hcHAvYXBwLm1vZHVsZSc7XHJcblxyXG5lbmFibGVQcm9kTW9kZSgpO1xyXG5jb25zdCBwbGF0Zm9ybSA9IHBsYXRmb3JtTm9kZUR5bmFtaWMoKTtcclxuXHJcbmV4cG9ydCBkZWZhdWx0IGNyZWF0ZVNlcnZlclJlbmRlcmVyKHBhcmFtcyA9PiB7XHJcbiAgICByZXR1cm4gbmV3IFByb21pc2U8UmVuZGVyUmVzdWx0PigocmVzb2x2ZSwgcmVqZWN0KSA9PiB7XHJcbiAgICAgICAgY29uc3QgcmVxdWVzdFpvbmUgPSBab25lLmN1cnJlbnQuZm9yayh7XHJcbiAgICAgICAgICAgIG5hbWU6ICdhbmd1bGFyLXVuaXZlcnNhbCByZXF1ZXN0JyxcclxuICAgICAgICAgICAgcHJvcGVydGllczoge1xyXG4gICAgICAgICAgICAgICAgYmFzZVVybDogJy8nLFxyXG4gICAgICAgICAgICAgICAgcmVxdWVzdFVybDogcGFyYW1zLnVybCxcclxuICAgICAgICAgICAgICAgIG9yaWdpblVybDogcGFyYW1zLm9yaWdpbixcclxuICAgICAgICAgICAgICAgIHByZWJvb3Q6IGZhbHNlLFxyXG4gICAgICAgICAgICAgICAgZG9jdW1lbnQ6ICc8YXBwPjwvYXBwPidcclxuICAgICAgICAgICAgfSxcclxuICAgICAgICAgICAgb25IYW5kbGVFcnJvcjogKHBhcmVudFpvbmUsIGN1cnJlbnRab25lLCB0YXJnZXRab25lLCBlcnJvcikgPT4ge1xyXG4gICAgICAgICAgICAgICAgLy8gSWYgYW55IGVycm9yIG9jY3VycyB3aGlsZSByZW5kZXJpbmcgdGhlIG1vZHVsZSwgcmVqZWN0IHRoZSB3aG9sZSBvcGVyYXRpb25cclxuICAgICAgICAgICAgICAgIHJlamVjdChlcnJvcik7XHJcbiAgICAgICAgICAgICAgICByZXR1cm4gdHJ1ZTtcclxuICAgICAgICAgICAgfVxyXG4gICAgICAgIH0pO1xyXG5cclxuICAgICAgICByZXR1cm4gcmVxdWVzdFpvbmUucnVuPFByb21pc2U8c3RyaW5nPj4oKCkgPT4gcGxhdGZvcm0uc2VyaWFsaXplTW9kdWxlKEFwcE1vZHVsZSkpLnRoZW4oaHRtbCA9PiB7XHJcbiAgICAgICAgICAgIHJlc29sdmUoeyBodG1sOiBodG1sIH0pO1xyXG4gICAgICAgIH0sIHJlamVjdCk7XHJcbiAgICB9KTtcclxufSk7XHJcblxuXG5cbi8vIFdFQlBBQ0sgRk9PVEVSIC8vXG4vLyAuL34vYW5ndWxhcjItdGVtcGxhdGUtbG9hZGVyIS4vQ2xpZW50QXBwL2Jvb3Qtc2VydmVyLnRzIl0sInNvdXJjZVJvb3QiOiIifQ==