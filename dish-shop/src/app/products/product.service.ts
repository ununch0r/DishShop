import { Injectable } from '@angular/core';
import { Product } from '../models/product.model';

@Injectable()
export class ProductService{

    private products : Product[] = [
        new Product(1, 'plate', 'nice plate', 20),
        new Product(2, 'glass', 'nice plate', 20)
    ]

    getProducts(){
        return this.products.slice();
    }

    getProduct(id: number)
    {
        return this.products[id];
    }
}