import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import {PagesModule} from "./pages/pages.module";
import {RouterModule} from "@angular/router";
import {AuthModule} from "./auth/auth.module";
import {AuthInterceptor} from "./shared/interceptors/auth.interceptor";
import {AuthGuard} from "./shared/guards/auth.guard";
import {JWT_OPTIONS, JwtHelperService} from "@auth0/angular-jwt";
import {RegistrationModule} from "./registration/registration.module";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    PagesModule,
    RouterModule,
    AuthModule,
    RegistrationModule,
    BrowserAnimationsModule
  ],
  providers: [
    AuthGuard,
    JwtHelperService,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
