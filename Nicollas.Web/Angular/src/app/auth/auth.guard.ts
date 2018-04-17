import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/Rx';
import { AuthService } from './auth.service';

import { Router, CanActivate, CanLoad, ActivatedRouteSnapshot, RouterStateSnapshot, CanActivateChild } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild {
    constructor(private router: Router, private authService: AuthService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.baseTest(route)) {
            return true;
        }
        // not logged in so redirect to login page with the return url
        this.router.navigate(['/login', { returnUrl: state.url }]);
        return false;
    }

    canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.baseTest(route)) {
            return true;
        }
        this.router.navigate([route.data['failUrl'] || '/']);
        return false;
    }

    private baseTest (route: ActivatedRouteSnapshot) {
        return this.authService.isAuthenticate() && this.HasClaim(route.data['claims'], true);
    }


    canLoad(route: Router): boolean {
        const url = `/${route.url}`;

        return this.authService.isAuthenticate();
    }

    HasClaim(claims: string[], passIfNoData = false): boolean {
        if (!claims || claims.length === 0) {
            return passIfNoData;
        }
        const token = this.authService.getToken();
        if (!token) { return false; }
        for (const claim of claims) {
            const result = token.claims.find(row => row.claimType === claim);
            if (result) {
                return result.claimValue === 'Allow';
            }
            if (token.roles_claims.some(row => row.claimType === claim && row.claimValue === 'Allow')) {
                return true;
            }
        }
        return false;
    }

    // HasClaim(
    //     claims: Nicollas.Dto.Identity.roleClaimDto[] | Nicollas.Dto.Identity.userClaimDto[],
    //     passIfNoData = false
    // ): boolean {
    //     if (claims.length === 0) {
    //         return passIfNoData;
    //     }
    //     const token = this.authService.getToken();
    //     if (!token) { return false; }
    //     for (const claim of claims) {
    //         const result = token.claims.find(row => row.claimType === claim.claimType);
    //         if (result) {
    //             return result.claimValue === 'Allow';
    //         }
    //         if ( token.roles_claims.some(row => row.claimType === claim.claimType && row.claimValue === 'Allow')) {
    //             return true;
    //         }
    //     }
    //     return false;
    // }
}
