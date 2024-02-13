import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {ProjectsComponent} from "./projects/components/projects/projects.component";
import {DishsComponent} from "./dishs/components/dishs/dishs.component";
import {WelcomeComponent} from "./welcome/components/welcome/welcome.component";

const routes: Routes = [
  {
    path: 'projects',
    component: ProjectsComponent
  },
  {
    path: 'dishs',
    component: DishsComponent
  },
  {
    path: 'welcome',
    component: WelcomeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
