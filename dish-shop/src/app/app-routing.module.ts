import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailComponent } from './products/product-detail/product-detail.component';
import { ProductStartComponent } from './products/product-start/product-start.component';
import { ProductsComponent } from './products/products.component';
import { ProductsResolverService } from './products/resolvers/products-resolver.service'
import { ProductEditComponent } from './products/product-edit/product-edit.component';
import { CharacteristicResolverService } from './products/resolvers/characteristic-resolver.service';
import { ShopsComponent } from './shops/shops.component';
import { ShopStartComponent } from './shops/shop-start/shop-start.component';
import { ShopDetailComponent } from './shops/shop-detail/shop-detail.component';
import { ShopsResolverService } from './shops/resolvers/shops-resolver.service';
import { EmployeeListComponent } from './shops/employee-list/employee-list.component';
import { SupplyListComponent } from './shops/supply-list/supply-list.component';
import { AvailabilityListComponent } from './shops/availability-list/availability-list.component';
import { EmployeeEditComponent } from './shops/employee-edit/employee-edit.component';
import { ShopEditComponent } from './shops/shop-edit/shop-edit.component';
import { ProvidersComponent } from './providers/providers.component';
import { ProvidersResolverService } from './providers/resolvers/providers-resolver.service';
import { ProvidersStartComponent } from './providers/providers-start/providers-start.component';
import { ContractListComponent } from './providers/contract-list/contract-list.component';
import { ProviderEditComponent } from './providers/provider-edit/provider-edit.component';
import { ContractEditComponent } from './providers/contract-list/contract-edit/contract-edit.component';
import { ContractDetailComponent } from './providers/contract-detail/contract-detail.component';

const appRoutes: Routes = [
    { path: '', redirectTo: '/products', pathMatch: 'full'},
    { path: 'products', component: ProductsComponent, children:[
        {path: '', component: ProductStartComponent},
        {path: 'new', component: ProductEditComponent, resolve: [ProductsResolverService, CharacteristicResolverService]},
        {path: ':id', component: ProductDetailComponent, resolve: [ProductsResolverService]},
        {path: ':id/edit', component: ProductEditComponent, resolve: [ProductsResolverService, CharacteristicResolverService]}
    ]},
    { path: 'shops', component: ShopsComponent,resolve:[ShopsResolverService], children:[
        {path: '', component: ShopStartComponent},
        {path: 'new', component: ShopEditComponent, resolve: [ShopsResolverService]},
        {path: ':id', component: ShopDetailComponent, resolve: [ShopsResolverService]},
        {path: ':id/employees', component: EmployeeListComponent, resolve: [ShopsResolverService]},
        {path: ':id/employees/new', component: EmployeeEditComponent, resolve: [ShopsResolverService]},
        {path: ':id/supplies', component: SupplyListComponent, resolve: [ShopsResolverService]},
        {path: ':id/availabilities', component: AvailabilityListComponent, resolve: [ShopsResolverService]}
    ]},
    { path: 'providers', component: ProvidersComponent,resolve:[ProvidersResolverService], children:[
        {path: '', component: ProvidersStartComponent},
        {path: 'new', component: ProviderEditComponent, resolve: [ProvidersResolverService]},
        {path: ':id/contracts', component: ContractListComponent, resolve: [ProvidersResolverService]},
        {path: ':id/contracts/new', component: ContractEditComponent, resolve: [ProvidersResolverService]},
        {path: ':id/contracts/:contractId', component: ContractDetailComponent, resolve: [ProvidersResolverService]}
    ]}
]

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}