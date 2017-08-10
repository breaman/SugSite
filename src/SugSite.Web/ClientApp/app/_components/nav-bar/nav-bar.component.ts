import { Component, OnInit } from '@angular/core';
import { Subscription } from "rxjs/Subscription";
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  isAuthorizedSubscription: Subscription;
  isAuthorized: boolean;
  currentUserSubscription: Subscription;
  currentUser: any;

  constructor(public securityService : OidcSecurityService) { }

  ngOnInit() {
    this.isAuthorizedSubscription = this.securityService.getIsAuthorized().subscribe(
      (isAuthorized: boolean) => {
        console.log(isAuthorized);
        this.isAuthorized = isAuthorized;
      });

    this.currentUserSubscription = this.securityService.getUserData().subscribe(
      (currentUser: any) => {
        console.log(currentUser);
        this.currentUser = currentUser;
      });

    if (typeof location !== 'undefined' && window.location.hash) {
      this.securityService.authorizedCallback();
    }
  }

  ngOnDestroy() {
    this.isAuthorizedSubscription.unsubscribe();
    this.currentUserSubscription.unsubscribe();
  }

  login() {
    console.log('start login');
    this.securityService.authorize();
  }

  refreshSession() {
    console.log('start refreshSession');
    this.securityService.authorize();
  }

  logout() {
    console.log('start logoff');
    this.securityService.logoff();
  }
}
