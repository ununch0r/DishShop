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
        {path: ':id', component: ShopDetailComponent, resolve: [ShopsResolverService]}
    ]},
]

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}