import { TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { StudentComponent } from './student/student.component';

describe('AppComponent', () => {
  beforeEach(() => TestBed.configureTestingModule({
    declarations: [StudentComponent]
  }));

  //This checks if the component is created or not
  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  //This checks if the title variable is assigned with value as the title
  it(`should have as title 'Snappet Class'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('Snappet Class');
  });

  //This checks if the title of the page as "Snappet Class" is loaded
  it('should render Snappet Class title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h1')?.textContent).toContain('Snappet Class');
  });
});
