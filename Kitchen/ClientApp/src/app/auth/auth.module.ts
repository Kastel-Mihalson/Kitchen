import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthComponent } from './components/auth/auth.component';
import {CheckboxModule} from "primeng/checkbox";
import {InputTextModule} from "primeng/inputtext";
import {ButtonModule} from "primeng/button";
import {RippleModule} from "primeng/ripple";
import {PasswordModule} from "primeng/password";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {LoadingSpinnerModule} from "../shared/components/loading-spinner/loading-spinner.module";



@NgModule({
  declarations: [
    AuthComponent
  ],
  imports: [
    CommonModule,
    CheckboxModule,
    InputTextModule,
    ButtonModule,
    RippleModule,
    PasswordModule,
    FormsModule,
    ReactiveFormsModule,
    LoadingSpinnerModule
  ]
})
export class AuthModule { }
