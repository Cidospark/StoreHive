import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MarketplaceComponent } from './marketplace/marketplace.component';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'marketplace', component: MarketplaceComponent},
    {path: '**', redirectTo: '', pathMatch: 'full'}
];
