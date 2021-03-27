import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Product } from '../models/product.model';
import { ProductsStateService } from './products-state.service';

@Injectable()
export class ProductsResolverService implements Resolve<Product[]>{
    constructor(private productStateService: ProductsStateService){}

    resolve(route : ActivatedRouteSnapshot, state : RouterStateSnapshot){
        let products = this.productStateService.getProducts();
        if(products.length ===0)
        {
            return this.productStateService.fetchProducts();
        }
        else{
            return products;
        }
    }
}