SystemJS.config({
    paths: {
        "github:": "jspm_packages/github/",
        "npm:": "jspm_packages/npm/",
        "SnappetChallenge/": "src/"
    },
    browserConfig: {
        "baseURL": "/",
        "bundles": {
            "dist/build-dev.js": [
                "SnappetChallenge/main.ts",
                "SnappetChallenge/app.module.ts",
                "SnappetChallenge/work.service.ts",
                "npm:rxjs@5.2.0/add/operator/toPromise.js",
                "npm:rxjs@5.2.0.json",
                "npm:rxjs@5.2.0/operator/toPromise.js",
                "npm:rxjs@5.2.0/util/root.js",
                "npm:rxjs@5.2.0/Observable.js",
                "npm:rxjs@5.2.0/symbol/observable.js",
                "npm:rxjs@5.2.0/util/toSubscriber.js",
                "npm:rxjs@5.2.0/Observer.js",
                "npm:rxjs@5.2.0/symbol/rxSubscriber.js",
                "npm:rxjs@5.2.0/Subscriber.js",
                "npm:rxjs@5.2.0/Subscription.js",
                "npm:rxjs@5.2.0/util/UnsubscriptionError.js",
                "npm:rxjs@5.2.0/util/errorObject.js",
                "npm:rxjs@5.2.0/util/tryCatch.js",
                "npm:rxjs@5.2.0/util/isFunction.js",
                "npm:rxjs@5.2.0/util/isObject.js",
                "npm:rxjs@5.2.0/util/isArray.js",
                "npm:@angular/http@2.4.10/bundles/http.umd.js",
                "npm:@angular/http@2.4.10.json",
                "npm:@angular/platform-browser@2.4.10/bundles/platform-browser.umd.js",
                "npm:@angular/platform-browser@2.4.10.json",
                "npm:@angular/core@2.4.10/bundles/core.umd.js",
                "npm:@angular/core@2.4.10.json",
                "npm:rxjs@5.2.0/Subject.js",
                "npm:rxjs@5.2.0/SubjectSubscription.js",
                "npm:rxjs@5.2.0/util/ObjectUnsubscribedError.js",
                "npm:@angular/common@2.4.10/bundles/common.umd.js",
                "npm:@angular/common@2.4.10.json",
                "SnappetChallenge/subjectstatistics.component.ts",
                "npm:angular2-toaster@2.0.0/bundles/angular2-toaster.umd.js",
                "npm:angular2-toaster@2.0.0.json",
                "npm:rxjs@5.2.0/add/operator/share.js",
                "npm:rxjs@5.2.0/operator/share.js",
                "npm:rxjs@5.2.0/operator/multicast.js",
                "npm:rxjs@5.2.0/observable/ConnectableObservable.js",
                "npm:@angular/router@3.4.10/bundles/router.umd.js",
                "npm:@angular/router@3.4.10.json",
                "npm:rxjs@5.2.0/operator/filter.js",
                "npm:rxjs@5.2.0/operator/mergeAll.js",
                "npm:rxjs@5.2.0/util/subscribeToResult.js",
                "npm:rxjs@5.2.0/InnerSubscriber.js",
                "npm:rxjs@5.2.0/symbol/iterator.js",
                "npm:rxjs@5.2.0/util/isPromise.js",
                "npm:rxjs@5.2.0/util/isArrayLike.js",
                "npm:rxjs@5.2.0/OuterSubscriber.js",
                "npm:rxjs@5.2.0/operator/last.js",
                "npm:rxjs@5.2.0/util/EmptyError.js",
                "npm:rxjs@5.2.0/observable/fromPromise.js",
                "npm:rxjs@5.2.0/observable/PromiseObservable.js",
                "npm:rxjs@5.2.0/operator/concatAll.js",
                "npm:rxjs@5.2.0/operator/catch.js",
                "npm:rxjs@5.2.0/operator/reduce.js",
                "npm:rxjs@5.2.0/operator/mergeMap.js",
                "npm:rxjs@5.2.0/operator/map.js",
                "npm:rxjs@5.2.0/operator/first.js",
                "npm:rxjs@5.2.0/operator/every.js",
                "npm:rxjs@5.2.0/operator/concatMap.js",
                "npm:rxjs@5.2.0/observable/of.js",
                "npm:rxjs@5.2.0/observable/ArrayObservable.js",
                "npm:rxjs@5.2.0/util/isScheduler.js",
                "npm:rxjs@5.2.0/observable/EmptyObservable.js",
                "npm:rxjs@5.2.0/observable/ScalarObservable.js",
                "npm:rxjs@5.2.0/observable/from.js",
                "npm:rxjs@5.2.0/observable/FromObservable.js",
                "npm:rxjs@5.2.0/operator/observeOn.js",
                "npm:rxjs@5.2.0/Notification.js",
                "npm:rxjs@5.2.0/observable/ArrayLikeObservable.js",
                "npm:rxjs@5.2.0/observable/IteratorObservable.js",
                "npm:rxjs@5.2.0/BehaviorSubject.js",
                "SnappetChallenge/subjects.component.ts",
                "SnappetChallenge/progress.component.ts",
                "SnappetChallenge/app.routing.ts",
                "SnappetChallenge/app.component.ts",
                "npm:angular2-toaster@2.0.0/toaster.css",
                "npm:ng2-charts@1.5.0/bundles/ng2-charts.umd.js",
                "npm:ng2-charts@1.5.0.json",
                "npm:@angular/platform-browser-dynamic@2.4.10/bundles/platform-browser-dynamic.umd.js",
                "npm:@angular/platform-browser-dynamic@2.4.10.json",
                "npm:@angular/compiler@2.4.10/bundles/compiler.umd.js",
                "npm:@angular/compiler@2.4.10.json",
                "npm:chart.js@2.5.0/src/chart.js",
                "npm:chart.js@2.5.0.json",
                "npm:jspm-nodelibs-process@0.2.0/process.js",
                "npm:jspm-nodelibs-process@0.2.0.json",
                "npm:chart.js@2.5.0/src/charts/Chart.Scatter.js",
                "npm:chart.js@2.5.0/src/charts/Chart.Radar.js",
                "npm:chart.js@2.5.0/src/charts/Chart.PolarArea.js",
                "npm:chart.js@2.5.0/src/charts/Chart.Line.js",
                "npm:chart.js@2.5.0/src/charts/Chart.Doughnut.js",
                "npm:chart.js@2.5.0/src/charts/Chart.Bubble.js",
                "npm:chart.js@2.5.0/src/charts/Chart.Bar.js",
                "npm:chart.js@2.5.0/src/controllers/controller.radar.js",
                "npm:chart.js@2.5.0/src/controllers/controller.polarArea.js",
                "npm:chart.js@2.5.0/src/controllers/controller.line.js",
                "npm:chart.js@2.5.0/src/controllers/controller.doughnut.js",
                "npm:chart.js@2.5.0/src/controllers/controller.bubble.js",
                "npm:chart.js@2.5.0/src/controllers/controller.bar.js",
                "npm:chart.js@2.5.0/src/scales/scale.time.js",
                "npm:moment@2.18.0/moment.js",
                "npm:moment@2.18.0.json",
                "npm:chart.js@2.5.0/src/scales/scale.radialLinear.js",
                "npm:chart.js@2.5.0/src/scales/scale.logarithmic.js",
                "npm:chart.js@2.5.0/src/scales/scale.linear.js",
                "npm:chart.js@2.5.0/src/scales/scale.category.js",
                "npm:chart.js@2.5.0/src/scales/scale.linearbase.js",
                "npm:chart.js@2.5.0/src/elements/element.rectangle.js",
                "npm:chart.js@2.5.0/src/elements/element.point.js",
                "npm:chart.js@2.5.0/src/elements/element.line.js",
                "npm:chart.js@2.5.0/src/elements/element.arc.js",
                "npm:chart.js@2.5.0/src/core/core.tooltip.js",
                "npm:chart.js@2.5.0/src/core/core.interaction.js",
                "npm:chart.js@2.5.0/src/core/core.legend.js",
                "npm:chart.js@2.5.0/src/core/core.title.js",
                "npm:chart.js@2.5.0/src/core/core.scale.js",
                "npm:chart.js@2.5.0/src/core/core.ticks.js",
                "npm:chart.js@2.5.0/src/core/core.scaleService.js",
                "npm:chart.js@2.5.0/src/core/core.layoutService.js",
                "npm:chart.js@2.5.0/src/core/core.datasetController.js",
                "npm:chart.js@2.5.0/src/core/core.controller.js",
                "npm:chart.js@2.5.0/src/core/core.animation.js",
                "npm:chart.js@2.5.0/src/core/core.element.js",
                "npm:chart.js@2.5.0/src/core/core.plugin.js",
                "npm:chart.js@2.5.0/src/core/core.canvasHelpers.js",
                "npm:chart.js@2.5.0/src/platforms/platform.js",
                "npm:chart.js@2.5.0/src/platforms/platform.dom.js",
                "npm:chart.js@2.5.0/src/core/core.helpers.js",
                "npm:chartjs-color@2.1.0/index.js",
                "npm:chartjs-color@2.1.0.json",
                "npm:chartjs-color-string@0.4.0/color-string.js",
                "npm:chartjs-color-string@0.4.0.json",
                "npm:color-name@1.1.2/index.js",
                "npm:color-name@1.1.2.json",
                "npm:color-convert@0.5.3/index.js",
                "npm:color-convert@0.5.3.json",
                "npm:color-convert@0.5.3/conversions.js",
                "npm:chart.js@2.5.0/src/core/core.js",
                "npm:zone.js@0.7.2/dist/zone.js",
                "npm:zone.js@0.7.2.json",
                "npm:reflect-metadata@0.1.10/Reflect.js",
                "npm:reflect-metadata@0.1.10.json",
                "npm:es6-shim@0.35.3/es6-shim.js",
                "npm:es6-shim@0.35.3.json"
            ]
        }
    },
    transpiler: "plugin-typescript",
    typescriptOptions: {
        "tsconfig": true,
        "module": "commonjs"
    },
    packages: {
        "SnappetChallenge": {
            "main": "main.ts",
            "format": "system",
            "defaultExtension": "ts",
            "meta": {
                "*.ts": {
                    "loader": "plugin-typescript"
                }
            }
        }
    },
    meta: {
        "npm:angular2/core": {
            "deps": [
                "es6-shim",
                "reflect-metadata",
                "rxjs"
            ]
        },
        "*.css": {
            "loader": "css"
        },
        "*.ts": {
            "loader": "plugin-typescript"
        }
    }
});

SystemJS.config({
    packageConfigPaths: [
        "github:*/*.json",
        "npm:@*/*.json",
        "npm:*.json"
    ],
    map: {
        "@angular/common": "npm:@angular/common@2.4.10",
        "@angular/compiler": "npm:@angular/compiler@2.4.10",
        "@angular/core": "npm:@angular/core@2.4.10",
        "@angular/http": "npm:@angular/http@2.4.10",
        "@angular/platform-browser": "npm:@angular/platform-browser@2.4.10",
        "@angular/platform-browser-dynamic": "npm:@angular/platform-browser-dynamic@2.4.10",
        "@angular/router": "npm:@angular/router@3.4.10",
        "@reactivex/rxjs": "npm:@reactivex/rxjs@5.2.0",
        "angular2-toaster": "npm:angular2-toaster@2.0.0",
        "assert": "npm:jspm-nodelibs-assert@0.2.0",
        "buffer": "npm:jspm-nodelibs-buffer@0.2.1",
        "chart.js": "npm:chart.js@2.5.0",
        "child_process": "npm:jspm-nodelibs-child_process@0.2.0",
        "constants": "npm:jspm-nodelibs-constants@0.2.0",
        "crypto": "npm:jspm-nodelibs-crypto@0.2.0",
        "css": "github:systemjs/plugin-css@0.1.33",
        "es6-shim": "npm:es6-shim@0.35.3",
        "events": "npm:jspm-nodelibs-events@0.2.0",
        "fs": "npm:jspm-nodelibs-fs@0.2.0",
        "module": "npm:jspm-nodelibs-module@0.2.0",
        "net": "npm:jspm-nodelibs-net@0.2.0",
        "ng2-charts": "npm:ng2-charts@1.5.0",
        "os": "npm:jspm-nodelibs-os@0.2.0",
        "path": "npm:jspm-nodelibs-path@0.2.1",
        "plugin-typescript": "github:frankwallis/plugin-typescript@7.0.5",
        "process": "npm:jspm-nodelibs-process@0.2.0",
        "reflect-metadata": "npm:reflect-metadata@0.1.10",
        "rxjs": "npm:rxjs@5.2.0",
        "stream": "npm:jspm-nodelibs-stream@0.2.0",
        "string_decoder": "npm:jspm-nodelibs-string_decoder@0.2.0",
        "systemjs-hot-reloader": "npm:systemjs-hot-reloader@1.1.0",
        "timers": "npm:jspm-nodelibs-timers@0.2.0",
        "typescript": "npm:typescript@2.2.1",
        "util": "npm:jspm-nodelibs-util@0.2.1",
        "vm": "npm:jspm-nodelibs-vm@0.2.0",
        "zone.js": "npm:zone.js@0.7.2"
    },
    packages: {
        "npm:typescript@2.2.1": {
            "map": {
                "source-map-support": "npm:source-map-support@0.4.14"
            }
        },
        "npm:jspm-nodelibs-os@0.2.0": {
            "map": {
                "os-browserify": "npm:os-browserify@0.2.1"
            }
        },
        "npm:jspm-nodelibs-crypto@0.2.0": {
            "map": {
                "crypto-browserify": "npm:crypto-browserify@3.11.0"
            }
        },
        "npm:crypto-browserify@3.11.0": {
            "map": {
                "browserify-sign": "npm:browserify-sign@4.0.0",
                "create-hmac": "npm:create-hmac@1.1.4",
                "public-encrypt": "npm:public-encrypt@4.0.0",
                "browserify-cipher": "npm:browserify-cipher@1.0.0",
                "create-ecdh": "npm:create-ecdh@4.0.0",
                "diffie-hellman": "npm:diffie-hellman@5.0.2",
                "randombytes": "npm:randombytes@2.0.3",
                "create-hash": "npm:create-hash@1.1.2",
                "inherits": "npm:inherits@2.0.3",
                "pbkdf2": "npm:pbkdf2@3.0.9"
            }
        },
        "npm:browserify-sign@4.0.0": {
            "map": {
                "create-hmac": "npm:create-hmac@1.1.4",
                "create-hash": "npm:create-hash@1.1.2",
                "inherits": "npm:inherits@2.0.3",
                "bn.js": "npm:bn.js@4.11.6",
                "elliptic": "npm:elliptic@6.4.0",
                "browserify-rsa": "npm:browserify-rsa@4.0.1",
                "parse-asn1": "npm:parse-asn1@5.1.0"
            }
        },
        "npm:create-hmac@1.1.4": {
            "map": {
                "create-hash": "npm:create-hash@1.1.2",
                "inherits": "npm:inherits@2.0.3"
            }
        },
        "npm:public-encrypt@4.0.0": {
            "map": {
                "create-hash": "npm:create-hash@1.1.2",
                "randombytes": "npm:randombytes@2.0.3",
                "bn.js": "npm:bn.js@4.11.6",
                "browserify-rsa": "npm:browserify-rsa@4.0.1",
                "parse-asn1": "npm:parse-asn1@5.1.0"
            }
        },
        "npm:diffie-hellman@5.0.2": {
            "map": {
                "randombytes": "npm:randombytes@2.0.3",
                "bn.js": "npm:bn.js@4.11.6",
                "miller-rabin": "npm:miller-rabin@4.0.0"
            }
        },
        "npm:create-hash@1.1.2": {
            "map": {
                "inherits": "npm:inherits@2.0.3",
                "sha.js": "npm:sha.js@2.4.8",
                "cipher-base": "npm:cipher-base@1.0.3",
                "ripemd160": "npm:ripemd160@1.0.1"
            }
        },
        "npm:create-ecdh@4.0.0": {
            "map": {
                "bn.js": "npm:bn.js@4.11.6",
                "elliptic": "npm:elliptic@6.4.0"
            }
        },
        "npm:browserify-cipher@1.0.0": {
            "map": {
                "evp_bytestokey": "npm:evp_bytestokey@1.0.0",
                "browserify-des": "npm:browserify-des@1.0.0",
                "browserify-aes": "npm:browserify-aes@1.0.6"
            }
        },
        "npm:jspm-nodelibs-buffer@0.2.1": {
            "map": {
                "buffer": "npm:buffer@4.9.1"
            }
        },
        "npm:pbkdf2@3.0.9": {
            "map": {
                "create-hmac": "npm:create-hmac@1.1.4"
            }
        },
        "npm:elliptic@6.4.0": {
            "map": {
                "bn.js": "npm:bn.js@4.11.6",
                "inherits": "npm:inherits@2.0.3",
                "hash.js": "npm:hash.js@1.0.3",
                "hmac-drbg": "npm:hmac-drbg@1.0.0",
                "brorand": "npm:brorand@1.1.0",
                "minimalistic-assert": "npm:minimalistic-assert@1.0.0",
                "minimalistic-crypto-utils": "npm:minimalistic-crypto-utils@1.0.1"
            }
        },
        "npm:miller-rabin@4.0.0": {
            "map": {
                "bn.js": "npm:bn.js@4.11.6",
                "brorand": "npm:brorand@1.1.0"
            }
        },
        "npm:browserify-rsa@4.0.1": {
            "map": {
                "bn.js": "npm:bn.js@4.11.6",
                "randombytes": "npm:randombytes@2.0.3"
            }
        },
        "npm:evp_bytestokey@1.0.0": {
            "map": {
                "create-hash": "npm:create-hash@1.1.2"
            }
        },
        "npm:browserify-des@1.0.0": {
            "map": {
                "inherits": "npm:inherits@2.0.3",
                "cipher-base": "npm:cipher-base@1.0.3",
                "des.js": "npm:des.js@1.0.0"
            }
        },
        "npm:browserify-aes@1.0.6": {
            "map": {
                "create-hash": "npm:create-hash@1.1.2",
                "evp_bytestokey": "npm:evp_bytestokey@1.0.0",
                "inherits": "npm:inherits@2.0.3",
                "cipher-base": "npm:cipher-base@1.0.3",
                "buffer-xor": "npm:buffer-xor@1.0.3"
            }
        },
        "npm:parse-asn1@5.1.0": {
            "map": {
                "browserify-aes": "npm:browserify-aes@1.0.6",
                "create-hash": "npm:create-hash@1.1.2",
                "evp_bytestokey": "npm:evp_bytestokey@1.0.0",
                "pbkdf2": "npm:pbkdf2@3.0.9",
                "asn1.js": "npm:asn1.js@4.9.1"
            }
        },
        "npm:jspm-nodelibs-stream@0.2.0": {
            "map": {
                "stream-browserify": "npm:stream-browserify@2.0.1"
            }
        },
        "npm:buffer@4.9.1": {
            "map": {
                "ieee754": "npm:ieee754@1.1.8",
                "isarray": "npm:isarray@1.0.0",
                "base64-js": "npm:base64-js@1.2.0"
            }
        },
        "npm:sha.js@2.4.8": {
            "map": {
                "inherits": "npm:inherits@2.0.3"
            }
        },
        "npm:cipher-base@1.0.3": {
            "map": {
                "inherits": "npm:inherits@2.0.3"
            }
        },
        "npm:asn1.js@4.9.1": {
            "map": {
                "bn.js": "npm:bn.js@4.11.6",
                "inherits": "npm:inherits@2.0.3",
                "minimalistic-assert": "npm:minimalistic-assert@1.0.0"
            }
        },
        "npm:stream-browserify@2.0.1": {
            "map": {
                "inherits": "npm:inherits@2.0.3",
                "readable-stream": "npm:readable-stream@2.2.6"
            }
        },
        "npm:hash.js@1.0.3": {
            "map": {
                "inherits": "npm:inherits@2.0.3"
            }
        },
        "npm:hmac-drbg@1.0.0": {
            "map": {
                "hash.js": "npm:hash.js@1.0.3",
                "minimalistic-assert": "npm:minimalistic-assert@1.0.0",
                "minimalistic-crypto-utils": "npm:minimalistic-crypto-utils@1.0.1"
            }
        },
        "npm:des.js@1.0.0": {
            "map": {
                "inherits": "npm:inherits@2.0.3",
                "minimalistic-assert": "npm:minimalistic-assert@1.0.0"
            }
        },
        "npm:jspm-nodelibs-string_decoder@0.2.0": {
            "map": {
                "string_decoder-browserify": "npm:string_decoder@0.10.31"
            }
        },
        "npm:readable-stream@2.2.6": {
            "map": {
                "isarray": "npm:isarray@1.0.0",
                "inherits": "npm:inherits@2.0.3",
                "string_decoder": "npm:string_decoder@0.10.31",
                "util-deprecate": "npm:util-deprecate@1.0.2",
                "buffer-shims": "npm:buffer-shims@1.0.0",
                "core-util-is": "npm:core-util-is@1.0.2",
                "process-nextick-args": "npm:process-nextick-args@1.0.7"
            }
        },
        "npm:rxjs@5.2.0": {
            "map": {
                "symbol-observable": "npm:symbol-observable@1.0.4"
            }
        },
        "npm:jspm-nodelibs-timers@0.2.0": {
            "map": {
                "timers-browserify": "npm:timers-browserify@1.4.2"
            }
        },
        "npm:timers-browserify@1.4.2": {
            "map": {
                "process": "npm:process@0.11.9"
            }
        },
        "npm:systemjs-hot-reloader@1.1.0": {
            "map": {
                "systemjs-hmr": "npm:systemjs-hmr@2.0.9"
            }
        },
        "npm:@reactivex/rxjs@5.2.0": {
            "map": {
                "symbol-observable": "npm:symbol-observable@1.0.4"
            }
        },
        "npm:source-map-support@0.4.14": {
            "map": {
                "source-map": "npm:source-map@0.5.6"
            }
        },
        "npm:ng2-charts@1.5.0": {
            "map": {
                "chart.js": "npm:chart.js@2.5.0"
            }
        },
        "npm:chart.js@2.5.0": {
            "map": {
                "chartjs-color": "npm:chartjs-color@2.1.0",
                "moment": "npm:moment@2.18.0"
            }
        },
        "npm:chartjs-color@2.1.0": {
            "map": {
                "color-convert": "npm:color-convert@0.5.3",
                "chartjs-color-string": "npm:chartjs-color-string@0.4.0"
            }
        },
        "npm:chartjs-color-string@0.4.0": {
            "map": {
                "color-name": "npm:color-name@1.1.2"
            }
        }
    }
});
