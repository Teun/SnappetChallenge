import { Injectable } from '@angular/core';
import { HttpEvent, HttpEventType, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { LoadingService } from '../_services/loading.service';

@Injectable()
export class HttpProgressInterceptor implements HttpInterceptor {

    constructor(
        private loadingService: LoadingService // my personal service for the progress bar - replace with your own
    ) {
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            tap((event: HttpEvent<any>) => {
                if (event.type === HttpEventType.DownloadProgress) {
                    // here we get the updated progress values, call your service or what ever here
                    // @ts-ignore
                    this.loadingService.setLoadingClass(true); // display & update progress bar
                } else if (event.type === HttpEventType.Response) {
                    this.loadingService.setLoadingClass(false); // hide progress bar
                }
            }, error => {
                this.loadingService.setLoadingClass(false); // hide progress bar
            })
        );
    }
}
