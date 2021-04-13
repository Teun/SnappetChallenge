import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { DropDownComponent } from './ui-components/drop-down/drop-down.component';
import { RadioButtonComponent } from './ui-components/radio-button/radio-button.component';
import { ButtonComponent } from './ui-components/button/button.component';
import { TextFieldComponent } from './ui-components/text-field/text-field.component';
import { NavBarComponent } from './ui-components/nav-bar/nav-bar.component';
import { SideNavComponent } from './ui-components/side-nav/side-nav.component';
import { HeaderComponent } from './ui-components/header/header.component';
import { RouterModule } from '@angular/router';
import { ErrorPageComponent } from './ui-components/error-page/error-page.component';



@NgModule({
  declarations: [
    DropDownComponent,
    RadioButtonComponent,
    ButtonComponent,
    TextFieldComponent,
    NavBarComponent,
    SideNavComponent,
    HeaderComponent,
    ErrorPageComponent
  ],
  imports: [
    RouterModule,
    CommonModule,
    ReactiveFormsModule,
  ],
  exports: [
    HeaderComponent,
    TextFieldComponent,
    SideNavComponent,
    DropDownComponent
  ]
})
export class SharedModule { }
