import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import {AuthModule, OpenIDImplicitFlowConfiguration, OidcSecurityService} from 'angular-auth-oidc-client';

import { routing } from "./_routes/app.routes";

import { AppComponent } from './_components/app/app.component';
import { HomeComponent } from './_components/home/home.component';
import { NavBarComponent } from './_components/nav-bar/nav-bar.component';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        NavBarComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        AuthModule.forRoot(),
        routing
    ],
    providers: [
        OidcSecurityService
    ]
})
export class AppModuleShared {
    constructor(public oidcSecurityService: OidcSecurityService) {
        let openIDImplicitFlowConfiguration = new OpenIDImplicitFlowConfiguration();

        openIDImplicitFlowConfiguration.stsServer = 'http://localhost:5000';
        openIDImplicitFlowConfiguration.redirect_url = 'http://localhost:5000';

        openIDImplicitFlowConfiguration.client_id = 'angular';
        openIDImplicitFlowConfiguration.response_type = 'id_token token';
        openIDImplicitFlowConfiguration.scope = 'openid profile';
        openIDImplicitFlowConfiguration.post_logout_redirect_uri = 'http://localhost:5000';
        openIDImplicitFlowConfiguration.start_checksession = false;
        openIDImplicitFlowConfiguration.max_id_token_iat_offset_allowed_in_seconds = 10;
        openIDImplicitFlowConfiguration.silent_renew = true;

        openIDImplicitFlowConfiguration.startup_route = '/';

        openIDImplicitFlowConfiguration.log_console_warning_active = true;
        openIDImplicitFlowConfiguration.log_console_debug_active = true;

        this.oidcSecurityService.setupModule(openIDImplicitFlowConfiguration);
        this.oidcSecurityService.setCustomRequestParameters({"none": ""});
    }
}
