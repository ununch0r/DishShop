import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailComponent } from './products/product-detail/product-detail.component';
import { ProductStartComponent } from './products/product-start/product-start.component';
import { ProductsComponent } from './products/products.component';


const appRoutes: Routes = [
    { path: '', redirectTo: '/products', pathMatch: 'full'},
    { path: 'products', component: ProductsComponent, children:[
        {path: '', component: ProductStartComponent},
        {path: ':id', component: ProductDetailComponent}
    ]}
]

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}