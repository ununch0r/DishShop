import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Product } from 'src/app/models/product.model';
import { ProductService } from '../product.service';
import { ProductsStateService } from '../products-state.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  productsSubscription : Subscription;
  products : Product[];

  constructor(private productService: ProductsStateService) { }

  ngOnInit(): void {
    this.products = this.productService.getProducts();
    this.productsSubscription = this.productService.productsCollectionChanged.subscribe(
      data => {
        this.products = data;
      }
    );
  }

}
