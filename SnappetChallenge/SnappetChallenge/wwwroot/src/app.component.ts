import { Component } from '@angular/core';
import { ToasterConfig } from 'angular2-toaster';
import 'angular2-toaster/toaster.css';

@Component({
    selector: 'my-app',
    templateUrl: 'src/app.component.html',
})
export class AppComponent {
    public title = 'Waar heeft mijn klas vandaag aan gewerkt';
    public collapsed = true;
    public toasterconfig: ToasterConfig = new ToasterConfig({
        timeout: 2000,
    });
}
