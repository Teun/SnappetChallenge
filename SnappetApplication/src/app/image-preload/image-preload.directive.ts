import { Directive, Input, HostBinding } from '@angular/core';

@Directive({
// tslint:disable-next-line: directive-selector
  selector: 'img[default]',
// tslint:disable-next-line: use-host-property-decorator
  host: {
    '(error)': 'updateUrl()',
    '(load)': 'load()',
    '[src]': 'src'
  }
})

export class ImagePreloadDirective {
  @Input() src: string;
  @Input() default: string;
  @HostBinding('class') className;

  updateUrl() {
    this.src = this.default;
  }
  load() {
    this.className = 'image-loaded';
  }
}
