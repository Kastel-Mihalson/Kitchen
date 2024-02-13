import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagesRoutingModule } from './pages-routing.module';
import {LayoutModule} from "./layout/layout.module";
import {ProjectsModule} from "./projects/projects.module";
import {DishsModule} from "./dishs/dishs.module";


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    PagesRoutingModule,
    LayoutModule,
    ProjectsModule,
    DishsModule
  ]
})
export class PagesModule { }
