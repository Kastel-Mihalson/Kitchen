import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DishsComponent } from './components/dishs/dishs.component';
import {CardModule} from "primeng/card";
import {SelectButtonModule} from "primeng/selectbutton";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {ButtonModule} from "primeng/button";
import {RippleModule} from "primeng/ripple";
import {LoadingSpinnerModule} from "../../shared/components/loading-spinner/loading-spinner.module";
import {DialogModule} from "primeng/dialog";
import {InputTextModule} from "primeng/inputtext";
import {InputTextareaModule} from "primeng/inputtextarea";
import {DropdownModule} from "primeng/dropdown";
import {MenuModule} from "primeng/menu";
import {ToastModule} from "primeng/toast";
import {PanelModule} from "primeng/panel";
import {ConfirmDialogModule} from "primeng/confirmdialog";
import {TableModule} from "primeng/table";

@NgModule({
  declarations: [
    DishsComponent
  ],
    imports: [
        CommonModule,
        CardModule,
        SelectButtonModule,
        FormsModule,
        ButtonModule,
        RippleModule,
        LoadingSpinnerModule,
        DialogModule,
        InputTextModule,
        InputTextareaModule,
        ReactiveFormsModule,
        DropdownModule,
        MenuModule,
        ToastModule,
        PanelModule,
        ConfirmDialogModule,
        TableModule
    ]
})
export class DishsModule { }
