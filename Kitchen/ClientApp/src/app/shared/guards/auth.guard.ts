import {AuthService} from "../services/auth.service";
import {
  ActivatedRouteSnapshot,
  CanActivate,
  CanActivateChild,
  Router,
  RouterStateSnapshot,
  UrlTree
} from "@angular/router";
import {Injectable} from "@angular/core";
import {Observable, of} from "rxjs";
import {JwtHelperService} from "@auth0/angular-jwt";

@Injectable()
export class AuthGuard
  implements CanActivate, CanActivateChild {

  constructor(
    private authService: AuthService,
    private jwtHelper: JwtHelperService,
    private readonly router: Router
  ) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> {
    const accessToken = localStorage.getItem('accessToken');
    if (accessToken) {
      if (this.jwtHelper.isTokenExpired(accessToken)) {
        return of(this.router.createUrlTree(['/auth']));
      }
    }else{
      return of(this.router.createUrlTree(['/auth']));
    }
    return of(true);
  }

  canActivateChild(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> {
    return this.canActivate(next, state)
  }
}
