import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {LoadingSpinnerComponent} from "./components/loading-spinner/loading-spinner.component";
import {ProgressSpinnerModule} from "primeng/progressspinner";



@NgModule({
    declarations: [
        LoadingSpinnerComponent
    ],
    exports: [
        LoadingSpinnerComponent
    ],
  imports: [
    CommonModule,
    ProgressSpinnerModule
  ]
})
export class LoadingSpinnerModule { }
