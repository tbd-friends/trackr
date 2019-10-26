import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  Router,
  UrlTree,
  CanActivate
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { AuthService } from './services/auth.service';
import { tap, concatMap, mergeMap, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private auth: AuthService, private router: Router) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean {
    return true;

    const roles = next.data.roles as Array<string>;

    const authenticated = this.auth.isAuthenticated$;

    if (roles) {
      return authenticated.pipe(mergeMap(() => this.auth.isInRole(roles))).pipe(
        map(r => {
          if (!r) {
            return this.router.parseUrl('/');
          }

          return true;
        })
      );
    }

    return authenticated;
  }
}
