import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailComponent } from './products/product-detail/product-detail.component';
import { ProductsComponent } from './products/products.component';
import { ProductsResolverService } from './products/resolvers/products-resolver.service'
import { ProductEditComponent } from './products/product-edit/product-edit.component';
import { CharacteristicResolverService } from './products/resolvers/characteristic-resolver.service';
import { ShopsComponent } from './shops/shops.component';
import { ShopDetailComponent } from './shops/shop-detail/shop-detail.component';
import { ShopsResolverService } from './shops/resolvers/shops-resolver.service';
import { EmployeeListComponent } from './shops/employee-list/employee-list.component';
import { SupplyListComponent } from './shops/supply-list/supply-list.component';
import { AvailabilityListComponent } from './shops/availability-list/availability-list.component';
import { EmployeeEditComponent } from './shops/employee-edit/employee-edit.component';
import { ShopEditComponent } from './shops/shop-edit/shop-edit.component';
import { ProvidersComponent } from './providers/providers.component';
import { ProvidersResolverService } from './providers/resolvers/providers-resolver.service';
import { ContractListComponent } from './providers/contract-list/contract-list.component';
import { ProviderEditComponent } from './providers/provider-edit/provider-edit.component';
import { ContractEditComponent } from './providers/contract-list/contract-edit/contract-edit.component';
import { ContractDetailComponent } from './providers/contract-detail/contract-detail.component';
import { SuppliesComponent } from './supplies/supplies.component';
import { SupplyEditComponent } from './supplies/supply-edit/supply-edit.component';
import { SupplyDetailComponent } from './supplies/supply-detail/supply-detail.component';
import { SuppliesResolverService } from './supplies/resolvers/supplies-resolver.service';
import { StartComponent } from './start/start.component';
import { UtilitiesComponent } from './utilities/utilities.component';
import { HomeComponent } from './home/home.component';
import { AuthComponent } from './auth/auth.component';
import {AuthGuardService as AuthGuard} from './auth/auth-guard.service'
import { UserResolverService } from './shared/user-resolver.service' 
import { StatisticsComponent } from './statistics/statistics.component';

const appRoutes: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full'},
    { path: 'home', component: HomeComponent, resolve:[UserResolverService]},
    { path: 'auth', component: AuthComponent},
    { path: 'products', component: ProductsComponent, canActivate: [AuthGuard], resolve:[UserResolverService],  children:[
        {path: '', component: StartComponent},
        {path: 'new', component: ProductEditComponent, resolve: [ProductsResolverService, CharacteristicResolverService]},
        {path: ':id', component: ProductDetailComponent, resolve: [ProductsResolverService,UserResolverService]},
        {path: ':id/edit', component: ProductEditComponent, resolve: [ProductsResolverService, CharacteristicResolverService]}
    ]},
    { path: 'shops', component: ShopsComponent,resolve:[ShopsResolverService,UserResolverService], canActivate: [AuthGuard], children:[
        {path: '', component: StartComponent},
        {path: 'new', component: ShopEditComponent, resolve: [ShopsResolverService]},
        {path: ':id', component: ShopDetailComponent, resolve: [ShopsResolverService,UserResolverService]},
        {path: ':id/employees', component: EmployeeListComponent, resolve: [ShopsResolverService, UserResolverService]},
        {path: ':id/employees/new', component: EmployeeEditComponent, resolve: [ShopsResolverService]},
        {path: ':id/supplies', component: SupplyListComponent, resolve: [ShopsResolverService]},
        {path: ':id/availabilities', component: AvailabilityListComponent, resolve: [ShopsResolverService]}
    ]},
    { path: 'providers', component: ProvidersComponent,resolve:[ProvidersResolverService,UserResolverService], canActivate: [AuthGuard], children:[
        {path: '', component: StartComponent},
        {path: 'new', component: ProviderEditComponent, resolve: [ProvidersResolverService]},
        {path: ':id/contracts', component: ContractListComponent, resolve: [ProvidersResolverService,UserResolverService]},
        {path: ':id/contracts/new', component: ContractEditComponent, resolve: [ProvidersResolverService]},
        {path: ':id/contracts/:contractId', component: ContractDetailComponent, resolve: [ProvidersResolverService]}
    ]},
    { path: 'supplies', component: SuppliesComponent,resolve:[SuppliesResolverService,UserResolverService], canActivate: [AuthGuard], children:[
        {path: '', component: StartComponent},
        {path: 'new', component: SupplyEditComponent, resolve: [SuppliesResolverService,UserResolverService]},
        {path: ':id', component: SupplyDetailComponent, resolve: [SuppliesResolverService]}
    ]},
    {path: 'utilities', component: UtilitiesComponent, canActivate: [AuthGuard]},
    {path: 'statistics', component: StatisticsComponent ,resolve:[ShopsResolverService,UserResolverService], canActivate: [AuthGuard]}
]

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}