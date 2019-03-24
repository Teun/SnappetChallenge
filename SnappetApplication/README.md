# SnappetApplication

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 7.3.5. It is the front-end application for ClassRoom data.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Getting "No 'Access-Control-Allow-Origin' header is present"?
This is not a fix for production or when application has to be shown to the client, this is only helpful when UI and Backend development are on different servers and in production they are actually on same server. For example: While developing UI for any application if there is a need to test it locally pointing it to backend server, in that scenario this is the perfect fix. For production fix, CORS headers has to be added to the backend server to allow cross origin access.

The easy way is to just add the extension in google chrome to allow access using CORS.

(https://chrome.google.com/webstore/detail/allow-control-allow-origi/nlfbmbojpeacfghkpbjhddihlkkiljbi?hl=en-US)

Just enable this extension whenever you want allow access to no 'access-control-allow-origin' header request.

Or

In Windows, paste this command in run window

```
chrome.exe --user-data-dir="C:/Chrome dev session" --disable-web-security
this will open a new chrome browser which allow access to no 'access-control-allow-origin' header request.
```

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
