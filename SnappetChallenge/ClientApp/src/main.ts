import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));

// The line below is added by the Angular upgrade from 8 to 9 but causes it to break.
//https://stackoverflow.com/questions/60114758/uncaught-syntaxerror-strict-mode-code-may-not-include-a-with-statement
//export { renderModule, renderModuleFactory } from '@angular/platform-server';