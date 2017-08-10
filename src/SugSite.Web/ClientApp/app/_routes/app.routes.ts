import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from "../_components/home/home.component";

const appRoutes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full' }
];

export const routing = RouterModule.forRoot(appRoutes);