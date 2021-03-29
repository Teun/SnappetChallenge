import { Injectable, Renderer2 } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class LoadingService {

    constructor(private renderer: Renderer2) {
    }

    setLoadingClass(set: boolean = false): void {
        if (set) {
            this.renderer.addClass(document.body, 'loading');
        } else {
            this.renderer.removeClass(document.body, 'loading');
        }
    }

}
