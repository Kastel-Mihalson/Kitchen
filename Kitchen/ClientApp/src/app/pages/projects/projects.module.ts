import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectsComponent } from './components/projects/projects.component';
import {CardModule} from "primeng/card";
import {RouterLink} from "@angular/router";
import {LoadingSpinnerModule} from "../../shared/components/loading-spinner/loading-spinner.module";
import {ButtonModule} from "primeng/button";
import {RippleModule} from "primeng/ripple";
import {DialogModule} from "primeng/dialog";
import {InputTextModule} from "primeng/inputtext";
import {FormsModule} from "@angular/forms";
import {ReactiveFormsModule} from "@angular/forms";
import {InputTextareaModule} from "primeng/inputtextarea";
import {SplitButtonModule} from "primeng/splitbutton";
import {ToastModule} from "primeng/toast";
import {PanelModule} from "primeng/panel";
import {ConfirmDialogModule} from "primeng/confirmdialog";

@NgModule({
  declarations: [
    ProjectsComponent
  ],
    imports: [
        CommonModule,
        CardModule,
        RouterLink,
        LoadingSpinnerModule,
        ButtonModule,
        RippleModule,
        DialogModule,
        InputTextModule,
        FormsModule,
        ReactiveFormsModule,
        InputTextareaModule,
        SplitButtonModule,
        ToastModule,
        PanelModule,
        ConfirmDialogModule
    ]
})
export class ProjectsModule { }
