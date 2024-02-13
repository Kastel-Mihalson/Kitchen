import { NgModule } from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {LayoutComponent} from "./pages/layout/components/layout/layout.component";
import {AuthComponent} from "./auth/components/auth/auth.component";
import {AuthGuard} from "./shared/guards/auth.guard";
import {RegistrationComponent} from "./registration/components/registration/registration.component";

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard],
    children: [
      {path: '', loadChildren: () => import('./pages/pages.module').then(m => m.PagesModule)}
    ]
  },
  {
    path: 'auth',
    component: AuthComponent
  },
  {
    path: 'registration',
    component: RegistrationComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes, {scrollPositionRestoration: 'enabled', anchorScrolling: 'enabled', onSameUrlNavigation: 'reload'})
  ],
})
export class AppRoutingModule { }
