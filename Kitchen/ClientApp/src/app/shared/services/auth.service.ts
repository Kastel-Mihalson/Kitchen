import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../../environments/environment";
import {JwtHelperService} from "@auth0/angular-jwt";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private httpClient: HttpClient,
    private jwtHelper: JwtHelperService
  ) { }

  Login(email: string, password: string) : Observable<any> {
    return this.httpClient.post<any>(`${environment.apiUrl}/Auth/login`, {
      email,
      password
    });
  }

  Registration(email: string, name: string, password: string) : Observable<any> {
    return this.httpClient.post<any>(`${environment.apiUrl}/Auth/register`, {
      email,
      name,
      password
    });
  }

  GetUserClaims() {
    const accessToken = localStorage.getItem('accessToken');
    if (accessToken) {
      const decodeToken = this.jwtHelper.decodeToken(accessToken);
      let str;
      const newObj = {} as any;
      for (let prop in decodeToken) {
        const val = decodeToken[prop];
        if (prop.includes('/')) {
          str = prop.substring(prop.lastIndexOf('/') + 1, prop.length);
        }
        else {
          str = prop;
        }
        newObj[str] = val;
      }
      return newObj;
    }
    return null;
  }
}
